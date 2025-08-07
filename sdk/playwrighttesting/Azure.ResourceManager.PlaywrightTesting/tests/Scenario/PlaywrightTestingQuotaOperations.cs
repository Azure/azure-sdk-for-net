// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PlaywrightTesting.Models;
using Azure.ResourceManager.PlaywrightTesting.Tests.Helper;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PlaywrightTesting.Tests.Scenario
{
    public class PlaywrightTestingQuotaOperations : PlaywrightTestingManagementTestBase
    {
        private PlaywrightTestingQuotaCollection _quotaCollection { get; set; }
        private PlaywrightTestingQuotaResource _quotaResource { get; set; }
        private PlaywrightTestingQuotaData _quotaData { get; set; }

        public PlaywrightTestingQuotaOperations(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            _quotaCollection = subscription.GetAllPlaywrightTestingQuota(ResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaOperationTestsScalable()
        {
            //GET API
            Response<PlaywrightTestingQuotaResource> getResponse = await _quotaCollection.GetAsync(PlaywrightTestingQuotaName.ScalableExecution);
            Assert.NotNull(getResponse);
            Assert.IsNotNull(getResponse.Value);
            Assert.IsNotNull(getResponse.Value.Data);
            Assert.IsNotNull(getResponse.Value.Data.Name);
            Assert.IsNotNull(getResponse.Value.Data.Properties);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, getResponse.Value.Data.Properties.ProvisioningState);
            Assert.IsNotNull(getResponse.Value.Data.Properties.FreeTrial);
            Assert.IsNotNull(getResponse.Value.Data.Properties.FreeTrial.AccountId);
            Assert.AreEqual(PlaywrightTestingQuotaName.ScalableExecution.ToString(), getResponse.Value.Data.Name);

            //List API
            List<PlaywrightTestingQuotaResource> listResponse = await _quotaCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listResponse);
            foreach (PlaywrightTestingQuotaResource resource in listResponse)
            {
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data);
                Assert.IsNotNull(resource.Data.Name);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.Properties.FreeTrial);
                Assert.IsNotNull(resource.Data.Properties.FreeTrial.AccountId);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaOperationTestsReporting()
        {
            //GET API
            Response<PlaywrightTestingQuotaResource> getResponseReporting = await _quotaCollection.GetAsync(PlaywrightTestingQuotaName.Reporting);
            Assert.NotNull(getResponseReporting);
            Assert.IsNotNull(getResponseReporting.Value);
            Assert.IsNotNull(getResponseReporting.Value.Data);
            Assert.IsNotNull(getResponseReporting.Value.Data.Name);
            Assert.AreEqual(PlaywrightTestingQuotaName.Reporting.ToString(), getResponseReporting.Value.Data.Name);
            Assert.IsNotNull(getResponseReporting.Value.Data.Properties);
            Assert.AreEqual(PlaywrightTestingProvisioningState.Succeeded, getResponseReporting.Value.Data.Properties.ProvisioningState);
            Assert.IsNotNull(getResponseReporting.Value.Data.Properties.FreeTrial);
            Assert.IsNotNull(getResponseReporting.Value.Data.Properties.FreeTrial.AccountId);
        }
    }
}
