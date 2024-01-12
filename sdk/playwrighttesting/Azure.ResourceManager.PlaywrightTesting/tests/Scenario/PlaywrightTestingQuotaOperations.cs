// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        private QuotumCollection _quotaCollection { get; set; }
        private QuotumResource _quotaResource { get; set; }
        private QuotumData _quotaData { get; set; }

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
            _quotaCollection = subscription.GetQuota(ResourceHelper.RESOURCE_LOCATION);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task QuotaOperationTests()
        {
            //GET API
            Response<QuotumResource> getResponse = await _quotaCollection.GetAsync(QuotaName.ScalableExecution);
            Assert.NotNull(getResponse);
            Assert.IsNotNull(getResponse.Value);
            Assert.IsNotNull(getResponse.Value.Data);
            Assert.IsNotNull(getResponse.Value.Data.Name);
            Assert.AreEqual(QuotaName.ScalableExecution.ToString(), getResponse.Value.Data.Name);
            Assert.IsNotNull(getResponse.Value.Data.FreeTrial);
            Assert.IsNotNull(getResponse.Value.Data.FreeTrial.AccountId);

            //List API
            List<QuotumResource> listResponse = await _quotaCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(listResponse);
            foreach (QuotumResource resource in listResponse)
            {
                Assert.IsTrue(resource.HasData);
                Assert.IsNotNull(resource.Data);
                Assert.IsNotNull(resource.Data.Name);
                Assert.IsNotNull(resource.Data.Id);
                Assert.IsNotNull(resource.Data.FreeTrial);
                Assert.IsNotNull(resource.Data.FreeTrial.AccountId);
            }
        }
    }
}
