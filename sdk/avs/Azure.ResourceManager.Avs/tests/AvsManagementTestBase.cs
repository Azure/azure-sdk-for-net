// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using System.Net.Http;
using Azure.Identity;
using System.Threading;
using System.Net.Security;
using System.Net;

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
        public const string WORKLOAD_NETWORK_NAME = "03335585-9574-4d44-a001-818ca9a9c282";
        public const string HOST_ID = "esx14-r04.p02.westus2.avs.azure.com";
        public const string PROVISIONED_NETWORK_NAME = "vsan";
        public const string STORAGE_POLICY_NAME = "storagePolicy1";
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
        protected AvsHostResource getAvsHostResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsHostResourceId = AvsHostResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME, CLUSTER1_NAME, HOST_ID);
            AvsHostResource avsHost = Client.GetAvsHostResource(avsHostResourceId);
            return avsHost;
        }
        protected AvsHostCollection getAvsHostCollection()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPrivateCloudClusterResourceId = AvsPrivateCloudClusterResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME, CLUSTER1_NAME);
            AvsPrivateCloudClusterResource avsPrivateCloudCluster = Client.GetAvsPrivateCloudClusterResource(avsPrivateCloudClusterResourceId);
            AvsHostCollection collection = avsPrivateCloudCluster.GetAvsHosts();
            return collection;
        }
        protected AvsProvisionedNetworkResource getAvsProvisionedNetworksResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsProvisionedNetworkResourceId = AvsProvisionedNetworkResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME, PROVISIONED_NETWORK_NAME);
            AvsProvisionedNetworkResource avsProvisionedNetwork = Client.GetAvsProvisionedNetworkResource(avsProvisionedNetworkResourceId);
            return avsProvisionedNetwork;
        }
        protected AvsProvisionedNetworkCollection getAvsProvisionedNetworksCollection()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPrivateCloudResourceId = AvsPrivateCloudResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            AvsPrivateCloudResource avsPrivateCloud = Client.GetAvsPrivateCloudResource(avsPrivateCloudResourceId);
            AvsProvisionedNetworkCollection collection = avsPrivateCloud.GetAvsProvisionedNetworks();
            return collection;
        }
        protected AvsPureStoragePolicyResource getAvsPureStoragePolicyResource()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPureStoragePolicyResourceId = AvsPureStoragePolicyResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME, STORAGE_POLICY_NAME);
            AvsPureStoragePolicyResource avsPureStoragePolicy = Client.GetAvsPureStoragePolicyResource(avsPureStoragePolicyResourceId);
            return avsPureStoragePolicy;
        }
        protected AvsPureStoragePolicyCollection getAvsPureStoragePolicyCollection()
        {
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceIdentifier avsPrivateCloudResourceId = AvsPrivateCloudResource.CreateResourceIdentifier(subscriptionId, RESOURCE_GROUP_NAME, PRIVATE_CLOUD_NAME);
            AvsPrivateCloudResource avsPrivateCloud = Client.GetAvsPrivateCloudResource(avsPrivateCloudResourceId);
            AvsPureStoragePolicyCollection collection = avsPrivateCloud.GetAvsPureStoragePolicies();
            return collection;
        }
    }
}