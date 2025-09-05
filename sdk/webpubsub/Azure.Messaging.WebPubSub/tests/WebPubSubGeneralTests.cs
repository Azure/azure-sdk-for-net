// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.WebPubSub;

using NUnit.Framework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubGeneralTests : RecordedTestBase<WebPubSubTestEnvironment>
    {
        public WebPubSubGeneralTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task ServiceClientCanBroadcastMessages()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());

            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(ServiceClientCanBroadcastMessages), options);
            // broadcast messages
            var textContent = "Hello";
            var response = await serviceClient.SendToAllAsync(textContent, ContentType.TextPlain);

            Assert.AreEqual(202, response.Status);

            var jsonContent = BinaryData.FromObjectAsJson(new { hello = "world" });
            response = await serviceClient.SendToAllAsync(RequestContent.Create(jsonContent), ContentType.ApplicationJson);
            Assert.AreEqual(202, response.Status);
            var binaryContent = BinaryData.FromString("Hello");
            response = await serviceClient.SendToAllAsync(RequestContent.Create(binaryContent), ContentType.ApplicationOctetStream);
            Assert.AreEqual(202, response.Status);
        }

        [TestCase(6, 6, null, 6, 1)]
        [TestCase(6, 3, null, 3, 1)]
        [TestCase(6, null, 2, 6, 3)]
        [TestCase(6, 5, 2, 5, 3)]
        public async Task ServiceClientCanListConnectionsInGroup(int totalConnectionCount, int? maxCountToList, int? maxPageSize, int expectedTotalCount, int expectedPageCount)
        {
            WebPubSubServiceClientOptions serviceClientOptions = InstrumentClientOptions(new WebPubSubServiceClientOptions());
            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(ServiceClientCanListConnectionsInGroup).ToLower(), serviceClientOptions);

            // Connect a few websocket connections to a group
            var groupName = "group1";
            Uri clientAccessUri = serviceClient.GetClientAccessUri(groups: [groupName]);

            var clients = new ClientWebSocket[totalConnectionCount];
            // Client WebSocket connections cannot be recorded, so disable them in playback mode.
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
            {
                for (int i = 0; i < totalConnectionCount; i++)
                {
                    var client = new ClientWebSocket();
                    await client.ConnectAsync(clientAccessUri, CancellationToken.None);
                    clients[i] = client;
                }
            }

            // List connections in the group
            var actualPageCount = 0;
            var actualConnectionCount = 0;

            await foreach (Page<WebPubSubGroupMember> page in serviceClient.ListConnectionsInGroupAsync(groupName, maxPageSize, maxCountToList).AsPages())
            {
                //actualPageCount++;
                actualConnectionCount += page.Values.Count;
                actualPageCount++;
            }

            Assert.AreEqual(expectedPageCount, actualPageCount);
            Assert.AreEqual(expectedTotalCount, actualConnectionCount);

            if (TestEnvironment.Mode != RecordedTestMode.Playback)
            {
                foreach (ClientWebSocket client in clients)
                {
                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    client.Dispose();
                }
            }
        }

        [Test]
        public async Task ServiceClientCanListConnectionsInGroupWithContinuationToken()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());
            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(ServiceClientCanListConnectionsInGroupWithContinuationToken).ToLower(), options);

            // Connect a few websocket connections to a group
            var groupName = nameof(ServiceClientCanListConnectionsInGroupWithContinuationToken).ToLower();
            var totalCount = 2;
            Uri clientAccessUri = serviceClient.GetClientAccessUri(groups: [groupName]);

            var clients = new ClientWebSocket[totalCount];
            // Client WebSocket connections cannot be recorded, so disable them in playback mode.
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
            {
                for (int i = 0; i < totalCount; i++)
                {
                    var client = new ClientWebSocket();
                    await client.ConnectAsync(clientAccessUri, CancellationToken.None);
                    clients[i] = client;
                }
            }

            // List connections in the group
            var firstContinuationToken = "";
            var firstPageSize = 0;

            await foreach (var page in serviceClient.ListConnectionsInGroupAsync(groupName, maxpagesize: 1).AsPages())
            {
                firstContinuationToken = page.ContinuationToken;
                firstPageSize = page.Values.Count;
                break;
            }

            List<WebPubSubGroupMember> remainingConnectionsAfterFirstPage = await serviceClient.ListConnectionsInGroupAsync(groupName, continuationToken: firstContinuationToken).ToEnumerableAsync();
            Assert.AreEqual(totalCount - firstPageSize, remainingConnectionsAfterFirstPage.Count);

            if (TestEnvironment.Mode != RecordedTestMode.Playback)
            {
                foreach (ClientWebSocket client in clients)
                {
                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    client.Dispose();
                }
            }
        }
    }
}
