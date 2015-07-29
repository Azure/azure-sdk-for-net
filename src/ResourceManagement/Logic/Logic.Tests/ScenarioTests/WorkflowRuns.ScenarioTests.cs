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

    [Collection("WorkflowRunsScenarioTests")]
    public class WorkflowRunsScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void RunGetAndListRuns()
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

                var firstRun = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());
                var secondRun = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());

                var run = client.WorkflowRuns.Get(this.resourceGroupName, workflowName, secondRun.Name);
                Assert.Equal(secondRun.Name, run.Name);

                var list = client.WorkflowRuns.List(this.resourceGroupName, workflowName, 1, r => r.Status == WorkflowStatus.Failed);
                Assert.Equal(1, list.Count());

                var list2 = client.WorkflowRuns.List(this.resourceGroupName, workflowName);
                Assert.NotEmpty(list2);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
