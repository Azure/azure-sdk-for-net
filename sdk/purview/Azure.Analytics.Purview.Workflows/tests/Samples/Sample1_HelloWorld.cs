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
    public class WorkflowsSamples: SamplesBase<WorkflowsClientTestEnvironment>
    {
        [Test]
        public async Task CreateWorkflowClient()
        {
            #region Snippet:Azure_Analytics_Purview_Workflows_CreateClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
#else
            TokenCredential credential = TestEnvironment.Credential;
#endif

            var client = new WorkflowsClient(endpoint, credential);
#endregion

            //Perform an operation
            AsyncPageable<BinaryData> workflowList = client.GetWorkflowsAsync(new RequestContext());

            await foreach (var workflow in workflowList)
            {
                using var workflowsJsonDocument = JsonDocument.Parse(workflow);
                JsonElement bodyJson = workflowsJsonDocument.RootElement;
                Console.WriteLine(bodyJson.GetProperty("name").ToString());
            }

            Assert.IsNotNull(workflowList);
        }

        [Test]
        public async Task CreateWorkflow()
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
            var client = new WorkflowClient(endpoint, TestEnvironment.Credential);

            #region Snippet:Azure_Analytics_Purview_Workflows_CreateWorkflow
            Guid workflowId = Guid.NewGuid();

            string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/20031e20-b4df-4a66-a61d-1b0716f3fa48\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@outputs('Startandwaitforanapproval')['body/outcome']\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isapproved.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isrejected.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

            Response createResult = await client.CreateOrReplaceAsync(workflowId, RequestContent.Create(workflow));

            #endregion

            using var createJsonDocument = JsonDocument.Parse(GetContentFromResponse(createResult));
            JsonElement createBodyJson = createJsonDocument.RootElement;

            Assert.AreEqual(workflowId.ToString(), createBodyJson.GetProperty("id").ToString());
        }

        [Test]
        public async Task GetWorkflow()
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("WORKFLOW_ENDPOINT"));
            var client = new WorkflowClient(endpoint, TestEnvironment.Credential);

            #region Snippet:Azure_Analytics_Purview_Workflows_GetWorkflow
            // This workflowId represents an existing workflow. The id can be obtained by calling CreateOrReplaceWorkflowAsync API or list workflows by calling GetWorkflowsAsync API.
            Guid workflowId = new Guid("8af1ecae-16ee-4b2d-8972-00d611dd2f99");

            Response getResult = await client.GetWorkflowAsync(workflowId, new());

            #endregion

            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResult));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(workflowId.ToString(), getBodyJson.GetProperty("id").GetString());
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            using MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
    }
}
