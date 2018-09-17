// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Xunit;

    [Collection("WorkflowVersionsScenarioTests")]
    public class WorkflowVersionsScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        private readonly string workflowName;
        private readonly Workflow workflow;

        public WorkflowVersionsScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
            this.workflow = this.CreateWorkflow(this.workflowName);
        }

        public void Dispose()
        {
            this.client.Workflows.Delete(Constants.DefaultResourceGroup, this.workflowName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void WorkflowVersions_Get_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var workflowVersion = this.client.WorkflowVersions.Get(Constants.DefaultResourceGroup, this.workflowName, createdWorkflow.Version);

            this.ValidateWorkflowVersion(this.workflow, workflowVersion);
        }

        [Fact]
        public void WorkflowVersions_List_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var workflowVersions = this.client.WorkflowVersions.List(Constants.DefaultResourceGroup, this.workflowName);

            foreach(var workflowVersion in workflowVersions)
            {
                this.ValidateWorkflowVersion(this.workflow, workflowVersion);
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
