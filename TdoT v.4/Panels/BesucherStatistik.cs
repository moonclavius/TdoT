using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TdoT_v._4.Klassen;

namespace TdoT_v._4.Panels
{
    public partial class BesucherStatistik : Form
    {
        public int itel = 0, et = 0, hif = 0;

        public BesucherStatistik()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                chart.Series["IF"].BorderWidth = 4;
                chart.Series["ITEL"].BorderWidth = 4;
                chart.Series["ET"].BorderWidth = 4;

                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
                chart.ChartAreas[0].AxisY.Minimum = 1;

                chart.ChartAreas[0].AxisX.Minimum = 100.0;
                chart.ChartAreas[0].AxisX.Maximum = 1.0;

                LoadData();
            }
            catch (Exception) { }
        }

        public void LoadData()
        {
            try
            {
                foreach (Führung fg in Main.führung.OrderBy(x => x.Start).ToList())
                {
                    foreach (Führer f in Main.führer.Values.Where(x => x.Führungen > 0))
                    {
                        if (fg.Uuid.Equals(f.Uuid))
                        {
                            UpdateChart(fg.Start, f.Abteilung, fg.Anzahl);
                            break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public int MaximumBesucher()
        {
            try
            {
                int abteilung_if = 0, abteilung_itel = 0, abteilung_et = 0;

                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("IF") && x.Führungen > 0))
                {
                    abteilung_if += Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl);
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ITEL") && x.Führungen > 0))
                {
                    abteilung_itel += Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl);
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ET") && x.Führungen > 0))
                {
                    abteilung_et += Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl);
                }

                return abteilung_if > abteilung_itel ? abteilung_if > abteilung_et ? abteilung_if : abteilung_et : abteilung_itel > abteilung_et ? abteilung_itel : abteilung_et;
            }
            catch (Exception) { }
            return 0;
        }

        public void UpdateChart(DateTime startzeit, string abteilung, int sum)
        {
            switch (abteilung)
            {
                case "IF":
                    hif += sum;
                    sum = hif;
                    break;
                case "ITEL":
                    itel += sum;
                    sum = itel;
                    break;
                case "ET":
                    et += sum;
                    sum = et;
                    break;
            }

            try
            {
                List<Führung> tmp = new List<Führung>();
                foreach (Führer item in Main.führer.Values.Where(x => x.Führungen > 0 && x.Abteilung.Equals(abteilung)))
                {
                    tmp.AddRange(Main.führung.Where(x => x.Uuid.Equals(item.Uuid) && !x.Start.Equals(new DateTime()) && !x.Ende.Equals(new DateTime())));
                }

                chart.ChartAreas[0].AxisX.Minimum = tmp.Min(x => x.Start).ToOADate();
                chart.ChartAreas[0].AxisX.Maximum = tmp.Max(x => x.Ende).ToOADate();
                chart.ChartAreas[0].AxisY.Maximum = MaximumBesucher();
                chart.Series.Where(x => x.Name.Equals(abteilung)).First().Points.AddXY(startzeit, sum);
            }
            catch (Exception) { }
        }

        private void Chart_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Directory.CreateDirectory(Main.einstellungpath + "img");
                    chart.SaveImage(Main.einstellungpath + "img\\besucher" + DateTime.UtcNow.AddHours(1).ToString("HH.mm.ss_dd-MM-yyyy") + ".png", ChartImageFormat.Png);
                    MessageBox.Show("Gespeichert unter: " + Main.einstellungpath + "img\\besucher...", "Benachrichtigung", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Speicher der Statistik", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}