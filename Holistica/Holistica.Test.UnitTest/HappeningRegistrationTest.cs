using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Holistica.Core._1_Application_Services;
using Holistica.Core._2_Domain_Services;
using Holistica.Core._3_Domain_Model;
using Microsoft.VisualBasic;
using Moq;
using NUnit.Framework;

namespace Holistica.Test.UnitTest
{
    class HappeningRegistrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestRegistrationOK()
        {
            var registrationMock =  new Mock<IHappeningRegistrationRepository>();
            registrationMock.Setup(hr => hr.Create(It.IsAny<HappeningRegistration>())).ReturnsAsync(true);
            var service = new HappeningRegistrationService(registrationMock.Object);
            var registration =  new HappeningRegistration("Test", 1, "Karl", "Tname", "Yoga");
            var isSucsess = await service.Register(registration);
            Assert.IsTrue(isSucsess);
            registrationMock.Verify(hr =>hr.Create(It.Is<HappeningRegistration>(r=>r.HappeningName =="Test")));
            registrationMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestRegistrationFailure()
        {

            var registrationMock = new Mock<IHappeningRegistrationRepository>();
            registrationMock.Setup(hr => hr.Create(It.IsAny<HappeningRegistration>())).ReturnsAsync(false);
            var service = new HappeningRegistrationService(registrationMock.Object);
            var registration = new HappeningRegistration("Test", 1, "Karl", "Tname", "Yoga");
            var isSucsess = await service.Register(registration);
            Assert.IsFalse(isSucsess);
            registrationMock.Verify(hr => hr.Create(It.Is<HappeningRegistration>(r => r.HappeningName == "Test")));
            registrationMock.VerifyNoOtherCalls();
        }
        [Test]
        public async Task TestUnregisterOk()
        {
            var HappeningID = 1;
            var personID = "Torfin";
           var readRequest = new HappeningRegistration(null, HappeningID, null, personID, null);
            var dbRequest = new HappeningRegistration("Test", 2,"Torfin", "ID", "Yoga");

            var registrationMock = new Mock<IHappeningRegistrationRepository>();
            registrationMock.Setup(hr => hr.Read(personID, HappeningID)).ReturnsAsync(dbRequest);
            registrationMock.Setup(hr => hr.Delete(It.IsAny<HappeningRegistration>())).ReturnsAsync(true);
            var service =  new HappeningRegistrationService(registrationMock.Object);
            var isSucsess = await service.UnRegister(dbRequest);

            Assert.IsTrue(isSucsess);
  
        }

        [Test]
        public async Task TestUnregisterFailure()
        {

            var HappeningID = 1;
            var personID = "Torfin";
            
            var dbRequest = new HappeningRegistration("Test", 2, "Torfin", "ID", "Yoga");

            var registrationMock = new Mock<IHappeningRegistrationRepository>();
            registrationMock.Setup(hr => hr.Read(personID, HappeningID)).ReturnsAsync(dbRequest);
            registrationMock.Setup(hr => hr.Delete(It.IsAny<HappeningRegistration>())).ReturnsAsync(false);
            var service = new HappeningRegistrationService(registrationMock.Object);
            var isSucsess = await service.UnRegister(dbRequest);

            Assert.IsFalse(isSucsess);
        }

    }
}
