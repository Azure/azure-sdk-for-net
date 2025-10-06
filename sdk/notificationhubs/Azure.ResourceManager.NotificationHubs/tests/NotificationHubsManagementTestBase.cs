// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NotificationHubs.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NotificationHubs.Tests
{
    public class NotificationHubsManagementTestBase : ManagementRecordedTestBase<NotificationHubsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string ResourceGroupNamePrefix = "NotificationHubRG-";

        protected NotificationHubsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected NotificationHubsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<NotificationHubNamespaceResource> CreateNotificationHubNamespace(ResourceGroupResource resourceGroup, string namespaceName)
        {
            var data = new NotificationHubNamespaceData(DefaultLocation)
            {
                Sku = new NotificationHubSku(NotificationHubSkuName.Standard),
            };
            var notificationHubNamespace = await resourceGroup.GetNotificationHubNamespaces().CreateOrUpdateAsync(WaitUntil.Completed, namespaceName, data);
            return notificationHubNamespace.Value;
        }

        protected async Task<NotificationHubResource> CreateNotificationHub(NotificationHubNamespaceResource notificationHubNamespaceResource, string notificationHubName)
        {
            var data = new NotificationHubData(DefaultLocation);
            var notificationHub = await notificationHubNamespaceResource.GetNotificationHubs().CreateOrUpdateAsync(WaitUntil.Completed, notificationHubName, data);
            return notificationHub.Value;
        }
    }
}
