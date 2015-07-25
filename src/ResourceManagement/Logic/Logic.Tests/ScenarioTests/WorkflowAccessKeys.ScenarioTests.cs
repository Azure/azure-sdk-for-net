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
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class WorkflowAccessKeysScenarioTests : BaseScenarioTests
    {
        [Fact]
        public void CreateAndDelete()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
				string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                client.Workflows.CreateOrUpdate(
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

				// Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

				// Delete the access key
                client.WorkflowAccessKeys.Delete(this.resourceGroupName, workflowName, accessKeyName);

				// List access key and verify only one key
                var accesskeys = client.WorkflowAccessKeys.List(this.resourceGroupName, workflowName);
                Assert.Equal(1, accesskeys.Count());
            }
        }

		[Fact]
        public void CreateAndList()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                client.Workflows.CreateOrUpdate(
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

                // Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

                // List access key and verify the response
                var accesskeys = client.WorkflowAccessKeys.List(this.resourceGroupName, workflowName);
                Assert.Equal(2, accesskeys.Count());
            }
        }

		[Fact]
		public void RegenerateAndListSecretKeys()
        {
            using (MockContext context = MockContext.Start())
            {
                string workflowName = TestUtilities.GenerateName("logicwf");
                string accessKeyName = TestUtilities.GenerateName("accesskey");
                var client = this.GetLogicManagementClient();

                // Create a workflow
                client.Workflows.CreateOrUpdate(
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

                // Create an access key
                var accessKey = client.WorkflowAccessKeys.CreateOrUpdate(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new WorkflowAccessKey
                    {
                        NotBefore = DateTime.UtcNow.AddDays(1),
                        NotAfter = DateTime.UtcNow.AddDays(7)
                    });

                Assert.NotNull(accessKey.NotBefore);
                Assert.NotNull(accessKey.NotAfter);

                // Regenerate seret key
                var secretKeys = client.WorkflowAccessKeys.RegenerateSecretKey(
                    this.resourceGroupName,
                    workflowName,
                    accessKeyName,
                    new RegenerateSecretKeyParameters
                    {
                        KeyType = KeyType.Primary
                    });

                Assert.NotEmpty(secretKeys.PrimarySecretKey);
                Assert.NotEmpty(secretKeys.SecondarySecretKey);

				// List secrets and verify response
                secretKeys = client.WorkflowAccessKeys.ListSecretKeys(this.resourceGroupName, workflowName, accessKeyName);
                Assert.NotEmpty(secretKeys.PrimarySecretKey);
                Assert.NotEmpty(secretKeys.SecondarySecretKey);
            }
        }
    }
}
