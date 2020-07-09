// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    internal class EventGridSerializer : IUtf8JsonSerializable
    {
        public object _egEvent;
        public CancellationToken _cancellationToken;

        public EventGridSerializer(object egEvent, CancellationToken cancellationToken)
        {
            _egEvent = egEvent;
            _cancellationToken = cancellationToken;
        }
        public void Write(Utf8JsonWriter writer)
        {
            JsonObjectSerializer serializer = new JsonObjectSerializer();
            var stream = new MemoryStream();
            serializer.Serialize(stream, _egEvent, typeof(object), _cancellationToken);
            stream.Seek(0, SeekOrigin.Begin);
            JsonDocument.Parse(stream).WriteTo(writer);
        }
    }
}
