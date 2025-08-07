// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
            var client = new ApprovalClient(endpoint, TestEnvironment.Credential);

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
