// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Buffers;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    public class JsonServerlessProtocol : IServerlessProtocol
    {
        private const string TypePropertyName = "type";

        public int Version => 1;

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

        private ServerlessMessage SafeParseMessage<T>(JObject jObject) where T : ServerlessMessage
        {
            try
            {
                return jObject.ToObject<T>();
            }
            catch
            {
                return null;
            }
        }
    }
}