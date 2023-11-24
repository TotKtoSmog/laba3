
using System.Collections.Generic;
using System.Xml.Serialization;

namespace laba3.Task3
{
    [XmlRoot("Metall")]
    public class Metall
    {
        [XmlAttribute("FromDate")]
        public string fromDate { get; set; }
        [XmlAttribute("ToDate")]
        public string toDate { get; set; }
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlElement("Record")]
        public List<RecordMetall> records { get; set; }
    }
}
