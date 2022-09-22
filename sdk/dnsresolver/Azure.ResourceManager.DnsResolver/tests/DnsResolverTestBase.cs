// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DnsResolver.Tests;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverTestBase : ManagementRecordedTestBase<DnsResolverManagementTestEnvironment>
    {
        protected string SubnetName => "snet-endpoint";

        protected AzureLocation DefaultLocation => AzureLocation.AustraliaEast;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public DnsResolverTestBase(bool isAsync) : base(isAsync)
        {
        }

        public DnsResolverTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }

        protected async Task CreateVirtualNetworkAsync(string virtualNetworkName)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = TestEnvironment.Location,
                Subnets = {
                    new SubnetData()
                    {
                        Name = SubnetName,
                        AddressPrefix = "10.2.2.0/28",
                    }
                }
            };

            vnet.AddressPrefixes.Add("10.0.0.0/8");

            var subscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SubscriptionId);
            var resourceGroup = await subscription.Value.GetResourceGroups().GetAsync(TestEnvironment.ResourceGroup);

            var virtualNetworks = resourceGroup.Value.GetVirtualNetworks();
            await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, vnet);
        }
    }
}
