using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._2_Domain_Services
{
   public interface INewsletterSubscriptionRepository
    {
        Task<bool> Create(NewsletterSubscription subsciption);
        Task<NewsletterSubscription> ReadByEmail(string email);
        Task<bool> Update(NewsletterSubscription subscription);
        Task<bool> Delete(NewsletterSubscription subscription);
    }
}
