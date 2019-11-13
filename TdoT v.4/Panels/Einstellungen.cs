using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace TdoT_v._4.Panels
{
    public partial class Einstellungen : Form
    {
        public Einstellungen()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                baudrate.Text = Main.baudrate.ToString();
                port.Items.AddRange(SerialPort.GetPortNames());
            }
            catch (Exception) { MessageBox.Show("Fehler beim der Initialisierung der Einstellungen", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Bestätigen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(port.SelectedItem + "") && !string.IsNullOrEmpty(baudrate.SelectedItem + ""))
                {
                    Directory.CreateDirectory(Main.einstellungpath);
                    File.WriteAllText(Main.einstellungpath + "settings.conf", "Baudrate:" + baudrate.SelectedItem + "\nPort:" + port.SelectedItem);

                    Main.port = port.SelectedItem.ToString();
                    Main.baudrate = int.Parse(baudrate.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Die Werte drüfen nicht null oder ungültig sein!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
                Dispose();
            }
            catch (Exception) { MessageBox.Show("Fehler bei den Einstellungen", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
