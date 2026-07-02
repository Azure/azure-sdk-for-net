// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Databricks.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Databricks.Tests.Scenario
{
    [TestFixture]
    [Ignore("Databricks workspace scenario recording is pending; requires a configured Record-mode authentication environment.")]
    public class DatabricksWorkspaceTests : DatabricksManagementTestBase
    {
        public DatabricksWorkspaceTests()
            : base(true)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetAll_ListsDatabricksWorkspaces()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, "databricks-rg-", AzureLocation.WestUS);
            DatabricksWorkspaceResource workspace = null;

            try
            {
                DatabricksWorkspaceCollection collection = resourceGroup.GetDatabricksWorkspaces();
                string workspaceName = Recording.GenerateAssetName("databricks-ws-");
                DatabricksWorkspaceData data = new DatabricksWorkspaceData(AzureLocation.WestUS, ComputeMode.Serverless)
                {
                    Sku = new DatabricksSku("premium")
                };

                ArmOperation<DatabricksWorkspaceResource> operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, data);
                workspace = operation.Value;

                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(workspace, Is.Not.Null);
                Assert.That(workspace.Data.Name, Is.EqualTo(workspaceName));
                Assert.That(workspace.Data.Location, Is.EqualTo(AzureLocation.WestUS));

                bool existsInResourceGroup = false;
                await foreach (DatabricksWorkspaceResource item in collection.GetAllAsync())
                {
                    Assert.That(item, Is.Not.Null);
                    if (item.Id == workspace.Id)
                    {
                        existsInResourceGroup = true;
                        break;
                    }
                }

                Assert.That(existsInResourceGroup, Is.True);

                bool existsInSubscription = false;
                await foreach (DatabricksWorkspaceResource item in DefaultSubscription.GetDatabricksWorkspacesAsync())
                {
                    Assert.That(item, Is.Not.Null);
                    if (item.Id == workspace.Id)
                    {
                        existsInSubscription = true;
                        break;
                    }
                }

                Assert.That(existsInSubscription, Is.True);
            }
            finally
            {
                try
                {
                    if (workspace != null)
                    {
                        await workspace.DeleteAsync(WaitUntil.Completed, forceDeletion: true);
                    }
                }
                finally
                {
                    await resourceGroup.DeleteAsync(WaitUntil.Completed);
                }
            }
        }
    }
}
