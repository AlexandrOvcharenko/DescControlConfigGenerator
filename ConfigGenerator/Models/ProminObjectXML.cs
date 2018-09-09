using System.Xml;

namespace ConfigGenerator.Models
{
    class ProminObjectXML
    {
        public XmlElement ProminObjectXml { get; set; }
        public XmlElement SectorXml { get; set; }
        public XmlElement BuildingNoXml { get; set; }
        public XmlElement BuildingObjectNumberXml { get; set; }
        public XmlElement GateNumberXml { get; set; }
        public XmlElement BitXml { get; set; }
        public XmlElement CodeXml { get; set; }
        public XmlElement IsInvertedXml { get; set; }
        public XmlElement IgnoreNotification { get; set; }
        public XmlElement TypeXml { get; set; }
    }
