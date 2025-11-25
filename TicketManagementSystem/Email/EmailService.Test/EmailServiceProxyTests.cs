using System;
using NUnit.Framework;

namespace EmailService.Test
{
    [TestFixture]
    public class EmailServiceProxyTests
    {
        [Test]
        public void ShallThrowExceptionOnNullIncidentTitle()
        {

            //STEP 1 - ARRANGE
            var proxy = new EmailServiceProxy();


            //STEP 2 - ACT
            Assert.That(() => proxy.SendEmailToAdministrator(null, null), Throws.TypeOf<ArgumentNullException>());


            //STEP 3 - ASSERT   
        }
    }
}
