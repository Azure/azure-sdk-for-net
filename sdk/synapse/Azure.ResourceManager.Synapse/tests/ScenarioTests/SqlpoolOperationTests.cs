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
            Assert.That(sqlpoolCreate.Data.ResourceType, Is.EqualTo(CommonTestFixture.SqlpoolType));
            Assert.That(sqlpoolCreate.Data.Name, Is.EqualTo(sqlpoolName));
            Assert.That(sqlpoolCreate.Data.Location, Is.EqualTo(CommonData.Location));

            // get sqlpool
            for (int i = 0; i < 60; i++)
            {
                var sqlpoolGet = (await sqlPoolCollection.GetAsync(sqlpoolName)).Value;
                if (sqlpoolGet.Data.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.That(sqlpoolCreate.Data.ResourceType, Is.EqualTo(CommonTestFixture.SqlpoolType));
                    Assert.That(sqlpoolCreate.Data.Name, Is.EqualTo(sqlpoolName));
                    Assert.That(sqlpoolCreate.Data.Location, Is.EqualTo(CommonData.Location));
                    break;
                }

                Thread.Sleep(30000);
                Assert.That(i < 60, Is.True, "Synapse SqlPool is not in succeeded state even after 30 min.");
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
            Assert.That(sqlpoolUpdate.Data.Tags["TestTag"], Is.EqualTo("TestUpdate"));

            // list sqlpool from workspace
            var sqlpoolFromWorkspace = sqlPoolCollection.GetAllAsync();
            var sqlpoolList = await sqlpoolFromWorkspace.ToEnumerableAsync();
            var sqlpoolCount = sqlpoolList.Count;
            var sqlpool = sqlpoolList.Single(pool => pool.Data.Name == sqlpoolName);

            Assert.That(sqlpool != null, Is.True, string.Format("sql pool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete sqlpool
            await sqlpool.DeleteAsync(WaitUntil.Completed);
            var sqlPoolList = await sqlPoolCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(sqlPoolList.Count, Is.EqualTo(sqlpoolCount - 1));
        }
    }
}
