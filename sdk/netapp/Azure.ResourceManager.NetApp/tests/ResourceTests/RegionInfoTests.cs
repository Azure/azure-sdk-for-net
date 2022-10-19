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
    public class RegionInfoTests: NetAppTestBase
    {
        public RegionInfoTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
        }

        [Test]
        [Ignore("Ignore for now due to manifest issue, re-enable when manifest is fixed")]
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
