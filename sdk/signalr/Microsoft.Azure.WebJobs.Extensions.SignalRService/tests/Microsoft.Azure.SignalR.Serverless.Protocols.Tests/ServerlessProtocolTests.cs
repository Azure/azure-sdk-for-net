// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Common;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.SignalR.Serverless.Protocols.Tests
{
    public class ServerlessProtocolTests
    {
        public static IEnumerable<object[]> GetParameters()
        {
            var protocols = new string[] { "json", "messagepack" };
            foreach (var protocol in protocols)
            {
                yield return new object[] { protocol, null, Guid.NewGuid().ToString(), new object[0] };
                yield return new object[] { protocol, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new object[0] };
                yield return new object[]
                {
                    protocol,
                    Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    new object[] {Guid.NewGuid().ToString(), Guid.NewGuid().ToString()}
                };
                yield return new object[]
                {
                    protocol,
                    Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    new object[] {new object[] {Guid.NewGuid().ToString()}, Guid.NewGuid().ToString()}
                };
                yield return new object[]
                {
                    protocol,
                    Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new object[] { new Dictionary<string, string>
                    {
                        [Guid.NewGuid().ToString()] = Guid.NewGuid().ToString(),
                        [Guid.NewGuid().ToString()] = Guid.NewGuid().ToString(),
                    }}
                };
                yield return new object[]
                {
                    protocol,
                    Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                    new object[] {new object[] { null, Guid.NewGuid().ToString() }}
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetParameters))]
        public void InvocationMessageParseTest(string protocolName, string invocationId, string target, object[] arguments)
        {
            var message = new AspNetCore.SignalR.Protocol.InvocationMessage(invocationId, target, arguments);
            IHubProtocol protocol = protocolName == "json" ? (IHubProtocol)new JsonHubProtocol() : new MessagePackHubProtocol();
            var bytes = new ReadOnlySequence<byte>(protocol.GetMessageBytes(message));
            ReadOnlySequence<byte> payload;
            if (protocolName == "json")
            {
                TextMessageParser.TryParseMessage(ref bytes, out payload);
            }
            else
            {
                BinaryMessageParser.TryParseMessage(ref bytes, out payload);
            }
            var serverlessProtocol = protocolName == "json" ? (IServerlessProtocol)new JsonServerlessProtocol() : new MessagePackServerlessProtocol();
            Assert.True(serverlessProtocol.TryParseMessage(ref payload, out var parsedMessage));
            var invocationMessage = (InvocationMessage)parsedMessage;
            Assert.Equal(1, invocationMessage.Type);
            Assert.Equal(invocationId, invocationMessage.InvocationId);
            Assert.Equal(target, invocationMessage.Target);
            var expected = JsonConvert.SerializeObject(arguments);
            var actual = JsonConvert.SerializeObject(invocationMessage.Arguments);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OpenConnectionMessageParseTest()
        {
            var openConnectionPayload = new ReadOnlySequence<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new OpenConnectionMessage { Type = 10 })));
            var serverlessProtocol = new JsonServerlessProtocol();
            Assert.True(serverlessProtocol.TryParseMessage(ref openConnectionPayload, out var message));
            Assert.Equal(typeof(OpenConnectionMessage), message.GetType());
        }

        [Theory]
        [InlineData("")]
        [InlineData("error")]
        [InlineData(null)]
        public void CloseConnectionMessageParseTest(string error)
        {
            var openConnectionPayload = new ReadOnlySequence<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new CloseConnectionMessage() { Type = 11, Error = error })));
            var serverlessProtocol = new JsonServerlessProtocol();
            Assert.True(serverlessProtocol.TryParseMessage(ref openConnectionPayload, out var message));
            Assert.Equal(error, ((CloseConnectionMessage)message).Error);
            Assert.Equal(typeof(CloseConnectionMessage), message.GetType());
        }
    }
}