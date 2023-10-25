// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Synapse;
using Azure.ResourceManager.Synapse.Models;
using Azure.ResourceManager.Synapse.Tests;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using NUnit;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class KustopoolOperationTests : SynapseManagementTestBase
    {
        public KustopoolOperationTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task Initialize()
        {
            await TestInitialize();

            await CreateWorkspace();
        }

        [Test]
        [RecordedTest]
        public async Task TestKustoPoolLifeCycle()
        {
            KustoPoolState runningState = KustoPoolState.Running;

            var workspaceName = WorkspaceResource.Data.Name;

            // create kusto pool
            string kustoPoolName = Recording.GenerateAssetName("kustopool");
            var createKustopoolParams = CommonData.PrepareKustopoolCreateParams();
            createKustopoolParams.WorkspaceUid = WorkspaceResource.Data.WorkspaceUid;
            SynapseKustoPoolCollection kustoPoolCollection = WorkspaceResource.GetSynapseKustoPools();
            var kustoPoolCreate = (await kustoPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, kustoPoolName, createKustopoolParams)).Value;
            VerifyKustoPool(kustoPoolCreate, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // get kusto pool
            var kustoPoolGet = (await kustoPoolCollection.GetAsync(kustoPoolName)).Value;
            VerifyKustoPool(kustoPoolGet, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // update kusto pool
            createKustopoolParams.Sku = CommonData.UpdatedKustoSku;
            var kustoPoolUpdate = (await kustoPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, kustoPoolName, createKustopoolParams)).Value;
            VerifyKustoPool(kustoPoolUpdate, kustoPoolName, createKustopoolParams.Sku, state: runningState, workspaceName);

            // list kusto pools from workspace
            var kustoPoolFromWorkspace = kustoPoolCollection.GetAllAsync();
            var kustoPoolList = await kustoPoolFromWorkspace.ToEnumerableAsync();
            var kustoPoolCount = kustoPoolList.Count;
            var expectedKustoPoolName = GetFullKustoPoolName(workspaceName, kustoPoolName);
            var kustoPool = kustoPoolList.Single(pool => pool.Data.Name == expectedKustoPoolName);

            Assert.True(kustoPool != null, string.Format("kusto pool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete kusto pool
            await kustoPool.DeleteAsync(WaitUntil.Completed);
            kustoPoolList = await kustoPoolCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(kustoPoolCount - 1, kustoPoolList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task TestKustoPoolDatabaseLifeCycle()
        {
            var workspaceName = WorkspaceResource.Data.Name;

            // create kusto pool
            string kustoPoolName = Recording.GenerateAssetName("kustopool");
            var createKustopoolParams = CommonData.PrepareKustopoolCreateParams();
            createKustopoolParams.WorkspaceUid = WorkspaceResource.Data.WorkspaceUid;
            SynapseKustoPoolCollection kustoPoolCollection = WorkspaceResource.GetSynapseKustoPools();
            var kustoPoolCreate = (await kustoPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, kustoPoolName, createKustopoolParams)).Value;

            // create kusto database
            string kustoDatabaseName = Recording.GenerateAssetName("kustodatabase");
            var createKustoDatabaseParams = CommonData.PrepareKustoDatabaseCreateParams();
            SynapseDatabaseCollection kustoPoolDatabaseCollection = kustoPoolCreate.GetSynapseDatabases();
            var kustoDatabaseCreate = (await kustoPoolDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, kustoDatabaseName, createKustoDatabaseParams)).Value.Data as SynapseReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseCreate, kustoDatabaseName, CommonData.SoftDeletePeriod, CommonData.HotCachePeriod, workspaceName, kustoPoolName);

            // get database
            var kustoDatabaseGet = (await kustoPoolDatabaseCollection.GetAsync(kustoDatabaseName)).Value.Data as SynapseReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseGet, kustoDatabaseName, CommonData.SoftDeletePeriod, CommonData.HotCachePeriod, workspaceName, kustoPoolName);

            // update database
            createKustoDatabaseParams.SoftDeletePeriod = CommonData.UpdatedSoftDeletePeriod;
            createKustoDatabaseParams.HotCachePeriod = CommonData.UpdatedHotCachePeriod;
            var kustoDatabaseUpdate = (await kustoPoolDatabaseCollection.CreateOrUpdateAsync(WaitUntil.Completed, kustoDatabaseName, createKustoDatabaseParams)).Value.Data as SynapseReadWriteDatabase;
            VerifyReadWriteDatabase(kustoDatabaseUpdate, kustoDatabaseName, CommonData.UpdatedSoftDeletePeriod, CommonData.UpdatedHotCachePeriod, workspaceName, kustoPoolName);

            // list databases
            var kustoDatabasesFromPool = kustoPoolDatabaseCollection.GetAllAsync();
            var kustoDatabaseList = await kustoDatabasesFromPool.ToEnumerableAsync();
            var kustoDatabaseCount = kustoDatabaseList.Count();
            var expectedKustoDatabaseName = GetFullKustoDatabaseName(workspaceName,kustoPoolName,kustoDatabaseName);
            var kustoDatabase = kustoDatabaseList.Single(database => database.Data.Name == expectedKustoDatabaseName);

            Assert.True(kustoDatabase != null, string.Format("kusto Database created earlier is not found when listing all in kusto pool {0}", kustoPoolName));

            // delete database
            await kustoDatabase.DeleteAsync(WaitUntil.Completed);
            kustoDatabaseList = await kustoPoolDatabaseCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(kustoDatabaseCount - 1, kustoDatabaseList.Count);
        }

        private void VerifyKustoPool(SynapseKustoPoolResource kustoPool, string name, SynapseDataSourceSku sku, KustoPoolState state, string workspaceName)
        {
            var poolFullName = GetFullKustoPoolName(workspaceName, name);
            Assert.AreEqual(kustoPool.Data.Name, poolFullName);
            AssetEqualtsSku(kustoPool.Data.Sku, sku);
            Assert.AreEqual(state, kustoPool.Data.State);
        }

        private string GetFullKustoPoolName(string workspaceName, string kustoPoolName)
        {
            return $"{workspaceName}/{kustoPoolName}";
        }

        private void AssetEqualtsSku(SynapseDataSourceSku sku1, SynapseDataSourceSku sku2)
        {
            Assert.AreEqual(sku1.Size, sku2.Size);
            Assert.AreEqual(sku1.Name, sku2.Name);
        }

        private void VerifyReadWriteDatabase(SynapseReadWriteDatabase database, string databaseName, TimeSpan? softDeletePeriod, TimeSpan? hotCachePeriod, string workspaceName, string kustoPoolName)
        {
            var databaseFullName = GetFullKustoDatabaseName(workspaceName, kustoPoolName, databaseName);
            Assert.NotNull(database);
            Assert.AreEqual(database.Name, databaseFullName);
            Assert.AreEqual(database.SoftDeletePeriod, softDeletePeriod);
            Assert.AreEqual(database.HotCachePeriod, hotCachePeriod);
        }

        private string GetFullKustoDatabaseName(string workspaceName, string kustoPoolName, string kustoDatabaseName)
        {
            return $"{workspaceName}/{kustoPoolName}/{kustoDatabaseName}";
        }
    }
}
