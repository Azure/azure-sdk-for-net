// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class Test1
    {
        [Test]
        public async Task TestDns()
        {
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
            string subscription = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");
            string rgName = "Dns-RG-0000";

            // Create ArmClient
            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            ArmClient armClient = new ArmClient(clientSecretCredential, subscription);

            // Create a resource group
            ResourceGroupCollection rgCollection = armClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups();
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.EastUS) { };
            var rgLro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            var resourceGroup = rgLro.Value;
            Assert.IsNotNull(resourceGroup);
            Assert.AreEqual(rgName, resourceGroup.Data.Name);

            DnsZoneCollection collection = resourceGroup.GetDnsZones();
            string zoneName = "dns20220402.com";
            DnsZoneData data = new DnsZoneData("Global")
            {
            };
            var dns = await collection.CreateOrUpdateAsync(WaitUntil.Completed, zoneName, data);

            RecordSetAaaaCollection aaaa = dns.Value.GetRecordSetAaaas();
            await aaaa.CreateOrUpdateAsync(WaitUntil.Completed,"newaaaa",new AaaaRecordSetData() { });
            //var dns2 = await collection.GetAsync("dns20220407.com");
        }
    }
}
