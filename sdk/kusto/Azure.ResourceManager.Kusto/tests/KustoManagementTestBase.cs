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
        private AzureLocation _location;
        private readonly KustoSku _sku = new(KustoSkuName.StandardD11V2, KustoSkuTier.Standard);

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }
        protected string ResourceGroupName { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected string ClusterName { get; private set; }
        protected KustoClusterData ClusterData { get; private set; }
        protected string DatabaseName { get; private set; }
        protected KustoDatabaseData DatabaseData { get; private set; }

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
            Subscription = await Client.GetDefaultSubscriptionAsync();

            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                _location = (await Client.GetTenantResourceProviderAsync("Microsoft.Kusto")).Value.ResourceTypes
                    .First(r => "clusters".Equals(r.ResourceType, StringComparison.Ordinal)).Locations
                    .Select(l => new AzureLocation(l)).First();
            }

            ResourceGroupName = Recording.GenerateAssetName("rg");
            ResourceGroup = await CreateResourceGroup(Subscription);

            ClusterName = Recording.GenerateAssetName("cluster");
            ClusterData = new KustoClusterData(_location, _sku);

            DatabaseName = Recording.GenerateAssetName("database");
            DatabaseData = new KustoDatabaseData();
        }

        // Resource Management Methods
        private async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription)
        {
            var input = new ResourceGroupData(_location);
            var res = await subscription.GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, ResourceGroupName, input);
            return res.Value;
        }

        protected async Task<KustoClusterResource> GetCluster(ResourceGroupResource resourceGroup)
        {
            var clusterCollection = resourceGroup.GetKustoClusters();

            if (await clusterCollection.ExistsAsync(ClusterName))
            {
                return (await clusterCollection.GetAsync(ClusterName)).Value;
            }

            return (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, ClusterName, ClusterData)).Value;
        }

        protected async Task<KustoDatabaseResource> GetDatabase(KustoClusterResource cluster)
        {
            var databaseCollection = cluster.GetKustoDatabases();

            if (await databaseCollection.ExistsAsync(DatabaseName))
            {
                return (await databaseCollection.GetAsync(DatabaseName)).Value;
            }

            return (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, DatabaseName, DatabaseData)).Value;
        }

        // Collection Testing Methods
        protected string GetResourceName<T>(T resource)
        {
            var dataProperty = resource.GetType().GetProperty("Data");
            var data = dataProperty?.GetValue(resource);

            var nameProperty = data?.GetType().GetProperty("Name");
            var name = nameProperty?.GetValue(data);

            return name?.ToString();
        }

        protected void ValidateResource(object resource, string resourceName)
        {
            Assert.AreEqual(resourceName, GetResourceName(resource));
        }

        protected delegate Task<ArmOperation<T>> CreateOrUpdateAsync<T, S>(string resourceName, S resourceData);

        protected async Task CreateOrUpdateTest<T, S>(CreateOrUpdateAsync<T, S> createOrUpdateAsync,
            string resourceName, S resourceData)
        {
            var resource = (await createOrUpdateAsync(resourceName, resourceData)).Value;
            ValidateResource(resource, resourceName);
        }

        protected delegate Task<Response<T>> GetAsync<T>(string resourceName,
            CancellationToken cancellationToken = default);

        protected async Task GetTest<T>(GetAsync<T> getAsync, string resourceName)
        {
            var resource = (await getAsync(resourceName)).Value;
            ValidateResource(resource, resourceName);
        }

        protected delegate AsyncPageable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

        protected async Task GetAllTest<T>(GetAllAsync<T> getAllAsync, string resourceName)
        {
            var resourceNames = await getAllAsync().Select(GetResourceName).ToListAsync();
            Assert.AreEqual(new List<string> { resourceName }, resourceNames);
        }

        protected delegate Task<Response<bool>> ExistsAsync(string resourceName,
            CancellationToken cancellationToken = default);

        protected async Task ExistsTest(ExistsAsync existsAsync, string resourceName)
        {
            var exists = (await existsAsync(resourceName)).Value;
            Assert.IsTrue(exists);
            exists = (await existsAsync(new Guid().ToString())).Value;
            Assert.IsFalse(exists);
        }

        protected async Task CollectionTests<T, S>(
            string resourceName, S resourceData,
            CreateOrUpdateAsync<T, S> createOrUpdateAsync,
            GetAsync<T> getAsync,
            GetAllAsync<T> getAllAsync,
            ExistsAsync existsAsync
        )
        {
            if (createOrUpdateAsync is not null)
            {
                await CreateOrUpdateTest(createOrUpdateAsync, resourceName, resourceData);
            }

            await GetTest(getAsync, resourceName);
            await GetAllTest(getAllAsync, resourceName);
            await ExistsTest(existsAsync, resourceName);
        }
    }
}
