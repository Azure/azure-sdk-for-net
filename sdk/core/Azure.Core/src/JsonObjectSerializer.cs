// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// A <see cref="JsonObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class JsonObjectSerializer : ObjectSerializer
    {
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes new instance of <see cref="JsonObjectSerializer"/>.
        /// </summary>
        public JsonObjectSerializer() : this(new JsonSerializerOptions())
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> instance to use when serializing/deserializing.</param>
        public JsonObjectSerializer(JsonSerializerOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public override void Serialize(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            var buffer = JsonSerializer.SerializeToUtf8Bytes(value, inputType, _options);
            stream.Write(buffer, 0, buffer.Length);
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object? value, Type inputType, CancellationToken cancellationToken)
        {
            await JsonSerializer.SerializeAsync(stream, value, inputType, _options, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return JsonSerializer.Deserialize(memoryStream.ToArray(), returnType, _options);
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync(stream, returnType, _options, cancellationToken).ConfigureAwait(false);
        }
    }
}