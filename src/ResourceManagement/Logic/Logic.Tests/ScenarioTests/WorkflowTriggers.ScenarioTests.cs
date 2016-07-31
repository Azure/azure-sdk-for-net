// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WorkflowTriggersScenarioTests")]
    public class WorkflowTriggersScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void ListNoTrigger()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowTriggersScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.definition)
                    });

                // List the triggers
                var triggers = client.WorkflowTriggers.List(this.resourceGroupName, workflowName);

                Assert.Equal(0, triggers.Count());

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void GetAndListTriggers()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowTriggersScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.simpleTriggerDefinition)
                    });

                // List the triggers
                var triggers = client.WorkflowTriggers.List(this.resourceGroupName, workflowName);

                Assert.Equal(1, triggers.Count());

                var trigger = client.WorkflowTriggers.Get(this.resourceGroupName, workflowName, "httpTrigger");

                Assert.NotNull(trigger.CreatedTime);
                Assert.NotNull(trigger.ChangedTime);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void RunTrigger()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowTriggersScenarioTests"))
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetWorkflowClient(context);
                
                // Create a workflow
                var workflow = client.Workflows.CreateOrUpdate(
                    resourceGroupName: this.resourceGroupName,
                    workflowName: workflowName,
                    workflow: new Workflow
                    {
                        Location = this.location,
                        Sku = this.Sku,
                        Definition = JToken.Parse(this.simpleTriggerDefinition)
                    });

                // Run the trigger
                client.WorkflowTriggers.Run(this.resourceGroupName, workflowName, "httpTrigger");

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
