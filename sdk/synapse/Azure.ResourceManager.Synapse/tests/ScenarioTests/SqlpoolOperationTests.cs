// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Synapse.Models;
using Azure.ResourceManager.Synapse.Tests;
using System.Collections.Generic;
using NUnit;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using System;
using System.Linq;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class SqlpoolOperationTests : SynapseManagementTestBase
    {
        public SqlpoolOperationTests(bool async) : base(async)
        { }

        [SetUp]
        public async Task Initialize()
        {
            await TestInitialize();

            await CreateWorkspace();
        }

        [Test]
        [RecordedTest]
        public async Task TestSqlPoolLifeCycle()
        {
            var workspaceName = WorkspaceResource.Data.Name;

            // create sqlpool
            string sqlpoolName = Recording.GenerateAssetName("sqlpool");
            var createSqlpoolParams = CommonData.PrepareSqlpoolCreateParams();
            SynapseSqlPoolCollection sqlPoolCollection = WorkspaceResource.GetSynapseSqlPools();
            var sqlpoolCreate =(await sqlPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, sqlpoolName, createSqlpoolParams)).Value;
            Assert.AreEqual(CommonTestFixture.SqlpoolType, sqlpoolCreate.Data.ResourceType);
            Assert.AreEqual(sqlpoolName, sqlpoolCreate.Data.Name);
            Assert.AreEqual(CommonData.Location, sqlpoolCreate.Data.Location);

            // get sqlpool
            for (int i = 0; i < 60; i++)
            {
                var sqlpoolGet = (await sqlPoolCollection.GetAsync(sqlpoolName)).Value;
                if (sqlpoolGet.Data.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.AreEqual(CommonTestFixture.SqlpoolType, sqlpoolCreate.Data.ResourceType);
                    Assert.AreEqual(sqlpoolName, sqlpoolCreate.Data.Name);
                    Assert.AreEqual(CommonData.Location, sqlpoolCreate.Data.Location);
                    break;
                }

                Thread.Sleep(30000);
                Assert.True(i < 60, "Synapse SqlPool is not in succeeded state even after 30 min.");
            }

            // update sqlpool
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string> { { "TestTag", "TestUpdate" } };
            SynapseSqlPoolPatch sqlPoolPatchInfo = new SynapseSqlPoolPatch
            {
                Sku = sqlpoolCreate.Data.Sku
            };
            sqlPoolPatchInfo.Tags.ReplaceWith(tagsToUpdate);

            await sqlpoolCreate.UpdateAsync(WaitUntil.Completed, sqlPoolPatchInfo);

            var sqlpoolUpdate = (await sqlPoolCollection.GetAsync(sqlpoolName)).Value;
            Assert.NotNull(sqlpoolUpdate.Data.Tags);
            Assert.AreEqual("TestUpdate", sqlpoolUpdate.Data.Tags["TestTag"]);

            // list sqlpool from workspace
            var sqlpoolFromWorkspace = sqlPoolCollection.GetAllAsync();
            var sqlpoolList = await sqlpoolFromWorkspace.ToEnumerableAsync();
            var sqlpoolCount = sqlpoolList.Count;
            var sqlpool = sqlpoolList.Single(pool => pool.Data.Name == sqlpoolName);

            Assert.True(sqlpool != null, string.Format("sql pool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete sqlpool
            await sqlpool.DeleteAsync(WaitUntil.Completed);
            var sqlPoolList = await sqlPoolCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(sqlpoolCount - 1, sqlPoolList.Count);
        }
    }
}
