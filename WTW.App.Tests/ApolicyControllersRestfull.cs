using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebApplication1.Controllers;
using WTW.App.Domain;
using WTW.App.Tests;
using WTW.App.Web.Api.Interfaces.Services;

namespace Tests
{
    public class ApolicyControllersRestfull
    {
        private List<Policy> _policies;
        //private IPolicyService _policeService;
        private HttpClient _client;
        //private string _token;
        private const string ServiceBaseURL = "http://localhost:5000/";

        [SetUp]
        public void Setup()
        {
            _policies = Arrangers.GetPolicies();
            _client = new HttpClient
            {
                BaseAddress = new Uri(ServiceBaseURL)
            };
        }

        [Test]
        public void Get()
        {
            // arrange
            Mock<IPolicyService> moqService = new Mock<IPolicyService>();
            moqService.Setup(get => get.Get()).ReturnsAsync(_policies);
            PolicyController contrl = new PolicyController(moqService.Object);

            //act
            var PolicyController = new PolicyController(moqService.Object);
            var result = PolicyController.Get().Result;

            //assert
            Assert.AreEqual(result.Count(), _policies.Count);
        }

        [Test]
        [TestCase(739562)]
        public async Task GetOk(int policyNumber)
        {
            // arrange
            Mock<IPolicyService> moqService = new Mock<IPolicyService>();
            var police = _policies.Where(a => a.PolicyNumber == policyNumber).FirstOrDefault();
            moqService.Setup(get => get.GetByPolicyNumber(policyNumber)).ReturnsAsync(police);
            PolicyController contrl = new PolicyController(moqService.Object);

            //act
            var controller = new PolicyController(moqService.Object);
            var resultOk = await controller.GetByPolicyNumber(policyNumber) as ActionResult<Policy>;

            //assert
            Assert.AreEqual(resultOk.Value.PolicyHolderId, police.PolicyHolderId);
        }

        [Test]
        [TestCase(999999)]
        public async Task GetBadRequest(int policyNumber)
        {
            // arrange
            Mock<IPolicyService> moqService = new Mock<IPolicyService>();
            var police = _policies.Where(a => a.PolicyNumber == policyNumber).FirstOrDefault();
            moqService.Setup(get => get.GetByPolicyNumber(policyNumber)).ReturnsAsync(police);
            PolicyController contrl = new PolicyController(moqService.Object);

            //act
            var controller = new PolicyController(moqService.Object);
            var resultBad = await controller.GetByPolicyNumber(policyNumber) as ActionResult<Policy>;


            //assert
            Assert.AreEqual(((ObjectResult)resultBad.Result).StatusCode, 404);
        }

        [Test]
        public async Task DeleteOk()
        {
            // arrange
            Mock<IPolicyService> moqService = new Mock<IPolicyService>();
            var policy = new Policy
            {
                PolicyNumber = 11111,
                PolicyHolderId = 22222,
                PolicyHolder = new PolicyHolder
                {
                    Id = 2222,
                    Age = 22,
                    Gender = Gender.Male,
                    Name = "Sebastian"
                }
            };

            moqService.Setup(get => get.GetByPolicyNumber(policy.PolicyNumber)).ReturnsAsync(policy);
            moqService.Setup(r => r.Remove(policy.PolicyNumber));

            //act
            var controller = new PolicyController(moqService.Object);
            var resultOk = await controller.Delete(policy.PolicyNumber) as ActionResult;

            //assert
            Assert.AreEqual(204, ((Microsoft.AspNetCore.Mvc.StatusCodeResult)resultOk).StatusCode);
        }

        [Test]
        public async Task DeleteBadRequest()
        {
            // arrange
            Mock<IPolicyService> moqService = new Mock<IPolicyService>();
            Policy policy = null;
            int policyNumber = 12345;

            moqService.Setup(get => get.GetByPolicyNumber(policyNumber)).ReturnsAsync(policy);
            moqService.Setup(r => r.Remove(policyNumber));

            //act
            var controller = new PolicyController(moqService.Object);
            var resultOk = await controller.Delete(policyNumber) as ActionResult;

            //assert
            Assert.AreEqual(404, ((Microsoft.AspNetCore.Mvc.ObjectResult)resultOk).StatusCode);
        }

        [TearDown]
        public void DisposeAllObjects()
        {
            if (_client != null) _client.Dispose();
        }
    }
}