// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("WorkflowVersionsScenarioTests")]
    public class WorkflowVersionsScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void WorkflowVersions_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);
                var createdWorkflow = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName,
                    workflow);

                var workflowVersion = client.WorkflowVersions.Get(Constants.DefaultResourceGroup, workflowName, createdWorkflow.Version);

                this.ValidateWorkflowVersion(workflow, workflowVersion);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowVersions_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);
                var createdWorkflow = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName,
                    workflow);

                var workflowVersions = client.WorkflowVersions.List(Constants.DefaultResourceGroup, workflowName);

                foreach (var workflowVersion in workflowVersions)
                {
                    this.ValidateWorkflowVersion(workflow, workflowVersion);
                }

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        private void ValidateWorkflowVersion(Workflow expected, WorkflowVersion actual)
        {
            Assert.Equal(expected.Definition, actual.Definition);
            Assert.Equal(expected.Tags, actual.Tags);
            Assert.NotNull(actual.ChangedTime);
            Assert.NotNull(actual.CreatedTime);
        }
    }
}

