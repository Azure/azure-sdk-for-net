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

namespace Azure.Analytics.Purview.Sharing.Tests
{
    public class SentSharesClientTest : SentSharesClientTestBase
    {
        private string sentShareId => "3fa235b9-4368-4827-8100-745042c14771";

        private string sentShareInvitationId => "e0162694-c77e-4f47-94f9-d876a1252021";

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
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourcegroups/ads-dev-shared/providers/Microsoft.Storage/storageAccounts/rlandaetasdkprovideradls",
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

            Operation<BinaryData> createResponse = await client.CreateOrReplaceSentShareAsync(WaitUntil.Completed, sentShareId, RequestContent.Create(data));

            Assert.IsTrue(createResponse.HasCompleted);

            var jsonDocument = JsonDocument.Parse(createResponse.Value);

            var actualId = jsonDocument.RootElement.GetProperty("id").ToString();
            var expectedId = sentShareId;
            Assert.AreEqual(expectedId, actualId);

            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            var actualDisplayName = properties.GetProperty("displayName").ToString();
            var expectedDisplayName = "testDisplayName1";
            Assert.AreEqual(expectedDisplayName, actualDisplayName);
        }

        [RecordedTest]
        public async Task GetListSentSharesTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Response response = await client.GetSentShareAsync(sentShareId);

            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;

            Assert.AreEqual(sentShareId, getBodyJson.GetProperty("id").GetString());

            JsonElement properties = getBodyJson.GetProperty("properties");

            var actualDisplayName = properties.GetProperty("displayName").ToString();
            var expectedDisplayName = "testDisplayName1";
            Assert.AreEqual(expectedDisplayName, actualDisplayName);

            List<BinaryData> listResponse = await client.GetAllSentSharesAsync("/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourcegroups/ads-dev-shared/providers/Microsoft.Storage/storageAccounts/rlandaetasdkprovideradls").ToEnumerableAsync();

            Assert.Greater(listResponse.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareAsync(WaitUntil.Completed, sentShareId);

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
                    TargetObjectId = "67bb1d64-b708-496a-ba33-48c242cbb6c8",
                }
            };

            SentSharesClient client = GetSentSharesClient();

            Response response = await client.CreateSentShareInvitationAsync(sentShareId, sentShareInvitationId, RequestContent.Create(data));

            Assert.AreEqual(201, response.Status);
        }

        [RecordedTest]
        public async Task GetListSentShareInvitationsTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Response testing = await client.GetSentShareInvitationAsync(sentShareId, sentShareInvitationId);

            Assert.AreEqual(200, testing.Status);

            List<BinaryData> invitations = await client.GetAllSentShareInvitationsAsync(sentShareId).ToEnumerableAsync();

            Assert.GreaterOrEqual(invitations.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareInvitationTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareInvitationAsync(WaitUntil.Completed, sentShareId, sentShareInvitationId);

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
