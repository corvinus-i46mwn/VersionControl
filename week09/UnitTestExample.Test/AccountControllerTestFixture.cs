using Moq;
using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Abstractions;
using UnitTestExample.Controllers;
using UnitTestExample.Entities;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();
            //Act
            var actualResult = ac.ValidateEmail(email);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [
            Test,
            TestCase("abcdgffgnfREG", false),
            TestCase("WHWHD467", false),
            TestCase("seadgrz56tzh", false),
            TestCase("roVid1", false),
            TestCase("MegfeleloJelszo12",true)
            ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();
            //Act
            var actualResult = ac.ValidatePassword(password);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [
    Test,
    TestCase("irf@uni-corvinus.hu", "Abcd1234"),
    TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Returns<Account>(a => a);
            ac.AccountManager = accountServiceMock.Object;
            //Act
            var actualAccount= ac.Register(email, password);
            //Assert
            Assert.AreEqual(email, actualAccount.Email);
            Assert.AreEqual(password, actualAccount.Password);
            Assert.AreNotEqual(Guid.Empty, actualAccount.ID);
            accountServiceMock.Verify(m => m.CreateAccount(actualAccount), Times.Once);
        }

        [Test,
    TestCase("irf@uni-corvinus", "Abcd1234"),
    TestCase("irf.uni-corvinus.hu", "Abcd1234"),
    TestCase("irf@uni-corvinus.hu", "abcd1234"),
    TestCase("irf@uni-corvinus.hu", "ABCD1234"),
    TestCase("irf@uni-corvinus.hu", "abcdABCD"),
    TestCase("irf@uni-corvinus.hu", "Ab1234")]
        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();
            //Act(+Assert)
            try
            {
                var actualAccount = ac.Register(email, password);
                Assert.Fail();
            }
            catch (Exception er)
            {
                Assert.IsInstanceOf<ValidationException>(er);
            }
            
            
        }
        [
    Test,
    TestCase("irf@uni-corvinus.hu", "Abcd1234")
]
        public void TestRegisterApplicationException(string newEmail, string newPassword)
        {
            // Arrange
            var accountServiceMock = new Mock<IAccountManager>(MockBehavior.Strict);
            accountServiceMock
                .Setup(m => m.CreateAccount(It.IsAny<Account>()))
                .Throws<ApplicationException>();
            var accountController = new AccountController();
            accountController.AccountManager = accountServiceMock.Object;

            // Act
            try
            {
                var actualResult = accountController.Register(newEmail, newPassword);
                Assert.Fail();
            }
            catch (Exception er)
            {
                Assert.IsInstanceOf<ApplicationException>(er);
            }

           
        }
    }
}
