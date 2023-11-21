
using System.Xml.Serialization;

namespace laba3
{
    [XmlRoot("Salarys")]
    public class Salary
    {
        [XmlElement("Year")]
        public int year { get; set; }
        [XmlElement("Month")]
        public int month { get; set; }
        [XmlElement("Size")]
        public int size { get; set; }
    }
}
