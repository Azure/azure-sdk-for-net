// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP3_1_OR_GREATER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub.Clients;
using Xunit;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    public class WebPubSubClientLiveTest
    {
        private static Random _random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        [SkipIfNoConnectionString]
        public async Task LiveHelloWorldTest()
        {
            var serviceClient = new WebPubSubServiceClient(Environment.GetEnvironmentVariable("AWPS_CONNECTION_STRING"), "hub");

            var client = new WebPubSubClient(new WebPubSubClientCredential(token =>
                new ValueTask<Uri>(serviceClient.GetClientAccessUriAsync(roles: new[] { "webpubsub.joinLeaveGroup", "webpubsub.sendToGroup" }))));

            var connectedTcs = new MultipleTimesTaskCompletionSource<WebPubSubConnectedEventArgs>(10);
            var disconnectedTcs = new MultipleTimesTaskCompletionSource<WebPubSubDisconnectedEventArgs>(10);
            var groupMessageTcs = new MultipleTimesTaskCompletionSource<WebPubSubGroupMessageEventArgs>(10);

            client.Connected += e =>
            {
                connectedTcs.IncreaseCallTimes(e);
                return Task.CompletedTask;
            };
            client.Disconnected += e =>
            {
                disconnectedTcs.IncreaseCallTimes(e);
                return Task.CompletedTask;
            };
            client.GroupMessageReceived += e =>
            {
                groupMessageTcs.IncreaseCallTimes(e);
                return Task.CompletedTask;
            };

            await client.StartAsync();

            await connectedTcs.VerifyCalledTimesAsync(1).OrTimeout();

            var groupName = RandomString(10);
            await client.JoinGroupAsync(groupName);

            await client.SendToGroupAsync(groupName, BinaryData.FromString("hello world"), WebPubSubDataType.Text);
            var message = await groupMessageTcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("hello world", message.Message.Data.ToString());
            Assert.Equal(groupName, message.Message.Group);

            await client.SendToGroupAsync(groupName, BinaryData.FromObjectAsJson(new JsonPayload
            {
                Foo = "Hello World!",
                Bar = 42
            }), WebPubSubDataType.Json);
            message = await groupMessageTcs.VerifyCalledTimesAsync(2).OrTimeout();
            var payload = message.Message.Data.ToObjectFromJson<JsonPayload>();
            Assert.Equal("Hello World!", payload.Foo);
            Assert.Equal(42, payload.Bar);

            await client.SendToGroupAsync(groupName, BinaryData.FromBytes(Convert.FromBase64String("aGVsbG8gd29ybGQ=")), WebPubSubDataType.Binary);
            message = await groupMessageTcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.Equal("hello world", message.Message.Data.ToString());

            await client.StopAsync();
            await disconnectedTcs.VerifyCalledTimesAsync(1).OrTimeout();

            await client.StartAsync();
            await connectedTcs.VerifyCalledTimesAsync(2).OrTimeout();

            await client.StopAsync();
            await disconnectedTcs.VerifyCalledTimesAsync(2).OrTimeout();
        }

        private class JsonPayload
        {
            public string Foo { get; set; }
            public int Bar { get; set; }
        }
    }
}
#endif
