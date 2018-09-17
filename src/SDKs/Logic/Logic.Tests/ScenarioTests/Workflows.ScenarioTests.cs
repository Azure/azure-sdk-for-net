// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
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
    public class WorkflowsScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        private readonly string workflowName;
        private readonly Workflow workflow;

        public WorkflowsScenarioTests()
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
        public void Workflows_Create_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.ValidateWorkflow(this.workflow, createdWorkflow);
        }

        [Fact]
        public void Workflows_Get_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var retrievedWorkflow = this.client.Workflows.Get(Constants.DefaultResourceGroup, this.workflowName);

            this.ValidateWorkflow(this.workflow, retrievedWorkflow);
        }

        [Fact]
        public void Workflows_List_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var workflowName2 = TestUtilities.GenerateName(Constants.WorkflowPrefix);
            var workflow2 = this.CreateWorkflow(workflowName2);
            workflow2.State = WorkflowState.Disabled;
            var createdWorkflow2 = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                workflowName2,
                workflow2);

            var workflowName3 = TestUtilities.GenerateName(Constants.WorkflowPrefix);
            var workflow3 = this.CreateWorkflow(workflowName3);
            workflow3.State = WorkflowState.Disabled;
            var createdWorkflow3 = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                workflowName3,
                workflow3);

            var workflows = this.client.Workflows.ListByResourceGroup(Constants.DefaultResourceGroup, new ODataQuery<WorkflowFilter>(f => f.State == WorkflowState.Disabled) { Top = 2 });

            Assert.Equal(2, workflows.Count());
            this.ValidateWorkflow(workflow2, workflows.Single(x => x.Name == workflow2.Name));
            this.ValidateWorkflow(workflow3, workflows.Single(x => x.Name == workflow3.Name));

            // Not handled by the dispose method
            this.client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName2);
            this.client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName3);
        }

        [Fact]
        public void Workflows_Update_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var updatesToBeMade = new Workflow
            {
                Tags = new Dictionary<string, string>
                {
                    { "abc", "def" }
                }
            };
            var updatedWorkflow = this.client.Workflows.Update(Constants.DefaultResourceGroup, this.workflowName, updatesToBeMade);

            Assert.Equal("def", updatedWorkflow.Tags["abc"]);
        }

        [Fact]
        public void Workflows_Delete_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.client.Workflows.Delete(Constants.DefaultResourceGroup, this.workflowName);
            Assert.Throws<CloudException>(() => this.client.Workflows.Get(Constants.DefaultResourceGroup, this.workflowName));
        }

        [Fact]
        public void Workflows_Disable_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.client.Workflows.Disable(Constants.DefaultResourceGroup, this.workflowName);
            var retrievedWorkflow = this.client.Workflows.Get(Constants.DefaultResourceGroup, this.workflowName);

            Assert.Equal(WorkflowState.Disabled, retrievedWorkflow.State);
        }

        [Fact]
        public void Workflows_Enable_OK()
        {
            this.workflow.State = WorkflowState.Disabled;
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.client.Workflows.Enable(Constants.DefaultResourceGroup, this.workflowName);
            var retrievedWorkflow = this.client.Workflows.Get(Constants.DefaultResourceGroup, this.workflowName);

            Assert.Equal(WorkflowState.Enabled, retrievedWorkflow.State);
        }

        [Fact]
        public void Workflows_Validate_OK()
        {
            this.client.Workflows.ValidateByLocation(Constants.DefaultResourceGroup,
                    Constants.DefaultLocation,
                    this.workflowName,
                    this.workflow);
        }

        [Fact]
        public void Workflows_Validate_Exception()
        {
            this.workflow.Definition = "Invalid Definition";

            Assert.Throws<CloudException>(() => this.client.Workflows.ValidateByLocation(Constants.DefaultResourceGroup,
                Constants.DefaultLocation,
                this.workflowName,
                this.workflow));
        }

        [Fact]
        public void Workflows_RegenerateAccessKey_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            this.client.Workflows.RegenerateAccessKey(Constants.DefaultResourceGroup, this.workflowName, new RegenerateActionParameter(KeyType.Primary));
            var retrievedWorkflow = this.client.Workflows.Get(Constants.DefaultResourceGroup, this.workflowName);

            Assert.NotEqual(this.workflow.AccessEndpoint, retrievedWorkflow.AccessEndpoint);
        }

        [Fact]
        public void Workflows_ListSwagger_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var retrievedSwagger = this.client.Workflows.ListSwagger(Constants.DefaultResourceGroup, this.workflowName) as JObject;
        }

        [Fact]
        public void Workflows_GenerateUpgradedDefinition_OK()
        {
            this.workflow.Definition = this.WorkflowToBeUpgradedDefinition;
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var upgradedDefinition = this.client.Workflows.GenerateUpgradedDefinition(Constants.DefaultResourceGroup,
                this.workflowName,
                new GenerateUpgradedDefinitionParameters
                {
                    TargetSchemaVersion = "2016-06-01"
                }) as Workflow;
        }

        private void ValidateWorkflow(Workflow expected, Workflow actual)
        {
            // Freshly created workflows don't have a state yet
            if(expected.State != null)
            {
                Assert.Equal(expected.State, actual.State);
            }
            Assert.Equal(expected.Definition, actual.Definition);
            Assert.Equal(expected.Tags, actual.Tags);
            Assert.NotNull(actual.ChangedTime);
            Assert.NotNull(actual.CreatedTime);
        }

        private JToken WorkflowToBeUpgradedDefinition => JToken.Parse(@"
        {
            '$schema': 'https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2015-08-01-preview/workflowdefinition.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {},
            'triggers': {},
            'actions': {},
            'outputs': {}
        }");
    }
}
