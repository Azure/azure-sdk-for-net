// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Share.Tests
{
    public class ShareClientTest : ShareClientTestBase
    {
        public ShareClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SentShareTests()
        {
            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    description = "",
                    collection = new
                    {
                        referenceName = "w95gh9ze",
                        type = "CollectionReference"
                    }
                }
            };

            //Create sent shares client
            SentSharesClient client = GetSentSharesClient();

            //Create a new sent share
            Response createResponse = await client.CreateOrUpdateAsync("sentShare1", RequestContent.Create(data));

            Assert.AreEqual(201, createResponse.Status);

            //Get the newly created sent share
            Response getResponse = await client.GetSentShareAsync("sentShare1", new());

            Assert.AreEqual(200, getResponse.Status);
            using var jsonDocumentGet = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getBodyJson = jsonDocumentGet.RootElement;
            Assert.AreEqual("/sentShares/sentShare1", getBodyJson.GetProperty("id").GetString());

            //List sent shares
            List<BinaryData> listSentSharesResponse = await client.GetSentSharesAsync().ToEnumerableAsync();

            Assert.IsTrue(listSentSharesResponse.Count > 0);
            Assert.IsTrue(listSentSharesResponse[0] != null);
            using var jsonDocumentListSentShares = JsonDocument.Parse(listSentSharesResponse[0]);
            JsonElement listSentSharesResponseJson = jsonDocumentListSentShares.RootElement;
            Assert.IsTrue(listSentSharesResponseJson.GetProperty("id").GetString() != null);

            //Delete sent share
            Operation deleteSentShareOperation = await client.DeleteAsync(WaitUntil.Completed, "sentShare1");

            Assert.IsTrue(deleteSentShareOperation.HasCompleted);
        }

        [RecordedTest]
        public async Task AssetsTests()
        {
            AssetsClient assetsClient = GetAssetsClient();

            var assetData = new
            {
                kind = "AdlsGen2Account",
                properties = new
                {
                    storageAccountResourceId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan",
                    receiverAssetName = "testAsset1",
                    paths = new[]
                     {
                        new { containerName = "container1", senderPath = "testfolder1", receiverPath = "testfolder1"}
                    }
                }
            };

            //Create a new asset
            await assetsClient.CreateAsync(WaitUntil.Started, "sentShare1", "asset1", RequestContent.Create(assetData));

            //Get newly created asset
            Response getAssetResponse = await assetsClient.GetAssetAsync("sentShare1", "asset1");

            Assert.AreEqual(200, getAssetResponse.Status);
            using var jsonDocumentGetAsset = JsonDocument.Parse(GetContentFromResponse(getAssetResponse));
            JsonElement getAssetResponseJson = jsonDocumentGetAsset.RootElement;
            Assert.AreEqual("/sentShares/sentShare1/assets/asset1", getAssetResponseJson.GetProperty("id").GetString());

            //List all assets
            List<BinaryData> listAssetsResponse = await assetsClient.GetAssetsAsync("sentShare1").ToEnumerableAsync();

            using var jsonDocumentListAssets = JsonDocument.Parse(listAssetsResponse[0]);
            JsonElement listAssetsResponseJson = jsonDocumentListAssets.RootElement;
            Assert.AreEqual("/sentShares/sentShare1/assets/asset1", listAssetsResponseJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task DeleteAsset()
        {
            AssetsClient assetsClient = GetAssetsClient();

            //Delete asset
            await assetsClient.DeleteAsync(WaitUntil.Completed, "sentShare1", "asset1");

            //List all assets
            List<BinaryData> listAssetsResponseAfter = await assetsClient.GetAssetsAsync("sentShare1").ToEnumerableAsync();

            Assert.AreEqual(0, listAssetsResponseAfter.Count);
        }

        [RecordedTest]
        public async Task SentShareInvitationsTest()
        {
            //Create sent share invitations client
            SentShareInvitationsClient sentShareInvitationsClient = GetSentShareInvitationsClient();

            var sentShareInvitationData = new
            {
                invitationKind = "User",
                properties = new
                {
                    targetEmail = "faisalaltell@microsoft.com"
                }
            };

            //Create a new invitation
            Response sentShareInvitationResponse = await sentShareInvitationsClient.CreateOrUpdateAsync("sentShare1", "invitation1", RequestContent.Create(sentShareInvitationData));

            Assert.AreEqual(201, sentShareInvitationResponse.Status);
            using var jsonDocumentSenetShareInvitation = JsonDocument.Parse(GetContentFromResponse(sentShareInvitationResponse));
            JsonElement sentShareInvitationResponseJson = jsonDocumentSenetShareInvitation.RootElement;
            Assert.IsTrue(sentShareInvitationResponseJson.GetProperty("id").GetString().Contains("/sentShares/sentShare1/sentShareInvitations/"));
            Assert.AreEqual(sentShareInvitationData.properties.targetEmail, sentShareInvitationResponseJson.GetProperty("properties").GetProperty("targetEmail").GetString());

            string invitationName = sentShareInvitationResponseJson.GetProperty("name").GetString();

            //Get sent share invitation
            Response getSentShareInvitationResponse = await sentShareInvitationsClient.GetSentShareInvitationAsync("sentShare1", invitationName);

            Assert.AreEqual(200, getSentShareInvitationResponse.Status);
            using var jsonDocumentGetSentShareInvitation = JsonDocument.Parse(GetContentFromResponse(getSentShareInvitationResponse));
            JsonElement getSentShareInvitationResponseJson = jsonDocumentGetSentShareInvitation.RootElement;
            Assert.AreEqual(invitationName, getSentShareInvitationResponseJson.GetProperty("name").GetString());

            //List sent share invitations
            List<BinaryData> listSentShareInvitationResponse = await sentShareInvitationsClient.GetSentShareInvitationsAsync("sentShare1").ToEnumerableAsync();

            Assert.AreEqual(1, listSentShareInvitationResponse.Count);
            using var jsonDocumentListSentShareInvitation = JsonDocument.Parse(listSentShareInvitationResponse[0]);
            JsonElement listSentShareInvitationResponseJson = jsonDocumentListSentShareInvitation.RootElement;
            Assert.AreEqual(invitationName, listSentShareInvitationResponseJson.GetProperty("name").GetString());

            //Delete sent share invitation
            Response deleteSentShareInvitation = await sentShareInvitationsClient.DeleteAsync("sentShare1", invitationName);

            Assert.AreEqual(204, deleteSentShareInvitation.Status);
        }

        //Get received invitation not found
        [RecordedTest]
        public async Task ReceivedShareTests()
        {
            //Create received shares client
            ReceivedSharesClient receivedSharesClient = GetReceivedSharesClient();

            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    invitationId = "d3a8440d-6ff1-4816-b1eb-41a31585439b",
                    sentShareLocation = "eastus",
                    collection = new
                    {
                        referenceName = "w95gh9ze",
                        type = "CollectionReference"
                    }
                }
            };

            //Create a new received share
            Response createResponse = await receivedSharesClient.CreateAsync("receivedShare1", RequestContent.Create(data));

            Assert.AreEqual(201, createResponse.Status);

            //Get the newly created received share
            Response getReceivedShareResponse = await receivedSharesClient.GetReceivedShareAsync("receivedShare1");

            Assert.AreEqual(200, getReceivedShareResponse.Status);
            using var jsonDocumentGetReceivedShare = JsonDocument.Parse(GetContentFromResponse(getReceivedShareResponse));
            JsonElement getReceivedShareBodyJson = jsonDocumentGetReceivedShare.RootElement;
            Assert.AreEqual("/receivedShares/receivedShare1", getReceivedShareBodyJson.GetProperty("id").GetString());

            //List received shares
            List<BinaryData> listReceivedSharesResponse = await receivedSharesClient.GetReceivedSharesAsync().ToEnumerableAsync();

            Assert.IsTrue(listReceivedSharesResponse.Count > 0);
            Assert.IsTrue(listReceivedSharesResponse[0] != null);
            using var jsonDocumentListReceivedShares = JsonDocument.Parse(listReceivedSharesResponse[0]);
            JsonElement listReceivedSharesResponseJson = jsonDocumentListReceivedShares.RootElement;
            Assert.IsTrue(listReceivedSharesResponseJson.GetProperty("id").GetString() != null);

            //Delete received share
            Operation deleteReceivedShareOperation = await receivedSharesClient.DeleteAsync(WaitUntil.Completed, "receivedShare1");

            Assert.IsTrue(deleteReceivedShareOperation.HasCompleted);
        }

        [RecordedTest]
        public async Task ReceivedAssetsTest()
        {
            ReceivedAssetsClient receivedAssetsClient = GetReceivedAssetsClient();

            //List received assets
            List<BinaryData> receivedAssets = await receivedAssetsClient.GetReceivedAssetsAsync("sentShare1").ToEnumerableAsync();

            Assert.IsTrue(receivedAssets.Count == 1);
            Assert.IsTrue(receivedAssets[0] != null);
            using var jsonDocumentListReceivedAssets = JsonDocument.Parse(receivedAssets[0]);
            JsonElement listReceivedAssetsResponseJson = jsonDocumentListReceivedAssets.RootElement;
            Assert.IsTrue(listReceivedAssetsResponseJson.GetProperty("id").GetString() != null);
        }

        [RecordedTest]
        public async Task ReceivedInvitationTest()
        {
            ReceivedInvitationsClient receivedInvitationsClient = GetReceivedInvitationsClient();

            List<BinaryData> receivedInvitations = await receivedInvitationsClient.GetReceivedInvitationsAsync().ToEnumerableAsync();

            Assert.AreEqual(1, receivedInvitations.Count);
        }

        [RecordedTest]
        public async Task RevokeTest()
        {
            const string sentShareName = "sentShare1";
            const string acceptedSentShareName = "425559bf-8b64-4d8c-a5b4-a25dd92f666a";
            const string revokedStatus = "Revoked";

            AcceptedSentSharesClient acceptedSentSharesClient = GetAcceptedSentSharesClient();

            //Revoke
            await acceptedSentSharesClient.RevokeAsync(WaitUntil.Completed, sentShareName, acceptedSentShareName);

            //Get Accepted Sent Share
            Response getResponse = await acceptedSentSharesClient.GetAcceptedSentShareAsync(sentShareName, acceptedSentShareName);

            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getResponseJson = jsonDocument.RootElement;

            Assert.AreEqual(revokedStatus, getResponseJson.GetProperty("properties").GetProperty("receivedShareStatus").GetString());
        }

        [RecordedTest]
        public async Task UpdateExpirationTest()
        {
            const string sentShareName = "sentShare1";
            const string acceptedSentShareName = "425559bf-8b64-4d8c-a5b4-a25dd92f666a";

            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    expirationDate = new DateTime(2023, 11, 14, 10, 57, 36).ToString("MM/dd/yyyy HH:mm:ss tt")
                }
            };

            AcceptedSentSharesClient acceptedSentSharesClient = GetAcceptedSentSharesClient();

            //Update Expiration
            await acceptedSentSharesClient.UpdateExpirationAsync(WaitUntil.Started, sentShareName, acceptedSentShareName, RequestContent.Create(data));

            //Check Expiration Date

            //Get Accepted Sent Share
            Response getResponse = await acceptedSentSharesClient.GetAcceptedSentShareAsync(sentShareName, acceptedSentShareName);

            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getResponseJson = jsonDocument.RootElement;

            //Assert date before == date after
            Assert.AreEqual(data.properties.expirationDate, getResponseJson.GetProperty("properties").GetProperty("expirationDate").GetDateTime().ToString("MM/dd/yyyy HH:mm:ss tt"));
        }

        [RecordedTest]
        public async Task AcceptedSentSharesTests()
        {
            AcceptedSentSharesClient acceptedSentSharesClient = GetAcceptedSentSharesClient();

            List<BinaryData> acceptedSentShares = await acceptedSentSharesClient.GetAcceptedSentSharesAsync("ft-testShare-3").ToEnumerableAsync();

            Assert.IsTrue(acceptedSentShares.Count == 1);
            using var jsonDocument = JsonDocument.Parse(acceptedSentShares[0]);
            JsonElement listSentSharesResponseJson = jsonDocument.RootElement;
            Assert.AreEqual("/sentShares/ft-testShare-3/acceptedSentShares/d5d52fdb-6aef-45a2-9271-3aa1becfceb3", listSentSharesResponseJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task AcceptedSentShareTests()
        {
            AcceptedSentSharesClient acceptedSentSharesClient = GetAcceptedSentSharesClient();

            Response acceptedSentShare = await acceptedSentSharesClient.GetAcceptedSentShareAsync("ft-testShare-3", "d5d52fdb-6aef-45a2-9271-3aa1becfceb3");

            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(acceptedSentShare));
            JsonElement acceptedSentShareJson = jsonDocument.RootElement;

            Assert.AreEqual(200, acceptedSentShare.Status);
            Assert.AreEqual("/sentShares/ft-testShare-3/acceptedSentShares/d5d52fdb-6aef-45a2-9271-3aa1becfceb3", acceptedSentShareJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task ReinstateTest()
        {
            const string sentShareName = "sentShare1";
            const string acceptedSentShareName = "425559bf-8b64-4d8c-a5b4-a25dd92f666a";
            const string reinstatedStatus = "Active";

            var data = new
            {
                shareKind = "InPlace"
            };

            AcceptedSentSharesClient acceptedSentSharesClient = GetAcceptedSentSharesClient();

            //Reinstate
            await acceptedSentSharesClient.ReinstateAsync(WaitUntil.Completed, sentShareName, acceptedSentShareName, RequestContent.Create(data));

            //Get Accepted Sent Share
            Response getResponse = await acceptedSentSharesClient.GetAcceptedSentShareAsync(sentShareName, acceptedSentShareName);

            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(getResponse));
            JsonElement getResponseJson = jsonDocument.RootElement;

            Assert.AreEqual(reinstatedStatus, getResponseJson.GetProperty("properties").GetProperty("receivedShareStatus").GetString());
        }

        [RecordedTest]
        public async Task CreateAssetMappingTest()
        {
            const string receivedShareName = "sentShare1";
            const string assetMappingName = "testAsset1";
            const string assetMappingStatus = "Ok";
            const string provisioningState = "Succeeded";

            var data = new
            {
                kind = "AdlsGen2Account",
                properties = new
                {
                    assetId = "18c8af16-db4c-4a1d-9101-94b3e7ff3f25",
                    storageAccountResourceId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan",
                    containerName = "receivepath1",
                    mountPath = "",
                    folder = "receiveFolder1"
                }
            };

            //Get AssetMappingsClient
            AssetMappingsClient assetMappingsClient = GetAssetMappingsClient();

            //Create Asset Mapping to delete
            Operation<BinaryData> createResponse = await assetMappingsClient.CreateAsync(WaitUntil.Completed, receivedShareName, assetMappingName, RequestContent.Create(data));

            //Assert MappingStatus and ProvisioningState
            using var jsonDocument = JsonDocument.Parse(createResponse.Value);
            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            Assert.AreEqual(assetMappingStatus, properties.GetProperty("assetMappingStatus").ToString());
            Assert.AreEqual(provisioningState, properties.GetProperty("provisioningState").ToString());
        }

        [RecordedTest]
        public async Task DeleteAssetMappingTest()
        {
            const string receivedShareName = "sentShare1";
            const string assetMappingName = "testAsset1";

            //Get AssetMappingsClient
            AssetMappingsClient assetMappingsClient = GetAssetMappingsClient();

            //Delete Asset Mapping
            Operation operation = await assetMappingsClient.DeleteAsync(WaitUntil.Completed, receivedShareName, assetMappingName);

            //Get Response
            Response response = operation.GetRawResponse();

            //Assert Status
            Assert.AreEqual(200, response.Status);
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

        private async Task CreateSentShare(string sentShareName = "sentShare1")
        {
            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    description = "",
                    collection = new
                    {
                        referenceName = "w95gh9ze",
                        type = "CollectionReference"
                    }
                }
            };

            //Create sent shares client
            SentSharesClient client = GetSentSharesClient();

            //Create a new sent share
            await client.CreateOrUpdateAsync(sentShareName, RequestContent.Create(data));
        }

        private async Task CreateAdlsGen2Asset(
            string sentShareName = "sentShare1",
            string assetName = "asset1",
            string receiverAssetName = "testAsset1",
            string storageAccountResourceId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan",
            string containerName = "container1",
            string senderPath = "testfolder1",
            string receiverPath = "testfolder1")
        {
            AssetsClient assetsClient = GetAssetsClient();

            var assetData = new
            {
                kind = "AdlsGen2Account",
                properties = new
                {
                    storageAccountResourceId = storageAccountResourceId,
                    receiverAssetName = receiverAssetName,
                    paths = new[]
                     {
                        new { containerName, senderPath, receiverPath }
                    }
                }
            };

            //Create a new asset
            await assetsClient.CreateAsync(WaitUntil.Started, sentShareName, assetName, RequestContent.Create(assetData));
        }

        private async Task CreateSentShareInvitation()
        {
            //Create sent share invitations client
            SentShareInvitationsClient sentShareInvitationsClient = GetSentShareInvitationsClient();

            var sentShareInvitationData = new
            {
                invitationKind = "Application",
                properties = new
                {
                    TargetActiveDirectoryId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    TargetObjectId = "fc010728-94f6-4e9c-be3c-c08687414bd4"
                }
            };

            //Create a new invitation
            Response sentShareInvitationResponse = await sentShareInvitationsClient.CreateOrUpdateAsync("sentShare1", "invitation2", RequestContent.Create(sentShareInvitationData));
        }

        #endregion
    }
}
