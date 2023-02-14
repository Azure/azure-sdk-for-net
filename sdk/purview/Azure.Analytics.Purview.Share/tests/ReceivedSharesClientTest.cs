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
    public class ReceivedSharesClientTest : ReceivedSharesClientTestBase
    {
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
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan",
                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
                            containerName = "container213509",
                            folder = "folder213509",
                            mountPath = "",
                        }
                    },
                    displayName = "testDisplayName1",
                }
            };

            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation<BinaryData> createResponse = await client.CreateOrUpdateReceivedShareAsync(WaitUntil.Completed, "fd19de76-ced3-4199-99cc-001ad46fa5c5", RequestContent.Create(data));

            Assert.IsTrue(createResponse.HasCompleted);

            var jsonDocument = JsonDocument.Parse(createResponse.Value);
            var actualId = jsonDocument.RootElement.GetProperty("id").ToString();

            Assert.AreEqual("fd19de76-ced3-4199-99cc-001ad46fa5c5", actualId);

            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            var actualShareStatus = properties.GetProperty("shareStatus").ToString();

            Assert.AreEqual("Attached", actualShareStatus);
        }

        [RecordedTest]
        public async Task GetReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Response response = await client.GetReceivedShareAsync("fd19de76-ced3-4199-99cc-001ad46fa5c5");

            var jsonDocument = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocument.RootElement;

            Assert.AreEqual("fd19de76-ced3-4199-99cc-001ad46fa5c5", getBodyJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task DeleteReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation response = await client.DeleteReceivedShareAsync(WaitUntil.Completed, "fd19de76-ced3-4199-99cc-001ad46fa5c5");

            Assert.IsTrue(response.HasCompleted);
        }

        [RecordedTest]
        public async Task GetDetachedReceivedSharesTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            List<BinaryData> detachedReceivedShares = await client.GetAllDetachedReceivedSharesAsync().ToEnumerableAsync();

            Assert.AreEqual(1, detachedReceivedShares.Count);

            var detachedReceivedShare = detachedReceivedShares[0];

            var jsonDocument = JsonDocument.Parse(detachedReceivedShare);

            var actualShareStatus = jsonDocument.RootElement.GetProperty("properties").GetProperty("shareStatus").ToString();

            Assert.AreEqual("Detached", actualShareStatus);
        }

        [RecordedTest]
        public async Task GetAttachedReceivedSharesTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            List<BinaryData> attachedReceivedShares = await client.GetAllAttachedReceivedSharesAsync("/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan").ToEnumerableAsync();

            Assert.AreEqual(1, attachedReceivedShares.Count);

            var attachedReceivedShare = attachedReceivedShares[0];

            var jsonDocument = JsonDocument.Parse(attachedReceivedShare);

            var actualShareStatus = jsonDocument.RootElement.GetProperty("properties").GetProperty("shareStatus").ToString();

            Assert.AreEqual("Attached", actualShareStatus);
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
