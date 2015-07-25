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
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

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

                var lastRun = client.Workflows.Run(this.resourceGroupName, workflowName, new RunWorkflowParameters());

                var run = client.WorkflowRuns.Get(this.resourceGroupName, workflowName, lastRun.Name);
                Assert.Equal(lastRun.Name, run.Name);

                var lists = client.WorkflowRuns.List(this.resourceGroupName, workflowName);
                Assert.NotEmpty(lists);

                // Delete the workflow
                client.Workflows.Delete(this.resourceGroupName, workflowName);
            }
        }
    }
}
