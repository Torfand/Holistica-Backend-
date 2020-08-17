using System.Reflection.Metadata;
using System.Threading.Tasks;
using Holistica.Core._1_Application_Services;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;
using Moq;
using NUnit.Framework;

namespace Holistica.Test.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestSubOK()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<INewsletterSubscriptionRepository>();
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                .ReturnsAsync(true);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<NewsletterSubscription>()))
                .ReturnsAsync(true);
            var service = new NewsletterSubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);

            var subscription = new NewsletterSubscription("Terje", "terje@kolderup.net");
            var subscribeIsSuccess = await service.Subscribe(subscription);

            Assert.IsTrue(subscribeIsSuccess);
            emailServiceMock.Verify(
                   es => es.Send(It.Is<Email>(e => e.To == "To: " + "terje@kolderup.net")));
            subscriptionRepoMock.Verify(
                sr => sr.Create(It.Is<NewsletterSubscription>(s => s.Email == "terje@kolderup.net")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }
        [Test]
        public async Task TestSubFailure()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<INewsletterSubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<NewsletterSubscription>())).ReturnsAsync(false);
            var service = new NewsletterSubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new NewsletterSubscription("Torfin", "Torfand@gmail.com");
            var isSucsess = await service.Subscribe(subscription);
            Assert.IsFalse(isSucsess);
            subscriptionRepoMock.Verify(sr=> sr.Create(It.Is<NewsletterSubscription>(s=> s.Email == "Torfand@gmail.com")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestVerificationOK()
        {
            var code = "c0303f97-db5d-479b-8557-47b379594bf1";
            var email = "ikkeEnEkteEpost@epost.no";
            var verifictionRequest = new NewsletterSubscription(null, email, code);
            var dbSubscritpionRequest = new NewsletterSubscription(null,null,code);

            var subscriptionRepoMock = new Mock<INewsletterSubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(dbSubscritpionRequest);
            subscriptionRepoMock.Setup(sr => sr.Update(It.IsAny<NewsletterSubscription>())).ReturnsAsync(true);
            var service = new NewsletterSubscriptionService(null, subscriptionRepoMock.Object);
            var isSucsess = await service.Verify(verifictionRequest);
            Assert.IsTrue(isSucsess);
            subscriptionRepoMock.Verify(sr=> sr.Update(It.IsAny<NewsletterSubscription>()));

        }
        [Test]
        public async Task TestVerficationInvalid()
        {
            var code1 = "c0303f97-db5d-479b-8557-47b379594bf1";
            var code2 = "c0303f97-db5d-479b-8557-47b379594bf2";
            var email = "ikkeEnEkteEpost@epost.no";
            var verificationRequest = new  NewsletterSubscription(null, email, code1);
            var dbSubRequest = new NewsletterSubscription(null, null, code2);

            var subRepoMock = new Mock<INewsletterSubscriptionRepository>();
            subRepoMock.Setup(sr => sr.ReadByEmail(email)).ReturnsAsync(dbSubRequest);
            var service = new NewsletterSubscriptionService(null, subRepoMock.Object);
            var IsSucsess = await service.Verify(verificationRequest);
            Assert.IsFalse(IsSucsess);
            subRepoMock.Verify(sr => sr.ReadByEmail(email));
            subRepoMock.VerifyNoOtherCalls();
        }
     


    }
    }
