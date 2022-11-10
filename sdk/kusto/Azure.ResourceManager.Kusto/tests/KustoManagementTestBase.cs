// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Kusto.Tests
{
    public class KustoManagementTestBase : ManagementRecordedTestBase<KustoManagementTestEnvironment>
    {
        protected KustoManagementTestEnvironment TE => TestEnvironment;
        private ArmClient Client { get; set; }
        private SubscriptionResource Subscription { get; set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected KustoClusterResource Cluster { get; private set; }
        protected KustoDatabaseResource Database { get; private set; }

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

            ResourceGroup = (await Subscription.GetResourceGroupAsync(TE.ResourceGroup)).Value;

            if (cluster || database)
            {
                Cluster = (await ResourceGroup.GetKustoClusterAsync(TE.ClusterName)).Value;
            }

            if (database)
            {
                Database = (await Cluster.GetKustoDatabaseAsync(TE.DatabaseName)).Value;
            }
        }

        // Testing Methods
        protected delegate Task<ArmOperation<T>> CreateOrUpdateAsync<T, in TS>(
            string resourceName, TS resourceData
        );

        protected delegate Task<Response<T>> GetAsync<T>(
            string resourceName, CancellationToken cancellationToken = default
        );

        protected delegate IAsyncEnumerable<T> GetAllAsync<out T>(
            CancellationToken cancellationToken = default
        );

        protected delegate Task<Response<bool>> ExistsAsync(
            string resourceName, CancellationToken cancellationToken = default
        );

        protected delegate void Validate<in TS>(
            string expectedFullResourceName, TS expectedResourceData, TS actualResourceData
        );

        private static object GetResourceData(object resource)
        {
            return resource.GetType().GetProperty("Data")?.GetValue(resource, null);
        }

        private static string GetResourceName(object resource)
        {
            return ((ResourceData)GetResourceData(resource)).Name;
        }

        protected static async Task CollectionTests<T, TS>(
            string expectedResourceName,
            string expectedFullResourceName,
            TS resourceDataCreate,
            TS resourceDataUpdate,
            CreateOrUpdateAsync<T, TS> createOrUpdateAsync,
            GetAsync<T> getAsync,
            GetAllAsync<T> getAllAsync,
            ExistsAsync existsAsync,
            Validate<TS> validate
        )
            where T : ArmResource
        {
            T resource;

            if (createOrUpdateAsync is not null && resourceDataCreate is not null)
            {
                resource = (await createOrUpdateAsync(expectedResourceName, resourceDataCreate)).Value;
                validate(
                    expectedResourceName, resourceDataCreate, (TS)GetResourceData(resource)
                );
            }

            if (createOrUpdateAsync is not null && resourceDataUpdate is not null)
            {
                resource = (await createOrUpdateAsync(expectedResourceName, resourceDataUpdate)).Value;
                validate(
                    expectedResourceName, resourceDataUpdate, (TS)GetResourceData(resource)
                );
            }

            resource = (await getAsync(expectedResourceName)).Value;
            validate(
                expectedResourceName, resourceDataUpdate, (TS)GetResourceData(resource)
            );

            resource = await getAllAsync().FirstOrDefaultAsync(r => expectedFullResourceName == GetResourceName(r));
            validate(
                expectedFullResourceName, resourceDataUpdate, (TS)GetResourceData(resource)
            );

            var exists = (await existsAsync(expectedResourceName)).Value;
            Assert.IsTrue(exists);
            exists = (await existsAsync(new Guid().ToString())).Value;
            Assert.IsFalse(exists);
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

        // Utility Methods
        protected string GenerateAssetName(string prefix)
        {
            return prefix + TE.Id;
        }

        protected string GetFullClusterChildResourceName(string resourceName, string clusterName = null)
        {
            return $"{clusterName ?? TE.ClusterName}/{resourceName}";
        }

        protected string GetFullDatabaseChildResourceName(string resourceName, string clusterName = null,
            string databaseName = null)
        {
            return GetFullClusterChildResourceName(
                $"{databaseName ?? TE.DatabaseName}/{resourceName}", clusterName
            );
        }

        protected static void AssertEquality<T>(T expected, T actual, Action<T, T> assertEquals)
        {
            if (expected is null)
            {
                Assert.IsNull(actual);
            }
            else
            {
                Assert.IsNotNull(actual);

                assertEquals(expected, actual);
            }
        }
    }
}
