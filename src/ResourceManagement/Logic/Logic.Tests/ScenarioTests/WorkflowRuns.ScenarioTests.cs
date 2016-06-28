// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WorkflowRunsScenarioTests")]
    public class WorkflowRunsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void RunGetAndListRuns()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowRunsScenarioTests"))
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

                var firstRun = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());
                var secondRun = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());

                var run = client.WorkflowRuns.Get(this.resourceGroupName, workflowName, secondRun.Name);
                Assert.Equal(secondRun.Name, run.Name);

                var list = client.WorkflowRuns.List(this.resourceGroupName, workflowName, new ODataQuery<WorkflowRunFilter>(r => r.Status == WorkflowStatus.Failed) { Top = 1 });
                Assert.Equal(1, list.Count());

                var list2 = client.WorkflowRuns.List(this.resourceGroupName, workflowName);
                Assert.NotEmpty(list2);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
