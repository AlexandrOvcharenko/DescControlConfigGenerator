using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigGenerator.Models
{
    public class ProminObject
    {
        public int sector { get; set; }
        public int buildingNo { get; set; }
        public int buildingObjectNo { get; set; }
        public int gateNo { get; set; }
        public int bit { get; set; }
        public int code { get; set; }
        public bool isInverted { get; set; }
        public bool ignoreNotification { get; set; }
        public string type { get; set; }
    }
}
