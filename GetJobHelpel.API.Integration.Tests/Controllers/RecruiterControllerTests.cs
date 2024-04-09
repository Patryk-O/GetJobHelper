using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GetJobHelper.API.DBContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GetJobHelper.API.Controllers;
using Data;
using System.Net.Http.Json;

namespace GetJobHelpel.API.Integration.Tests.Controllers
{
    [TestClass()]
    public class RecruiterControllerTests
    {
        [TestMethod()]
        public async Task GetAllRecruitersAsyncTest()
        {
            // Arrange
            var app = new GetJobHelpelWebApplicationTests();
            var client = app.CreateClient();

            // Act
            var response = await client.GetAsync("/api/recruiter");
            // Assert
            response.EnsureSuccessStatusCode();

            var matchResponse = await response.Content.ReadFromJsonAsync<IEnumerable<RecruiterDTO>>();
            Assert.IsNotNull(matchResponse);
            Assert.IsTrue(matchResponse.Count() > 0);
        }

        [TestMethod()]
        [DataRow(1, true)]
        [DataRow(9, true)]
        [DataRow(11, false)]
        public async Task GetRecruiterByIdAsyncTest(int Id, bool shouldExist)
        {
            // Arrange
            var app = new GetJobHelpelWebApplicationTests();
            var client = app.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/recruiter/Id?Id={Id}");
            // Assert
            if(shouldExist)
            {
                response.EnsureSuccessStatusCode();

                var matchResponse = await response.Content.ReadFromJsonAsync<RecruiterDTO>();
                Assert.IsNotNull(matchResponse);
                Assert.AreEqual(matchResponse.Id, Id);
            }
            else
            {
                Assert.IsFalse(response.IsSuccessStatusCode);
            }
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public async Task CreateRecruiterTest(int TryAdd)
        {
            // Arrange
            var testRecruiterDto = new RecruiterDTO { Id = 999, Link = "testLink", Name = "TestName" };
            HttpResponseMessage response = new HttpResponseMessage();
            
            var app = new GetJobHelpelWebApplicationTests();
            var client = app.CreateClient();
            
            // Act
            for (int i = 0; i < TryAdd; i++)
            {
                response = await client.PostAsJsonAsync("/api/recruiter", testRecruiterDto);
            }
            // Assert
            if (TryAdd == 1)
            {
                Assert.IsTrue(response.IsSuccessStatusCode);
            }
            else
            {
                Assert.IsFalse(response.IsSuccessStatusCode);
            }
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public async Task UpdateRecruiterTest(int Id)
        {
            // Arrange
            var testRecruiterDto = new RecruiterDTO { Id = Id, Link = "testLink", Name = "TestName" };

            var app = new GetJobHelpelWebApplicationTests();
            var client = app.CreateClient();

            // Act
            var response = await client.PutAsJsonAsync($"/api/recruiter/Id?Id={Id}", testRecruiterDto);

            // Assert
            response.EnsureSuccessStatusCode();

            var checkExistence = await client.GetAsync($"/api/recruiter/Id?Id={Id}");
            checkExistence.EnsureSuccessStatusCode();
            var responseRecruiter = await checkExistence.Content.ReadFromJsonAsync<RecruiterDTO>();

            Assert.IsNotNull(responseRecruiter);
            Assert.AreEqual(responseRecruiter.Name, testRecruiterDto.Name);
            Assert.AreEqual(responseRecruiter.Link, testRecruiterDto.Link);
        }

        [TestMethod()]
        [DataRow(1, false)]
        [DataRow(2, false)]
        [DataRow(11, true)]
        public async Task DeleteRecruiterTest(int Id, bool ShouldntExist)
        {
            // Arrange
            var app = new GetJobHelpelWebApplicationTests();
            var client = app.CreateClient();

            // Act
            var response = await client.DeleteAsync($"/api/recruiter/Id?Id={Id}");
            // Assert

            
            if (response.IsSuccessStatusCode)
            {
                var checkExistence = await client.GetAsync($"/api/recruiter/Id?Id={Id}");
                Assert.IsFalse(checkExistence.IsSuccessStatusCode);
            }
            else
            {
                if(ShouldntExist == true)
                {
                    var checkExistence = await client.GetAsync($"/api/recruiter/Id?Id={Id}");
                    Assert.IsFalse(checkExistence.IsSuccessStatusCode);
                }
                else
                {
                    var checkExistence = await client.GetAsync($"/api/recruiter/Id?Id={Id}");
                    Assert.IsFalse(checkExistence.IsSuccessStatusCode);
                }
            }
        }
    }
}