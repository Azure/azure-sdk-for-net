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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    public class WorkflowsTasksSamples: SamplesBase<WorkflowsClientTestEnvironment>
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
            var client = new ApprovalClient(endpoint, usernamePasswordCredential);

            #region Snippet:Azure_Analytics_Purview_Workflows_ApproveWorkflowTask

            // This taskId represents an existing workflow task. The id can be obtained by calling GetWorkflowTasksAsync API.
            Guid taskId = new Guid("b129fe16-72d3-4994-9135-b997b9be46e0");

            string request = "{\"comment\":\"Thanks!\"}";

            Response approveResult = await client.ApproveAsync(taskId, RequestContent.Create(request));

            #endregion

            Assert.AreEqual(200, approveResult.Status);
        }
    }
}
