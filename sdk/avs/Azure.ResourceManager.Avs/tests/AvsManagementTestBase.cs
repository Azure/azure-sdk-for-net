// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Avs.Tests
{
    public class AvsManagementTestBase : ManagementRecordedTestBase<AvsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected AzureLocation DefaultLocation => AzureLocation.EastUS;

        protected AvsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected AvsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<AvsPrivateCloudResource> getAvsPrivateCloudResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            string resourceGroupName = "avs-sdk-test";
            string privateCloudName = "avs-sdk-test";
            ResourceIdentifier avsPrivateCloudResourceId = AvsPrivateCloudResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName);
            AvsPrivateCloudResource avsPrivateCloud = Client.GetAvsPrivateCloudResource(avsPrivateCloudResourceId);
            avsPrivateCloud = await avsPrivateCloud.GetAsync();
            Console.WriteLine(avsPrivateCloud.Data.Name);
            return avsPrivateCloud;
        }

        protected async Task<AvsPrivateCloudClusterResource> getAvsPrivateCloudClusterResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            string resourceGroupName = "avs-sdk-test";
            string privateCloudName = "avs-sdk-test";
            string clusterName = "Cluster-1";
            ResourceIdentifier avsPrivateCloudClusterResourceId = AvsPrivateCloudClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, privateCloudName, clusterName);
            AvsPrivateCloudClusterResource avsPrivateCloudCluster = Client.GetAvsPrivateCloudClusterResource(avsPrivateCloudClusterResourceId);
            avsPrivateCloudCluster = await avsPrivateCloudCluster.GetAsync();
            return avsPrivateCloudCluster;
        }
    }
}
