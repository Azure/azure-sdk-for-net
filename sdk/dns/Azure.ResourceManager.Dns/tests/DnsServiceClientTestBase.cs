// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Azure.Core;
using Azure.Identity;

namespace Azure.ResourceManager.Dns.Tests
{
    public abstract class DnsServiceClientTestBase : ManagementRecordedTestBase<DnsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string DefaultResourceGroupPrefix = "DnsRG";

        public DnsServiceClientTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        public async Task<DnsZoneResource> CreateDnsZone(string dnsZoneName, ResourceGroupResource rg)
        {
            DnsZoneCollection collection = rg.GetDnsZones();
            DnsZoneData data = new DnsZoneData("Global") { };
            var dns = await collection.CreateOrUpdateAsync(WaitUntil.Completed, dnsZoneName, data);
            return dns.Value;
        }
    }
}
