// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR.Serverless.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal abstract class MessageParser
    {
        public static readonly MessageParser Json = new JsonMessageParser();
        public static readonly MessageParser MessagePack = new MessagePackMessageParser();

        public static MessageParser GetParser(string protocol)
        {
            switch (protocol)
            {
                case Constants.JsonContentType:
                    return Json;
                case Constants.MessagePackContentType:
                    return MessagePack;
                default:
                    return null;
            }
        }

        public abstract bool TryParseMessage(ref ReadOnlySequence<byte> buffer, out ServerlessMessage message);

        public abstract IHubProtocol Protocol { get; }
    }
}