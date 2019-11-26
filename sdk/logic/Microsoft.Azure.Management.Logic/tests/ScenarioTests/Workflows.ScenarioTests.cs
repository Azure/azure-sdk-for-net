// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    [Collection("WorkflowsScenarioTests")]
    public class WorkflowsScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void Workflows_Create_OK()
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

                this.ValidateWorkflow(workflow, createdWorkflow);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_Get_OK()
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

                var retrievedWorkflow = client.Workflows.Get(Constants.DefaultResourceGroup, workflowName);

                this.ValidateWorkflow(workflow, retrievedWorkflow);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName1 = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow1 = this.CreateWorkflow(workflowName1);
                var createdWorkflow = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName1,
                    workflow1);

                var workflowName2 = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow2 = this.CreateWorkflow(workflowName2);
                workflow2.State = WorkflowState.Disabled;
                var createdWorkflow2 = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName2,
                    workflow2);

                var workflowName3 = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow3 = this.CreateWorkflow(workflowName3);
                workflow3.State = WorkflowState.Disabled;
                var createdWorkflow3 = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName3,
                    workflow3);

                var workflows = client.Workflows.ListByResourceGroup(Constants.DefaultResourceGroup, new ODataQuery<WorkflowFilter>(f => f.State == WorkflowState.Disabled) { Top = 2 });

                Assert.Equal(2, workflows.Count());
                this.ValidateWorkflow(workflow2, workflows.Single(x => x.Name == workflow2.Name));
                this.ValidateWorkflow(workflow3, workflows.Single(x => x.Name == workflow3.Name));

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName1);
                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName2);
                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName3);
            }

        }

        [Fact]
        public void Workflows_Update_OK()
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

                var updatesToBeMade = new Workflow
                {
                    Tags = new Dictionary<string, string>
                    {
                        { "abc", "def" }
                    }
                };
                var updatedWorkflow = client.Workflows.Update(Constants.DefaultResourceGroup, workflowName, updatesToBeMade);

                Assert.Equal("def", updatedWorkflow.Tags["abc"]);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_UpdateWithIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);

                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);
                workflow.IntegrationAccount = new ResourceReference
                {
                    Id = createdIntegrationAccount.Id
                };
                var createdWorkflow = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName,
                    workflow);

                var updatesToBeMade = new Workflow
                {
                    Tags = new Dictionary<string, string>
                    {
                        { "abc", "def" }
                    }
                };

                var updatedWorkflow = client.Workflows.Update(Constants.DefaultResourceGroup, workflowName, updatesToBeMade);

                Assert.Equal("def", updatedWorkflow.Tags["abc"]);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_Delete_OK()
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

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
                Assert.Throws<CloudException>(() => client.Workflows.Get(Constants.DefaultResourceGroup, workflowName));

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_Disable_OK()
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

                client.Workflows.Disable(Constants.DefaultResourceGroup, workflowName);
                var retrievedWorkflow = client.Workflows.Get(Constants.DefaultResourceGroup, workflowName);

                Assert.Equal(WorkflowState.Disabled, retrievedWorkflow.State);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_Enable_OK()
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

                client.Workflows.Enable(Constants.DefaultResourceGroup, workflowName);
                var retrievedWorkflow = client.Workflows.Get(Constants.DefaultResourceGroup, workflowName);

                Assert.Equal(WorkflowState.Enabled, retrievedWorkflow.State);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_Validate_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);

                client.Workflows.ValidateByLocation(Constants.DefaultResourceGroup,
                        Constants.DefaultLocation,
                        workflowName,
                        workflow);
            }
        }

        [Fact]
        public void Workflows_Validate_Exception()
        {

            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);
                workflow.Definition = "Invalid Definition";

                Assert.Throws<CloudException>(() => client.Workflows.ValidateByLocation(Constants.DefaultResourceGroup,
                    Constants.DefaultLocation,
                    workflowName,
                    workflow));
            }
        }

        [Fact]
        public void Workflows_RegenerateAccessKey_OK()
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

                client.Workflows.RegenerateAccessKey(Constants.DefaultResourceGroup, workflowName, new RegenerateActionParameter(KeyType.Primary));
                var retrievedWorkflow = client.Workflows.Get(Constants.DefaultResourceGroup, workflowName);

                Assert.NotEqual(workflow.AccessEndpoint, retrievedWorkflow.AccessEndpoint);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_ListSwagger_OK()
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

                var retrievedSwagger = client.Workflows.ListSwagger(Constants.DefaultResourceGroup, workflowName) as JObject;

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void Workflows_GenerateUpgradedDefinition_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var workflowName = TestUtilities.GenerateName(Constants.WorkflowPrefix);
                var workflow = this.CreateWorkflow(workflowName);
                workflow.Definition = this.WorkflowToBeUpgradedDefinition;
                var createdWorkflow = client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                    workflowName,
                    workflow);

                var upgradedDefinition = client.Workflows.GenerateUpgradedDefinition(Constants.DefaultResourceGroup,
                    workflowName,
                    new GenerateUpgradedDefinitionParameters
                    {
                        TargetSchemaVersion = "2016-06-01"
                    }) as Workflow;

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        private void ValidateWorkflow(Workflow expected, Workflow actual)
        {
            // Freshly created workflows don't have a state yet
            if (expected.State != null)
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

