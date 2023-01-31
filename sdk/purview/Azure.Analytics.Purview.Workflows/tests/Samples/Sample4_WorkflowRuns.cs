// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Workflows.Tests.Samples
{
    public partial class WorkflowsSamples: SamplesBase<WorkflowsClientTestEnvironment>
    {
        [Test]
        public async Task CancelWorkflowRun()
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
            string clientId = Environment.GetEnvironmentVariable("ClientId");
            string tenantId = Environment.GetEnvironmentVariable("TenantId");
            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(clientId,tenantId, username,password, null);
            var client = new PurviewWorkflowServiceClient(endpoint, usernamePasswordCredential);

            #region Snippet:Azure_Analytics_Purview_Workflows_CancelWorkflowRun
            // This workflowRunId is an existing workflow run's id, user could get workflow runs by calling GetWorkflowRunsAsync API.
            Guid workflowRunId = new Guid("4f8d70c3-c09b-4e56-bfd1-8b86c79bd4d9");

            string request = "{\"comment\":\"Thanks!\"}";

            Response cancelResult = await client.CancelWorkflowRunAsync(workflowRunId, RequestContent.Create(request));

            #endregion

            Assert.AreEqual(200, cancelResult.Status);
        }
    }
}
