using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holistica.Core._1_Application_Services;
using Holistica.Core._3_Domain_Model;
using Microsoft.AspNetCore.Mvc;

namespace Holistica.Infrastructure.Api.Controllers
{
    [Route("api/verify")]
    [ApiController]
    public class NewsletterVerificationController
    {
        private readonly NewsletterSubscriptionService _newsletterSubscriptionService;

        public NewsletterVerificationController(NewsletterSubscriptionService newsletterSubscriptionService)
        {
            _newsletterSubscriptionService = newsletterSubscriptionService;
        }

        [HttpPut]
        public async Task<bool> Verify(NewsletterVerification verificationRequest)
        {
            var request = new NewsletterSubscription { Email = verificationRequest.Email, Code = verificationRequest.Code };
            return await _newsletterSubscriptionService.Verify(request);
        }
    }
}
