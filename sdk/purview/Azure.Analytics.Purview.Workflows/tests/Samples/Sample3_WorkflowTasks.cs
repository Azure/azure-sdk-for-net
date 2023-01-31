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
        public async Task ApproveWorkflowTask()
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
            string clientId = Environment.GetEnvironmentVariable("ClientId");
            string tenantId = Environment.GetEnvironmentVariable("TenantId");
            string username = Environment.GetEnvironmentVariable("Username");
            string password = Environment.GetEnvironmentVariable("Password");

            TokenCredential usernamePasswordCredential = new UsernamePasswordCredential(clientId,tenantId, username,password, null);
            var client = new PurviewWorkflowServiceClient(endpoint, usernamePasswordCredential);

            #region Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask

            // This taskId is an existing workflow task's id, user could get workflow tasks by calling GetWorkflowTasksAsync API.
            Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

            string request = "{\"comment\":\"Thanks!\"}";

            Response approveResult = await client.ApproveApprovalTaskAsync(taskId, RequestContent.Create(request));

            #endregion

            Assert.AreEqual(200, approveResult.Status);
        }
    }
}
