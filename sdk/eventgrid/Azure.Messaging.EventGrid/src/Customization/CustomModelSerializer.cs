// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// UTF-8 JSON-serializable wrapper for objects such as custom schema events.
    /// Takes a custom ObjectSerializer to use when writing the object as JSON text.
    /// </summary>
    internal class CustomModelSerializer : IUtf8JsonSerializable
    {
        public object _payload;
        public CancellationToken _cancellationToken;
        public ObjectSerializer _serializer;

        /// <summary>
        /// Initializes an instance of the CustomModelSerializer class.
        /// </summary>
        /// <param name="payload">
        /// Object that can represent an event with a custom schema, or additional properties
        /// added to the event envelope.
        /// </param>
        /// <param name="serializer">
        /// Custom ObjectSerializer to use when writing the object as JSON text.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public CustomModelSerializer(object payload, ObjectSerializer serializer, CancellationToken cancellationToken)
        {
            _payload = payload;
            _serializer = serializer;
            _cancellationToken = cancellationToken;
        }
        public void Write(Utf8JsonWriter writer)
        {
            var stream = new MemoryStream();
            _serializer.Serialize(stream, _payload, _payload.GetType(), _cancellationToken);
            stream.Seek(0, SeekOrigin.Begin);
            JsonDocument.Parse(stream).WriteTo(writer);
        }
    }
}
