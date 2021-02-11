// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Dns.Tests;

namespace Azure.Management.Dns.Tests
{
    [TestFixture]
    public class ScenarioTestsZones : DnsManagementClientBase
    {
        private string location;
        private string resourceGroup;
        private string defaultZoneName;
        private bool setupRun = false;

        public ScenarioTestsZones()
            : base(true)
        {
            resourceGroup = null;
            location = "West US";
            defaultZoneName = "azure.ameredmond.dns";
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
            {
                InitializeClients();
                this.resourceGroup = Recording.GenerateAssetName("Default-Dns-Zones-");
                await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, this.location, this.resourceGroup);
                setupRun = true;
            }
            else if (setupRun)
            {
                initNewRecord();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task DnsCreateZoneDeleteAndUpdate()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await ZonesOperations.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            response = await ZonesOperations.GetAsync(resourceGroup, defaultZoneName);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            aZone = response.Value;
            aZone.Tags.Clear();
            aZone.Tags.Add("key1", "new_tag_1");
            aZone.Tags.Add("key2", "val2");
            response = await ZonesOperations.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            var delResponse = await this.WaitForCompletionAsync(await ZonesOperations.StartDeleteAsync(resourceGroup, this.defaultZoneName));
            Assert.AreEqual(delResponse.Value.Status, 200);
        }

        [TestCase]
        public async Task DnsListZone()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);

            var response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 1);
            var totalList = await response.ToEnumerableAsync();
            var zoneOneFound = false;
            var zoneTwoFound = false;
            foreach (var zone in totalList)
            {
                if (zone.Name == zoneNameOne)
                {
                    zoneOneFound = true;
                }
                else if (zone.Name == zoneNameTwo)
                {
                    zoneTwoFound = true;
                }
            }
            Assert.IsTrue(zoneOneFound && zoneTwoFound);
            await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameOne);
            await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameTwo);
        }

        [TestCase]
        public async Task DnsListZonesInSubscription()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);

            aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, this.location, this.resourceGroup + "-Two");
            var response = ZonesOperations.ListAsync();
            var totalList = response.ToEnumerableAsync().Result;
            var zoneOneFound = false;
            var zoneTwoFound = false;
            foreach (var zone in totalList)
            {
                if (zone.Name == zoneNameOne)
                {
                    zoneOneFound = true;
                }
                else if (zone.Name == zoneNameTwo)
                {
                    zoneTwoFound = true;
                }
            }
            Assert.IsTrue(zoneOneFound && zoneTwoFound);
            await ResourceGroupsOperations.StartDeleteAsync(this.resourceGroup + "-Two");
            await this.WaitForCompletionAsync(await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameOne));
        }

        [TestCase]
        public async Task DnsListZonesWithTopParameter()
        {
            string zoneNameOne = "dns.zoneonenametop.io";
            string zoneNameTwo = "dns.zonetwonametop.io";
            string zoneNameThree = "dns.zonethreenametop.io";
            var aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);
            var response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 1);
            var it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 1);
            aZone = new Zone("Global");
            await ZonesOperations.CreateOrUpdateAsync(resourceGroup, zoneNameThree, aZone);
            response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 2);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 2);
            response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 10);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.IsTrue(it.Current.Values.Count >= 3);

            await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameOne);
            await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameTwo);
            await ZonesOperations.StartDeleteAsync(resourceGroup, zoneNameThree);
        }

        [TestCase]
        public void DnsListZonesWithTopParameterExtremeParams()
        {
            var response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 0);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, -1);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = ZonesOperations.ListByResourceGroupAsync(resourceGroup, 1000000);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());
        }

        [TestCase]
        public async Task DnsUpdateZonePreconditionFailed()
        {
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await ZonesOperations.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await ZonesOperations.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, response, "somegibberish", null));
            await ZonesOperations.StartDeleteAsync(resourceGroup, this.defaultZoneName);
        }

        [TestCase]
        public void GetNonExistingZoneFailsAsExpected()
        {
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await ZonesOperations.GetAsync(resourceGroup, "somegibberish"));
        }
    }
}
