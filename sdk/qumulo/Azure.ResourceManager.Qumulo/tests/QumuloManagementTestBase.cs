// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Qumulo.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Qumulo.Tests
{
    public class QumuloManagementTestBase : ManagementRecordedTestBase<QumuloManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation Location { get; set; }
        protected string ResourceGroupPrefix { get; set; }

        protected QumuloManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected QumuloManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Location = AzureLocation.EastUS2;
            ResourceGroupPrefix = "Default-Qumulo-";
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException(nameof(subscription));
            }

            if (rgNamePrefix == null)
            {
                throw new ArgumentNullException(nameof(rgNamePrefix));
            }

            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<QumuloFileSystemResource> CreateQumuloFileSystemResource(ResourceGroupResource resourceGroup, AzureLocation location, string fileSystemName)
        {
            QumuloFileSystemResourceData data = new QumuloFileSystemResourceData(
                location, new MarketplaceDetails("qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M", "qumulo-saas-mpp", "qumulo1584033880660"),
                StorageSku.Performance,
                new QumuloUserDetails("abc@test.com", null),
                "/subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/NetworkWatcherRG/providers/Microsoft.Network/virtualNetworks/eastus2vnet/subnets/default",
                "Test123", 18)
            {
                AvailabilityZone = "2"
            };

            var lro = await resourceGroup.GetQumuloFileSystemResources().CreateOrUpdateAsync(WaitUntil.Completed, fileSystemName, data);
            return lro.Value;
        }
    }
}
