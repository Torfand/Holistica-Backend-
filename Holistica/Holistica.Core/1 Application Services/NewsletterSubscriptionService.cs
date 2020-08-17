using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;

namespace Holistica.Core._1_Application_Services
{
  public class NewsletterSubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly INewsletterSubscriptionRepository _subscriptionRepository;

        public NewsletterSubscriptionService(IEmailService emailService, INewsletterSubscriptionRepository subscriptionRepository)
        {
            _emailService = emailService;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> Subscribe(NewsletterSubscription request)
        {
            var subscription = new NewsletterSubscription(request.Name, request.Email, request.Code);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var url = $"https://localhost:5001/index.html?email={request.Email}&code={subscription.Code}";
            var text =
                $"Hello {request.Name}, Click the link below to confirm subscription to newsletter \n <a href =\"{url}\">Click here to Confirm Subscription to Newsletter</a> ";
            var confirmationEmail = new Email(
                "To: " + request.Email, 
                "From: " + "NewsletterTest@test.no",
                "Subject : " + "Confirm Subscription to Newsletter",
                text
            );
            var isSendt = await _emailService.Send(confirmationEmail);
            if (!isSendt) return false;
            return true;
        }

        public async Task<bool> Verify(NewsletterSubscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.Code != subscription.Code) return false;

            var hasUpdated = await _subscriptionRepository.Update(subscription);
            if (!hasUpdated)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> UnSubscribe(NewsletterSubscription request)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(request.Email);
            var isDeleted = await _subscriptionRepository.Delete(subscription);
            if (!isDeleted) return false;
            return true;


        }
    }
}
