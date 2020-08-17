using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holistica.Core._1_Application_Services;
using Holistica.Core._3_Domain_Model;
using Microsoft.AspNetCore.Mvc;

namespace Holistica.Infrastructure.Api.Controllers
{
    [Route("api/subscribe")]
    [ApiController]
    public class NewsletterSubscriptionController
    {
        private readonly NewsletterSubscriptionService _newsletterSubscriptionService;

        public NewsletterSubscriptionController(NewsletterSubscriptionService newsletterSubscriptionService)
        {
            _newsletterSubscriptionService = newsletterSubscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(Person person)
        {
            var code = new BaseEntity(new Guid());
            var subscription =  new NewsletterSubscription {Name = person.Name, Email = person.Email, Code = code.Id.ToString()};
            return await _newsletterSubscriptionService.Subscribe(subscription);
        }
        [HttpDelete]
        public async Task<bool> UnSubscribe(Person person)
        {
            var subscription =  new NewsletterSubscription{Name = person.Name, Email = person.Email};
            return await _newsletterSubscriptionService.UnSubscribe(subscription);
        }

    }
}
