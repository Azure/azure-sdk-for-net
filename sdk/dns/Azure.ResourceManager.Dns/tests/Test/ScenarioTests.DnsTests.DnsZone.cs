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
        private string defaultZoneName;

        public ScenarioTestsZones()
            : base(true)
        {
            resourceGroup = null;
            location = "West US";
            defaultZoneName = "azure.ameredmond.dns";
        }


        [TestCase]
        public async Task DnsCreateZoneDeleteAndUpdate()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            response = await this.DnsManagementClient.Zones.GetAsync(resourceGroup, defaultZoneName);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            aZone = response.Value;
            aZone.Tags.Clear();
            aZone.Tags.Add("key1", "new_tag_1");
            aZone.Tags.Add("key2", "val2");
            response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            var delResponse = await this.WaitForCompletionAsync(await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, this.defaultZoneName));
            Assert.AreEqual(delResponse.Value.Status, 200);
        }

        [TestCase]
        public async Task DnsListZone()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);

            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 1);
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
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameTwo);
        }

        [TestCase]
        public async Task DnsListZonesInSubscription()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);

            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);
            await Helper.TryRegisterResourceGroupAsync(this.ResourcesManagementClient.ResourceGroups, this.location, this.resourceGroup + "-Two");
            var response = this.DnsManagementClient.Zones.ListAsync();
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
            await this.ResourcesManagementClient.ResourceGroups.StartDeleteAsync(this.resourceGroup + "-Two");
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameTwo);
        }

        [TestCase]
        public async Task DnsListZonesWithTopParameter()
        {
            string zoneNameOne = "dns.zoneonenametop.io";
            string zoneNameTwo = "dns.zonetwonametop.io";
            string zoneNameThree = "dns.zonethreenametop.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameTwo, aZone);
            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 1);
            var it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 1);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, zoneNameThree, aZone);
            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 2);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 2);
            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 10);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.IsTrue(it.Current.Values.Count >= 3);

            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameTwo);
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, zoneNameThree);
        }

        [TestCase]
        public void DnsListZonesWithTopParameterExtremeParams()
        {
            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 0);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, -1);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(resourceGroup, 1000000);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());
        }

        [TestCase]
        public async Task DnsUpdateZonePreconditionFailed()
        {
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, aZone);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await this.DnsManagementClient.Zones.CreateOrUpdateAsync(resourceGroup, this.defaultZoneName, response, "somegibberish", null));
            await this.DnsManagementClient.Zones.StartDeleteAsync(resourceGroup, this.defaultZoneName);

        }

        [TestCase]
        public void GetNonExistingZoneFailsAsExpected()
        {
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await this.DnsManagementClient.Zones.GetAsync(resourceGroup, "somegibberish"));
        }
    }
}