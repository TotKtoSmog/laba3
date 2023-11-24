using System.Collections.Generic;
using System.Xml.Serialization;

namespace laba3.Task2
{
    [XmlRoot("Valuta")]
    public class Valuta
    {
        [XmlElement("Item")]
        public List<Item> Items { get; set; }
    }
    
}
