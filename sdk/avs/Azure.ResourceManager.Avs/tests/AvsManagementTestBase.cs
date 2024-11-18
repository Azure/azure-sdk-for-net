﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        public const string RESOURCE_GROUP_NAME = "avs-dotnet-test";
        public const string PRIVATE_CLOUD_NAME = "avs-dotnet-test-w2";
        public const string CLUSTER1_NAME = "Cluster-1";
        public const string CLUSTER2_NAME = "Cluster-2";
        public const string ISCSI_PATH_NAME = "default";
        public const string WORKLOAD_NETWORK_NAME = "a8b7ddce-a5d6-11e8-a7e5-43344e310957";

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
            ResourceIdentifier avsPrivateCloudResourceId = AvsPrivateCloudResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            AvsPrivateCloudResource avsPrivateCloud = Client.GetAvsPrivateCloudResource(avsPrivateCloudResourceId);
            avsPrivateCloud = await avsPrivateCloud.GetAsync();
            Console.WriteLine(avsPrivateCloud.Data.Name);
            return avsPrivateCloud;
        }

        protected async Task<AvsPrivateCloudClusterResource> getAvsPrivateCloudClusterResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPrivateCloudClusterResourceId = AvsPrivateCloudClusterResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME, CLUSTER1_NAME);
            AvsPrivateCloudClusterResource avsPrivateCloudCluster = Client.GetAvsPrivateCloudClusterResource(avsPrivateCloudClusterResourceId);
            avsPrivateCloudCluster = await avsPrivateCloudCluster.GetAsync();
            return avsPrivateCloudCluster;
        }
        protected IscsiPathResource getIscsiPathResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier iscsiPathResourceId = IscsiPathResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            IscsiPathResource iscsiPath = Client.GetIscsiPathResource(iscsiPathResourceId);
            return iscsiPath;
        }
        protected WorkloadNetworkResource getWorkloadNetworkResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier workloadNetworkResourceId = WorkloadNetworkResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            WorkloadNetworkResource workloadNetwork = Client.GetWorkloadNetworkResource(workloadNetworkResourceId);
            return workloadNetwork;
        }
        protected AvsPrivateCloudResource getWorkloadNetworkResourceOld()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPrivateCloudResourceId = AvsPrivateCloudResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            AvsPrivateCloudResource avsPrivateCloud = Client.GetAvsPrivateCloudResource(avsPrivateCloudResourceId);
            return avsPrivateCloud;
        }
    }
}
