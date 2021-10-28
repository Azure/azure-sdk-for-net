// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    ///
    /// </summary>
    public static class SchemaRegistryAvroEncoderExtensions
    {
        private const string AvroMimeType = "avro/binary";

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="avroEncoder"></param>
        /// <param name="value"></param>
        /// <param name="inputType"></param>
        /// <param name="cancellationToken"></param>
        public static void EncodeMessageBody(
            this MessageWithMetadata message,
            SchemaRegistryAvroEncoder avroEncoder,
            object value,
            Type inputType = default,
            CancellationToken cancellationToken = default)
        {
            (string schemaId, BinaryData data) = avroEncoder.Encode(value, inputType ?? value?.GetType(), cancellationToken);
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            message.Data = data;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="avroEncoder"></param>
        /// <param name="value"></param>
        /// <param name="inputType"></param>
        /// <param name="cancellationToken"></param>
        public static async Task EncodeMessageBodyAsync(
            this MessageWithMetadata message,
            SchemaRegistryAvroEncoder avroEncoder,
            object value,
            Type inputType = default,
            CancellationToken cancellationToken = default)
        {
            (string schemaId, BinaryData data) = await avroEncoder.EncodeAsync(value, inputType ?? value?.GetType(), cancellationToken).ConfigureAwait(false);
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            message.Data = data;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="avroEncoder"></param>
        /// <param name="returnType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static object DecodeMessageBody(
            this ReadOnlyMessageWithMetadata message,
            SchemaRegistryAvroEncoder avroEncoder,
            Type returnType,
            CancellationToken cancellationToken = default)
            => DecodeMessageBodyInternalAsync(message, avroEncoder, returnType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="avroEncoder"></param>
        /// <param name="returnType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async ValueTask<object> DecodeMessageBodyAsync(
            this ReadOnlyMessageWithMetadata message,
            SchemaRegistryAvroEncoder avroEncoder,
            Type returnType,
            CancellationToken cancellationToken = default)
            => await DecodeMessageBodyInternalAsync(message, avroEncoder, returnType, true, cancellationToken).ConfigureAwait(false);

        private static async ValueTask<object> DecodeMessageBodyInternalAsync(
            ReadOnlyMessageWithMetadata message,
            SchemaRegistryAvroEncoder avroEncoder,
            Type returnType,
            bool async,
            CancellationToken cancellationToken)
        {
            string[] contentType = message.ContentType.Split('+');
            if (contentType.Length != 2)
            {
                throw new FormatException("Content type was not in the expected format of MIME type + schema ID");
            }

            if (contentType[0] != AvroMimeType)
            {
                throw new InvalidOperationException("An avro encoder may only be used on content that is of 'avro/binary' type");
            }

            if (async)
            {
                return await avroEncoder.DecodeAsync(message.Data, contentType[1], returnType, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return avroEncoder.Decode(message.Data, contentType[1], returnType, cancellationToken);
            }
        }
    }
}