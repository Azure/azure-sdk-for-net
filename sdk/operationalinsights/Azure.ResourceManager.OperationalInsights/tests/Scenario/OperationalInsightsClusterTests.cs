// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests.Scenario
{
    public class OperationalInsightsClusterTests : OperationalInsightsManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public OperationalInsightsClusterTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        public async Task RemovingKeyVaultPropertiesTest()
        {
            string clusterName = "sdkcluser";
            var clusterData = new OperationalInsightsClusterData(_resourceGroup.Data.Location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Sku = new OperationalInsightsClusterSku()
                {
                    Name = OperationalInsightsClusterSkuName.CapacityReservation,
                    Capacity = OperationalInsightsClusterCapacity.TenHundred,
                },
                KeyVaultProperties = new OperationalInsightsKeyVaultProperties()
                {
                    KeyVaultUri = new Uri("", UriKind.Relative),
                    KeyName = "",
                    KeyVersion = "",
                }
            };
            var cluster = (await _resourceGroup.GetOperationalInsightsClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData)).Value;
            Assert.IsTrue(cluster.Data.KeyVaultProperties.KeyVaultUri.ToString().Equals(""));
        }
    }
}
