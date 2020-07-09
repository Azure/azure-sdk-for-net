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
        public object _customEvent;
        public CancellationToken _cancellationToken;
        public ObjectSerializer _serializer;

        public EventGridSerializer(object customEvent, ObjectSerializer serializer, CancellationToken cancellationToken)
        {
            _customEvent = customEvent;
            _serializer = serializer;
            _cancellationToken = cancellationToken;
        }
        public void Write(Utf8JsonWriter writer)
        {
            var stream = new MemoryStream();
            _serializer.Serialize(stream, _customEvent, _customEvent.GetType(), _cancellationToken);
            stream.Seek(0, SeekOrigin.Begin);
            JsonDocument.Parse(stream).WriteTo(writer);
        }
    }
}
