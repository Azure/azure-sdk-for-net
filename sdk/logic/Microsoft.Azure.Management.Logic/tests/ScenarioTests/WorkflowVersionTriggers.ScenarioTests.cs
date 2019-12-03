// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    [Collection("WorkflowVersionTriggersScenarioTests")]
    public class WorkflowVersionTriggersScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void WorkflowVersionTriggers_ListCallbackUrl_OK()
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

                var callbackUrl = client.WorkflowVersionTriggers.ListCallbackUrl(Constants.DefaultResourceGroup,
                    workflowName,
                    createdWorkflow.Version,
                    Constants.DefaultTriggerName,
                    new GetCallbackUrlParameters
                    {
                        KeyType = "Primary"
                    });

                Assert.NotEmpty(callbackUrl.BasePath);

                client.Workflows.Delete(Constants.DefaultResourceGroup, workflowName);
            }
        }
    }
}

