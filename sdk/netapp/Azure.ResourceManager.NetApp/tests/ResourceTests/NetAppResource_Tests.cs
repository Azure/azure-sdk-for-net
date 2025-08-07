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
    public class NetAppResource_Tests: NetAppTestBase
    {
        public NetAppResource_Tests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
        }

        [RecordedTest]
        public async Task CheckQuotaAvailability()
        {
            NetAppQuotaAvailabilityContent quotaAvailabilityContent = new("account1", NetAppQuotaAvailabilityResourceType.MicrosoftNetAppNetAppAccounts, _resourceGroup.Id.Name);
            Response<NetAppCheckAvailabilityResult> checkQuotaResult = await DefaultSubscription.CheckNetAppQuotaAvailabilityAsync(DefaultLocation, quotaAvailabilityContent);
            Assert.IsNotNull(checkQuotaResult);
            Assert.True(checkQuotaResult.Value.IsAvailable);
        }

        [RecordedTest]
        public async Task GetQuotaLimit()
        {
            Response<NetAppSubscriptionQuotaItem> quotaLimitsResponse = await DefaultSubscription.GetNetAppQuotaLimitAsync(DefaultLocation, "totalVolumesPerSubscription");
            Assert.IsNotNull(quotaLimitsResponse);
        }

        [RecordedTest]
        public async Task ListQuotaLimits()
        {
            AsyncPageable<NetAppSubscriptionQuotaItem> quotaLimitsResponse = DefaultSubscription.GetNetAppQuotaLimitsAsync(DefaultLocation);
            Assert.IsNotNull(quotaLimitsResponse);
            List<NetAppSubscriptionQuotaItem> qutoaItemlist = await quotaLimitsResponse.ToListAsync();
            Assert.IsNotEmpty(qutoaItemlist);
        }

        [RecordedTest]
        public async Task QueryRegionInfoTest()
        {
            Response<NetAppRegionInfo> regionInfo = await DefaultSubscription.QueryRegionInfoNetAppResourceAsync(DefaultLocation);
            Assert.IsNotNull(regionInfo);
            Assert.IsNotNull(regionInfo.Value.StorageToNetworkProximity);
            Assert.IsNotNull(regionInfo.Value.AvailabilityZoneMappings);
        }
    }
}
