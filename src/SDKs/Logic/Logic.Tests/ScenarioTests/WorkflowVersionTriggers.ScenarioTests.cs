// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Xunit;

    [Collection("WorkflowVersionTriggersScenarioTests")]
    public class WorkflowVersionTriggersScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;

        private readonly string workflowName;
        private readonly Workflow workflow;

        public WorkflowVersionTriggersScenarioTests()
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
        public void WorkflowVersionTriggers_ListCallbackUrl_OK()
        {
            var createdWorkflow = this.client.Workflows.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.workflowName,
                this.workflow);
          
            var callbackUrl = this.client.WorkflowVersionTriggers.ListCallbackUrl(Constants.DefaultResourceGroup,
                this.workflowName,
                createdWorkflow.Version,
                Constants.DefaultTriggerName,
                new GetCallbackUrlParameters
                {
                    KeyType = "Primary"
                });

            Assert.NotEmpty(callbackUrl.BasePath);
        }
    }
}
