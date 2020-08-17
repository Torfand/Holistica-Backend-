using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Infrastructure.DataAcsess.DataAcsess.Repository
{
    class HappeningRepository: IHappeningService
    {
        public async Task<bool> Create(Happening happening)
        {
            var connStr = @"connstr";
            using var connection =  new SqlConnection(connStr);
            const string insert =
                "INSERT INTO Happenings (Id, Name, Date, Price, CurrentParticipants, MaxParticipants) VALUES (@Id, @Name, @Date, @Price, @CurrentParticipants, @MaxParticipants)";
            var dbModel = MapToDB(happening);
            var rowsAffected = await connection.ExecuteAsync(insert, dbModel);
            return rowsAffected == 1;

        }


        public async Task<Person> ReadByPerson(Person person) // get all pepole registered to happenings
        {
            var connStr = @"connstr";
            using var connection = new SqlConnection(connStr);
            const string select =
                "SELECT Id, Name, Date, Price, CurrentParticipants, MaxParticipants FROM Happenings WHERE Id=@Id "; //PLACEHOLDER, MIGHT NEED JOIN WITH REGISTERED PEPOLE TABLE IN ORDER TO WORK PROPERLY
            var result = await connection.QueryAsync(select, new {Id = person.Email}); // Placeholder aswell, using person.email here will throw sql exeptions when called
            //foreach (dynamic name in result)
            //{
                
            //}
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);
        }


        public async Task<Happening> ReadByHappening(Happening happening) //get all happening one person has registered for 
        {
            var connStr = @"connstr";
            using var connection = new SqlConnection(connStr);
            const string select =
                "SELECT Id, Name, Date, Price, CurrentParticipants, MaxParticipants FROM Happenings WHERE Id=@Id "; //PLACEHOLDER, MIGHT NEED JOIN WITH ?? TABLE IN ORDER TO WORK PROPERLY
            var result = await connection.QueryAsync(select, new { Id = happening.Id }); // Placeholder aswell, using person.email here will throw sql exeptions when called
            //foreach (dynamic name in result)
            //{

            //}
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);
        }
        public async Task<Happening> ReadAllHappenings(Happening happening)
        {
            var connStr = @"connstr";
            using var connection = new SqlConnection(connStr);
            const string select = "Select Name, Date, Price, CurrentParticipants, MaxParticipants FROM Happenings";
            var result = await connection.QueryAsync(select);
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);
        }
        private Person MapToDomain(Person person)
        {
            throw new NotImplementedException();
        }

        private object MapToDB(Happening happening)
        {
            throw new NotImplementedException();
        }


        //    public async Task<Happening> ReadAllHappenings(Happening happening)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private object MapToDB(Happening happening)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
