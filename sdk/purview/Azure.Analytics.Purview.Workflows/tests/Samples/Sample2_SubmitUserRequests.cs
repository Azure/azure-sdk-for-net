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
    public class UserRequestsSamples: SamplesBase<WorkflowsClientTestEnvironment>
    {
        [Test]
        public async Task SubmitUserRequest()
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
            var client = new UserRequestsClient(endpoint, TestEnvironment.Credential);

            #region Snippet:Azure_Analytics_Purview_Workflows_SubmitUserRequests

            string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

            Response submitResult = await client.SubmitAsync(RequestContent.Create(request));

            #endregion

            Assert.AreEqual(200, submitResult.Status);
        }
    }
}
