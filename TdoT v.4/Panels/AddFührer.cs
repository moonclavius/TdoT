using System;
using System.Globalization;
using System.Windows.Forms;
using TdoT_v._4.Klassen;

namespace TdoT_v._4.Panels
{
    public partial class AddFührer : Form
    {
        private bool added = false;

        public AddFührer()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (nachname.Text.Length > 0 && vorname.Text.Length > 0 && klasse.Text.Length > 0)
                {
                    try
                    {
                        vorname.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vorname.Text.ToLower());
                        Main.führer.Add(nachname.Text + vorname.Text + klasse.Text, new Führer(Guid.NewGuid(), 0, nachname.Text, vorname.Text, klasse.Text, Methods.FindAbteilung(klasse.Text), 0, false, true, notiz.Text));

                        notiz.Text = string.Empty;
                        vorname.Text = string.Empty;
                        nachname.Text = string.Empty;
                        added = true;
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Ergänzen des Führers", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AddFührer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = added ? DialogResult.OK : DialogResult.None;
            Dispose();
        }
    }
}