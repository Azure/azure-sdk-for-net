// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WorkflowsScenarioTests")]
    public class WorkflowsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void CreateAndDeleteWorkflow()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.definition)                        
                    });

                // Get the workflow and verify the content
                var workflow = client.Workflows.Get(this.resourceGroupName, workflowName);
                Assert.Equal(WorkflowState.Enabled, workflow.State);
                Assert.Equal(this.location, workflow.Location);
                Assert.Equal(this.Sku.Name, workflow.Sku.Name);
                Assert.NotEmpty(workflow.Definition.ToString());

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void CreateAndEnableDisableWorkflow()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
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
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                string workflowName2 = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        State = WorkflowState.Disabled,
                        Definition = JToken.Parse(this.definition)
                    });

                // Verify the response
                Assert.Equal(workflowName, workflow.Name);
                Assert.Equal(WorkflowState.Disabled, workflow.State);

                // Create another workflow
                var workflow2 = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName2,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        State = WorkflowState.Disabled,
                        Definition = JToken.Parse(this.definition)
                    });

                // List the workflow in resource group
                var lists = client.Workflows.ListByResourceGroup(this.resourceGroupName, new ODataQuery<WorkflowFilter>(f => f.State == WorkflowState.Disabled) { Top = 1 });

                Assert.Equal(1, lists.Count());

                // List the workflow in resource group
                lists = client.Workflows.ListByResourceGroup(this.resourceGroupName);

                Assert.True(lists.Count() > 1);
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
        public void ValidateWorkflow()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.simpleTriggerDefinition)
                    });

                // Validate a workflow
                client.Workflows.Validate(
                    this.resourceGroupName,
                    this.location,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.definition)
                    });

                Assert.Throws<CloudException>(() =>
                {
                    // Validate an invlaid workflow
                    client.Workflows.Validate(
                        this.resourceGroupName,
                        this.location,
                        workflowName,
                        new Workflow
                        {
                            Location = this.location,
                            Sku = this.Sku,
                            Definition = "invalid definition"
                        });
                });
            }
        }

        [Fact]
        public void DeleteAllWorkflows()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                var client = this.GetWorkflowClient(context);
                
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

        [Fact]
        public void UpdateWorkflow()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowsScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
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
