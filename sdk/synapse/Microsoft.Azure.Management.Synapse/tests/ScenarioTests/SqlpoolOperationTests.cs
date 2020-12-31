// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Synapse.Models;
using System.Collections.Generic;
using Xunit;
using System.Threading;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class SqlpoolOperationTests : SynapseManagementTestBase
    {
        [Fact]
        public void TestSqlPoolLifeCycle()
        {
            TestInitialize();

            // create workspace
            string workspaceName = TestUtilities.GenerateName("synapsesdkworkspace");
            var createWorkspaceParams = CommonData.PrepareWorkspaceCreateParams();
            var workspaceCreate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createWorkspaceParams);
            Assert.Equal(CommonTestFixture.WorkspaceType, workspaceCreate.Type);
            Assert.Equal(workspaceName, workspaceCreate.Name);
            Assert.Equal(CommonData.Location, workspaceCreate.Location);

            for (int i = 0; i < 60; i++)
            {
                var workspaceGet = SynapseClient.Workspaces.Get(CommonData.ResourceGroupName, workspaceName);
                if (workspaceGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceGet.Type);
                    Assert.Equal(workspaceName, workspaceGet.Name);
                    Assert.Equal(CommonData.Location, workspaceGet.Location);
                    break;
                }

                Thread.Sleep(30000);
                Assert.True(i < 60, "Synapse Workspace is not in succeeded state even after 30 min.");
            }

            // create sqlpool
            string sqlpoolName = TestUtilities.GenerateName("sqlpool");
            var createSqlpoolParams = CommonData.PrepareSqlpoolCreateParams();
            var sqlpoolCreate = SynapseClient.SqlPools.Create(CommonData.ResourceGroupName, workspaceName, sqlpoolName, createSqlpoolParams);
            Assert.Equal(CommonTestFixture.SqlpoolType, sqlpoolCreate.Type);
            Assert.Equal(sqlpoolName, sqlpoolCreate.Name);
            Assert.Equal(CommonData.Location, sqlpoolCreate.Location);

            // get sqlpool
            for (int i = 0; i < 60; i++)
            {
                var sqlpoolGet = SynapseClient.SqlPools.Get(CommonData.ResourceGroupName, workspaceName, sqlpoolName);
                if (sqlpoolGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.SqlpoolType, sqlpoolCreate.Type);
                    Assert.Equal(sqlpoolName, sqlpoolCreate.Name);
                    Assert.Equal(CommonData.Location, sqlpoolCreate.Location);
                    break;
                }

                Thread.Sleep(30000);
                Assert.True(i < 60, "Synapse SqlPool is not in succeeded state even after 30 min.");
            }

            // update sqlpool
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string> { { "TestTag", "TestUpdate" } };
            SqlPoolPatchInfo sqlPoolPatchInfo = new SqlPoolPatchInfo
            {
                Tags = tagsToUpdate,
                Sku = sqlpoolCreate.Sku
            };

            SynapseClient.SqlPools.Update(CommonData.ResourceGroupName, workspaceName, sqlpoolName, sqlPoolPatchInfo);
            Thread.Sleep(30000);
            var sqlpoolUpdate = SynapseClient.SqlPools.Get(CommonData.ResourceGroupName, workspaceName, sqlpoolName);
            Assert.NotNull(sqlpoolUpdate.Tags);
            Assert.Equal("TestUpdate", sqlpoolUpdate.Tags["TestTag"]);

            // list sqlpool from workspace
            var firstPage = SynapseClient.SqlPools.ListByWorkspace(CommonData.ResourceGroupName, workspaceName);
            var sqlpoolFromWorkspace = SynapseManagementTestUtilities.ListResources(firstPage, SynapseClient.SqlPools.ListByWorkspaceNext);
            Assert.True(1 <= sqlpoolFromWorkspace.Count);
            bool isFound = false;
            int sqlpoolCount = sqlpoolFromWorkspace.Count;
            for (int i = 0; i < sqlpoolCount; i++)
            {
                if (sqlpoolFromWorkspace[i].Name.Equals(sqlpoolName))
                {
                    isFound = true;
                    Assert.Equal("Microsoft.Synapse/workspaces/sqlPools", sqlpoolFromWorkspace[i].Type);
                    Assert.Equal(CommonData.Location, sqlpoolFromWorkspace[i].Location);
                    break;
                }
            }

            Assert.True(isFound, string.Format("Sqlpool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete sqlpool
            SynapseClient.SqlPools.Delete(CommonData.ResourceGroupName, workspaceName, sqlpoolName);
            firstPage = SynapseClient.SqlPools.ListByWorkspace(CommonData.ResourceGroupName, workspaceName);
            var sqlpoolAfterDelete = SynapseManagementTestUtilities.ListResources(firstPage, SynapseClient.SqlPools.ListByWorkspaceNext);
            Assert.True(sqlpoolCount - 1 == sqlpoolAfterDelete.Count);
        }
    }
}
