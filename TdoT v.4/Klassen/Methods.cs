using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TdoT_v._4.Klassen
{
    public class Methods
    {
        public static DataTable MainDataTable()
        {
            DataTable table = new DataTable();

            try
            {
                table.Columns.Add("Nachname", typeof(string));
                table.Columns.Add("Vorname", typeof(string));
                table.Columns.Add("Klasse", typeof(string));
                table.Columns.Add("Führungen", typeof(short));
                table.Columns.Add("Status", typeof(string));

                foreach (Führer item in Main.führer.Values)
                {
                    table.Rows.Add(item.Nachname, item.Vorname, item.Klasse, item.Führungen, "Aktivieren");
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Erstellen der MainDataTable", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public static DataTable InfoDataTable(List<Führung> fg)
        {
            DataTable table = new DataTable();

            try
            {
                table.Columns.Add("Anzahl", typeof(short));
                table.Columns.Add("Start", typeof(string));
                table.Columns.Add("Ende", typeof(string));
                table.Columns.Add("Dauer", typeof(string));

                foreach (Führung item in fg)
                {
                    table.Rows.Add(item.Anzahl, FormatTime(item.Start), FormatTime(item.Ende), item.Ende != new DateTime() ? FormatTime(new DateTime(item.Ende.Subtract(item.Start).Ticks)) : "führt...");
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Erstellen der InfoDataTable", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public static string FormatTime(DateTime dt)
        {
            try
            {
                return string.Format("{0:HH:mm:ss}", dt);
            }
            catch (Exception) { MessageBox.Show("Fehler beim Formatieren der Zeit", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return "00:00:00";
        }

        public static string FindAbteilung(string klasse)
        {
            try
            {
                return (klasse.Substring(2)) switch
                {
                    "HIF" => "IF",
                    "FET" => "ET",
                    "HET" => "ET",
                    _ => "ITEL",
                };
            }
            catch (Exception) { MessageBox.Show("Fehler bei der Zuteilung der Abteilung", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return "";
        }

        public static Color ChangeStatus(bool status, bool extra)
        {
            return status ? Color.LightGray : extra ? Color.LightGreen : Color.OrangeRed;
        }

        public static void CreateFolder()
        {
            try
            {
                Directory.CreateDirectory(Main.einstellungpath);
                if (File.Exists(Main.einstellungpath + "settings.conf"))
                {
                    string[] inhalt = File.ReadAllLines(Main.einstellungpath + "settings.conf").Select(x => x.Split(':')[1]).ToArray();
                    if (inhalt.Length > 1 && Regex.IsMatch(inhalt[0], "^[0-9]{3,6}$"))
                    {
                        Main.baudrate = int.Parse(inhalt[0]);
                        Main.port = inhalt[1];
                    }
                }
                else
                {
                    File.WriteAllText(Main.einstellungpath + "settings.conf", "Baudrate:9600\nPort:0");
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Erstellen des TdoT-Ordners und der TdoT-Konfig", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static string GetDate()
        {
            return DateTime.UtcNow.AddHours(1).ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
        }
    }
}