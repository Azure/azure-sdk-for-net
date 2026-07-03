// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DomainServices.Tests
{
    public class DomainServicesManagementTestBase : ManagementRecordedTestBase<DomainServicesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public SubscriptionResource DefaultSubscription { get; private set; }
        public AzureLocation DefaultLocation => AzureLocation.WestUS2;
        public const string ResourceGroupNamePrefix = "domainservicesRG";
        protected string SubnetName => "aadds-subnet";

        protected DomainServicesManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
        }

        protected DomainServicesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreNetworkDependencyVersions();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        // Azure AD Domain Services must be deployed into a dedicated virtual-network subnet.
        // Create the network dependency in the same resource group and return the subnet id.
        protected async Task<ResourceIdentifier> CreateSubnetAsync(ResourceGroupResource resourceGroup)
        {
            var vnet = new VirtualNetworkData { Location = DefaultLocation };
            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.Subnets.Add(new SubnetData
            {
                Name = SubnetName,
                AddressPrefix = "10.0.0.0/24",
            });

            string vnetName = Recording.GenerateAssetName("dsvnet-");
            var vnetLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            return vnetLro.Value.Data.Subnets[0].Id;
        }
    }
}
