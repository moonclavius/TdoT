using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TdoT_v._4.Klassen;

namespace TdoT_v._4.Panels
{
    public partial class Protokoll : Form
    {
        public Protokoll()
        {
            InitializeComponent();
            UpdateStatistiken();
        }

        public void UpdateStatistiken()
        {
            try
            {
                bs.Text = "0";
                if_bs.Text = "0";
                itel_bs.Text = "0";
                et_bs.Text = "0";

                fg.Text = "0";
                if_fg.Text = "0";
                itel_fg.Text = "0";
                et_fg.Text = "0";

                fr.Text = "0";
                if_fr.Text = "0";
                itel_fr.Text = "0";
                et_fr.Text = "0";

                sz.Text = "00:00:00 bis 00:00:00";
                if_sz.Text = "00:00:00";
                itel_sz.Text = "00:00:00";
                et_sz.Text = "00:00:00";

                fr.Text = Main.führer.Values.Count.ToString();
                if_fr.Text = Main.führer.Values.Count(x => x.Abteilung.Equals("IF")).ToString();
                itel_fr.Text = Main.führer.Values.Count(x => x.Abteilung.Equals("ITEL")).ToString();
                et_fr.Text = Main.führer.Values.Count(x => x.Abteilung.Equals("ET")).ToString();

                bs.Text = Main.führung.Sum(x => x.Anzahl).ToString();
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("IF") && x.Führungen > 0))
                {
                    if_bs.Text = (int.Parse(if_bs.Text) + Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl)).ToString();
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ITEL") && x.Führungen > 0))
                {
                    itel_bs.Text = (int.Parse(itel_bs.Text) + Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl)).ToString();
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ET") && x.Führungen > 0))
                {
                    et_bs.Text = (int.Parse(et_bs.Text) + Main.führung.Where(x => x.Uuid == s.Uuid).Sum(x => x.Anzahl)).ToString();
                }

                fg.Text = Main.führer.Values.Sum(x => x.Führungen).ToString();
                if_fg.Text = Main.führer.Values.Where(x => x.Abteilung.Equals("IF")).Sum(x => x.Führungen).ToString();
                itel_fg.Text = Main.führer.Values.Where(x => x.Abteilung.Equals("ITEL")).Sum(x => x.Führungen).ToString();
                et_fg.Text = Main.führer.Values.Where(x => x.Abteilung.Equals("ET")).Sum(x => x.Führungen).ToString();

                sz.Text = Main.führung.Min(x => x.Start).ToLongTimeString() + " bis " + Main.führung.Where(x => !x.Ende.Equals(new DateTime())).Max(x => x.Ende).ToLongTimeString();
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("IF") && x.Führungen > 0))
                {
                    string tmp = Main.führung.Where(x => !x.Ende.Equals(new DateTime()) && x.Uuid.Equals(s.Uuid)).Max(x => x.Ende).ToLongTimeString();
                    if_sz.Text = DateTime.Parse(if_sz.Text) > DateTime.Parse(tmp) ? if_sz.Text : tmp;
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ITEL") && x.Führungen > 0))
                {
                    string tmp = Main.führung.Where(x => !x.Ende.Equals(new DateTime()) && x.Uuid.Equals(s.Uuid)).Max(x => x.Ende).ToLongTimeString();
                    itel_sz.Text = DateTime.Parse(itel_sz.Text) > DateTime.Parse(tmp) ? itel_sz.Text : tmp;
                }
                foreach (Führer s in Main.führer.Values.Where(x => x.Abteilung.Equals("ET") && x.Führungen > 0))
                {
                    string tmp = Main.führung.Where(x => !x.Ende.Equals(new DateTime()) && x.Uuid.Equals(s.Uuid)).Max(x => x.Ende).ToLongTimeString();
                    et_sz.Text = DateTime.Parse(et_sz.Text) > DateTime.Parse(tmp) ? et_sz.Text : tmp;
                }
            }
            catch (Exception) { }
        }

        private void Auto_Tick(object sender, EventArgs e)
        {
            UpdateStatistiken();
        }
    }
}
