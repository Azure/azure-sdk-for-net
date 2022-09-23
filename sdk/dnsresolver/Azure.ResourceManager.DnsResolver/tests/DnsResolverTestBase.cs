// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Network;
using NUnit.Framework;

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
