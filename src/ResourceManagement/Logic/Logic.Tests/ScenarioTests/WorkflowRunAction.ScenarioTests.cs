//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Test.Azure.Management.Logic
{
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class WorkflowRunActionsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void ListAndGetActions()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                var client = this.GetLogicManagementClient();

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

                // Run the workflow
                var run = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());

                // List the actions
                var actions = client.WorkflowRunActions.List(this.resourceGroupName, workflowName, run.Name);

                Assert.Equal(1, actions.Count());
                var action = actions.First();
                Assert.NotNull(action.StartTime);
                Assert.NotNull(action.EndTime);
                Assert.NotNull(action.Code);
                Assert.NotNull(action.Name);

                // Get the action
                action = client.WorkflowRunActions.Get(this.resourceGroupName, workflowName, run.Name, action.Name);

                Assert.NotNull(action.StartTime);
                Assert.NotNull(action.EndTime);
                Assert.NotNull(action.Code);
                Assert.NotNull(action.Name);
            }
        }
    }
}
