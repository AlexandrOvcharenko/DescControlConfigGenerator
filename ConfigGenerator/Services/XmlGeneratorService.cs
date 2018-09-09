using System.Collections.Generic;
using System.Xml;
using ConfigGenerator.Models;
using ConfigGenerator.Services;

namespace ConfigGenerator.infra
{
    public class XmlGeneratorService
    {
        private readonly ParserService parserSerivce;
        private readonly ReaderService readerService;
        private string iniFileAsString { get; set; }
        private XmlElement ArrayOfProminObject { get; set; }

        public XmlGeneratorService(ReaderService reader, ParserService parser)
        {
            parserSerivce = parser;
            readerService = reader;
        }

        public XmlDocument GenerateXmlDocument()
        {
            XmlDocument xmlDocument = GenerateXmlSkeleton();

            int buildingObjectNumber = 0;
            iniFileAsString = readerService.GetIniFileAsString();

            List<ProminObject> prominObjects = parserSerivce.SplitByUnits(iniFileAsString);

            foreach(var prominObject in prominObjects)
            {
                buildingObjectNumber++;

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

                ArrayOfProminObject.AppendChild(prominObjectXml);
                prominObjectXml.AppendChild(sectorXml);
                prominObjectXml.AppendChild(buildingNoXml);
                prominObjectXml.AppendChild(buildingObjectNumberXml);
                prominObjectXml.AppendChild(gateNumberXml);
                prominObjectXml.AppendChild(bitXml);
                prominObjectXml.AppendChild(codeXml);
                prominObjectXml.AppendChild(isInvertedXml);
                prominObjectXml.AppendChild(ignoreNotification);
                prominObjectXml.AppendChild(typeXml);
            }

            xmlDocument.AppendChild(ArrayOfProminObject);
            xmlDocument.Save("ProminObject.xml");

            return xmlDocument;
        }

        private XmlDocument GenerateXmlSkeleton()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDecl = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            ArrayOfProminObject = xmlDocument.CreateElement("ArrayOfProminObject");
            xmlDocument.AppendChild(xmlDecl);
            xmlDocument.AppendChild(ArrayOfProminObject);

            return xmlDocument;
        }
    }
}
