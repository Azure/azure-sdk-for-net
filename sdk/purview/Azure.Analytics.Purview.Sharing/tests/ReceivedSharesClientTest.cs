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
    public class ReceivedSharesClientTest : ReceivedSharesClientTestBase
    {
        private string receivedShareId => "098d6c8e-165f-4cf1-9653-79f6a7f99048";

        public ReceivedSharesClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateReceivedShareTest()
        {
            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    sink = new
                    {
                        storeKind = "AdlsGen2Account",
                        storeReference = new
                        {
                            referenceName = "/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/consumeraccount",
                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
                            containerName = "container222613",
                            folder = "folder222613",
                            mountPath = "",
                        }
                    },
                    displayName = "testDisplayName1",
                }
            };

            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation<BinaryData> createResponse = await client.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, receivedShareId, RequestContent.Create(data));

            Assert.That(createResponse.HasCompleted, Is.True);

            var jsonDocument = JsonDocument.Parse(createResponse.Value);
            var actualId = jsonDocument.RootElement.GetProperty("id").ToString();

            Assert.That(actualId, Is.EqualTo(receivedShareId));

            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            var actualShareStatus = properties.GetProperty("shareStatus").ToString();

            Assert.That(actualShareStatus, Is.EqualTo("Attached"));
        }

        [RecordedTest]
        public async Task GetReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Response response = await client.GetReceivedShareAsync(receivedShareId, new());

            var jsonDocument = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocument.RootElement;

            Assert.That(getBodyJson.GetProperty("id").GetString(), Is.EqualTo(receivedShareId));
        }

        [RecordedTest]
        public async Task DeleteReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation response = await client.DeleteReceivedShareAsync(WaitUntil.Completed, receivedShareId, new());

            Assert.That(response.HasCompleted, Is.True);
        }

        [RecordedTest]
        public async Task GetDetachedReceivedSharesTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            List<BinaryData> detachedReceivedShares = await client.GetAllDetachedReceivedSharesAsync(null, null, new()).ToEnumerableAsync();

            Assert.Greater(detachedReceivedShares.Count, 0);

            var detachedReceivedShare = detachedReceivedShares[0];

            var jsonDocument = JsonDocument.Parse(detachedReceivedShare);

            var actualShareStatus = jsonDocument.RootElement.GetProperty("properties").GetProperty("shareStatus").ToString();

            Assert.That(actualShareStatus, Is.EqualTo("Detached"));
        }

        [RecordedTest]
        public async Task GetAttachedReceivedSharesTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            List<BinaryData> attachedReceivedShares = await client.GetAllAttachedReceivedSharesAsync("/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/consumeraccount", null, null, new()).ToEnumerableAsync();

            Assert.Greater(attachedReceivedShares.Count, 0);

            var attachedReceivedShare = attachedReceivedShares[0];

            var jsonDocument = JsonDocument.Parse(attachedReceivedShare);

            var actualShareStatus = jsonDocument.RootElement.GetProperty("properties").GetProperty("shareStatus").ToString();

            Assert.That(actualShareStatus, Is.EqualTo("Attached"));
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
