// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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