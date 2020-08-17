using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._2_Domain_Services
{
   public interface IHappeningService
    {
        Task<bool> Create(Happening happening);

        Task<Person> ReadByPerson(Person person);

        Task<Happening> ReadByHappening(Happening happening);

        Task<Happening> ReadAllHappenings(Happening happening);
        //Task<bool> AddHappening(Happening happening);
        //List<Happening> ListAllHappeningsForPerson(Person person);
        //List<Person> ListAllPersonsInHappening(Happening happening);
        //List<Happening> GetAllHappenings(Happening happening);
    }
}
