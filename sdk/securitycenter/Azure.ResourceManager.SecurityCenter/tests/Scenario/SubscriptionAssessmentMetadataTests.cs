// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SubscriptionAssessmentMetadataTests : SecurityCenterManagementTestBase
    {
        private SubscriptionAssessmentMetadataCollection _subAssessmentMetadataCollection => DefaultSubscription.GetAllSubscriptionAssessmentMetadata();

        public SubscriptionAssessmentMetadataTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
            JsonPathSanitizers.Add("$..description");
            JsonPathSanitizers.Add("$..remediationDescription");
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var allAssessmentMetadata = await _subAssessmentMetadataCollection.GetAllAsync().ToEnumerableAsync();
            var list = allAssessmentMetadata.Where(item => item.Data.Description == "JustForTest");
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SubscriptionAssessmentMetadataResource> CreateSubscriptionAssessmentMetadata(string assessmentMetadataName)
        {
            var data = new SecurityAssessmentMetadataData()
            {
                DisplayName = "JustForTest",
                Description = "JustForTest",
                RemediationDescription = "JustForTest",
                Categories = { SecurityAssessmentResourceCategory.Compute },
                Severity = SecurityAssessmentSeverity.Medium,
                UserImpact = SecurityAssessmentUserImpact.Low,
                ImplementationEffort = ImplementationEffort.Low,
                Threats =
                {
                    SecurityThreat.DataExfiltration,
                    SecurityThreat.DataSpillage,
                    SecurityThreat.MaliciousInsider
                },
                AssessmentType = SecurityAssessmentType.CustomerManaged
            };
            var subAssessmentMetadata = await _subAssessmentMetadataCollection.CreateOrUpdateAsync(WaitUntil.Completed, assessmentMetadataName, data);
            return subAssessmentMetadata.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            var subAssessmentMetadata = await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            ValidateSubscriptionAssessmentMetadata(subAssessmentMetadata, assessmentMetadataName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            bool flag = await _subAssessmentMetadataCollection.ExistsAsync(assessmentMetadataName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            var subAssessmentMetadata = await _subAssessmentMetadataCollection.GetAsync(assessmentMetadataName);
            ValidateSubscriptionAssessmentMetadata(subAssessmentMetadata, assessmentMetadataName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            var list = await _subAssessmentMetadataCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSubscriptionAssessmentMetadata(list.First(item => item.Data.Name == assessmentMetadataName), assessmentMetadataName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            var subAssessmentMetadata = await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            bool flag = await _subAssessmentMetadataCollection.ExistsAsync(assessmentMetadataName);
            Assert.IsTrue(flag);

            await subAssessmentMetadata.DeleteAsync(WaitUntil.Completed);
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(20000);
            }
            flag = await _subAssessmentMetadataCollection.ExistsAsync(assessmentMetadataName);
            Assert.IsFalse(flag);
        }

        private void ValidateSubscriptionAssessmentMetadata(SubscriptionAssessmentMetadataResource subAssessmentMetadata, string assessmentMetadataName)
        {
            Assert.IsNotNull(subAssessmentMetadata);
            Assert.IsNotNull(subAssessmentMetadata.Data.Id);
            Assert.AreEqual(assessmentMetadataName, subAssessmentMetadata.Data.Name);
            Assert.AreEqual("Microsoft.Security/assessmentMetadata", subAssessmentMetadata.Data.ResourceType.ToString());
            Assert.AreEqual("JustForTest", subAssessmentMetadata.Data.DisplayName);
            Assert.AreEqual(SecurityAssessmentSeverity.Medium, subAssessmentMetadata.Data.Severity);
            Assert.AreEqual(SecurityAssessmentUserImpact.Low, subAssessmentMetadata.Data.UserImpact);
            Assert.AreEqual(ImplementationEffort.Low, subAssessmentMetadata.Data.ImplementationEffort);
            Assert.AreEqual(SecurityAssessmentType.CustomerManaged, subAssessmentMetadata.Data.AssessmentType);
        }
    }
}
