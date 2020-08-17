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
    public class HappeningRegistrationRepository : IHappeningRegistrationRepository
    {
        public async Task<bool> Create(HappeningRegistration registration)
        {
            var connstr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connstr);
            const string insert = "INSERT INTO Hreg (HappeningName,  PersonName, PersonID, Type) VALUES (@HappeningName,  @PersonName, @PersonID, @Type)";
            var dbModel = MapToDB(registration);
            var rowsAffected = await connection.ExecuteAsync(insert, dbModel);
            return rowsAffected == 1;

        }

        

        public async Task<HappeningRegistration> Read(string personID, int happeningID)
        {
            var connstr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connstr);
            const string select =
                "SELECT HappeningName, HappeningID, PersonName, PersonID FROM Hreg WHERE PersonID =@PersonID AND HappeningID = HappeningID";
            var result = await connection.QueryAsync<HappeningRegistration>(select, new {PersonID = personID , HappeningID = happeningID});
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);


        }

      

        public async Task<bool> Delete(HappeningRegistration registration)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string delete = "DELETE FROM Hreg WHERE  HappeningID = @HappeningID AND PersonID =@PersonID";
            var dbModel = MapToDB(registration);
            var rowsAffected = await connection.ExecuteAsync(delete, dbModel);
            return rowsAffected == 1;
        }
        private HappeningRegistration MapToDB(HappeningRegistration registration)
        {
           return new HappeningRegistration(registration.HappeningName, registration.HappeningID, registration.PersonName, registration.PersonID, registration.Type);
        }
        private HappeningRegistration MapToDomain(HappeningRegistration registration)
        {
            return new HappeningRegistration(registration.HappeningName, registration.HappeningID, registration.PersonName, registration.PersonID, registration.Type);
        }
    }
}
