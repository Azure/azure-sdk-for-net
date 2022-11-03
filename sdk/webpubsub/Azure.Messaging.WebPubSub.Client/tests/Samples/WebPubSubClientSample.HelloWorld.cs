// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP3_1_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub.Clients;
using Xunit;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    public class WebPubSubClientSample
    {
        public void ConstructWebPubSubClient()
        {
            #region Snippet:WebPubSubClient_Construct
            var client = new WebPubSubClient(new Uri("<client-access-uri>"));
            #endregion
        }

        public void ConstructWebPubSubClient2()
        {
            #region Snippet:WebPubSubClient_Construct2
            var serviceClient = new WebPubSubServiceClient("<connection-string>", "hub");

            var client = new WebPubSubClient(new WebPubSubClientCredential(token =>
            {
                return new ValueTask<Uri>(serviceClient.GetClientAccessUriAsync(roles: new[] { "webpubsub.joinLeaveGroup", "webpubsub.sendToGroup" }));
            }));
            #endregion
        }

        public void WebPubSubClientSubscribeConnected(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_Connected
            client.Connected += e =>
            {
                Console.WriteLine($"Connection {e.ConnectionId} is connected");
                return Task.CompletedTask;
            };
            #endregion
        }

        public void WebPubSubClientSubscribeDisconnected(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_Disconnected
            client.Disconnected += e =>
            {
                Console.WriteLine($"Connection is disconnected");
                return Task.CompletedTask;
            };
            #endregion
        }

        public void WebPubSubClientSubscribeStopped(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_Stopped
            client.Stopped += e =>
            {
                Console.WriteLine($"Client is stopped");
                return Task.CompletedTask;
            };
            #endregion
        }

        public void WebPubSubClientSubscribeServerMessage(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_ServerMessage
            client.ServerMessageReceived += e =>
            {
                Console.WriteLine($"Receive message: {e.Message.Data}");
                return Task.CompletedTask;
            };
            #endregion
        }

        public void WebPubSubClientSubscribeGroupMessage(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_GroupMessage
            client.GroupMessageReceived += e =>
            {
                Console.WriteLine($"Receive group message from {e.Message.Group}: {e.Message.Data}");
                return Task.CompletedTask;
            };
            #endregion
        }

        public void WebPubSubClientSubscribeRestoreFailed(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_Subscribe_RestoreFailed
            client.RestoreGroupFailed += e =>
            {
                Console.WriteLine($"Restore group failed");
                return Task.CompletedTask;
            };
            #endregion
        }

        public async Task WebPubSubClientSendToGroup(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_SendToGroup
            // Send message to group "testGroup"
            await client.SendToGroupAsync("testGroup", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
            #endregion
        }

        public async Task WebPubSubClientSendEvent(WebPubSubClient client)
        {
            #region Snippet:WebPubSubClient_SendEvent
            // Send custom event to server
            await client.SendEventAsync("testEvent", BinaryData.FromString("hello world"), WebPubSubDataType.Text);
            #endregion
        }
    }
}
#endif
