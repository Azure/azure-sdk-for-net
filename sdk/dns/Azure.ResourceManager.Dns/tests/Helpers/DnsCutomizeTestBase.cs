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

namespace Azure.ResourceManager.Dns.Tests.Helpers
{
    internal class DnsCutomizeTestBase
    {
        public async Task<ResourceGroupResource> CreateAResourceGroup(string rgName)
        {
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
            string subscription = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");
            // Create ArmClient
            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            ArmClient armClient = new ArmClient(clientSecretCredential, subscription);

            // Create a resource group
            ResourceGroupCollection rgCollection = armClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups();
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.EastUS) { };
            var rgLro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            return rgLro.Value;
        }

        public async Task<DnsZoneResource> CreateADnsZone(ResourceGroupResource rg)
        {
            string dnsZoneName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.Mx.com";
            DnsZoneCollection collection = rg.GetDnsZones();
            DnsZoneData data = new DnsZoneData("Global")
            {
            };
            var dns = await collection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
            return dns.Value;
        }

        public string GenerateAssetName(string prefix)
        {
            Random random = new Random();
            return prefix + random.Next(9999);
        }
    }
}
