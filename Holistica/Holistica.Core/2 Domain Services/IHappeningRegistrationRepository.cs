using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._2_Domain_Services
{
    public interface IHappeningRegistrationRepository
    {
        Task<bool> Create(HappeningRegistration registration);
        Task<HappeningRegistration> Read(string personId, int happeningID);
        Task<bool> Delete(HappeningRegistration registration);
    }
}
