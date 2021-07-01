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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A <see cref="SchemaRegistryAvroObjectSerializer"/> implementation that uses <see cref="SchemaRegistryClient"/> for Avro serialization/deserialization.
    /// </summary>
    public class SchemaRegistryAvroObjectSerializer : ObjectSerializer
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaRegistryAvroObjectSerializerOptions _options;

        /// <summary>
        /// Initializes new instance of <see cref="SchemaRegistryAvroObjectSerializer"/>.
        /// </summary>
        public SchemaRegistryAvroObjectSerializer(SchemaRegistryClient client, string groupName, SchemaRegistryAvroObjectSerializerOptions options = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;
        }

        private static readonly byte[] EmptyRecordFormatIndicator = { 0, 0, 0, 0 };
        private static readonly Encoding Utf8Encoding = new UTF8Encoding(false);

        private const int RecordFormatIndicatorLength = 4;
        private const int SchemaIdLength = 32;
        private const int PayloadStartPosition = RecordFormatIndicatorLength + SchemaIdLength;
        private readonly Dictionary<string, Schema> _cachedSchemas = new Dictionary<string, Schema>();

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

        private string GetSchemaId(Schema schema, CancellationToken cancellationToken)
        {
            var schemaProperties = _options.AutoRegisterSchemas
                ? _client.RegisterSchema(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString(), cancellationToken)
                : _client.GetSchemaId(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString(), cancellationToken);
            return schemaProperties.Value.Id;
        }

        private async Task<string> GetSchemaIdAsync(Schema schema, CancellationToken cancellationToken)
        {
            var schemaProperties = await (_options.AutoRegisterSchemas
                    ? _client.RegisterSchemaAsync(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString(), cancellationToken)
                    : _client.GetSchemaIdAsync(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString(), cancellationToken))
                .ConfigureAwait(false);
            return schemaProperties.Value.Id;
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

        /// <inheritdoc />
        public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(inputType, nameof(inputType));

            var supportedType = GetSupportedTypeOrThrow(inputType);
            var writer = GetWriterAndSchema(value, supportedType, out var schema);
            var schemaId = GetSchemaId(schema, cancellationToken);

            var binaryEncoder = new BinaryEncoder(stream);
            stream.Write(EmptyRecordFormatIndicator, 0, RecordFormatIndicatorLength);
            stream.Write(Utf8Encoding.GetBytes(schemaId), 0, SchemaIdLength);
            writer.Write(value, binaryEncoder);
            binaryEncoder.Flush();
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(value, nameof(value));
            Argument.AssertNotNull(inputType, nameof(inputType));

            var supportedType = GetSupportedTypeOrThrow(inputType);
            var writer = GetWriterAndSchema(value, supportedType, out var schema);
            var schemaId = await GetSchemaIdAsync(schema, cancellationToken).ConfigureAwait(false);

            var binaryEncoder = new BinaryEncoder(stream);
            await stream.WriteAsync(EmptyRecordFormatIndicator, 0, RecordFormatIndicatorLength, cancellationToken).ConfigureAwait(false);
            await stream.WriteAsync(Utf8Encoding.GetBytes(schemaId), 0, SchemaIdLength, cancellationToken).ConfigureAwait(false);
            writer.Write(value, binaryEncoder);
            binaryEncoder.Flush();
        }

        private Schema GetSchemaById(string schemaId, CancellationToken cancellationToken)
        {
            if (_cachedSchemas.TryGetValue(schemaId, out var cachedSchema))
            {
                return cachedSchema;
            }

            var schemaContent = _client.GetSchema(schemaId, cancellationToken).Value.Content;
            var schema = Schema.Parse(schemaContent);
            _cachedSchemas.Add(schemaId, schema);
            return schema;
        }

        private async Task<Schema> GetSchemaByIdAsync(string schemaId, CancellationToken cancellationToken)
        {
            if (_cachedSchemas.TryGetValue(schemaId, out var cachedSchema))
            {
                return cachedSchema;
            }

            var schemaContent = (await _client.GetSchemaAsync(schemaId, cancellationToken).ConfigureAwait(false)).Value.Content;
            var schema = Schema.Parse(schemaContent);
            _cachedSchemas.Add(schemaId, schema);
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

        private static ReadOnlyMemory<byte> CopyToReadOnlyMemory(Stream stream)
        {
            using var tempMemoryStream = new MemoryStream();
            stream.CopyTo(tempMemoryStream);
            return new ReadOnlyMemory<byte>(tempMemoryStream.ToArray());
        }

        private static void ValidateRecordFormatIdentifier(ReadOnlyMemory<byte> message)
        {
            var recordFormatIdentifier = message.Slice(0, RecordFormatIndicatorLength).ToArray();
            if (!recordFormatIdentifier.SequenceEqual(EmptyRecordFormatIndicator))
            {
                throw new InvalidDataContractException(
                    $"The record format identifier ({recordFormatIdentifier[0]:X} {recordFormatIdentifier[1]:X} {recordFormatIdentifier[2]:X} {recordFormatIdentifier[3]:X}) for the message is invalid.");
            }
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(returnType, nameof(returnType));

            var supportedType = GetSupportedTypeOrThrow(returnType);
            var message = CopyToReadOnlyMemory(stream);
            ValidateRecordFormatIdentifier(message);
            var schemaIdBytes = message.Slice(RecordFormatIndicatorLength, SchemaIdLength).ToArray();
            var schemaId = Utf8Encoding.GetString(schemaIdBytes);
            var schema = GetSchemaById(schemaId, cancellationToken);
            using var valueStream = new MemoryStream(message.Slice(PayloadStartPosition, message.Length - PayloadStartPosition).ToArray());

            var binaryDecoder = new BinaryDecoder(valueStream);
            var reader = GetReader(schema, supportedType);
            return reader.Read(reuse: null, binaryDecoder);
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            Argument.AssertNotNull(returnType, nameof(returnType));

            var supportedType = GetSupportedTypeOrThrow(returnType);
            var message = CopyToReadOnlyMemory(stream);
            ValidateRecordFormatIdentifier(message);
            var schemaIdBytes = message.Slice(RecordFormatIndicatorLength, SchemaIdLength).ToArray();
            var schemaId = Utf8Encoding.GetString(schemaIdBytes);
            var schema = await GetSchemaByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
            using var valueStream = new MemoryStream(message.Slice(PayloadStartPosition, message.Length - PayloadStartPosition).ToArray());

            var binaryDecoder = new BinaryDecoder(valueStream);
            var reader = GetReader(schema, supportedType);
            return reader.Read(reuse: null, binaryDecoder);
        }
    }
}
