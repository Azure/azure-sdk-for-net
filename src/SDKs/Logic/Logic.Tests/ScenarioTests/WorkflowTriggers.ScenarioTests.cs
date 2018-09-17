// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("WorkflowTriggersScenarioTests")]
    public class WorkflowTriggersScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        private readonly string workflowName;
        private readonly Workflow workflow;

        public WorkflowTriggersScenarioTests()
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
        public void WorkflowTriggers_Get_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var retrievedTrigger = this.client.WorkflowTriggers.Get(Constants.DefaultResourceGroup,
                this.workflowName,
                Constants.DefaultTriggerName);

            this.ValidateTrigger(retrievedTrigger);
        }

        [Fact]
        public void WorkflowTriggers_List_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var triggers = this.client.WorkflowTriggers.List(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);

            this.ValidateTrigger(triggers.First());
        }

        [Fact]
        public void WorkflowTriggers_GetJsonSchema_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var jsonSchema = this.client.WorkflowTriggers.GetSchemaJson(Constants.DefaultResourceGroup,
                this.workflowName,
                Constants.DefaultTriggerName);

            Assert.NotNull(jsonSchema);
        }

        [Fact]
        public void WorkflowTriggers_ListCallbackUrl_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var callbackUrl = this.client.WorkflowTriggers.ListCallbackUrl(Constants.DefaultResourceGroup,
                this.workflowName,
                Constants.DefaultTriggerName);

            Assert.NotEmpty(callbackUrl.BasePath);
        }

        [Fact]
        public void WorkflowTriggers_Run_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);
        }

        [Fact]
        public void WorkflowTriggers_Reset_Exception()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            Assert.Throws<CloudException>(() => this.client.WorkflowTriggers.Reset(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName));
        }

        private void ValidateTrigger(WorkflowTrigger actual)
        {
            Assert.Equal(Constants.DefaultTriggerName, actual.Name);
            Assert.Equal("Succeeded", actual.ProvisioningState);
            Assert.Equal("Enabled", actual.State);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);
        }
    }
}
