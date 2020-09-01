// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
        //private readonly string _schemaContent;
        private readonly string _groupName;
        private readonly AvroObjectSerializerOptions _options;

        /// <summary>
        /// Initializes new instance of <see cref="AvroObjectSerializer"/>.
        /// </summary>
        public AvroObjectSerializer(SchemaRegistryClient client, string groupName, AvroObjectSerializerOptions options = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            //_schemaContent = schemaContent;
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;
        }

        private static readonly byte[] s_emptyRecordFormatIndicator = { 0, 0, 0, 0 };

        //private Dictionary<Type, string> _cachedSchemas = new Dictionary<Type, string>();

        private static Schema GetSchemaFromType(Type type)
        {
            //https://stackoverflow.com/a/5898469/294804
            var schemaField = type.GetField("_SCHEMA", BindingFlags.Public | BindingFlags.Static);
            if (!(schemaField?.GetValue(null) is Schema schema))
            {
                throw new MissingFieldException($"Field _SCHEMA is missing on type {type.Name}.");
            }

            return schema;
        }

        /// <inheritdoc />
        public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(inputType);
            if (isSpecific)
            {
                //var schema = GetSchemaFromType(inputType);
                var schema = ((ISpecificRecord)value).Schema;
                var schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString())
                    : _client.GetSchemaId(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString());

                var writer = new SpecificDatumWriter<object>(schema);
                stream.Write(s_emptyRecordFormatIndicator, 0, 4);
                var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
                stream.Write(schemaId, 0, 32);

                var binaryEncoder = new BinaryEncoder(stream);
                writer.Write(value, binaryEncoder);
                binaryEncoder.Flush();
                return;
            }

            var isGeneric = typeof(GenericRecord).IsAssignableFrom(inputType);
            if (isGeneric)
            {
                var schema = ((GenericRecord)value).Schema;
                var schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString())
                    : _client.GetSchemaId(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString());

                var writer = new GenericDatumWriter<object>(schema);
                stream.Write(s_emptyRecordFormatIndicator, 0, 4);
                var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
                stream.Write(schemaId, 0, 32);

                var binaryEncoder = new BinaryEncoder(stream);
                writer.Write(value, binaryEncoder);
                binaryEncoder.Flush();
                return;
            }
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            await Task.Run(() => Serialize(stream, value, inputType, cancellationToken), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(returnType);
            if (isSpecific)
            {
                using var memoryStream = new MemoryStream();
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                var message = new Memory<byte>(memoryStream.ToArray());

                var recordFormatIdentifier = message.Slice(0, 4).ToArray();
                if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
                {
                    throw new InvalidDataContractException("The record format identifier for the message is invalid.");
                }

                var schemaIdBytes = message.Slice(4, 32).ToArray();
                var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
                var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
                var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

                var binaryDecoder = new BinaryDecoder(valueStream);
                var reader = new SpecificDatumReader<object>(schema, schema);
                return reader.Read(null, binaryDecoder);
            }

            var isGeneric = typeof(GenericRecord).IsAssignableFrom(returnType);
            if (isGeneric)
            {
                using var memoryStream = new MemoryStream();
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                var message = new ReadOnlyMemory<byte>(memoryStream.ToArray());

                var recordFormatIdentifier = message.Slice(0, 4).ToArray();
                if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
                {
                    throw new InvalidDataContractException("The record format identifier for the message is invalid.");
                }

                var schemaIdBytes = message.Slice(4, 32).ToArray();
                var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
                var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
                var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

                var binaryDecoder = new BinaryDecoder(valueStream);
                var reader = new GenericDatumReader<object>(schema, schema);
                return reader.Read(null, binaryDecoder);
            }

            return null;
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await Task.Run(() => Deserialize(stream, returnType, cancellationToken), cancellationToken).ConfigureAwait(false);
        }
    }
}
