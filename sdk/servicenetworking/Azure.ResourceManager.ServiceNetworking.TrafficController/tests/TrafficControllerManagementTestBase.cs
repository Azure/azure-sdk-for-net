// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Castle.Core.Resource;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ServiceNetworking.TrafficController.Tests
{
    public class TrafficControllerManagementTestBase : ManagementRecordedTestBase<TrafficControllerManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected TrafficControllerManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected TrafficControllerManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }
        public Resources.SubscriptionResource Subscription
        {
            get
            {
                return Client.GetDefaultSubscription();
            }
        }

        public Resources.ResourceGroupResource ResourceGroup
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public Resources.ResourceGroupResource GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().Get(name).Value;
        }

        protected TrafficControllerCollection GetTrafficControllers(string resourceGroupName)
        {
            return GetTrafficControllerCollection(resourceGroupName);
        }

        protected FrontendCollection GetFrontends(TrafficControllerResource trafficController)
        {
            return trafficController.GetFrontends();
        }

        protected AssociationCollection GetAssociations(TrafficControllerResource trafficController)
        {
            return trafficController.GetAssociations();
        }

        protected VirtualNetworkCollection GetVirtualNetworks(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetVirtualNetworks();
        }

        protected ResourceGroupResource CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            var rgResourceTask = CreateResourceGroupAsync(Subscription, rgNamePrefix, location);
            rgResourceTask.Wait();
            var rgResource = rgResourceTask.Result;
            Assert.NotNull(rgResource, "Resource Group not created successfully");  //TODO: Validate that this won't be an issue (name reused)
            return rgResource;
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected TrafficControllerCollection GetTrafficControllerCollection(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetTrafficControllers();
        }
    }
}
