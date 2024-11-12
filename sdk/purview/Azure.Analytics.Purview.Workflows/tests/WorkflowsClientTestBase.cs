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
        }

        public WorkflowClient GetWorkflowClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new WorkflowClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }

        public WorkflowsClient GetWorkflowsClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new WorkflowsClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }

        public UserRequestsClient GetUserRequestsClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new UserRequestsClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }

        public WorkflowRunClient GetWorkflowRunClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new WorkflowRunClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }

        public ApprovalClient GetApprovalClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewWorkflowServiceClientOptions { Transport = new HttpClientTransport(httpHandler) };
            return InstrumentClient(new ApprovalClient(TestEnvironment.Endpoint, TestEnvironment.UsernamePasswordCredential, InstrumentClientOptions(options)));
        }
    }
}
