// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Share.Tests
{
    public class SentSharesClientTest : SentSharesClientTestBase
    {
        public SentSharesClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareTest()
        {
            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    artifact = new
                    {
                        storeKind = "AdlsGen2Account",
                        storeReference = new
                        {
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan",
                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
                            paths = new[]
                           {
                                new { containerName = "container1", senderPath = "testfolder1", receiverPath = "testfolder1"}
                            }
                        }
                    },
                    displayName = "testDisplayName1",
                    description = "updatedDescription",
                }
            };

            SentSharesClient client = GetSentSharesClient();

            Operation<BinaryData> createResponse = await client.CreateOrReplaceSentShareAsync(WaitUntil.Completed, "5f789532-a7b5-4194-a9a8-81f1bbd27562", RequestContent.Create(data));

            Assert.IsTrue(createResponse.HasCompleted);

            var jsonDocument = JsonDocument.Parse(createResponse.Value);

            var actualId = jsonDocument.RootElement.GetProperty("id").ToString();
            var expectedId = "5f789532-a7b5-4194-a9a8-81f1bbd27562";
            Assert.AreEqual(expectedId, actualId);

            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            var actualStoreId = properties.GetProperty("artifact").GetProperty("storeReference").GetProperty("referenceName").ToString();
            var expectedStoreId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan";
            Assert.AreEqual(expectedStoreId, actualStoreId);

            var actualDisplayName = properties.GetProperty("displayName").ToString();
            var expectedDisplayName = "testDisplayName1";
            Assert.AreEqual(expectedDisplayName, actualDisplayName);
        }

        [RecordedTest]
        public async Task GetListSentSharesTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Response response = await client.GetSentShareAsync("5f789532-a7b5-4194-a9a8-81f1bbd27562");

            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;

            Assert.AreEqual("5f789532-a7b5-4194-a9a8-81f1bbd27562", getBodyJson.GetProperty("id").GetString());

            JsonElement properties = getBodyJson.GetProperty("properties");

            var actualStoreId = properties.GetProperty("artifact").GetProperty("storeReference").GetProperty("referenceName").ToString();
            var expectedStoreId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan";
            Assert.AreEqual(expectedStoreId, actualStoreId);

            var actualDisplayName = properties.GetProperty("displayName").ToString();
            var expectedDisplayName = "testDisplayName1";
            Assert.AreEqual(expectedDisplayName, actualDisplayName);

            List<BinaryData> listResponse = await client.GetAllSentSharesAsync("/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan").ToEnumerableAsync();

            Assert.Greater(listResponse.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareAsync(WaitUntil.Completed, "5f789532-a7b5-4194-a9a8-81f1bbd27562");

            Assert.IsTrue(response.HasCompleted);
        }

        [RecordedTest]
        public async Task CreateSentShareInvitationTest()
        {
            var data = new
            {
                invitationKind = "Service",
                properties = new
                {
                    TargetActiveDirectoryId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    TargetObjectId = "fc010728-94f6-4e9c-be3c-c08687414bd4",
                }
            };

            SentSharesClient client = GetSentSharesClient();

            Response response = await client.CreateSentShareInvitationAsync("5f789532-a7b5-4194-a9a8-81f1bbd27562", "be5ea079-c652-4328-91b1-76f15f9e6cf2", RequestContent.Create(data));

            Assert.AreEqual(201, response.Status);

            var createJsonDocument = JsonDocument.Parse(GetContentFromResponse(response));
            string actualTargetActiveDirectoryId = createJsonDocument.RootElement.GetProperty("properties").GetProperty("targetActiveDirectoryId").ToString();
            string actualTargetObjectId = createJsonDocument.RootElement.GetProperty("properties").GetProperty("targetObjectId").ToString();

            Assert.AreEqual("fc010728-94f6-4e9c-be3c-c08687414bd4", actualTargetObjectId);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", actualTargetActiveDirectoryId);
        }

        [RecordedTest]
        public async Task GetListSentShareInvitationsTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Response testing = await client.GetSentShareInvitationAsync("5f789532-a7b5-4194-a9a8-81f1bbd27562", "be5ea079-c652-4328-91b1-76f15f9e6cf2");

            var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(testing));
            string actualTargetActiveDirectoryId = jsonDocumentGet.RootElement.GetProperty("properties").GetProperty("targetActiveDirectoryId").ToString();
            string actualTargetObjectId = jsonDocumentGet.RootElement.GetProperty("properties").GetProperty("targetObjectId").ToString();

            Assert.AreEqual("fc010728-94f6-4e9c-be3c-c08687414bd4", actualTargetObjectId);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", actualTargetActiveDirectoryId);

            List<BinaryData> invitations = await client.GetAllSentShareInvitationsAsync("5f789532-a7b5-4194-a9a8-81f1bbd27562").ToEnumerableAsync();

            Assert.GreaterOrEqual(invitations.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareInvitationTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareInvitationAsync(WaitUntil.Completed, "5f789532-a7b5-4194-a9a8-81f1bbd27562", "be5ea079-c652-4328-91b1-76f15f9e6cf2");

            Assert.IsTrue(response.HasCompleted);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }

        #endregion
    }
}
