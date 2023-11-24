using System.Xml.Serialization;

namespace laba3.Task2
{
    public class Item
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("EngName")]
        public string EngName { get; set; }

        [XmlElement("Nominal")]
        public int Nominal { get; set; }

        [XmlElement("ParentCode")]
        public string ParentCode { get; set; }
    }
}
