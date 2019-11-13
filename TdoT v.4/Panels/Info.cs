using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TdoT_v._4.Klassen;

namespace TdoT_v._4.Panels
{
    public partial class Info : Form
    {
        private readonly Führer f = new Führer();
        private readonly List<Führung> fg = new List<Führung>();

        public Info(Führer f, List<Führung> fg)
        {
            this.f = f;
            this.fg = fg;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                nachname.Text = f.Nachname;
                vorname.Text = f.Vorname;
                klasse.Text = f.Klasse;
                abteilung.Text = f.Abteilung;
                führungen.Text = f.Führungen.ToString();
                status.Text = f.Status ? "Aktiv" : "Pause";
                anwesenheit.Text = f.Anwesenheit ? "Anwesend" : "Fehlt";
                notiz.Text = f.Notiz;
                uuid.Text = f.Uuid.ToString();
                nfc.Text = f.Nfc.ToString();

                besucher.Text = fg.Sum(x => x.Anzahl).ToString();
                dauer.Text = Methods.FormatTime(new DateTime(fg.Where(x => x.Ende != new DateTime()).Sum(x => ((x.Ende) - x.Start).Ticks)));
                start.Text = fg.Min(x => x.Start).ToString();
                ende.Text = fg.Max(x => x.Ende).Equals(new DateTime()) ? "führt..." : fg.Max(x => x.Ende).ToString();

                output.DataSource = Methods.InfoDataTable(fg);
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Info-Anzeige", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}