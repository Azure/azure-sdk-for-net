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
                            referenceName = "/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/provideraccount",
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

            Response response = await client.GetSentShareAsync(sentShareId, new());

            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;

            Assert.AreEqual(sentShareId, getBodyJson.GetProperty("id").GetString());

            JsonElement properties = getBodyJson.GetProperty("properties");

            var actualDisplayName = properties.GetProperty("displayName").ToString();
            var expectedDisplayName = "testDisplayName1";
            Assert.AreEqual(expectedDisplayName, actualDisplayName);

            List<BinaryData> listResponse = await client.GetAllSentSharesAsync("/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/provideraccount", null, null, new()).ToEnumerableAsync();

            Assert.Greater(listResponse.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareAsync(WaitUntil.Completed, sentShareId, new());

            Assert.IsTrue(response.HasCompleted);
        }

        [RecordedTest]
        public async Task CreateSentShareServiceInvitationTest()
        {
            var data = new
            {
                invitationKind = "Service",
                properties = new
                {
                    TargetActiveDirectoryId = "165944e1-1963-4e83-920f-4d0e9c44599c",
                    TargetObjectId = "5fc438a9-bdb9-46d4-89d7-43fdccc0f23e",
                }
            };

            SentSharesClient client = GetSentSharesClient();

            Response response = await client.CreateSentShareInvitationAsync(sentShareId, sentShareInvitationId, RequestContent.Create(data));

            Assert.AreEqual(201, response.Status);
        }
        [RecordedTest]
        public async Task CreateSentShareUserInvitationTest()
        {
            var data = new
            {
                invitationKind = "User",
                properties = new
                {
                    TargetEmail = "customer@contoso.com",
                    Notify = true,
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

            Response testing = await client.GetSentShareInvitationAsync(sentShareId, sentShareInvitationId, new());

            Assert.AreEqual(200, testing.Status);

            List<BinaryData> invitations = await client.GetAllSentShareInvitationsAsync(sentShareId, null, null, new()).ToEnumerableAsync();

            Assert.GreaterOrEqual(invitations.Count, 0);
        }

        [RecordedTest]
        public async Task DeleteSentShareInvitationTest()
        {
            SentSharesClient client = GetSentSharesClient();

            Operation response = await client.DeleteSentShareInvitationAsync(WaitUntil.Completed, sentShareId, sentShareInvitationId, new());

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
