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
    public class WorkflowTriggerHistoriesScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void WorkflowTriggerHistories_Get_OK()
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

                var preHistories = client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);
                Assert.Empty(preHistories);

                client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);

                var postHistories = client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);
                var retrievedHistory = client.WorkflowTriggerHistories.Get(Constants.DefaultResourceGroup,
                    workflowName,
                    Constants.DefaultTriggerName,
                    postHistories.First().Name);

                this.ValidateHistory(retrievedHistory);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }

        [Fact]
        public void WorkflowTriggerHistories_List_OK()
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

                var preHistories = client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);
                Assert.Empty(preHistories);

                client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);
                client.WorkflowTriggers.Run(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);

                var postHistories = client.WorkflowTriggerHistories.List(Constants.DefaultResourceGroup, workflowName, Constants.DefaultTriggerName);

                Assert.Equal(2, postHistories.Count());
                foreach (var history in postHistories)
                {
                    this.ValidateHistory(history);
                }

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
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

