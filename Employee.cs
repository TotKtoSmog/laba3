using System.Collections.Generic;
using System.Xml.Serialization;

namespace laba3
{
    [XmlRoot("Employee")]
    public class Employee
    {
        [XmlElement("FIO")]
        public string FIO { get; set; }
        [XmlElement("yearOfBirth")]
        public string yearOfBirth { get; set; }
        [XmlElement("address")]
        public string address { get; set; }
        [XmlElement("phone")]
        public string phone { get; set; }

        public List<Job> Jobs { get; set; }
        public List<Salary> Salarys { get; set; }
    }
}
