// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Analytics.Purview.Workflow.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Workflows.Tests
{
    public class WorkflowsClientTest: WorkflowsClientTestBase
    {
        public WorkflowsClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateWorkflow()
        {
            var client = GetWorkflowClient();

            Guid workflowId = new Guid("c504f8ad-c0d6-4e76-ada8-33a0d3cccba7");

            string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/20031e20-b4df-4a66-a61d-1b0716f3fa48\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@outputs('Startandwaitforanapproval')['body/outcome']\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isapproved.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{triggerBody()['request']['term']['name']}isrejected.\",\"emailRecipients\":[\"@{triggerBody()['request']['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

            Response createResult = await client.CreateOrReplaceWorkflowAsync(workflowId, RequestContent.Create(workflow));

            using var createJsonDocument = JsonDocument.Parse(GetContentFromResponse(createResult));
            JsonElement createBodyJson = createJsonDocument.RootElement;

            Assert.AreEqual(workflowId.ToString(), createBodyJson.GetProperty("id").ToString());
        }

        [RecordedTest]
        public async Task ListWorkflow()
        {
            var client = GetWorkflowClient();
            var workflowsList = client.GetWorkflowsAsync(new()).GetAsyncEnumerator();
            await workflowsList.MoveNextAsync();
            using var workflowsListJsonDocument = JsonDocument.Parse(workflowsList.Current);
            JsonElement listBodyJson = workflowsListJsonDocument.RootElement;
            await workflowsList.DisposeAsync();
            Assert.AreEqual("Delete glossary term", listBodyJson.GetProperty("name").ToString());
        }

        [RecordedTest]
        public async Task GetWorkflow()
        {
            var client = GetWorkflowClient();
            Guid workflowId = new Guid("8af1ecae-16ee-4b2d-8972-00d611dd2f99");
            Response getResult = await client.GetWorkflowAsync(workflowId);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResult));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(workflowId.ToString(), getBodyJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task DeleteWorkflow()
        {
            var client = GetWorkflowClient();

            Guid workflowId = new Guid("5ec07661-0111-4264-aed8-2a335773a831");

            Response deleteResult = await client.DeleteWorkflowAsync(workflowId);
            Assert.AreEqual(204, deleteResult.Status);
        }

        [RecordedTest]
        public async Task SubmitUserRequest()
        {
            var client = GetWorkflowClient();

            string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"20031e20-b4df-4a66-a61d-1b0716f3fa48\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

            Response submitResult = await client.SubmitUserRequestsAsync(RequestContent.Create(request));
            Assert.AreEqual(200, submitResult.Status);
        }

        [RecordedTest]
        public async Task CancelWorkflowRuns()
        {
            var client = GetWorkflowClient();

            Guid workflowRunId = new Guid("d77281b4-2af3-4bc5-8d2f-14a2b63fa33d");

            string request = "{\"comment\":\"Thanks!\"}";

            Response cancelResult = await client.CancelWorkflowRunAsync(workflowRunId, RequestContent.Create(request));

            Assert.AreEqual(200, cancelResult.Status);
        }

        [RecordedTest]
        public async Task ApproveWorkflowTask()
        {
            var client = GetWorkflowClient();

            Guid taskId = new Guid("507d9e8a-e5c4-41db-ace5-358961e0bfeb");

            string request = "{\"comment\":\"Thanks!\"}";

            Response approveResult = await client.ApproveApprovalTaskAsync(taskId, RequestContent.Create(request));

            Assert.AreEqual(200, approveResult.Status);
        }
        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
