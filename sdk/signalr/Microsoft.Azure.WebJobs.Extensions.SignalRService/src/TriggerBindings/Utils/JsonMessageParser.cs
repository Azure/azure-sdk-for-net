// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;

using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Serverless.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class JsonMessageParser : MessageParser
    {
        private static readonly IServerlessProtocol ServerlessProtocol = new JsonServerlessProtocol();

        public override bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out ServerlessMessage message) =>
            ServerlessProtocol.TryParseMessage(ref buffer, out message);

        public override IHubProtocol Protocol { get; } = new JsonHubProtocol();
    }
}