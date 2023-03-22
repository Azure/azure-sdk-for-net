// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Network;
using NUnit.Framework;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverTestBase : ManagementRecordedTestBase<DnsResolverManagementTestEnvironment>
    {
        protected string SubnetName => "snet-endpoint";
        public string DefaultVnetID;
        public string DefaultSubnetID;
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

        protected async Task CreateVirtualNetworkAsync()
        {
            var vnet = new VirtualNetworkData()
            {
                Location = AzureLocation.AustraliaEast,
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
            var resourceGroup = await CreateResourceGroupAsync();
            var vnetName = Recording.GenerateAssetName("dnsResolver-");

            var virtualNetworks = resourceGroup.GetVirtualNetworks();
            //await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, vnet);
            ResourceIdentifier vnetID;
            ResourceIdentifier subnetID;
            if (Mode == RecordedTestMode.Playback)
            {
                subnetID = SubnetResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName, SubnetName);
                vnetID = VirtualNetworkResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var vnetResource = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
                    var subnetCollection = vnetResource.Value.GetSubnets();
                    //SubnetResource subnetResource = (await subnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, subnetName2, subnetData)).Value;
                    vnetID = vnetResource.Value.Data.Id;
                    subnetID = vnetResource.Value.Data.Subnets[0].Id;
                }
            }
            DefaultVnetID = vnetID;
            DefaultSubnetID = subnetID;
        }
    }
}
