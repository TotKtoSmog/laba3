using System.Xml.Serialization;

namespace laba3.Task4
{
    public class RecordSanatorium
    {
        [XmlElement("name")]
        public string name { get; set; }
        [XmlElement("unit")]
        public string unit { get; set; }
        [XmlElement("legaladdress")]
        public string legaladdress { get; set; }
        [XmlElement("actualaddress")]
        public string actualaddress { get; set; }

    }
}
