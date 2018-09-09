using System;
using System.Collections.Generic;
using ConfigGenerator.Models;
using ConfigGenerator.Consts;

namespace ConfigGenerator.Services
{
    public class ParserService
    {
        public List<ProminObject> SplitByUnits(string iniFile)
        {
            List<ProminObject> units = new List<ProminObject>();
            int prominObjectNumber = 0;

            string[] parsedByGatesIniFile = iniFile.Split(Consts.gatesDivider, StringSplitOptions.RemoveEmptyEntries);

            for (int gateIterator = 1; gateIterator < parsedByGatesIniFile.Length; gateIterator++)
            {
                ProminObject prominObjectModel = new ProminObject();

                string[] gateSplittedIntoProminObjects = splitByProminObjects(parsedByGatesIniFile[gateIterator]);
                int gateNumber = getGateNumber(gateSplittedIntoProminObjects);

                for (int prominObjectIterator = 0; prominObjectIterator <= gateSplittedIntoProminObjects.Length;
                    prominObjectIterator++)
                {
                    prominObjectNumber++;

                    ProminObject gate = new ProminObject();

                    if (parsedByGatesIniFile[1] == "ПСО")
                    {
                        
                    }
                    else if(parsedByGatesIniFile[1] == "Щит інженерний" || parsedByGatesIniFile[1] == "Щит ліфта")
                    {
                        gate = CreateProminObjectModel(gate, prominObjectIterator, prominObjectNumber, gateNumber);
                    }

                    units.Add(gate);
                }
            }

            return units;
        }

        private string[] splitByProminObjects(string gate)
        {
            string[] gateParsedByProminObjects = gate.Split(Consts.prominObjectsDivider, StringSplitOptions.RemoveEmptyEntries);

            return gateParsedByProminObjects;
        }

        public ProminObject CreateProminObjectModel(ProminObject prominObjectModel, int bitNumber, int buildingObjectNubmer, int gateNumber)
        {
            prominObjectModel.sector = 234; //TODO: add logic for getting sector number
            prominObjectModel.buildingNo = 1; //TODO: add logic for getting building number
            prominObjectModel.buildingObjectNo = buildingObjectNubmer;
            prominObjectModel.gateNo = gateNumber;
            prominObjectModel.bit = bitNumber;
            prominObjectModel.code = 16; //TODO: addlogic for getting code number
            prominObjectModel.isInverted = true;
            prominObjectModel.type = "Additional"; //TODO: addlogic for getting type
            prominObjectModel.ignoreNotification = false;

            return prominObjectModel;
        }

        public int getGateNumber(string[] gateSplittedIntoProminObjects)
        {
            int gateNumber = Int32.Parse(gateSplittedIntoProminObjects[2]
                .Split(Consts.gateNumberDivider, StringSplitOptions.RemoveEmptyEntries)[1]);

            return gateNumber;
        }
    }
}
