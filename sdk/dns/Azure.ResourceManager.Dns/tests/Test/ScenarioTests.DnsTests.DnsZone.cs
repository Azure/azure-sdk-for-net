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
            : base(true, "Default-Zones-")
        {
            location = "East US";
            defaultZoneName = "azure.ameredmond.dns";
        }


        [TestCase]
        public async Task DnsCreateZoneDeleteAndUpdate()
        {
            var namespaceName = Recording.GenerateAssetName("sdk-RecordSet");
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            response = await this.DnsManagementClient.Zones.GetAsync(this.defaultResourceGroup, defaultZoneName);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            aZone = response.Value;
            aZone.Tags.Clear();
            aZone.Tags.Add("key1", "new_tag_1");
            aZone.Tags.Add("key2", "val2");
            response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, this.defaultZoneName, aZone);
            Assert.IsTrue(Helper.AreEqual(response, aZone, ignoreEtag: true));
            var delResponse = await this.WaitForCompletionAsync(await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, this.defaultZoneName));
            Assert.AreEqual(delResponse.Value.Status, 200);
        }

        [TestCase]
        public async Task DnsListZone()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameTwo, aZone);

            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 1);
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
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameTwo);
        }

        [TestCase]
        public async Task DnsListZonesInSubscription()
        {
            string zoneNameOne = "dns.zoneonename.io";
            string zoneNameTwo = "dns.zonetwoname.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameOne, aZone);

            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameTwo, aZone);
            await Helper.TryRegisterResourceGroupAsync(this.ResourcesManagementClient.ResourceGroups, this.location, this.defaultResourceGroup + "-Two");
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
            await this.ResourcesManagementClient.ResourceGroups.StartDeleteAsync(this.defaultResourceGroup + "-Two");
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameTwo);
        }

        [TestCase]
        public async Task DnsListZonesWithTopParameter()
        {
            string zoneNameOne = "dns.zoneonenametop.io";
            string zoneNameTwo = "dns.zonetwonametop.io";
            string zoneNameThree = "dns.zonethreenametop.io";
            var aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameOne, aZone);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameTwo, aZone);
            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 1);
            var it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 1);
            aZone = new Zone("Global");
            await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, zoneNameThree, aZone);
            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 2);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.AreEqual(it.Current.Values.Count, 2);
            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 10);
            it = response.AsPages().GetAsyncEnumerator();
            await it.MoveNextAsync();
            Assert.IsTrue(it.Current.Values.Count >= 3);

            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameOne);
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameTwo);
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, zoneNameThree);
        }

        [TestCase]
        public void DnsListZonesWithTopParameterExtremeParams()
        {
            var response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 0);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, -1);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());

            response = this.DnsManagementClient.Zones.ListByResourceGroupAsync(this.defaultResourceGroup, 1000000);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await response.AsPages().GetAsyncEnumerator().MoveNextAsync());
        }

        [TestCase]
        public async Task DnsUpdateZonePreconditionFailed()
        {
            var aZone = new Zone("Global");
            aZone.Tags.Add("key1", "value1");
            var response = await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, this.defaultZoneName, aZone);
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await this.DnsManagementClient.Zones.CreateOrUpdateAsync(this.defaultResourceGroup, this.defaultZoneName, response, "somegibberish", null));
            await this.DnsManagementClient.Zones.StartDeleteAsync(this.defaultResourceGroup, this.defaultZoneName);

        }

        [TestCase]
        public void GetNonExistingZoneFailsAsExpected()
        {
            Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await this.DnsManagementClient.Zones.GetAsync(this.defaultResourceGroup, "somegibberish"));
        }
    }
}