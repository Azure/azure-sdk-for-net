//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class WorkflowsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void CreateAndDeleteWorkflow()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic
                        },
                        Definition = JToken.Parse(this.definition)
                    });

                // Get the workflow and verify the content
                var workflow = client.Workflows.Get(this.resourceGroupName, workflowName);
                Assert.Equal(WorkflowState.Enabled, workflow.State);
                Assert.Equal(this.location, workflow.Location);
                Assert.Equal(SkuName.Basic, workflow.Sku.Name);
                Assert.NotEmpty(workflow.Definition.ToString());

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void CreateAndEnableDisableWorkflow()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Free
                        },
                        State = WorkflowState.Disabled,
                        Definition = JToken.Parse(this.definition)
                    });

                // Verify the response
                Assert.Equal(workflowName, workflow.Name);
                Assert.Equal(WorkflowState.Disabled, workflow.State);

                // Enable the workflow
                client.Workflows.Enable(this.resourceGroupName, workflowName);

                // Get the workflow and verify it's enabled
                workflow = client.Workflows.Get(this.resourceGroupName, workflowName);
                Assert.Equal(WorkflowState.Enabled, workflow.State);

                // Disable the workflow
                client.Workflows.Disable(this.resourceGroupName, workflowName);

                // Get the workflow and verify it's disabled
                workflow = client.Workflows.Get(this.resourceGroupName, workflowName);
                Assert.Equal(WorkflowState.Disabled, workflow.State);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void ListWorkflow()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Free
                        },
                        State = WorkflowState.Disabled,
                        Definition = JToken.Parse(this.definition)
                    });

                // Verify the response
                Assert.Equal(workflowName, workflow.Name);
                Assert.Equal(WorkflowState.Disabled, workflow.State);

                // List the workflow in resource group
                var lists = client.Workflows.ListByResourceGroup(this.resourceGroupName);

                Assert.NotEmpty(lists);
                workflow = lists.First();
                Assert.NotNull(workflow.Id);
                Assert.NotNull(workflow.Name);
                Assert.NotNull(workflow.Type);

                lists = client.Workflows.ListBySubscription();

                Assert.NotEmpty(lists);
                workflow = lists.First();
                Assert.NotNull(workflow.Id);
                Assert.NotNull(workflow.Name);
                Assert.NotNull(workflow.Type);
                
                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void ValidateAndRunWorkflow()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic
                        },
                        Definition = JToken.Parse(this.definition)
                    });

                // Validate a workflow
                client.Workflows.Validate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Free
                        },
                        Definition = JToken.Parse(this.definition)
                    });

                Assert.Throws<CloudException>(() =>
                {
                    // Validate an invlaid workflow
                    client.Workflows.Validate(
                        this.resourceGroupName,
                        workflowName,
                        new Workflow
                        {
                            Location = this.location,
                            Sku = new Sku()
                            {
                                Name = SkuName.Free
                            },
                            Definition = "invalid definition"
                        });
                });
            }
        }

        [Fact]
        public void DeleteAllWorkflows()
        {
            using (MockContext context = MockContext.Start())
            {
                var client = this.GetLogicManagementClient();

                var workflows = client.Workflows.ListByResourceGroup(this.resourceGroupName);

                foreach (var workflow in workflows)
                {
                    client.Workflows.Delete(this.resourceGroupName, workflow.Name);
                }

                while (!string.IsNullOrEmpty(workflows.NextPageLink))
                {
                    workflows = client.Workflows.ListByResourceGroupNext(workflows.NextPageLink);

                    foreach (var workflow in workflows)
                    {
                        client.Workflows.Delete(this.resourceGroupName, workflow.Name);
                    }
                }

                workflows = client.Workflows.ListByResourceGroup(this.resourceGroupName);

                Assert.Equal(0, workflows.Count());
            }
        }

        // TODO Comment out for now.  Fix it after below issue is resolved.
        // https://github.com/Azure/autorest/issues/214
        // [Fact]
        public void UpdateAndRunWorkflow()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = new Sku()
                        {
                            Name = SkuName.Free
                        },
                        Definition = JToken.Parse(this.definition)
                    });

                // Verify the response
                Assert.Equal(workflowName, workflow.Name);
                Assert.Equal(WorkflowState.Enabled, workflow.State);
                Assert.Equal(null, workflow.Tags);

                // Update the workflow
                workflow = new Workflow()
                    {
                        Tags = new Dictionary<string, string>()
                    };
                workflow.Tags.Add("abc", "def");
                workflow = client.Workflows.Update(this.resourceGroupName, workflowName, workflow);

                Assert.Equal(1, workflow.Tags.Count);

            }
        }
    }
}
