using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._1_Application_Services
{
    public class HappeningRegistrationService
    {
        private readonly IHappeningRegistrationRepository _registrationRepository;

        public HappeningRegistrationService(IHappeningRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        public async Task<bool> Register(HappeningRegistration request)
        {
            var registration = new HappeningRegistration(request.HappeningName, request.HappeningID, request.PersonName, request.PersonID, request.Type);
            var isRegistered = await _registrationRepository.Create(registration);
            if (!isRegistered) return false;
            return true;
        }
        public async Task<bool> UnRegister(HappeningRegistration request)
        {
            var registration = await _registrationRepository.Read(request.PersonID, request.HappeningID);
            var isDeleted = await _registrationRepository.Delete(registration);
            if (!isDeleted) return false;

            return true;
        }
    }

}

