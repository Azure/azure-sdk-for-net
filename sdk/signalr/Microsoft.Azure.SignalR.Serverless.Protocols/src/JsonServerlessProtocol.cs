// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// Implementing serverless protocol with JSON.
    /// </summary>
    public class JsonServerlessProtocol : IServerlessProtocol
    {
        private const string TypePropertyName = "type";

        /// <inheritdoc/>
        public int Version => 1;

        /// <inheritdoc/>
        public bool TryParseMessage(ref ReadOnlySequence<byte> input, out ServerlessMessage message)
        {
            var textReader = new JsonTextReader(new StreamReader(new ReadOnlySequenceStream(input)));
            var jObject = JObject.Load(textReader);
            if (jObject.TryGetValue(TypePropertyName, StringComparison.OrdinalIgnoreCase, out var token))
            {
                var type = token.Value<int>();
                switch (type)
                {
                    case ServerlessProtocolConstants.InvocationMessageType:
                        message = SafeParseMessage<InvocationMessage>(jObject);
                        break;
                    case ServerlessProtocolConstants.OpenConnectionMessageType:
                        message = SafeParseMessage<OpenConnectionMessage>(jObject);
                        break;
                    case ServerlessProtocolConstants.CloseConnectionMessageType:
                        message = SafeParseMessage<CloseConnectionMessage>(jObject);
                        break;
                    default:
                        message = null;
                        break;
                }
                return message != null;
            }
            message = null;
            return false;
        }

        private static ServerlessMessage SafeParseMessage<T>(JObject jObject) where T : ServerlessMessage
        {
            try
            {
                return jObject.ToObject<T>();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                return null;
            }
        }
    }
}