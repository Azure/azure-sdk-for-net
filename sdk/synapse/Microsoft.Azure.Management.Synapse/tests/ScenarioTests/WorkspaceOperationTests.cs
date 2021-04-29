// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;
using System.Threading;
using Microsoft.Rest.Azure;
using System.Linq;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class WorkspaceOperationTests : SynapseManagementTestBase
    {
        [Fact]
        public void TestWorkspaceLifeCycle()
        {
            TestInitialize();

            // create workspace
            string workspaceName = TestUtilities.GenerateName("synapsesdkworkspace");
            var createParams = CommonData.PrepareWorkspaceCreateParams();
            var workspaceCreate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createParams);
            Assert.Equal(CommonTestFixture.WorkspaceType, workspaceCreate.Type);
            Assert.Equal(workspaceName, workspaceCreate.Name);
            Assert.Equal(CommonData.Location, workspaceCreate.Location);
            for(int i=0; i<60; i++)
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

            // update workspace
            Dictionary<string, string> tagsToUpdate = new Dictionary<string, string>{{ "TestTag", "TestUpdate" }};
            createParams.Tags = tagsToUpdate;
            var workspaceUpdate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createParams);
            Assert.NotNull(workspaceUpdate.Tags);
            Assert.Equal("TestUpdate", workspaceUpdate.Tags["TestTag"]);

            // list workspace from resource group
            var workspaceFromResourceGroup = SynapseClient.Workspaces.ListByResourceGroup(CommonData.ResourceGroupName).ToList();
            Assert.True(1 <= workspaceFromResourceGroup.Count);
            bool isFound = false;
            int workspaceCount = workspaceFromResourceGroup.Count;
            for(int i = 0; i< workspaceCount; i++)
            {
                if (workspaceFromResourceGroup[i].Name.Equals(workspaceName))
                {
                    isFound = true;
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceFromResourceGroup[i].Type);
                    Assert.Equal(CommonData.Location, workspaceFromResourceGroup[i].Location);
                    break;
                }
            }

            Assert.True(isFound, string.Format("Workspace created earlier is not found when listing all in resource group {0}", CommonData.ResourceGroupName));

            // list workspace from subscription
            var workspaceFromSubscription = SynapseClient.Workspaces.List().ToList();
            Assert.True(1 <= workspaceFromSubscription.Count);
            isFound = false;
            for (int i = 0; i < workspaceFromSubscription.Count; i++)
            {
                if (workspaceFromSubscription[i].Name.Equals(workspaceName))
                {
                    isFound = true;
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceFromSubscription[i].Type);
                    Assert.Equal(CommonData.Location, workspaceFromSubscription[i].Location);
                    break;
                }
            }

            Assert.True(isFound, string.Format("Workspace created earlier is not found when listing all in subscription {0}", CommonData.SubscriptionId));

            try
            {
                // delete workspace
                SynapseClient.Workspaces.Delete(CommonData.ResourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                Assert.Equal(404, (int)ex.Response.StatusCode);
                Assert.Contains($"Can not perform requested operation on nested resource. Parent resource '{workspaceName}' not found.", ex.Body.Message);
            }

            var workspaceAfterDelete = SynapseClient.Workspaces.ListByResourceGroup(CommonData.ResourceGroupName).ToList();
            Assert.True(workspaceCount-1 == workspaceAfterDelete.Count);
        }
    }
}
