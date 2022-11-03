// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests
{
    public class KustoManagementTestBase : ManagementRecordedTestBase<KustoManagementTestEnvironment>
    {
        protected ArmClient Client { get; set; }
        protected AzureLocation Location { get; set; }
        protected SubscriptionResource Subscription { get; set; }
        protected ResourceGroupResource ResourceGroup { get; set; }
        protected KustoClusterResource Cluster { get; set; }
        protected KustoDatabaseResource Database { get; set; }

        protected KustoManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected KustoManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected async Task BaseSetUp(bool cluster = false, bool database = false)
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            Location = TestEnvironment.Location;

            ResourceGroup = (await Subscription.GetResourceGroupAsync(TestEnvironment.ResourceGroup)).Value;

            if (cluster || database)
            {
                Cluster = (await ResourceGroup.GetKustoClusterAsync(TestEnvironment.ClusterName)).Value;
            }

            if (database)
            {
                Database = (await Cluster.GetKustoDatabaseAsync(TestEnvironment.DatabaseName)).Value;
            }
        }

        // Testing Methods
        protected delegate Task<ArmOperation<T>> CreateOrUpdateAsync<T, TS>(string resourceName, TS resourceData,
            bool create);

        protected delegate Task<Response<T>> GetAsync<T>(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate AsyncPageable<T> GetAllAsync<T>(CancellationToken cancellationToken = default);

        protected delegate Task<Response<bool>> ExistsAsync(string resourceName,
            CancellationToken cancellationToken = default);

        protected delegate void Validate<T, TS>(T resource, string resourceName, TS resourceData);

        protected async Task CollectionTests<T, TS>(
            string resourceName,
            TS resourceDataCreate, TS resourceDataUpdate,
            CreateOrUpdateAsync<T, TS> createOrUpdateAsync,
            GetAsync<T> getAsync,
            GetAllAsync<T> getAllAsync,
            ExistsAsync existsAsync,
            Validate<T, TS> validate,
            bool clusterChild = false,
            bool databaseChild = false
        )
        {
            T resource;

            var fullResourceName = resourceName;
            if (databaseChild)
                fullResourceName = $"{TestEnvironment.ClusterName}/{TestEnvironment.DatabaseName}/{resourceName}";
            else if (clusterChild)
                fullResourceName = $"{TestEnvironment.ClusterName}/{TestEnvironment.DatabaseName}/{resourceName}";

            if (resourceDataCreate is not null)
            {
                resource = (await createOrUpdateAsync(resourceName, resourceDataCreate, true)).Value;
                // validate(resource, fullResourceName, resourceDataCreate);
            }

            if (resourceDataUpdate is not null)
            {
                resource = (await createOrUpdateAsync(resourceName, resourceDataUpdate, false)).Value;
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

        protected static async Task DeletionTest<T>(
            string resourceName,
            GetAsync<T> getAsync,
            ExistsAsync existsAsync
        )
        {
            var resource = (await getAsync(resourceName)).Value;

            var deleteAsync = resource.GetType().GetMethod("DeleteAsync");
            Assert.IsNotNull(deleteAsync);
            var result = deleteAsync.Invoke(resource, new object[] { WaitUntil.Completed, default });
            Assert.IsNotNull(result);
            await (Task<ArmOperation>)result;

            var exists = await existsAsync(resourceName);
            Assert.IsFalse(exists);
        }
    }
}
