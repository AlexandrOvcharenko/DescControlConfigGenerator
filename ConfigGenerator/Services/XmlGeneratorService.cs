using System.Collections.Generic;
using System.Xml;
using ConfigGenerator.Models;
using ConfigGenerator.Services;

namespace ConfigGenerator.infra
{
    public class XmlGeneratorService
    {
        private readonly ParserService _parserSerivce;
        private readonly ReaderService _readerService;

        public XmlGeneratorService()
        {
            _parserSerivce = new ParserService();
            _readerService = new ReaderService();
        }

        public XmlDocument GenerateXmlDocument(string iniFilePath)
        {
            XmlDocument xmlDocument = GenerateXmlSkeleton();
            XmlElement arrayOfProminObject = xmlDocument.CreateElement("ArrayOfProminObject");

            int buildingObjectNumber = 0;
            string iniFileAsString = _readerService.GetIniFileAsString(iniFilePath);

            List<ProminObject> prominObjects = _parserSerivce.SplitByUnits(iniFileAsString);

            foreach (var prominObject in prominObjects)
            {
                buildingObjectNumber++;

                XmlElement prominObjectXML = GetProminObjectXML(xmlDocument, prominObject);
                arrayOfProminObject.AppendChild(prominObjectXML);
            }

            xmlDocument.AppendChild(arrayOfProminObject);
            xmlDocument.Save("ProminObject.xml");

            return xmlDocument;
        }

        private XmlElement GetProminObjectXML(XmlDocument xmlDocument, ProminObject prominObject)
        {
            XmlElement prominObjectXml = xmlDocument.CreateElement("ProminObject");
            XmlElement sectorXml = xmlDocument.CreateElement("Sector");
            XmlElement buildingNoXml = xmlDocument.CreateElement("BuildingNo");
            XmlElement buildingObjectNumberXml = xmlDocument.CreateElement("BuildingObjectNo");
            XmlElement gateNumberXml = xmlDocument.CreateElement("GateNo");
            XmlElement bitXml = xmlDocument.CreateElement("Bit");
            XmlElement codeXml = xmlDocument.CreateElement("Code");
            XmlElement isInvertedXml = xmlDocument.CreateElement("IsInverted");
            XmlElement ignoreNotification = xmlDocument.CreateElement("IgnoreNotification");
            XmlElement typeXml = xmlDocument.CreateElement("Type");

            sectorXml.InnerText = prominObject.sector.ToString();
            buildingNoXml.InnerText = prominObject.buildingNo.ToString();
            buildingObjectNumberXml.InnerText = prominObject.buildingObjectNo.ToString();
            gateNumberXml.InnerText = prominObject.gateNo.ToString();
            bitXml.InnerText = prominObject.bit.ToString();
            codeXml.InnerText = prominObject.code.ToString();
            isInvertedXml.InnerText = prominObject.isInverted.ToString();
            typeXml.InnerText = prominObject.type;

            prominObjectXml.AppendChild(sectorXml);
            prominObjectXml.AppendChild(buildingNoXml);
            prominObjectXml.AppendChild(buildingObjectNumberXml);
            prominObjectXml.AppendChild(gateNumberXml);
            prominObjectXml.AppendChild(bitXml);
            prominObjectXml.AppendChild(codeXml);
            prominObjectXml.AppendChild(isInvertedXml);
            prominObjectXml.AppendChild(ignoreNotification);
            prominObjectXml.AppendChild(typeXml);

            return prominObjectXml;
        }

        private XmlDocument GenerateXmlSkeleton()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(xmlDeclaration);

            return xmlDocument;
        }
    }
}
