// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests.Scenario
{
    public class OperationalInsightsClusterTests : OperationalInsightsManagementTestBase
    {
        public OperationalInsightsClusterTests(bool isAsync) : base(isAsync, Core.TestFramework.RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task Put()
        {
            var rg = await CreateResourceGroup();
            var resourceName = Recording.GenerateAssetName("sdktest");
            var data = new OperationalInsightsClusterData(AzureLocation.EastUS)
            {
                Sku = new OperationalInsightsClusterSku()
                {
                    Capacity = OperationalInsightsClusterCapacity.TenHundred,
                    Name = OperationalInsightsClusterSkuName.CapacityReservation,
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            var resource = (await rg.GetOperationalInsightsClusters().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data)).Value;
            Assert.AreEqual(resource.Data.Name, resourceName);
        }
    }
}
