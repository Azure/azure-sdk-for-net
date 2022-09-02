// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.NetApp.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ResourceAvailabilityTests: NetAppTestBase
    {
        public ResourceAvailabilityTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CheckQuotaAvailability()
        {
            QuotaAvailabilityContent quotaAvailabilityContent = new("account1", CheckQuotaNameResourceTypes.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name);
            Response<CheckAvailabilityResponse> checkQuotaResult = await DefaultSubscription.CheckQuotaAvailabilityNetAppResourceAsync(DefaultLocation, quotaAvailabilityContent);
            Assert.IsNotNull(checkQuotaResult);
            Assert.True(checkQuotaResult.Value.IsAvailable);
        }

        [Test]
        [RecordedTest]
        public async Task GetQuotaLimit()
        {
            Response<SubscriptionQuotaItemResource> quotaLimitsResponse = await DefaultSubscription.GetSubscriptionQuotaItemAsync(DefaultLocation, "totalVolumesPerSubscription");
            Assert.IsNotNull(quotaLimitsResponse);
        }

        [Test]
        [RecordedTest]
        public async Task ListQuotaLimits()
        {
            SubscriptionQuotaItemCollection quotaLimitsCollection = DefaultSubscription.GetSubscriptionQuotaItems(DefaultLocation);
            List<SubscriptionQuotaItemResource> quotaLimitsResponse = await quotaLimitsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(quotaLimitsResponse);
            Assert.IsNotEmpty(quotaLimitsResponse);
        }
    }
}
