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
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests
{
    public class KustoManagementTestBase : ManagementRecordedTestBase<KustoManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }
        protected string SubscriptionId { get; private set; }
        protected string ResourceGroupName { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected string ClusterName { get; private set; }
        protected KustoClusterData ClusterData { get; private set; }
        protected KustoClusterResource Cluster { get; private set; }
        protected KustoClusterResource ClientTestCluster { get; private set; }
        protected string DatabaseName { get; private set; }
        protected KustoReadWriteDatabase DatabaseData { get; private set; }
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
            ResourceGroupName = Recording.GenerateAssetName("sdkTestResourceGroup");
            ClusterName = Recording.GenerateAssetName("sdkTestCluster");
            DatabaseName = Recording.GenerateAssetName("sdkTestDatabase");

            Client = GetArmClient();

            Subscription = await Client.GetDefaultSubscriptionAsync();
            SubscriptionId = TestEnvironment.SubscriptionId;

            var resourceCollection = Subscription.GetResourceGroups();
            var resourceGroupData = new ResourceGroupData(KustoTestUtils.Location);
            ResourceGroup =
                (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, ResourceGroupName,
                    resourceGroupData)).Value;

            var clusterCollection = ResourceGroup.GetKustoClusters();
            var clusterIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentityResourceId = new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testclientidentity"
            );
            clusterIdentity.UserAssignedIdentities[userAssignedIdentityResourceId] = new UserAssignedIdentity();
            ClusterData = new KustoClusterData(KustoTestUtils.Location, KustoTestUtils.Sku1) { Identity = clusterIdentity };
            Cluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, ClusterName, ClusterData))
                .Value;
            ClientTestCluster = Client.GetKustoClusterResource(new ResourceIdentifier(
                $"/subscriptions/{SubscriptionId}/resourceGroups/test-clients-rg/providers/Microsoft.Kusto/clusters/eventgridclienttest"
            ));

            // var databaseCollection = Cluster.GetKustoDatabases();
            // DatabaseData = new KustoReadWriteDatabase
            // {
            //     Location = KustoTestUtils.Location,
            //     SoftDeletePeriod = KustoTestUtils.SoftDeletePeriod1,
            //     HotCachePeriod = KustoTestUtils.HotCachePeriod1
            // };
            // Database = (await databaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, DatabaseName, DatabaseData))
            //     .Value;
        }

        // Testing Methods
        protected delegate Task<ArmOperation<T>> CreateOrUpdateAsync<T, S>(string resourceName, S resourceData);

        protected delegate Task<Response<T>> GetAsync<T>(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate AsyncPageable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

        protected delegate Task<Response<bool>> ExistsAsync(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate void Validate<T, S>(T resource, string resourceName, S resourceData);

        protected async Task CollectionTests<T, S>(
            string resourceName,
            S resourceDataCreate, S resourceDataUpdate,
            CreateOrUpdateAsync<T, S> createOrUpdateAsync,
            GetAsync<T> getAsync,
            GetAllAsync<T> getAllAsync,
            ExistsAsync existsAsync,
            Validate<T, S> validate,
            T resource = default,
            bool clusterChild = false,
            bool databaseChild = false
        )
        {
            var fullResourceName = resourceName;
            if (databaseChild) fullResourceName = $"{ClusterName}/{DatabaseName}/{resourceName}";
            else if (clusterChild) fullResourceName = $"{ClusterName}/{DatabaseName}/{resourceName}";

            if (createOrUpdateAsync is not null)
            {
                if (resource is not null)
                {
                    resource = (await createOrUpdateAsync(resourceName, resourceDataCreate)).Value;
                }
                // validate(resource, fullResourceName, resourceDataCreate);

                resource = (await createOrUpdateAsync(resourceName, resourceDataUpdate)).Value;
                // validate(resource, fullResourceName, resourceDataUpdate);
            }

            resource = (await getAsync(resourceName)).Value;
            // validate(resource, fullResourceName, resourceDataUpdate);

            var resources = await getAllAsync().ToListAsync();
            // Assert.AreEqual(1, resources.Count);
            // validate(resources[0], fullResourceName, resourceDataUpdate);

            var exists = (await existsAsync(resourceName)).Value;
            // Assert.IsTrue(exists);
            exists = (await existsAsync(new Guid().ToString())).Value;
            // Assert.IsFalse(exists);
        }

        protected async Task DeletionTest<T>(
            string resourceName,
            GetAsync<T> getAsync,
            ExistsAsync existsAsync
        )
        {
            var resource = await getAsync(resourceName);
            var deleteAsync = resource.GetType().GetMethod("DeleteAsync");
            // Assert.IsNotNull(deleteAsync);
            var result = deleteAsync.Invoke(resource, new object[] { WaitUntil.Completed });
            // Assert.IsNotNull(result);
            await (Task<ArmOperation>)result;
            var exists = await existsAsync(resourceName);
            // Assert.IsFalse(exists);
        }
    }
}
