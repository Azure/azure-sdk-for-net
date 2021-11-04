// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Avro.IO;
using Avro.Specific;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Data.SchemaRegistry;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A <see cref="SchemaRegistryAvroEncoder"/> uses the <see cref="SchemaRegistryClient"/> to
    /// encode and decode Avro payloads.
    /// </summary>
    public class SchemaRegistryAvroEncoder
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaRegistryAvroObjectEncoderOptions _options;
        private const string AvroMimeType = "avro/binary";

        /// <summary>
        /// Initializes new instance of <see cref="SchemaRegistryAvroEncoder"/>.
        /// </summary>
        public SchemaRegistryAvroEncoder(SchemaRegistryClient client, string groupName, SchemaRegistryAvroObjectEncoderOptions options = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;
        }

        // TODO support backcompat for first beta
        // private static readonly byte[] EmptyRecordFormatIndicator = { 0, 0, 0, 0 };
        // private const int RecordFormatIndicatorLength = 4;
        // private const int SchemaIdLength = 32;
        // private const int PayloadStartPosition = RecordFormatIndicatorLength + SchemaIdLength;
        private readonly ConcurrentDictionary<string, Schema> _idToSchemaMap = new();
        private readonly ConcurrentDictionary<Schema, string> _schemaToIdMap = new();

        private enum SupportedType
        {
            SpecificRecord,
            GenericRecord
        }

        private static SupportedType GetSupportedTypeOrThrow(Type type)
        {
            if (typeof(ISpecificRecord).IsAssignableFrom(type))
            {
                return SupportedType.SpecificRecord;
            }

            if (typeof(GenericRecord).IsAssignableFrom(type))
            {
                return SupportedType.GenericRecord;
            }

            throw new ArgumentException($"Type {type.Name} is not supported for serialization operations.");
        }

        private async Task<string> GetSchemaIdAsync(Schema schema, bool async, CancellationToken cancellationToken)
        {
            if (_schemaToIdMap.TryGetValue(schema, out string schemaId))
            {
                return schemaId;
            }

            SchemaProperties schemaProperties;
            if (async)
            {
                schemaProperties = _options.AutoRegisterSchemas
                    ? (await _client
                        .RegisterSchemaAsync(_groupName, schema.Fullname, schema.ToString(), SchemaFormat.Avro, cancellationToken)
                        .ConfigureAwait(false)).Value
                    : await _client
                        .GetSchemaPropertiesAsync(_groupName, schema.Fullname, schema.ToString(), SchemaFormat.Avro, cancellationToken)
                        .ConfigureAwait(false);
            }
            else
            {
                schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, schema.ToString(), SchemaFormat.Avro, cancellationToken)
                    : _client.GetSchemaProperties(_groupName, schema.Fullname, schema.ToString(), SchemaFormat.Avro, cancellationToken);
            }

            string id = schemaProperties.Id;

            _schemaToIdMap.TryAdd(schema, id);
            _idToSchemaMap.TryAdd(id, schema);
            return id;
        }

        private static DatumWriter<object> GetWriterAndSchema(object value, SupportedType supportedType, out Schema schema)
        {
            switch (supportedType)
            {
                case SupportedType.SpecificRecord:
                    schema = ((ISpecificRecord)value).Schema;
                    return new SpecificDatumWriter<object>(schema);
                case SupportedType.GenericRecord:
                    schema = ((GenericRecord)value).Schema;
                    return new GenericDatumWriter<object>(schema);
                default:
                    throw new ArgumentException($"Invalid supported type value: {supportedType}");
            }
        }

        internal (string SchemaId, BinaryData Data) Encode(object value, Type inputType, CancellationToken cancellationToken) =>
            EncodeInternalAsync(value, inputType, false, cancellationToken).EnsureCompleted();

        internal async ValueTask<(string SchemaId, BinaryData Data)> EncodeAsync(object value, Type inputType, CancellationToken cancellationToken) =>
            await EncodeInternalAsync(value, inputType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<(string SchemaId, BinaryData Data)> EncodeInternalAsync(
            object value,
            Type inputType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(inputType, nameof(inputType));

            var supportedType = GetSupportedTypeOrThrow(inputType);
            var writer = GetWriterAndSchema(value, supportedType, out var schema);

            using Stream stream = new MemoryStream();
            var binaryEncoder = new BinaryEncoder(stream);

            writer.Write(value, binaryEncoder);
            binaryEncoder.Flush();
            stream.Position = 0;
            BinaryData data = BinaryData.FromStream(stream);

            if (async)
            {
                return (await GetSchemaIdAsync(schema, true, cancellationToken).ConfigureAwait(false), data);
            }
            else
            {
                return (GetSchemaIdAsync(schema, false, cancellationToken).EnsureCompleted(), data);
            }
        }

        private async Task<Schema> GetSchemaByIdAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            if (_idToSchemaMap.TryGetValue(schemaId, out Schema cachedSchema))
            {
                return cachedSchema;
            }

            string schemaDefinition;
            if (async)
            {
                schemaDefinition = (await _client.GetSchemaAsync(schemaId, cancellationToken).ConfigureAwait(false)).Value.Definition;
            }
            else
            {
                schemaDefinition = _client.GetSchema(schemaId, cancellationToken).Value.Definition;
            }
            var schema = Schema.Parse(schemaDefinition);
            _idToSchemaMap.TryAdd(schemaId, schema);
            _schemaToIdMap.TryAdd(schema, schemaId);
            return schema;
        }

        private static DatumReader<object> GetReader(Schema schema, SupportedType supportedType)
        {
            switch (supportedType)
            {
                case SupportedType.SpecificRecord:
                    return new SpecificDatumReader<object>(schema, schema);
                case SupportedType.GenericRecord:
                    return new GenericDatumReader<object>(schema, schema);
                default:
                    throw new ArgumentException($"Invalid supported type value: {supportedType}");
            }
        }

        /// <summary>
        /// Encodes the message data into Avro and stores it in <see cref="IMessageWithContentType.Data"/>. The <see cref="IMessageWithContentType.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="message">The message to store the data into.</param>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="inputType">The type to use to serialize the data.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public void EncodeMessageData(
            IMessageWithContentType message,
            object data,
            Type inputType = default,
            CancellationToken cancellationToken = default)
        {
            (string schemaId, BinaryData bd) = Encode(data, inputType ?? data?.GetType(), cancellationToken);
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            message.Data = bd;
        }

        /// <summary>
        /// Encodes the message data into Avro and stores it in <see cref="IMessageWithContentType.Data"/>. The <see cref="IMessageWithContentType.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="message">The message to store the data into.</param>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="inputType">The type to use to serialize the data.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public async ValueTask EncodeMessageDataAsync(
            IMessageWithContentType message,
            object data,
            Type inputType = default,
            CancellationToken cancellationToken = default)
        {
            (string schemaId, BinaryData bd) = await EncodeAsync(data, inputType ?? data?.GetType(), cancellationToken).ConfigureAwait(false);
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            message.Data = bd;
        }

        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="IMessageWithContentType.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="returnType">The type to deserialize to.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public object DecodeMessageData(
            IMessageWithContentType message,
            Type returnType,
            CancellationToken cancellationToken = default)
            => DecodeMessageBodyInternalAsync(message.Data, message.ContentType, returnType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="IMessageWithContentType.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="returnType">The type to deserialize to.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public async ValueTask<object> DecodeMessageDataAsync(
            IMessageWithContentType message,
            Type returnType,
            CancellationToken cancellationToken = default)
            => await DecodeMessageBodyInternalAsync(message.Data, message.ContentType, returnType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<object> DecodeMessageBodyInternalAsync(
            BinaryData data,
            string contentType,
            Type returnType,
            bool async,
            CancellationToken cancellationToken)
        {
            string[] contentTypeArray = contentType.Split('+');
            if (contentTypeArray.Length != 2)
            {
                throw new FormatException("Content type was not in the expected format of MIME type + schema ID");
            }

            if (contentTypeArray[0] != AvroMimeType)
            {
                throw new InvalidOperationException("An avro encoder may only be used on content that is of 'avro/binary' type");
            }

            if (async)
            {
                return await DecodeAsync(data, contentTypeArray[1], returnType, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return Decode(data, contentTypeArray[1], returnType, cancellationToken);
            }
        }

        internal object Decode(BinaryData data, string schemaId, Type returnType, CancellationToken cancellationToken) =>
            DecodeInternalAsync(data, schemaId, returnType, false, cancellationToken).EnsureCompleted();

        internal async ValueTask<object> DecodeAsync(BinaryData data, string schemaId, Type returnType, CancellationToken cancellationToken) =>
            await DecodeInternalAsync(data, schemaId, returnType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<object> DecodeInternalAsync(
            BinaryData data,
            string schemaId,
            Type returnType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(returnType, nameof(returnType));
            Argument.AssertNotNull(schemaId, nameof(schemaId));

            SupportedType supportedType = GetSupportedTypeOrThrow(returnType);

            Schema schema;
            if (async)
            {
                schema = await GetSchemaByIdAsync(schemaId, true, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                schema = GetSchemaByIdAsync(schemaId, false, cancellationToken).EnsureCompleted();
            }

            var binaryDecoder = new BinaryDecoder(data.ToStream());
            DatumReader<object> reader = GetReader(schema, supportedType);
            return reader.Read(reuse: null, binaryDecoder);
        }
    }
}
