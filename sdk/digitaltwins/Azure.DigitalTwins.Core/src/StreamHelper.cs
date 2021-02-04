// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    internal static class StreamHelper
    {
        /// <summary>
        /// Serializes an object and writes it into a memory stream.
        /// </summary>
        /// <typeparam name="T">Generic type of the object being serialized.</typeparam>
        /// <param name="obj">Object being serialized.</param>
        /// <param name="objectSerializer">Object serializer used to serialize/deserialize an object.</param>
        /// <param name="cancellationToken">Then cancellation token.</param>
        /// <returns>A binary representation of the object written to a stream. Requires disposing.</returns>
        internal static async Task<MemoryStream> WriteToStreamAsync<T>(T obj, ObjectSerializer objectSerializer, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();

            await objectSerializer.SerializeAsync(memoryStream, obj, typeof(T), cancellationToken).ConfigureAwait(false);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        /// <summary>
        /// Serializes an object and writes it into a memory stream.
        /// </summary>
        /// <typeparam name="T">Generic type of the object being serialized.</typeparam>
        /// <param name="obj">Object being serialized.</param>
        /// <param name="objectSerializer">Object serializer used to serialize/deserialize an object.</param>
        /// <param name="cancellationToken">Then cancellation token.</param>
        /// <returns>A binary representation of the object written to a stream. Requires disposing.</returns>
        internal static MemoryStream WriteToStream<T>(T obj, ObjectSerializer objectSerializer, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();

            objectSerializer.Serialize(memoryStream, obj, typeof(T), cancellationToken);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        /// <summary>
        /// Serializes a JsonElement and writes it into a memory stream.
        /// </summary>
        /// <param name="item">JsonElement to be deserialized into a stream.</param>
        /// <returns>A binary representation of the object written to a stream.</returns>
        internal static MemoryStream WriteJsonElementToStream(JsonElement item)
        {
            var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            item.WriteTo(writer);
            writer.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
