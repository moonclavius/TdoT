using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TdoT_v._4.Klassen
{
    public class ReadWrite
    {
        public static void ReadCSV(string path)
        {
            try
            {
                int count;
                string uuid = string.Empty, nn, vn, kl;

                List<string> file = File.ReadLines(path, Encoding.UTF8).ToList();
                bool status = file.First().Equals("[TdoT - Uros Zivkovic]");

                if (status)
                {
                    for (int i = 1; i < file.Count; i++)
                    {
                        count = file[i].Count(x => x.Equals(';'));
                        if (count > 4)
                        {
                            uuid = FilterString(file[i], 0);
                            nn = FilterString(file[i], 2);
                            vn = FilterString(file[i], 3);
                            kl = FilterString(file[i], 4);

                            try
                            {
                                Main.führer.Add(nn + vn + kl, new Führer(new Guid(uuid), long.Parse(FilterString(file[i], 1)), nn, vn, kl, FilterString(file[i], 5), short.Parse(FilterString(file[i], 6)), FilterString(file[i], 7).Equals("True") ? true : false, FilterString(file[i], 8).Equals("True") ? true : false, FilterString(file[i], 9)));
                            }
                            catch (ArgumentException) { }
                        }
                        else if (count == 4)
                        {
                            Main.führung.Add(new Führung(new Guid(uuid), short.Parse(FilterString(file[i], 1)), DateTime.Parse(FilterString(file[i], 2)), DateTime.Parse(FilterString(file[i], 3))));
                        }
                    }
                }
                else
                {
                    foreach (string line in file)
                    {
                        vn = FilterString(line, 0);
                        nn = FilterString(line, 1).ToUpper();
                        kl = FilterString(line, 2).ToUpper();

                        try
                        {
                            Main.führer.Add(nn + vn + kl, new Führer(Guid.NewGuid(), 0, nn, vn, kl, Methods.FindAbteilung(kl), 0, false, false, string.Empty));
                        }
                        catch (ArgumentException) { }
                    }
                }
                SortData();
            }
            catch (Exception) { MessageBox.Show("Fehler beim Lesen der CSV", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void WriteCSV(string path)
        {
            try
            {
                SortData();
                if (!path.EndsWith(".csv"))
                {
                    path += ".csv";
                }

                using StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8, 65536);
                sw.WriteLine("[TdoT - Uros Zivkovic]");
                foreach (Führer item in Main.führer.Values)
                {
                    sw.WriteLine(item.ReturnValue());
                    foreach (Führung temp in Main.führung.Where(x => x.Uuid.Equals(item.Uuid)).ToList())
                    {
                        sw.WriteLine(temp.ReturnValue());
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Fehler beim Erstellen der CSV", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static void WritePDF(string path, string klasse)
        {
            SortData();
            if (!path.EndsWith(".pdf"))
            {
                path += ".pdf";
            }

            new PDF().CreateExportFile(Main.führer.Values.Where(x => x.Klasse.Equals(klasse)).ToList(), Main.führung, klasse, path);
        }

        private static void SortData()
        {
            try
            {
                Main.führer = Main.führer.OrderByDescending(x => x.Value.Klasse).ThenBy(x => x.Value.Nachname).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception) { MessageBox.Show("Fehler beim Sortieren", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private static string FilterString(string line, int nummber)
        {
            try
            {
                return line.Split(';')[nummber];
            }
            catch (Exception) { MessageBox.Show("Fehler beim Filtern des Strings", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return "";
        }
    }
}