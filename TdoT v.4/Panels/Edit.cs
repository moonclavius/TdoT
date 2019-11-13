using System;
using System.Globalization;
using System.Windows.Forms;
using TdoT_v._4.Klassen;

namespace TdoT_v._4.Panels
{
    public partial class Edit : Form
    {
        private readonly Führer f = new Führer();

        public Edit(ref Führer f)
        {
            this.f = f;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            nachname.Text = f.Nachname;
            vorname.Text = f.Vorname;
            klasse.Text = f.Klasse;
            notiz.Text = f.Notiz;
        }

        private void Ändern_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (nachname.Text.Length > 0 && vorname.Text.Length > 0 && klasse.Text.Length > 0)
                {
                    f.Nachname = nachname.Text;
                    f.Vorname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vorname.Text.ToLower());
                    f.Klasse = klasse.Text;
                    f.Abteilung = Methods.FindAbteilung(klasse.Text);
                    f.Notiz = notiz.Text;

                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Ändern des Führers", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}