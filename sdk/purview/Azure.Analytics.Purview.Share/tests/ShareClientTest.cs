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
