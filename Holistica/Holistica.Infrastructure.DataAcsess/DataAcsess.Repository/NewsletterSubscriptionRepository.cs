using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Infrastructure.DataAcsess.DataAcsess.Repository
{
   public class NewsletterSubscriptionRepository :INewsletterSubscriptionRepository
    {
        public async Task<bool> Create(NewsletterSubscription subsciption)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string insert =
                "INSERT INTO Regtest (Name, Email, Code, Status) VALUES (@Name, @Email, @Code, 'Not Verified')";
            var dbModel = MapToDB(subsciption);
            var rowsAffected = await connection.ExecuteAsync(insert, dbModel);
            return rowsAffected == 1;

        }



        public async Task<NewsletterSubscription> ReadByEmail(string email)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string select = "SELECT Name, Email, Code FROM Regtest WHERE Email = @Email";
            var result = await connection.QueryAsync<NewsletterSubscription>(select, new {Email = email});
            var dbModel = result.SingleOrDefault();
            return MapToDomain(dbModel);

        }

     

        public async Task<bool> Update(NewsletterSubscription subscription)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string update = "UPDATE Regtest SET status='Verified', Email=@Email WHERE Code=@Code";
            var dbModel = MapToDB(subscription);
            var rowsAffected = await connection.ExecuteAsync(update, dbModel);
            return rowsAffected == 1;
        }

        public async Task<bool> Delete(NewsletterSubscription subscription)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Subtest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            await using var connection = new SqlConnection(connStr);
            const string delete = "DELETE FROM Regtest WHERE  Email = @Email";
            var dbmodel = MapToDB(subscription);
            var rowsAffected = await connection.ExecuteAsync(delete, dbmodel);
            return rowsAffected == 1;
        }
        private NewsletterSubscription MapToDB(NewsletterSubscription subscription)
        {
            return new NewsletterSubscription(subscription.Name, subscription.Email, subscription.Code);
        }
        private NewsletterSubscription MapToDomain(NewsletterSubscription subscription)
        {
            return new NewsletterSubscription(subscription.Name, subscription.Email, subscription.Code);
        }
    }
}
    