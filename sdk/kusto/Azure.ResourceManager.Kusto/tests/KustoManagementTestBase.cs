// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests
{
    public class KustoManagementTestBase : ManagementRecordedTestBase<KustoManagementTestEnvironment>
    {
        protected AzureLocation Location = "";

        protected KustoSku Sku1 = new KustoSku(KustoSkuName.StandardD13V2, 2, KustoSkuTier.Standard);
        protected KustoSku Sku2 = new KustoSku(KustoSkuName.StandardD14V2, 2, KustoSkuTier.Standard);

        protected TimeSpan HotCachePeriod1 = TimeSpan.FromDays(2);
        protected TimeSpan HotCachePeriod2 = TimeSpan.FromDays(3);
        protected TimeSpan SoftDeletePeriod1 = TimeSpan.FromDays(4);
        protected TimeSpan SoftDeletePeriod2 = TimeSpan.FromDays(6);

        protected ArmClient Client { get; private set; }

        protected string SubscriptionId { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected string ResourceGroupName { get; private set; }

        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected string ClusterName { get; private set; }

        protected KustoClusterResource Cluster { get; private set; }

        protected string DatabaseName { get; private set; }

        protected KustoDatabaseResource Database { get; private set; }

        protected KustoManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected KustoManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task BaseSetup()
        {
            Client = GetArmClient();

            SubscriptionId = TestEnvironment.SubscriptionId;
            Subscription = await Client.GetDefaultSubscriptionAsync();

            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Location = (await Client.GetTenantResourceProviderAsync("Microsoft.Kusto")).Value.ResourceTypes
                    .First(r => "clusters".Equals(r.ResourceType, StringComparison.Ordinal)).Locations
                    .Select(l => new AzureLocation(l)).First();
            }

            ResourceGroupName = Recording.GenerateAssetName("sdkTestRg");
            ResourceGroup = await CreateResourceGroup(Subscription);
        }

        // Resource Management Methods
        private async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription)
        {
            var input = new ResourceGroupData(Location);
            var res = await subscription.GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, ResourceGroupName, input);
            return res.Value;
        }

        public async Task<KustoClusterResource> GetCluster(ResourceGroupResource resourceGroup)
        {
            if (Cluster is not null)
            {
                return Cluster;
            }

            ClusterName = Recording.GenerateAssetName("sdkTestCluster");

            var clusterCollection = resourceGroup.GetKustoClusters();
            var clusterData = new KustoClusterData(Location, Sku1);

            Cluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, ClusterName, clusterData))
                .Value;

            return Cluster;
        }

        public async Task<KustoDatabaseResource> GetDatabase(KustoClusterResource cluster)
        {
            if (Database is not null)
            {
                return Database;
            }

            DatabaseName = Recording.GenerateAssetName("sdkTestDatabase");

            var databaseCollection = cluster.GetKustoDatabases();
            var databaseData = new KustoReadWriteDatabase
            {
                Location = Location, SoftDeletePeriod = SoftDeletePeriod1, HotCachePeriod = HotCachePeriod1
            };

            Database = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, ClusterName, databaseData))
                .Value;

            return Database;
        }

        // Collection Testing Methods
        protected delegate Task<ArmOperation<T>> CreateOrUpdateAsync<T, S>(string resourceName, S resourceData);

        protected delegate Task<Response<T>> GetAsync<T>(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate AsyncPageable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

        protected delegate Task<Response<bool>> ExistsAsync(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate void Validate<T, S>(T resource, string resourceName, S resourceData);

        protected async Task CollectionTests<T, S>(
            string resourceName, string fullResourceName,
            S resourceDataCreate, S resourceDataUpdate,
            CreateOrUpdateAsync<T, S> createOrUpdateAsync,
            GetAsync<T> getAsync,
            GetAllAsync<T> getAllAsync,
            ExistsAsync existsAsync,
            Validate<T, S> validate
        )
        {
            T resource;
            List<T> resources;
            bool exists;

            if (createOrUpdateAsync is not null)
            {
                resource = (await createOrUpdateAsync(resourceName, resourceDataCreate)).Value;
                validate(resource, fullResourceName, resourceDataCreate);

                resource = (await createOrUpdateAsync(resourceName, resourceDataUpdate)).Value;
                validate(resource, fullResourceName, resourceDataUpdate);
            }

            resource = (await getAsync(resourceName)).Value;
            validate(resource, fullResourceName, resourceDataUpdate);

            resources = await getAllAsync().ToListAsync();
            Assert.AreEqual(1, resources.Count);
            validate(resources[0], fullResourceName, resourceDataUpdate);

            exists = (await existsAsync(resourceName)).Value;
            Assert.IsTrue(exists);
            exists = (await existsAsync(new Guid().ToString())).Value;
            Assert.IsFalse(exists);
        }
    }
}
