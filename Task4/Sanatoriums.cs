using System.Collections.Generic;
using System.Xml.Serialization;

namespace laba3.Task4
{
    [XmlRoot("data")]
    public class Sanatoriums
    {
        [XmlElement("record")]
        public List<RecordSanatorium> records { get; set; }
    }
}
