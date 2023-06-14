// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ChangeAnalysis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ChangeAnalysis.Tests.Scenario
{
    internal class ChangeAnalysisTests : ChangeAnalysisManagementTestBase
    {
        private DateTimeOffset _startTime;
        private DateTimeOffset _endTime;
        private long _totalSecondsInAWeek = 604800;

        public ChangeAnalysisTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _endTime = Recording.Now;
            _startTime = DateTimeOffset.FromUnixTimeSeconds(_endTime.ToUnixTimeSeconds() - _totalSecondsInAWeek);
        }

        [RecordedTest]
        public async Task GetChangesBySubscription()
        {
            var list = await DefaultSubscription.GetChangesBySubscriptionAsync(_startTime, _endTime).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDetectedChangeData(list.FirstOrDefault());
            Assert.AreEqual(list.FirstOrDefault().ResourceType, "Microsoft.ChangeAnalysis/changes");
        }

        [RecordedTest]
        public async Task GetChangesByResourceGroup()
        {
            var resourceGroup = await CreateResourceGroup();
            var list = await resourceGroup.GetChangesByResourceGroupAsync(_startTime, _endTime).ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [RecordedTest]
        public async Task GetChangesByTenants()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            var tenant = tenants.FirstOrDefault();

            var subscriptionChanges = await DefaultSubscription.GetChangesBySubscriptionAsync(_startTime, _endTime).ToEnumerableAsync();
            string changeId = subscriptionChanges.FirstOrDefault().Id.ToString();
            string resourceId = changeId.Substring(0, changeId.IndexOf("/providers/Microsoft.ChangeAnalysis/"));
            var list = await tenant.GetResourceChangesAsync(resourceId, _startTime, _endTime).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDetectedChangeData(list.FirstOrDefault());
            Assert.AreEqual(list.FirstOrDefault().ResourceType, "Microsoft.ChangeAnalysis/resourceChanges");
        }

        private void ValidateDetectedChangeData(DetectedChangeData detectedChange)
        {
            Assert.IsNotNull(detectedChange.Id);
            Assert.IsNotNull(detectedChange.Name);
        }
    }
}
