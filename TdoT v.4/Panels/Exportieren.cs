using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TdoT_v._4.Panels
{
    public partial class Exportieren : Form
    {
        public string klasse = string.Empty;

        public Exportieren()
        {
            InitializeComponent();
            ChangeSelection();
        }

        public void ChangeSelection()
        {
            try
            {
                klassen.Items.Clear();
                klassen.Items.AddRange(Main.führer.Values.Where(x => x.Abteilung == (itel.Checked ? "ITEL" : "") || x.Abteilung == (hif.Checked ? "IF" : "") || x.Abteilung == (het.Checked ? "ET" : "")).Select(x => x.Klasse).Distinct().ToArray());
                klassen.Refresh();
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Expotier-Auswahl", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                klasse = klassen.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Dispose();
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Expotier-Auswahl", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Itel_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSelection();
        }

        private void If_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSelection();
        }

        private void Et_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSelection();
        }
    }
}