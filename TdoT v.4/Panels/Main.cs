using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TdoT_v._4.Klassen;
using TdoT_v._4.Panels;

namespace TdoT_v._4
{
    public partial class Main : Form
    {
        #region Variables
        private string rfiditem = string.Empty;
        private SerialPort reader = new SerialPort();
        private readonly Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

        public BesucherStatistik bstatistik = null;
        public FührungenStatistik fstatistik = null;

        public static string port = "0";
        public static int baudrate = 9600;
        public static List<Führung> führung = new List<Führung>();
        public static Dictionary<string, Führer> führer = new Dictionary<string, Führer>();
        public static string einstellungpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TodT\\";
        #endregion

        #region Konstruktor
        public Main()
        {
            InitializeComponent();
            Initialize();
        }
        #endregion

        #region Methods
        public void Initialize()
        {
            try
            {
                Type dgvType = output.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(output, true, null);
            }
            catch (Exception) { }

            Methods.CreateFolder();
            PortConnection();
        }
        public void MenüBar(bool status)
        {
            dateispeichern.Enabled = status;
            dateiexportieren.Enabled = status;
            dateischließen.Enabled = status;
        }
        #endregion

        #region RFID
        public void PortConnection()
        {
            try
            {
                if (SerialPort.GetPortNames().Length > 0)
                {
                    reader = new SerialPort()
                    {
                        ReadTimeout = 1000,
                        BaudRate = baudrate,
                        PortName = SerialPort.GetPortNames().Contains(port) ? port : SerialPort.GetPortNames()[0],
                        DtrEnable = true
                    };
                    reader.DataReceived += new SerialDataReceivedEventHandler(RfidDataStream);
                    rfidstatus.BackColor = Color.YellowGreen;
                    reader.Open();
                }
                else
                {
                    rfidstatus.BackColor = Color.Red;
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim SerialPort", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RfidDataStream(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (führer.Values.Count() > 0)
                {
                    rfiditem = ((SerialPort)sender).ReadLine().Replace("\r", "");
                    if (rfiditem.Contains("*") && rfiditem.Contains(";"))
                    {
                        Invoke(new Action(() =>
                        {
                            rfiditem = rfiditem.Replace("*", "").Replace(";", "");
                            Führer f = führer.Values.Where(x => x.Nfc.ToString() == rfiditem).DefaultIfEmpty(null).First();
                            if (f != null)
                            {
                                rfiditem = string.Empty;
                                Output_CellClick(output, new DataGridViewCellEventArgs(4, (output.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[4].Tag.Equals(f.Uuid)).Select(r => r.Index)).First()));
                            }
                            else
                            {
                                MessageBox.Show("Klicken Sie auf einen Nachnamen, um die NFC-ID zu zuweisen!", "Hinweis!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }));
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim der SerialPort-Übertragung", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Menü
        #region Datei
        private void Dateiöffnen_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (open.ShowDialog().Equals(DialogResult.OK))
                {
                    if (!string.IsNullOrEmpty(open.FileName) && open.FileName.ToLower().EndsWith(".csv"))
                    {
                        ReadWrite.ReadCSV(open.FileName);
                        DisplayData();
                        MenüBar(true);
                        CountStatistik(true);
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Datei-Öffnung", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Dateispeichern_Click(object sender, System.EventArgs e)
        {
            try
            {
                save.Title = "TdoT - Speichern";
                save.Filter = "CSV|*csv";

                if (save.ShowDialog().Equals(DialogResult.OK))
                {
                    ReadWrite.WriteCSV(save.FileName);
                }
            }
            catch (Exception) { MessageBox.Show("Fehler bei der Datei-Speicherung", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Dateiexportieren_Click(object sender, EventArgs e)
        {
            try
            {
                if (xlApp == null)
                {
                    MessageBox.Show("Bitte installieren Sie Excel auf diesen Computer!");
                }
                else
                {
                    Exportieren ex = new Exportieren();
                    if (ex.ShowDialog().Equals(DialogResult.OK))
                    {
                        save.Title = "TdoT - Exportieren";
                        save.Filter = "PDF|*pdf";
                        save.FileName = ex.klasse;

                        if (save.ShowDialog().Equals(System.Windows.Forms.DialogResult.OK))
                        {
                            //HashSet<string> klassen = führer.Values.Select(x => x.Klasse).ToHashSet<string>();
                            //foreach (var item in klassen)
                            //{
                            //    ReadWrite.WritePDF(@"C:\Users\Uros Zivkovic\Desktop\09.11.2019\" + item + ".pdf", item);
                            //}
                            ReadWrite.WritePDF(save.FileName, ex.klasse);
                        }
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Datei-Exportierung", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Dateischließen_Click(object sender, System.EventArgs e)
        {
            if ((MessageBox.Show("Wollen Sie das Projekt wirklich schließen?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)).Equals(DialogResult.Yes))
            {
                führer = new Dictionary<string, Führer>();
                führung = new List<Führung>();
                output.DataSource = null;
                output.Columns.Clear();
                MenüBar(false);
                CountStatistik(true);
                Text = "TdoT - Uros Zivkovic";
            }
        }
        #endregion

        #region Ansicht
        private void Ansichtführer_Click(object sender, System.EventArgs e)
        {
            if (new AddFührer().ShowDialog().Equals(DialogResult.OK))
            {
                DisplayData();
                MenüBar(true);
                CountStatistik(false);
            }
        }

        private void Ansichtprotokoll_Click(object sender, System.EventArgs e)
        {
            new Protokoll().Show();
        }

        private void Ansichtstatistik_Click(object sender, System.EventArgs e)
        {
            try
            {
                bstatistik = new BesucherStatistik();
                fstatistik = new FührungenStatistik();

                bstatistik.Show();
                fstatistik.Show();
            }
            catch (Exception) { MessageBox.Show("Fehler beim Öffnen der Statistik", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Einstellungen
        private void Menueinstellungen_Click(object sender, System.EventArgs e)
        {
            if (new Einstellungen().ShowDialog().Equals(DialogResult.OK))
            {
                try
                {
                    reader.Close();
                    reader.Dispose();
                    PortConnection();
                }
                catch (Exception) { MessageBox.Show("Fehler beim Schließen des SerialPorts", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        #endregion

        #region Statistik
        public void CountStatistik(bool extra)
        {
            anwesende.Text = "Anwesende: " + führer.Count(x => x.Value.Anwesenheit == true);
            if (extra)
            {
                aktive.Text = "Aktive: " + führer.Count(x => x.Value.Status == true);
                führungen.Text = "Führungen: " + führer.Values.Sum(x => x.Führungen);
            }
        }
        #endregion

        #region Suchen
        private void Suchen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!suchen.Text.Equals("Suchen...") && suchen.Text.Length > 2 && output.Rows.Count > 0)
                {
                    (output.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nachname LIKE '%{0}%' OR Vorname LIKE '%{0}%' OR Klasse LIKE '%{0}%' OR CONVERT(Führungen, System.String) LIKE '%{0}%' OR Status LIKE '%{0}%'", suchen.Text);
                    UpdateValues();
                }
                else if (!suchen.Text.Equals("Suchen...") && suchen.Text.Length <= 2 && führer.Values.Count > 0)
                {
                    DisplayData();
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Suchen", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Suchen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(suchen.Text) && !suchen.Focused)
            {
                suchen.Text = "Suchen...";
            }
        }

        private void Suchen_MouseClick(object sender, MouseEventArgs e)
        {
            if (suchen.Text.Equals("Suchen..."))
            {
                suchen.Text = string.Empty;
            }
        }
        #endregion
        #endregion

        #region DataGridView
        public void DisplayData()
        {
            try
            {
                output.Columns.Clear();
                output.DataSource = Methods.MainDataTable();
                output.Columns[4].SortMode = DataGridViewColumnSortMode.Programmatic;
                output.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                output.ContextMenuStrip = edit;
                UpdateValues();
            }
            catch (Exception) { MessageBox.Show("Fehler beim Darstellen der Daten", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void UpdateValues()
        {
            try
            {
                foreach (DataGridViewRow item in output.Rows)
                {
                    Führer f = GetFührer(item);
                    item.Cells[3].Value = f.Führungen;
                    item.Cells[4].Tag = f.Uuid;
                    item.Cells[4].Value = f.Status ? "Pause" : "Aktivieren";
                    item.Cells[4].Style.BackColor = Methods.ChangeStatus(!f.Anwesenheit, f.Status);
                }
                output.ClearSelection();
            }
            catch (Exception) { MessageBox.Show("Fehler beim Updaten der Werte", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public Führer GetFührer()
        {
            try
            {
                return führer[output.SelectedCells[0].Value.ToString() + output.SelectedCells[1].Value.ToString() + output.SelectedCells[2].Value.ToString()];
            }
            catch (Exception) { MessageBox.Show("Fehler beim Beschaffen des Führers", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return new Führer();
        }

        public Führer GetFührer(DataGridViewRow row)
        {
            try
            {
                row.Selected = true;
                return führer[output.SelectedCells[0].Value.ToString() + output.SelectedCells[1].Value.ToString() + output.SelectedCells[2].Value.ToString()];
            }
            catch (Exception) { MessageBox.Show("Fehler beim Beschaffen des Führers", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return new Führer();
        }

        private void Output_Sorted(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void Output_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(rfiditem))
                {
                    if (e.ColumnIndex != 4 && e.RowIndex >= 0)
                    {
                        Führer f = GetFührer(output.Rows[e.RowIndex]);
                        if ((MessageBox.Show("Name: " + f.Nachname + " " + f.Vorname + "\nID: " + rfiditem, "Überprüfung?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)).Equals(DialogResult.Yes))
                        {
                            f.Nfc = long.Parse(rfiditem);
                            f.Anwesenheit = true;

                            CountStatistik(false);
                            output.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.OrangeRed;
                        }
                        rfiditem = string.Empty;
                    }
                }

                output.ClearSelection();
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    DataGridViewTextBoxCell status = (DataGridViewTextBoxCell)output.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Führer f = führer.Values.Where(x => x.Uuid.Equals((Guid)status.Tag)).First();

                    if (status.Value.Equals("Aktivieren"))
                    {
                        using Anzahl a = new Anzahl();
                        if (a.ShowDialog().Equals(DialogResult.OK))
                        {
                            DateTime tmptime = DateTime.UtcNow.AddHours(1);
                            f.Status = true;
                            f.Führungen += 1;
                            f.Anwesenheit = true;

                            status.Value = "Pause";
                            output.Rows[e.RowIndex].Cells[3].Value = f.Führungen;
                            output.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.LightGreen;

                            führung.Add(new Führung(f.Uuid, a.besucheranzahl, tmptime));

                            try
                            {
                                if (bstatistik != null || fstatistik != null)
                                {
                                    bstatistik.UpdateChart(tmptime, f.Abteilung, a.besucheranzahl);
                                    fstatistik.UpdateChart(tmptime, f.Abteilung);
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        f.Status = false;
                        status.Value = "Aktivieren";
                        output.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.OrangeRed;

                        führung.Where(x => x.Uuid.Equals(f.Uuid) && x.Ende == new DateTime()).First().Ende = DateTime.UtcNow.AddHours(1);
                    }
                    CountStatistik(true);
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Klicken der Ausgabe", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Autosave_Tick(object sender, EventArgs e)
        {
            try
            {
                if (führer.Count > 0)
                {
                    ReadWrite.WriteCSV(Path.GetTempPath() + "TdoT.csv");
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Autosave", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #region ContextMenu
        private void Output_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex != -1)
                    {
                        output.ClearSelection();
                        output.Rows[e.RowIndex].Selected = true;

                        Führer f = GetFührer();
                        nfc.Enabled = f.Nfc != 0;
                        infos.Enabled = f.Führungen > 0;
                        anwesenheit.Enabled = f.Führungen == 0;
                        anwesenheit.Checked = f.Anwesenheit;
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim ContextMenu", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Nfc_Click(object sender, EventArgs e)
        {
            try
            {
                Führer f = GetFührer();
                if ((MessageBox.Show("Bitte bestätigen Sie die NFC-Löschung!\nName: " + f.Nachname + " " + f.Vorname + "\tID: " + f.Nfc, "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)).Equals(DialogResult.Yes))
                {
                    f.Nfc = 0;
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim NFC-Klick", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Infos_Click(object sender, EventArgs e)
        {
            try
            {
                Führer f = GetFührer();
                using Info i = new Info(f, führung.Where(x => x.Uuid.Equals(f.Uuid)).ToList());
                i.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Fehler beim Info-Klick", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Anwesenheit_Click(object sender, EventArgs e)
        {
            try
            {
                GetFührer().Anwesenheit = anwesenheit.Checked;
                output.SelectedCells[4].Style.BackColor = Methods.ChangeStatus(!anwesenheit.Checked, false);
                CountStatistik(false);
            }
            catch (Exception) { MessageBox.Show("Fehler beim Anwesenheit-Klick", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Bearbeiten_Click(object sender, EventArgs e)
        {
            try
            {
                Führer f = GetFührer();
                string key = f.Nachname + f.Vorname + f.Klasse;
                using Edit edit = new Edit(ref f);
                if (edit.ShowDialog().Equals(DialogResult.OK))
                {
                    führer.Remove(key);
                    führer[f.Nachname + f.Vorname + f.Klasse] = f;
                    DisplayData();
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Bearbeiten-Klick", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Löschen_Click(object sender, EventArgs e)
        {
            try
            {
                Führer f = GetFührer();
                if ((MessageBox.Show("Wollen Sie den Schüler \"" + f.Nachname + " " + f.Vorname + "\" wirklich löschen? (Schülerdaten & Führungen)", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)).Equals(DialogResult.Yes))
                {
                    führer.Remove(f.Nachname + f.Vorname + f.Klasse);
                    führung.RemoveAll(x => x.Uuid.Equals((Guid)output.SelectedCells[4].Tag));
                    output.Rows.RemoveAt(output.SelectedRows[0].Index);
                    CountStatistik(true);
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Löschen-Klick", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
        #endregion
    }
}