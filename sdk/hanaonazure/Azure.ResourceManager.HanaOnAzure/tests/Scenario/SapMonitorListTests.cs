// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.HanaOnAzure.Tests.Scenario
{
    [TestFixture]
    public class SapMonitorListTests : HanaOnAzureManagementTestBase
    {
        public SapMonitorListTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            await CreateCommonClient();
        }

        [RecordedTest]
        [Ignore("https://learn.microsoft.com/en-us/azure/sap/large-instances/decommission-sap-hana")]
        public async Task List()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, "sapmon-rg", AzureLocation.WestUS2);
            string monitorName = Recording.GenerateAssetName("sapmon");
            await resourceGroup.GetSapMonitors().CreateOrUpdateAsync(WaitUntil.Completed, monitorName, new SapMonitorData(AzureLocation.WestUS2));

            SapMonitorResource found = null;
            await foreach (SapMonitorResource monitor in DefaultSubscription.GetSapMonitorsAsync())
            {
                if (monitor.Data.Name == monitorName)
                {
                    found = monitor;
                }
            }

            Assert.That(found, Is.Not.Null);
        }
    }
}
