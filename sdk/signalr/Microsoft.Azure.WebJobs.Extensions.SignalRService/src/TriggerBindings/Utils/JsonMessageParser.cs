// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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