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

    [Collection("WorkflowRunActionsScenarioTests")]
    public class WorkflowRunActionsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void ListAndGetActions()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowRunActionsScenarioTests"))
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
                        Sku = new Sku()
                        {
                            Name = SkuName.Basic
                        },
                        State = WorkflowState.Enabled,
                        Definition = JToken.Parse(this.simpleDefinition)
                    });

                // Run the workflow
                var run = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());

                // List the actions
                var actions = client.WorkflowRunActions.List(this.resourceGroupName, workflowName, run.Name);

                Assert.Equal(1, actions.Count());
                var action = actions.First();
                Assert.NotNull(action.StartTime);
                Assert.NotNull(action.EndTime);
                Assert.NotNull(action.Code);
                Assert.NotNull(action.Name);

                // Get the action
                action = client.WorkflowRunActions.Get(this.resourceGroupName, workflowName, run.Name, action.Name);

                Assert.NotNull(action.StartTime);
                Assert.NotNull(action.EndTime);
                Assert.NotNull(action.Code);
                Assert.NotNull(action.Name);
            }
        }
    }
}
