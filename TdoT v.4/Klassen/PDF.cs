using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TdoT_v._4.Klassen
{
    public class PDF
    {
        public void CreateExportFile(List<Führer> führer, List<Führung> führung, string klasse, string path)
        {
            try
            {
                Missing misValue = Missing.Value;
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.PageSetup.LeftHeader = "09.11.2019"; //Methods.GetDate(); 
                xlWorkSheet.PageSetup.CenterHeader = "TdoT - Auswertung";
                xlWorkSheet.PageSetup.RightHeader = klasse + " [" + Methods.FindAbteilung(klasse) + "]";

                xlWorkSheet.PageSetup.LeftMargin = 0.6D;
                xlWorkSheet.PageSetup.RightMargin = 0.6D;
                xlWorkSheet.PageSetup.BottomMargin = 1.9D;
                xlWorkSheet.PageSetup.CenterHorizontally = true;
                xlWorkSheet.PageSetup.AlignMarginsHeaderFooter = true;

                xlWorkSheet.Name = "TdoT";
                xlWorkSheet.Cells[1, 1] = "Nachname";
                xlWorkSheet.Cells[1, 2] = "Vorname";
                xlWorkSheet.Cells[1, 3] = "Anwesenheit";
                xlWorkSheet.Cells[1, 4] = "Führungen / Startzeit";
                xlWorkSheet.Cells[1, 5] = "Dauer";

                xlWorkSheet.get_Range("A:A", Type.Missing).EntireColumn.ColumnWidth = 17.86D;
                xlWorkSheet.get_Range("B:B", Type.Missing).EntireColumn.ColumnWidth = 26.43D;
                xlWorkSheet.get_Range("C:C", Type.Missing).EntireColumn.ColumnWidth = 13.57D;
                xlWorkSheet.get_Range("D:D", Type.Missing).EntireColumn.ColumnWidth = 20.86D;
                xlWorkSheet.get_Range("E:E", Type.Missing).EntireColumn.ColumnWidth = 12.71D;

                xlWorkSheet.get_Range("A1:E1", Type.Missing).EntireRow.RowHeight = 24;

                xlWorkSheet.get_Range("A1:E1", Type.Missing).Cells.Font.Bold = true;
                xlWorkSheet.get_Range("A1:E1", Type.Missing).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("A1:E1", Type.Missing).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                xlWorkSheet.get_Range("A1:E1", Type.Missing).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(221, 235, 247));

                int zeile = 1;
                foreach (Führer p in führer)
                {
                    zeile++;
                    List<Führung> tempführungen = p.Führungen > 0 ? führung.Where(x => x.Uuid.Equals(p.Uuid)).ToList() : new List<Führung>();

                    xlWorkSheet.Cells[zeile, 1] = p.Nachname;
                    xlWorkSheet.Cells[zeile, 2] = p.Vorname;
                    xlWorkSheet.Cells[zeile, 3] = p.Anwesenheit ? "Ja" + (p.Notiz.Contains("Fertig") ? " / Abgemeldet" : "") : "Nein";
                    xlWorkSheet.Cells[zeile, 4] = p.Führungen;
                    xlWorkSheet.Cells[zeile, 5] = tempführungen == new List<Führung>() ? "00:00:00" : Methods.FormatTime(new DateTime(tempführungen.Where(x => x.Ende != new DateTime()).Sum(x => ((x.Ende) - x.Start).Ticks)));

                    xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).EntireRow.RowHeight = 18;
                    xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range($"A{zeile}:B{zeile}", Type.Missing).Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    xlWorkSheet.get_Range($"C{zeile}:E{zeile}", Type.Missing).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).Interior.Color = ColorTranslator.ToOle(Color.FromArgb(226, 239, 218));

                    foreach (Führung f in tempführungen)
                    {
                        zeile++;
                        xlWorkSheet.Cells[zeile, 4] = Methods.FormatTime(f.Start);
                        xlWorkSheet.Cells[zeile, 5] = Methods.FormatTime(new DateTime(f.Ende != new DateTime() ? f.Ende.Subtract(f.Start).Ticks : DateTime.UtcNow.AddHours(1).Subtract(f.Start).Ticks));

                        xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).EntireRow.RowHeight = 18;
                        xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        xlWorkSheet.get_Range($"A{zeile}:E{zeile}", Type.Missing).Interior.Color = ColorTranslator.ToOle(Color.White);
                    }
                }

                xlWorkBook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, path, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook = null;
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlApp);

                Process[] excelProcesses = Process.GetProcessesByName("excel");
                foreach (Process p in excelProcesses)
                {
                    if (string.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        p.Kill();
                    }
                }

                GC.SuppressFinalize(this);
            }
            catch (Exception) { MessageBox.Show("Fehler beim Erstellen der PDF", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}