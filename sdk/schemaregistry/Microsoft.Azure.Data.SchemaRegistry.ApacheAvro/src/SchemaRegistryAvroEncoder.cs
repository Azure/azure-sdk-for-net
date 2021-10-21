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

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A <see cref="SchemaRegistryAvroEncoder"/> implementation that uses <see cref="SchemaRegistryClient"/> for Avro serialization/deserialization.
    /// </summary>
    public class SchemaRegistryAvroEncoder
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaRegistryAvroObjectEncoderOptions _options;

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

            string schemaContent;
            if (async)
            {
                schemaContent = (await _client.GetSchemaAsync(schemaId, cancellationToken).ConfigureAwait(false)).Value.Content;
            }
            else
            {
                schemaContent = _client.GetSchema(schemaId, cancellationToken).Value.Content;
            }
            var schema = Schema.Parse(schemaContent);
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

        private static ReadOnlyMemory<byte> CopyToReadOnlyMemory(BinaryData data)
        {
            using var tempMemoryStream = new MemoryStream();
            data.ToStream().CopyTo(tempMemoryStream);
            return new ReadOnlyMemory<byte>(tempMemoryStream.ToArray());
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
