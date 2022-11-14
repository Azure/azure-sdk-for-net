// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal class WebPubSubJsonProtocolBase
    {
        public ReadOnlyMemory<byte> GetMessageBytes(WebPubSubMessage message)
        {
            throw new NotImplementedException();
        }

        public virtual WebPubSubMessage ParseMessage(ReadOnlySequence<byte> input)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteMessage(WebPubSubMessage message, IBufferWriter<byte> output)
        {
            throw new NotImplementedException();
        }
    }
}
