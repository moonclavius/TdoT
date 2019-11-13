using System;

namespace TdoT_v._4.Klassen
{
    public class Führung
    {
        public Guid Uuid { get; set; }
        public short Anzahl { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }

        public Führung() { }

        public Führung(Guid uuid, short anzahl, DateTime start)
        {
            Uuid = uuid;
            Anzahl = anzahl;
            Start = start;
        }

        public Führung(Guid uuid, short anzahl, DateTime start, DateTime ende)
        {
            Uuid = uuid;
            Anzahl = anzahl;
            Start = start;
            Ende = ende;
        }

        public string ReturnValue()
        {
            return ";" + Anzahl + ";" + Start + ";" + Ende + ";";
        }
    }
}