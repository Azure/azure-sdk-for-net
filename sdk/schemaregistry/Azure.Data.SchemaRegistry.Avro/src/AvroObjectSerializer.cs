// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avro;
using Avro.Generic;
using Avro.IO;
using Avro.Specific;
using Azure.Core.Serialization;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry.Avro
{
    /// <summary>
    /// A <see cref="AvroObjectSerializer"/> implementation that uses <see cref="SchemaRegistryClient"/> for SpecificRecord serialization/deserialization.
    /// </summary>
    public class AvroObjectSerializer : ObjectSerializer
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly AvroObjectSerializerOptions _options;

        /// <summary>
        /// Initializes new instance of <see cref="AvroObjectSerializer"/>.
        /// </summary>
        public AvroObjectSerializer(SchemaRegistryClient client, string groupName, AvroObjectSerializerOptions options = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;
        }

        private static readonly byte[] s_emptyRecordFormatIndicator = { 0, 0, 0, 0 };

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
            //TODO: Null check input
            var supportedType = GetSupportedTypeOrThrow(inputType);
            var writer = GetWriterAndSchema(value, supportedType, out var schema);
            var schemaId = GetSchemaId(schema, cancellationToken);
            var binaryEncoder = new BinaryEncoder(stream);
            stream.Write(s_emptyRecordFormatIndicator, 0, 4);
            stream.Write(Encoding.UTF8.GetBytes(schemaId), 0, 32);
            writer.Write(value, binaryEncoder);
            binaryEncoder.Flush();
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            //TODO: Null check input
            //await Task.Run(() => Serialize(stream, value, inputType, cancellationToken), cancellationToken).ConfigureAwait(false);
            var supportedType = GetSupportedTypeOrThrow(inputType);
            var writer = GetWriterAndSchema(value, supportedType, out var schema);
            var schemaId = await GetSchemaIdAsync(schema, cancellationToken).ConfigureAwait(false);
            var binaryEncoder = new BinaryEncoder(stream);
            await stream.WriteAsync(s_emptyRecordFormatIndicator, 0, 4, cancellationToken).ConfigureAwait(false);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(schemaId), 0, 32, cancellationToken).ConfigureAwait(false);
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
            stream.Position = 0;
            stream.CopyTo(tempMemoryStream);
            return new ReadOnlyMemory<byte>(tempMemoryStream.ToArray());
        }

        private static void ValidateRecordFormatIdentifier(ReadOnlyMemory<byte> message)
        {
            var recordFormatIdentifier = message.Slice(0, 4).ToArray();
            if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
            {
                throw new InvalidDataContractException(
                    $"The record format identifier ({recordFormatIdentifier[0]:X} {recordFormatIdentifier[1]:X} {recordFormatIdentifier[2]:X} {recordFormatIdentifier[3]:X}) for the message is invalid.");
            }
        }

        private Schema GetSchema(ReadOnlyMemory<byte> message, CancellationToken cancellationToken)
        {
            var schemaIdBytes = message.Slice(4, 32).ToArray();
            var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
            var schemaContent = _client.GetSchema(schemaId, cancellationToken).Value.Content;
            return Schema.Parse(schemaContent);
        }

        private async Task<Schema> GetSchemaAsync(ReadOnlyMemory<byte> message, CancellationToken cancellationToken)
        {
            var schemaIdBytes = message.Slice(4, 32).ToArray();
            var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
            var schemaContent = (await _client.GetSchemaAsync(schemaId, cancellationToken).ConfigureAwait(false)).Value.Content;
            return Schema.Parse(schemaContent);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            //TODO: Null check input
            var supportedType = GetSupportedTypeOrThrow(returnType);
            var message = CopyToReadOnlyMemory(stream);
            ValidateRecordFormatIdentifier(message);
            var schema = GetSchema(message, cancellationToken);
            using var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());
            var binaryDecoder = new BinaryDecoder(valueStream);

            var reader = GetReader(schema, supportedType);
            return reader.Read(reuse: null, binaryDecoder);



            //var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(returnType);
            //if (isSpecific)
            //{
            //    using var memoryStream = new MemoryStream();
            //    stream.Position = 0;
            //    stream.CopyTo(memoryStream);
            //    var message = new Memory<byte>(memoryStream.ToArray());

            //    var recordFormatIdentifier = message.Slice(0, 4).ToArray();
            //    if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
            //    {
            //        throw new InvalidDataContractException("The record format identifier for the message is invalid.");
            //    }

            //    var schemaIdBytes = message.Slice(4, 32).ToArray();
            //    var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
            //    var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
            //    var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

            //    var binaryDecoder = new BinaryDecoder(valueStream);
            //    var reader = new SpecificDatumReader<object>(schema, schema);
            //    return reader.Read(null, binaryDecoder);
            //}

            //var isGeneric = typeof(GenericRecord).IsAssignableFrom(returnType);
            //if (isGeneric)
            //{
            //    using var memoryStream = new MemoryStream();
            //    stream.Position = 0;
            //    stream.CopyTo(memoryStream);
            //    var message = new ReadOnlyMemory<byte>(memoryStream.ToArray());

            //    var recordFormatIdentifier = message.Slice(0, 4).ToArray();
            //    if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
            //    {
            //        throw new InvalidDataContractException("The record format identifier for the message is invalid.");
            //    }

            //    var schemaIdBytes = message.Slice(4, 32).ToArray();
            //    var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
            //    var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
            //    var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

            //    var binaryDecoder = new BinaryDecoder(valueStream);
            //    var reader = new GenericDatumReader<object>(schema, schema);
            //    return reader.Read(null, binaryDecoder);
            //}

            //return null;
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            //return await Task.Run(() => Deserialize(stream, returnType, cancellationToken), cancellationToken).ConfigureAwait(false);
            //TODO: Null check input
            var supportedType = GetSupportedTypeOrThrow(returnType);
            var message = CopyToReadOnlyMemory(stream);
            ValidateRecordFormatIdentifier(message);
            var schema = await GetSchemaAsync(message, cancellationToken).ConfigureAwait(false);
            using var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());
            var binaryDecoder = new BinaryDecoder(valueStream);

            var reader = GetReader(schema, supportedType);
            return reader.Read(reuse: null, binaryDecoder);
        }
    }
}
