using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._1_Application_Services
{
    class HappeningService
    {
        private readonly IHappeningService _happeningService;

        public HappeningService(IHappeningService happeningService)
        {
            _happeningService = happeningService;
        }

       async Task<bool> AddHappening(Happening happening)
        {
            var add =  new Happening(happening.Id, happening.Name, happening.Date, happening.Price, happening.CurrentParticipants, happening.MaxParticipants);
            var isCreated = await _happeningService.Create(add);
            if (!isCreated) return false;
            return true;



        }

       async Task<List<Person>> ListAllHappeningsForPerson(Person person)
       {
           var happenings = await _happeningService.ReadByPerson(person);
           var happeningList = new List<Person> {happenings};
           return happeningList;
       }

       async Task<List<Happening>> ListAllHappeningsForPerson(Happening happening)
       {
           var pepole = await _happeningService.ReadByHappening(happening);
           var listOfPepole = new List<Happening> {pepole};
           return listOfPepole;
       }

       async Task<List<Happening>> ListAllHappenings(Happening happening)
       {
           var happenings = await _happeningService.ReadAllHappenings(happening);
           var listOfHappenings = new List<Happening> {happenings};
           return listOfHappenings;
       }
    }
}
