// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Serverless.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class MessagePackMessageParser : MessageParser
    {
        private static readonly IServerlessProtocol ServerlessProtocol = new MessagePackServerlessProtocol();

        public override bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out ServerlessMessage message) =>
            ServerlessProtocol.TryParseMessage(ref buffer, out message);

        public override IHubProtocol Protocol { get; } = new MessagePackHubProtocol();
    }
}