// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    public class StandbyPoolManagementTestBase : ManagementRecordedTestBase<StandbyPoolManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected GenericResourceCollection _genericResourceCollection { get; private set; }

        protected SubscriptionResource subscription { get; private set; }
        protected AzureLocation location { get; private set; }

        protected StandbyPoolManagementTestBase(bool isAsync, RecordedTestMode mode, AzureLocation location)
        : base(isAsync, mode)
        {
            this.location = location;
            IgnoreNetworkDependencyVersions();
        }

        protected StandbyPoolManagementTestBase(bool isAsync, AzureLocation location)
            : base(isAsync)
        {
            this.location = location;
            IgnoreNetworkDependencyVersions();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            _genericResourceCollection = Client.GetGenericResources();
            subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgName, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup, GenericResourceCollection _genericResourceCollection, AzureLocation location)
        {
            var vnetName = Recording.GenerateAssetName("testVNet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", "testSubnet-7301" },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }
    }
}
