// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("WorkflowTriggerHistoriesScenarioTests")]
    public class WorkflowTriggerHistoriesScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        private readonly string workflowName;
        private readonly Workflow workflow;

        public WorkflowTriggerHistoriesScenarioTests()
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
        public void WorkflowTriggerHistories_Get_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var preHistories = this.client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);
            Assert.Empty(preHistories);

            this.client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);

            var postHistories = this.client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);
            var retrievedHistory = this.client.WorkflowTriggerHistories.Get(Constants.DefaultResourceGroup, 
                this.workflowName, 
                Constants.DefaultTriggerName, 
                postHistories.First().Name);

            this.ValidateHistory(retrievedHistory);
        }

        [Fact]
        public void WorkflowTriggerHistories_List_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);

            var preHistories = this.client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);
            Assert.Empty(preHistories);

            this.client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);
            this.client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);

            var postHistories = this.client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, this.workflowName, Constants.DefaultTriggerName);

            Assert.Equal(2, postHistories.Count());
            foreach (var history in postHistories)
            {
                this.ValidateHistory(history);
            }
        }

        private void ValidateHistory(WorkflowTriggerHistory actual)
        {
            Assert.NotEmpty(actual.Correlation.ClientTrackingId);
            Assert.True(actual.Fired);
            Assert.NotEmpty(actual.Id);
            Assert.NotEmpty(actual.Run.Name);
            Assert.NotNull(actual.StartTime);
            Assert.NotNull(actual.EndTime);
        }
    }
}
