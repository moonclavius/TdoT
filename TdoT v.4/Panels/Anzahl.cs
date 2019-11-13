using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TdoT_v._4.Panels
{
    public partial class Anzahl : Form
    {
        public short besucheranzahl = 1;

        public Anzahl()
        {
            InitializeComponent();
        }

        private void CheckSend()
        {
            try
            {
                if (!string.IsNullOrEmpty(besucher.Text) && Regex.IsMatch(besucher.Text, "^[1-9][0-9]?$|^100$"))
                {
                    besucheranzahl = short.Parse(besucher.Text);
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Besuchereingabe", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Besucher_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                CheckSend();
            }
        }

        private void Bestätigen_Click(object sender, System.EventArgs e)
        {
            CheckSend();
        }
    }
}