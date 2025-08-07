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

            Guid workflowId = new Guid("e3467b48-a9d8-11ed-afa1-0242ac120002");

            string workflow = "{\"name\":\"Create glossary term workflow\",\"description\":\"\",\"triggers\":[{\"type\":\"when_term_creation_is_requested\",\"underGlossaryHierarchy\":\"/glossaries/5dae5e5b-5aa6-48f1-9e46-26fe7328de71\"}],\"isEnabled\":true,\"actionDag\":{\"actions\":{\"Startandwaitforanapproval\":{\"type\":\"Approval\",\"inputs\":{\"parameters\":{\"approvalType\":\"PendingOnAll\",\"title\":\"ApprovalRequestforCreateGlossaryTerm\",\"assignedTo\":[\"eece94d9-0619-4669-bb8a-d6ecec5220bc\"]}},\"runAfter\":{}},\"Condition\":{\"type\":\"If\",\"expression\":{\"and\":[{\"equals\":[\"@{outputs('Startandwaitforanapproval')['outcome']}\",\"Approved\"]}]},\"actions\":{\"Createglossaryterm\":{\"type\":\"CreateTerm\",\"runAfter\":{}},\"Sendemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-APPROVED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{runInput()['term']['name']}isapproved.\",\"emailRecipients\":[\"@{runInput()['requestor']}\"]}},\"runAfter\":{\"Createglossaryterm\":[\"Succeeded\"]}}},\"else\":{\"actions\":{\"Sendrejectemailnotification\":{\"type\":\"EmailNotification\",\"inputs\":{\"parameters\":{\"emailSubject\":\"GlossaryTermCreate-REJECTED\",\"emailMessage\":\"YourrequestforGlossaryTerm@{runInput()['term']['name']}isrejected.\",\"emailRecipients\":[\"@{runInput()['requestor']}\"]}},\"runAfter\":{}}}},\"runAfter\":{\"Startandwaitforanapproval\":[\"Succeeded\"]}}}}}";

            Response createResult = await client.CreateOrReplaceAsync(workflowId, RequestContent.Create(workflow));

            using var createJsonDocument = JsonDocument.Parse(GetContentFromResponse(createResult));
            JsonElement createBodyJson = createJsonDocument.RootElement;

            Assert.AreEqual(workflowId.ToString(), createBodyJson.GetProperty("id").ToString());
        }

        [RecordedTest]
        public async Task ListWorkflow()
        {
            var client = GetWorkflowsClient();
            var workflowsList = client.GetWorkflowsAsync(new()).GetAsyncEnumerator();
            await workflowsList.MoveNextAsync();
            using var workflowsListJsonDocument = JsonDocument.Parse(workflowsList.Current);
            JsonElement listBodyJson = workflowsListJsonDocument.RootElement;
            await workflowsList.DisposeAsync();
            Assert.NotNull(listBodyJson);
        }

        [RecordedTest]
        public async Task GetWorkflow()
        {
            var client = GetWorkflowClient();
            Guid workflowId = new Guid("e3467b48-a9d8-11ed-afa1-0242ac120002");
            Response getResult = await client.GetWorkflowAsync(workflowId, new());
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResult));
            JsonElement getBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(workflowId.ToString(), getBodyJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task DeleteWorkflow()
        {
            var client = GetWorkflowClient();

            Guid workflowId = new Guid("3f7a14f2-c9cd-4fe4-96df-ed3447256118");

            Response deleteResult = await client.DeleteAsync(workflowId);
            Assert.AreEqual(204, deleteResult.Status);
        }

        [RecordedTest]
        public async Task SubmitUserRequest()
        {
            var client = GetUserRequestsClient();

            string request = "{\"operations\":[{\"type\":\"CreateTerm\",\"payload\":{\"glossaryTerm\":{\"name\":\"term\",\"anchor\":{\"glossaryGuid\":\"5dae5e5b-5aa6-48f1-9e46-26fe7328de71\"},\"status\":\"Approved\",\"nickName\":\"term\"}}}],\"comment\":\"Thanks!\"}";

            Response submitResult = await client.SubmitAsync(RequestContent.Create(request));
            Assert.AreEqual(200, submitResult.Status);
        }

        [RecordedTest]
        public async Task CancelWorkflowRuns()
        {
            var client = GetWorkflowRunClient();

            Guid workflowRunId = new Guid("27022a5a-accd-4c91-baf5-33297b2a12ba");

            string request = "{\"comment\":\"Thanks!\"}";

            Response cancelResult = await client.CancelAsync(workflowRunId, RequestContent.Create(request));

            Assert.AreEqual(200, cancelResult.Status);
        }

        [RecordedTest]
        public async Task ApproveWorkflowTask()
        {
            var client = GetApprovalClient();

            Guid taskId = new Guid("ca7a1483-3635-4822-aa7d-9291f7d32f4c");

            string request = "{\"comment\":\"Thanks!\"}";

            Response approveResult = await client.ApproveAsync(taskId, RequestContent.Create(request));

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
