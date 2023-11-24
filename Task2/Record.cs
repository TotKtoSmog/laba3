using System.Xml.Serialization;

namespace laba3.Task2
{
    public class Record
    {
        [XmlAttribute("Date")]
        public string date { get; set; }
        [XmlAttribute("Id")]
        public string id { get; set; }
        [XmlElement("Nominal")]
        public string nominal { get; set; }
        [XmlElement("Value")]
        public string value { get; set; }
        [XmlElement("VunitRate")]
        public string vunitRate { get; set; }

    }
}
