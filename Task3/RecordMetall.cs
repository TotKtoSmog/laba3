using System.Xml.Serialization;

namespace laba3.Task3
{
    public class RecordMetall
    {
        [XmlAttribute("Date")]
        public string date { get; set; }
        [XmlAttribute("Code")]
        public string code { get; set; }
        [XmlElement("Buy")]
        public string buy { get; set; }

        [XmlElement("Sell")]
        public string Sell { get; set; }
        public string metallName 
        { 
            get
            {
                string s;
                switch (code)
                {
                    case "1": s = "Золото"; break;
                    case "2": s = "Cеребро"; break;
                    case "3": s = "Платина"; break;
                    case "4": s = "Палладий"; break;
                    default: s = "UNKNOWN"; break;
                }
                return s;
            }
        }
    }
}
