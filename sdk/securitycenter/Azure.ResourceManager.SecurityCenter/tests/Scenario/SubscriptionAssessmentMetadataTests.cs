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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidateSubscriptionAssessmentMetadata(list.First(item => item.Data.Name == assessmentMetadataName), assessmentMetadataName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var assessmentMetadataName = Recording.Random.NewGuid().ToString();
            var subAssessmentMetadata = await CreateSubscriptionAssessmentMetadata(assessmentMetadataName);
            bool flag = await _subAssessmentMetadataCollection.ExistsAsync(assessmentMetadataName);
            Assert.That(flag, Is.True);

            await subAssessmentMetadata.DeleteAsync(WaitUntil.Completed);
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(20000);
            }
            flag = await _subAssessmentMetadataCollection.ExistsAsync(assessmentMetadataName);
            Assert.That(flag, Is.False);
        }

        private void ValidateSubscriptionAssessmentMetadata(SubscriptionAssessmentMetadataResource subAssessmentMetadata, string assessmentMetadataName)
        {
            Assert.That(subAssessmentMetadata, Is.Not.Null);
            Assert.That(subAssessmentMetadata.Data.Id, Is.Not.Null);
            Assert.That(subAssessmentMetadata.Data.Name, Is.EqualTo(assessmentMetadataName));
            Assert.That(subAssessmentMetadata.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Security/assessmentMetadata"));
            Assert.That(subAssessmentMetadata.Data.DisplayName, Is.EqualTo("JustForTest"));
            Assert.That(subAssessmentMetadata.Data.Severity, Is.EqualTo(SecurityAssessmentSeverity.Medium));
            Assert.That(subAssessmentMetadata.Data.UserImpact, Is.EqualTo(SecurityAssessmentUserImpact.Low));
            Assert.That(subAssessmentMetadata.Data.ImplementationEffort, Is.EqualTo(ImplementationEffort.Low));
            Assert.That(subAssessmentMetadata.Data.AssessmentType, Is.EqualTo(SecurityAssessmentType.CustomerManaged));
        }
    }
}
