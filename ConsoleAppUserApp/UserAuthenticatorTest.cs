using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUserApp
{
    [TestFixture]
    public class UserAuthenticatorTests
    {
        private UserAuthenticator authenticator;

        [SetUp]
        public void Setup()
        {
            authenticator = new UserAuthenticator();
        }

        [Test]
        public void RegisterUser_SuccessfulRegistration()
        {
            bool result = authenticator.RegisterUser("testuser", "testpassword");
            Assert.IsTrue(result);
        }

        [Test]
        public void RegisterUser_FailedRegistration_DuplicateUser()
        {
            authenticator.RegisterUser("existinguser", "password");

            bool result = authenticator.RegisterUser("existinguser", "newpassword");
            Assert.IsFalse(result);
        }

        [Test]
        public void Login_SuccessfulLogin()
        {
            authenticator.RegisterUser("loginuser", "loginpassword");

            bool result = authenticator.Login("loginuser", "loginpassword");
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_FailedLogin_IncorrectCredentials()
        {
            authenticator.RegisterUser("loginuser", "loginpassword");

            bool result = authenticator.Login("loginuser", "wrongpassword");
            Assert.IsFalse(result);
        }
    }
}