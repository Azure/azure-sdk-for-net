// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SubscriptionApplicationTests : SecurityCenterManagementTestBase
    {
        private SubscriptionSecurityApplicationCollection _subAppCollection => DefaultSubscription.GetSubscriptionSecurityApplications();
        public SubscriptionApplicationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _subAppCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SubscriptionSecurityApplicationResource> CreateSubscriptionApplicationResource(string applicationId)
        {
            SecurityApplicationData data = new SecurityApplicationData()
            {
                DisplayName = "GCP Admin's application",
                Description = "An application on critical GCP recommendations",
                SourceResourceType = ApplicationSourceResourceType.Assessments,
                ConditionSets =
                {
                    new BinaryData("{\"conditions\":[{\"property\":\"$.Id\",\"value\":\"-prod-\",\"operator\":\"contains\"}]}")
                }
            };
            var subapp = await _subAppCollection.CreateOrUpdateAsync(WaitUntil.Completed, applicationId, data);
            return subapp.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var applicationId = Recording.Random.NewGuid().ToString();
            var subapp = await CreateSubscriptionApplicationResource(applicationId);
            ValidateSubscriptionApplication(subapp, applicationId);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var applicationId = Recording.Random.NewGuid().ToString();
            var subapp = await CreateSubscriptionApplicationResource(applicationId);
            bool flag = await _subAppCollection.ExistsAsync(applicationId);
            Assert.That(flag, Is.True);
        }

        [RecordedTest]
        public async Task Get()
        {
            var applicationId = Recording.Random.NewGuid().ToString();
            await CreateSubscriptionApplicationResource(applicationId);
            var subapp = await _subAppCollection.GetAsync(applicationId);
            ValidateSubscriptionApplication(subapp, applicationId);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var applicationId = Recording.Random.NewGuid().ToString();
            await CreateSubscriptionApplicationResource(applicationId);
            var list = await _subAppCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            ValidateSubscriptionApplication(list.First(item => item.Data.Name == applicationId), applicationId);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var applicationId = Recording.Random.NewGuid().ToString();
            var subapp = await CreateSubscriptionApplicationResource(applicationId);
            bool flag = await _subAppCollection.ExistsAsync(applicationId);
            Assert.That(flag, Is.True);

            await subapp.DeleteAsync(WaitUntil.Completed);
            flag = await _subAppCollection.ExistsAsync(applicationId);
            Assert.That(flag, Is.False);
        }

        private void ValidateSubscriptionApplication(SubscriptionSecurityApplicationResource subApp, string applicationId)
        {
            Assert.That(subApp, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(subApp.Data.Id, Is.Not.Null);
                Assert.That(subApp.Data.Name, Is.EqualTo(applicationId));
                Assert.That(subApp.Data.SourceResourceType, Is.EqualTo(ApplicationSourceResourceType.Assessments));
                Assert.That(subApp.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/applications"));
                Assert.That(subApp.Data.DisplayName, Is.EqualTo("GCP Admin's application"));
                Assert.That(subApp.Data.Description, Is.EqualTo("An application on critical GCP recommendations"));
            });
        }
    }
}
