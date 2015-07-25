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

    public class WorkflowTriggerHistoriesScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void ListHistory()
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
                        Definition = JToken.Parse(this.simpleTriggerDefinition)
                    });

                // List the histories
                var histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");

                // Run the trigger
                client.WorkflowTriggers.Run(this.resourceGroupName, workflowName, "httpTrigger");

                // List the histories
                histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");
                Assert.NotEmpty(histories);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }

        [Fact]
        public void GetHistory()
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
                        Definition = JToken.Parse(this.simpleTriggerDefinition)
                    });

                // Run the trigger
                client.WorkflowTriggers.Run(this.resourceGroupName, workflowName, "httpTrigger");

                // List the histories
                var histories = client.WorkflowTriggerHistories.List(this.resourceGroupName, workflowName, "httpTrigger");
                Assert.NotEmpty(histories);

                // Get the history
                var history = client.WorkflowTriggerHistories.Get(this.resourceGroupName, workflowName, "httpTrigger", histories.First().Name);

                Assert.NotNull(history.StartTime);
                Assert.NotNull(history.EndTime);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
