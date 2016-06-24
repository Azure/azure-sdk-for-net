// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WorkflowAccessKeysScenarioTests")]
    public class WorkflowAccessKeysScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void CreateAndDelete()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowAccessKeysScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
				string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic,
                        },
                        State = WorkflowState.Enabled,
                        Definition = JToken.Parse(this.simpleDefinition)
                    });

				// Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

				// Delete the access key
                client.WorkflowAccessKeys.Delete(this.resourceGroupName, workflowName, accessKeyName);

				// List access key and verify only one key
                var accesskeys = client.WorkflowAccessKeys.List(this.resourceGroupName, workflowName);
                Assert.Equal(1, accesskeys.Count());
            }
        }

		[Fact]
        public void CreateAndList()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowAccessKeysScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic,
                        },
                        State = WorkflowState.Enabled,
                        Definition = JToken.Parse(this.simpleDefinition)
                    });

                // Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

                // List access key and verify the response
                var accesskeys = client.WorkflowAccessKeys.List(this.resourceGroupName, workflowName);
                Assert.Equal(2, accesskeys.Count());
            }
        }

		[Fact]
		public void RegenerateAndListSecretKeys()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowAccessKeysScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic,
                        },
                        State = WorkflowState.Enabled,
                        Definition = JToken.Parse(this.simpleDefinition)
                    });

                // Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

                // Regenerate seret key
                var secretKeys = client.WorkflowAccessKeys.RegenerateSecretKey(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    KeyType.Primary
                    );

                Assert.NotEmpty(secretKeys.PrimarySecretKey);
                Assert.NotEmpty(secretKeys.SecondarySecretKey);

				// List secrets and verify response
                secretKeys = client.WorkflowAccessKeys.ListSecretKeys(this.resourceGroupName, workflowName, accessKeyName);
                Assert.NotEmpty(secretKeys.PrimarySecretKey);
                Assert.NotEmpty(secretKeys.SecondarySecretKey);
            }
        }
    }
}
