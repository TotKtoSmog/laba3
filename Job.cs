using System.Xml.Serialization;

namespace laba3
{
    [XmlRoot("Jobs")]
    public class Job
    {
        [XmlElement("Name")]
        public string name { get; set; }
        [XmlElement("Start_date")]
        public string startDate { get; set; }
        [XmlElement("End_date")]
        public string endDate { get; set; }
        [XmlElement("Department")]
        public string department { get; set; }
    }
}
