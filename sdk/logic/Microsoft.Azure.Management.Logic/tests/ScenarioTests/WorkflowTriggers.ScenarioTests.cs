// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("WorkflowTriggersScenarioTests")]
    public class WorkflowTriggersScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void WorkflowTriggers_Get_OK()
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

                var retrievedTrigger = client.WorkflowTriggers.Get(Constants.DefaultResourceGroup,
                    workflowName,
                    Constants.DefaultTriggerName);

                this.ValidateTrigger(retrievedTrigger);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggers_List_OK()
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

                var triggers = client.WorkflowTriggers.List(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);

                this.ValidateTrigger(triggers.First());

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggers_GetJsonSchema_OK()
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

                var jsonSchema = client.WorkflowTriggers.GetSchemaJson(Constants.DefaultResourceGroup,
                    workflowName,
                    Constants.DefaultTriggerName);

                Assert.NotNull(jsonSchema);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggers_ListCallbackUrl_OK()
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

                var callbackUrl = client.WorkflowTriggers.ListCallbackUrl(Constants.DefaultResourceGroup,
                    workflowName,
                    Constants.DefaultTriggerName);

                Assert.NotEmpty(callbackUrl.BasePath);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggers_Run_OK()
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

                client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggers_Reset_Exception()
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

                Assert.Throws<CloudException>(() => client.WorkflowTriggers.Reset(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName));

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
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

