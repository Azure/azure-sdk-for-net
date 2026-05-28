// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ServiceNetworking.Tests
{
    public class ServiceNetworkingManagementTestBase : ManagementRecordedTestBase<ServiceNetworkingManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ServiceNetworkingManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
        }

        protected ServiceNetworkingManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreNetworkDependencyVersions();
        }
        public Resources.SubscriptionResource Subscription
        {
            get
            {
                var defaultSub = Client.GetDefaultSubscriptionAsync();
                defaultSub.Wait();
                return defaultSub.Result;
            }
        }

        public Resources.ResourceGroupResource ResourceGroup
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public string DefaultLocation()
        {
            return "North Europe";
        }

        public Resources.ResourceGroupResource GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().GetAsync(name).Result.Value;
        }

        protected TrafficControllerCollection GetTrafficControllers(string resourceGroupName)
        {
            return GetTrafficControllerCollection(resourceGroupName);
        }

        protected TrafficControllerFrontendCollection GetFrontends(TrafficControllerResource trafficController)
        {
            return trafficController.GetTrafficControllerFrontends();
        }

        protected TrafficControllerAssociationCollection GetAssociations(TrafficControllerResource trafficController)
        {
            return trafficController.GetTrafficControllerAssociations();
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
