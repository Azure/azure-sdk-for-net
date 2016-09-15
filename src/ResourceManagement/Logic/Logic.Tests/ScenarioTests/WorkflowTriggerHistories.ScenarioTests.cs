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

    [Collection("WorkflowTriggerHistoriesScenarioTests")]
    public class WorkflowTriggerHistoriesScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void ListHistory()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowTriggerHistoriesScenarioTests"))
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

                // List the histories
                var histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");

                // Run the trigger
                client.WorkflowTriggers.Run(this.resourceGroupName, workflowName, "httpTrigger");

                // List the histories
                histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");
                Assert.NotEmpty(histories);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void GetHistory()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowTriggerHistoriesScenarioTests"))
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

                // List the histories
                var histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");
                Assert.NotEmpty(histories);

                // Get the history
                var history = client.WorkflowTriggerHistories.Get(this.resourceGroupName, workflowName, "httpTrigger", histories.First().Name);

                Assert.NotNull(history.StartTime);
                Assert.NotNull(history.EndTime);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
