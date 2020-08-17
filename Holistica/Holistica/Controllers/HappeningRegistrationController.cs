using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holistica.Core._1_Application_Services;
using Holistica.Core._3_Domain_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace Holistica.Infrastructure.Api.Controllers
{
    [Route("api/HappeningRegistration")]
    [ApiController]
    public class HappeningRegistrationController
    {
        private readonly HappeningRegistrationService _registrationService;

        public HappeningRegistrationController(HappeningRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<bool> Register(HappeningRegistration registration)
        {
           
            var register = new HappeningRegistration{HappeningName = registration.HappeningName, HappeningID = registration.HappeningID, PersonName = registration.PersonName, PersonID = registration.PersonID, Type = registration.Type};
            return await _registrationService.Register(register);
        }

        [HttpDelete]
        public async Task<bool> UnRegister(HappeningRegistration request)
        {
          
            var register = new HappeningRegistration { HappeningName = request.HappeningName, HappeningID = request.HappeningID, PersonName = request.PersonName, PersonID = request.PersonID, Type = request.Type };

            return await _registrationService.UnRegister(request);
        }
    }
}
