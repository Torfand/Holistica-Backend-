using System;
using System.Collections.Generic;
using System.Text;

namespace Holistica.Core._3_Domain_Model
{
    public class HappeningRegistration
    {
        public string HappeningName { get; set; }
        public int HappeningID { get; set; }
        public string PersonName { get; set; }
        public string PersonID { get; set; }
        public string Type { get; set; }

        public HappeningRegistration(string happeningName, int happeningId, string personName, string personId, string type)
        {
            HappeningName = happeningName;
            HappeningID = happeningId;
            PersonName = personName;
            PersonID = personId;
            Type = type;
        }

        public HappeningRegistration()
        {
            
        }
    }
}
