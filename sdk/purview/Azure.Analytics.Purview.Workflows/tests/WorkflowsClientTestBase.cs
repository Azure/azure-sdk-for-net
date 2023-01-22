// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Analytics.Purview.Workflows;
using Azure.Analytics.Purview.Workflows.Tests;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Workflow.Tests
{
    public class WorkflowsClientTestBase: RecordedTestBase<WorkflowsClientTestEnvironment>
    {
        public WorkflowsClientTestBase(bool isAsync, RecordedTestMode? mode = default) : base(isAsync)
        {
            //this.AddPurviewSanitizers();
        }

        public PurviewWorkflowServiceClient GetWorkflowClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new PurviewWorkflowServiceClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }
    }
}
