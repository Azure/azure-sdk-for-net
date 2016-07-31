// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WorkflowVersionsScenarioTests")]
    public class WorkflowVersionsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void CreateAndGetWorkflowVersion()
        {
            using (MockContext context = MockContext.Start("Test.Azure.Management.Logic.WorkflowVersionsScenarioTests"))
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

                // Get the workflow version and verify the content
                var version = client.WorkflowVersions.Get(this.resourceGroupName, workflowName, workflow.Version);
                Assert.Equal(WorkflowState.Enabled, workflow.State);
                Assert.Equal(this.Sku.Name, workflow.Sku.Name);
                Assert.NotEmpty(workflow.Definition.ToString());

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
