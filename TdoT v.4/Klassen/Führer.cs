using System;

namespace TdoT_v._4.Klassen
{
    public class Führer
    {
        public Guid Uuid { get; } = Guid.NewGuid();
        public long Nfc { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public string Klasse { get; set; }
        public string Abteilung { get; set; }
        public short Führungen { get; set; }
        public bool Status { get; set; }
        public bool Anwesenheit { get; set; }
        public string Notiz { get; set; }

        public Führer() { }

        public Führer(Guid uuid, long nfc, string nachname, string vorname, string klasse, string abteilung, short führungen, bool status, bool anwesenheit, string notiz)
        {
            Uuid = uuid;
            Nfc = nfc;
            Nachname = nachname;
            Vorname = vorname;
            Klasse = klasse;
            Abteilung = abteilung;
            Führungen = führungen;
            Status = status;
            Anwesenheit = anwesenheit;
            Notiz = notiz;
        }

        public string ReturnValue()
        {
            return Uuid + ";" + Nfc + ";" + Nachname + ";" + Vorname + ";" + Klasse + ";" + Abteilung + ";" + Führungen + ";" + Status + ";" + Anwesenheit + ";" + Notiz + ";";
        }
    }
}