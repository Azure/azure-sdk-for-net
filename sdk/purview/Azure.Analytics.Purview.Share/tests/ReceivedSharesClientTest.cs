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
                            containerName = "container2111212",
                            folder = "folder2111212",
                            mountPath = "",
                        }
                    },
                    displayName = "testDisplayName1",
                }
            };

            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation<BinaryData> createResponse = await client.CreateAsync(WaitUntil.Completed, "2d18740a-786b-475c-b791-c36fcaf884e7", RequestContent.Create(data));

            Assert.IsTrue(createResponse.HasCompleted);

            var jsonDocument = JsonDocument.Parse(createResponse.Value);
            var actualId = jsonDocument.RootElement.GetProperty("id").ToString();

            Assert.AreEqual("2d18740a-786b-475c-b791-c36fcaf884e7", actualId);

            JsonElement properties = jsonDocument.RootElement.GetProperty("properties");

            var actualShareStatus = properties.GetProperty("shareStatus").ToString();

            Assert.AreEqual("Attached", actualShareStatus);
        }

        [RecordedTest]
        public async Task GetReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Response response = await client.GetReceivedShareAsync("56f029a1-7692-46aa-8412-8bab6e685965");

            var jsonDocument = JsonDocument.Parse(GetContentFromResponse(response));
            JsonElement getBodyJson = jsonDocument.RootElement;

            Assert.AreEqual("56f029a1-7692-46aa-8412-8bab6e685965", getBodyJson.GetProperty("id").GetString());
        }

        [RecordedTest]
        public async Task DeleteReceivedShareTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            Operation response = await client.DeleteAsync(WaitUntil.Completed, "58657a0e-3591-48e8-9904-7fc0d2a93b80");

            Assert.IsTrue(response.HasCompleted);
        }

        [RecordedTest]
        public async Task GetDetachedReceivedSharesTest()
        {
            ReceivedSharesClient client = GetReceivedSharesClient();

            List<BinaryData> detachedReceivedShares = await client.GetDetachedsAsync().ToEnumerableAsync();

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

            List<BinaryData> detachedReceivedShares = await client.GetAttachedsAsync("").ToEnumerableAsync();
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
