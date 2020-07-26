// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Synapse.Models;
using System.Collections.Generic;
using Xunit;
using System.Threading;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class SparkpoolOperationTests : SynapseManagementTestBase
    {
        [Fact]
        public void TestSparkPoolLifeCycle()
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

            // create sparkpool unableautoscale
            string sparkpoolName = TestUtilities.GenerateName("sparkpool");
            var createSparkpoolParams = CommonData.PrepareSparkpoolCreateParams(enableAutoScale:false, enableAutoPause:false);
            var sparkpoolUnableAutoScale = SynapseClient.BigDataPools.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, sparkpoolName, createSparkpoolParams);
            Assert.Equal(CommonTestFixture.SparkpoolType, sparkpoolUnableAutoScale.Type);
            Assert.Equal(sparkpoolName, sparkpoolUnableAutoScale.Name);
            Assert.Equal(CommonData.Location, sparkpoolUnableAutoScale.Location);

            // get sparkpool
            for (int i = 0; i < 60; i++)
            {
                var sparkpoolGet = SynapseClient.BigDataPools.Get(CommonData.ResourceGroupName, workspaceName, sparkpoolName);
                if (sparkpoolGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.SparkpoolType, sparkpoolUnableAutoScale.Type);
                    Assert.Equal(sparkpoolName, sparkpoolUnableAutoScale.Name);
                    Assert.Equal(CommonData.Location, sparkpoolUnableAutoScale.Location);
                    break;
                }

                Thread.Sleep(30000);
                Assert.True(i < 60, "Synapse SparkPool is not in succeeded state even after 30 min.");
            }

            // update sparkpool
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string> { { "TestTag", "TestUpdate" } };
            BigDataPoolPatchInfo bigdataPoolPatchInfo = new BigDataPoolPatchInfo
            {
                Tags = tagsToUpdate
            };

            SynapseClient.BigDataPools.Update(CommonData.ResourceGroupName, workspaceName, sparkpoolName, bigdataPoolPatchInfo);
            var sparkpoolUpdate = SynapseClient.BigDataPools.Get(CommonData.ResourceGroupName, workspaceName, sparkpoolName);
            Thread.Sleep(30000);
            Assert.NotNull(sparkpoolUpdate.Tags);
            Assert.Equal("TestUpdate", sparkpoolUpdate.Tags["TestTag"]);

            // Enable Auto-scale and Auto-pause
            createSparkpoolParams = CommonData.PrepareSparkpoolCreateParams(enableAutoScale: true, enableAutoPause: true);
            var sparkpoolEnableAutoScale = SynapseClient.BigDataPools.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, sparkpoolName, createSparkpoolParams);
            Assert.Equal(CommonTestFixture.SparkpoolType, sparkpoolUnableAutoScale.Type);
            Assert.Equal(sparkpoolName, sparkpoolUnableAutoScale.Name);
            Assert.Equal(CommonData.Location, sparkpoolUnableAutoScale.Location);
            Assert.True(sparkpoolEnableAutoScale.AutoScale.Enabled);
            Assert.Equal(CommonData.AutoScaleMaxNodeCount, sparkpoolEnableAutoScale.AutoScale.MaxNodeCount);
            Assert.Equal(CommonData.AutoScaleMinNodeCount, sparkpoolEnableAutoScale.AutoScale.MinNodeCount);
            Assert.True(sparkpoolEnableAutoScale.AutoPause.Enabled);
            Assert.Equal(CommonData.AutoPauseDelayInMinute, sparkpoolEnableAutoScale.AutoPause.DelayInMinutes);

            // list sparkpool from workspace
            var firstPage = SynapseClient.BigDataPools.ListByWorkspace(CommonData.ResourceGroupName, workspaceName);
            var sparkpoolFromWorkspace = SynapseManagementTestUtilities.ListResources(firstPage, SynapseClient.BigDataPools.ListByWorkspaceNext);
            Assert.True(1 <= sparkpoolFromWorkspace.Count);

            bool isFound = false;
            int sparkpoolCount = sparkpoolFromWorkspace.Count;
            for (int i = 0; i < sparkpoolCount; i++)
            {
                if (sparkpoolFromWorkspace[i].Name.Equals(sparkpoolName))
                {
                    isFound = true;
                    Assert.Equal(CommonTestFixture.SparkpoolType, sparkpoolFromWorkspace[i].Type);
                    Assert.Equal(CommonData.Location, sparkpoolFromWorkspace[i].Location);
                    break;
                }
            }

            Assert.True(isFound, string.Format("Sparkpool created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete sqlpool
            SynapseClient.BigDataPools.Delete(CommonData.ResourceGroupName, workspaceName, sparkpoolName);
            firstPage = SynapseClient.BigDataPools.ListByWorkspace(CommonData.ResourceGroupName, workspaceName);
            var sparkpoolAfterDelete = SynapseManagementTestUtilities.ListResources(firstPage, SynapseClient.BigDataPools.ListByWorkspaceNext);
            Assert.True(sparkpoolCount - 1 == sparkpoolAfterDelete.Count);
        }
    }
}
