// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Avro;
using Avro.Generic;
using Avro.IO;
using Avro.Specific;
using Azure.Core;
using Azure.Data.SchemaRegistry;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Messaging;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A <see cref="SchemaRegistryAvroSerializer"/> uses the <see cref="SchemaRegistryClient"/> to
    /// serialize and deserialize Avro payloads.
    /// </summary>
    public class SchemaRegistryAvroSerializer
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaRegistryAvroSerializerOptions _options;
        private const string AvroMimeType = "avro/binary";
        private const int CacheCapacity = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryAvroSerializer"/>. This constructor can only be used to create an
        /// instance which will be used for deserialization. In order to serialize (or both serialize and deserialize) you will need to use
        /// one of the constructors that have a <code>groupName</code> parameter.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SchemaRegistryAvroSerializer(SchemaRegistryClient client)
            : this(client, null, new SchemaRegistryAvroSerializerOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryAvroSerializer"/>. This constructor can be used to create an instance
        /// that will work for both serialization and deserialization.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="groupName">The Schema Registry group name that contains the schemas that will be used to serialize.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SchemaRegistryAvroSerializer(SchemaRegistryClient client, string groupName)
            : this(client, groupName, new SchemaRegistryAvroSerializerOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryAvroSerializer"/>. This constructor can be used to create an instance
        /// that will work for both serialization and deserialization.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="groupName">The Schema Registry group name that contains the schemas that will be used to serialize.</param>
        /// <param name="options">The set of options to customize the <see cref="SchemaRegistryAvroSerializer"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SchemaRegistryAvroSerializer(SchemaRegistryClient client, string groupName, SchemaRegistryAvroSerializerOptions options)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName;
            _options = options?.Clone() ?? new SchemaRegistryAvroSerializerOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryAvroSerializer"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected SchemaRegistryAvroSerializer()
        {
        }

        private readonly LruCache<string, Schema> _idToSchemaMap = new(CacheCapacity);
        private readonly LruCache<Schema, string> _schemaToIdMap = new(CacheCapacity);

        private enum SupportedType
        {
            SpecificRecord,
            GenericRecord
        }

        #region Serialize
        /// <summary>
        /// Serializes the message data as Avro and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to serialize the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to serialize the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to serialize.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <code>groupName</code> was not specified when constructing the <see cref="SchemaRegistryAvroSerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <typeparamref name="TData"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the Avro schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public TMessage Serialize<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage) SerializeInternalAsync(data, typeof(TData), typeof(TMessage), false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// serializes the message data as Avro and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to serialize the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to serialize the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to serialize.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <code>groupName</code> was not specified when constructing the <see cref="SchemaRegistryAvroSerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <typeparamref name="TData"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the Avro schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public async ValueTask<TMessage> SerializeAsync<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage) await SerializeInternalAsync(data, typeof(TData), typeof(TMessage), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// serializes the message data as Avro and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to serialize the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and serialize into the message.</param>
        /// <param name="dataType">The type of the data to serialize. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to serialize the data into. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be serialized into a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <code>groupName</code> was not specified when constructing the <see cref="SchemaRegistryAvroSerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <paramref name="dataType"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the Avro schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public MessageContent Serialize(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => SerializeInternalAsync(data, dataType, messageType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// serializes the message data as Avro and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to serialize the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and serialize into the message.</param>
        /// <param name="dataType">The type of the data to serialize. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to serialize the data into. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be serialized into a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <code>groupName</code> was not specified when constructing the <see cref="SchemaRegistryAvroSerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <paramref name="dataType"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the Avro schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public async ValueTask<MessageContent> SerializeAsync(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => await SerializeInternalAsync(data, dataType, messageType, true, cancellationToken).ConfigureAwait(false);

        internal async ValueTask<MessageContent> SerializeInternalAsync(
            object data,
            Type dataType,
            Type messageType,
            bool async,
            CancellationToken cancellationToken)
        {
            if (_groupName == null)
            {
                throw new InvalidOperationException(
                    "A group name must be specified in the 'SchemaRegistryAvroSerializer' constructor if you will be attempting to serialize. " +
                    "The group name can be omitted if only deserializing.");
            }

            messageType ??= typeof(MessageContent);
            if (messageType.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new InvalidOperationException(
                    $"The type {messageType} must have a public parameterless constructor in order to use it as the 'MessageContent' type to serialize to.");
            }

            var message = (MessageContent)Activator.CreateInstance(messageType);

            (string schemaId, BinaryData bd) = async
                ? await SerializeInternalAsync(data, dataType, true, cancellationToken).ConfigureAwait(false)
                : SerializeInternalAsync(data, dataType, false, cancellationToken).EnsureCompleted();

            message.Data = bd;
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            return message;
        }

        private async ValueTask<(string SchemaId, BinaryData Data)> SerializeInternalAsync(
            object value,
            Type dataType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(value, nameof(value));
            dataType ??= value?.GetType() ?? typeof(object);

            var supportedType = GetSupportedTypeOrThrow(dataType);

            try
            {
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
            catch (SchemaParseException ex)
            {
                throw new Exception(
                    "An error occurred while attempting to parse the schema to use when serializing to Avro. " +
                    $"Make sure that the schema represents valid Avro.",
                    ex);
            }

            catch (AvroException ex)
            {
                throw new Exception(
                    "An error occurred while attempting to serialize to Avro. Make sure that the data you are " +
                    "attempting to serialize corresponds to the schema being used to serialize.",
                    ex);
            }
        }

        private async Task<string> GetSchemaIdAsync(Schema schema, bool async, CancellationToken cancellationToken)
        {
            if (_schemaToIdMap.TryGet(schema, out var value))
            {
                return value;
            }

            SchemaProperties schemaProperties;
            string schemaString = schema.ToString();
            if (async)
            {
                schemaProperties = _options.AutoRegisterSchemas
                    ? (await _client
                        .RegisterSchemaAsync(_groupName, schema.Fullname, schemaString, SchemaFormat.Avro, cancellationToken)
                        .ConfigureAwait(false)).Value
                    : await _client
                        .GetSchemaPropertiesAsync(_groupName, schema.Fullname, schemaString, SchemaFormat.Avro, cancellationToken)
                        .ConfigureAwait(false);
            }
            else
            {
                schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, schemaString, SchemaFormat.Avro, cancellationToken)
                    : _client.GetSchemaProperties(_groupName, schema.Fullname, schemaString, SchemaFormat.Avro, cancellationToken);
            }

            string id = schemaProperties.Id;

            _schemaToIdMap.AddOrUpdate(schema, id, schemaString.Length);
            _idToSchemaMap.AddOrUpdate(id, schema, schemaString.Length);
            SchemaRegistryAvroEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
            return id;
        }

        private static DatumWriter<object> GetWriterAndSchema(object value, SupportedType supportedType, out Schema schema)
        {
            if (supportedType == SupportedType.SpecificRecord)
            {
                schema = ((ISpecificRecord)value).Schema;
                return new SpecificDatumWriter<object>(schema);
            }

            schema = ((GenericRecord)value).Schema;
            return new GenericDatumWriter<object>(schema);
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

            throw new ArgumentException($"Type '{type.Name}' is not supported for serialization operations. The type being serialized" +
                                        $" must be convertible to 'ISpecificRecord' or 'GenericRecord'.");
        }
        #endregion

        #region Deserialize
        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The message containing the data to deserialize.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to deserialize the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'avro/binary+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <typeparamref name="TData"/> type is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public TData Deserialize<TData>(
            MessageContent content,
            CancellationToken cancellationToken = default)
            => (TData) DeserializeMessageDataInternalAsync(content.Data, typeof(TData), content.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The content to deserialize.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to deserialize the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'avro/binary+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <typeparamref name="TData"/> type is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public async ValueTask<TData> DeserializeAsync<TData>(
            MessageContent content,
            CancellationToken cancellationToken = default)
            => (TData) await DeserializeMessageDataInternalAsync(content.Data, typeof(TData), content.ContentType, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The message containing the data to deserialize.</param>
        /// <param name="dataType">The type to deserialize the message data into.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'avro/binary+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <paramref name="dataType"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public object Deserialize(
            MessageContent content,
            Type dataType,
            CancellationToken cancellationToken = default)
            => DeserializeMessageDataInternalAsync(content.Data, dataType, content.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The message containing the data to deserialize.</param>
        /// <param name="dataType">The type to deserialize the message data into.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'avro/binary+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   The <paramref name="dataType"/> is not convertible to ISpecificRecord or GenericRecord.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the Apache Avro library.
        /// </exception>
        public async ValueTask<object> DeserializeAsync(
            MessageContent content,
            Type dataType,
            CancellationToken cancellationToken = default)
            => await DeserializeMessageDataInternalAsync(content.Data, dataType, content.ContentType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<object> DeserializeMessageDataInternalAsync(
            BinaryData data,
            Type dataType,
            ContentType? contentType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(contentType, nameof(contentType));

            string[] contentTypeArray = contentType.ToString().Split('+');
            if (contentTypeArray.Length != 2 || contentTypeArray[0] != AvroMimeType)
            {
                throw new FormatException("Content type was not in the expected format of 'avro/binary+schema-id', where 'schema-id' " +
                                          "is the Schema Registry schema ID.");
            }

            string schemaId = contentTypeArray[1];

            if (async)
            {
                return await DeserializeInternalAsync(data, dataType, schemaId, true, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return DeserializeInternalAsync(data, dataType, schemaId, false, cancellationToken).EnsureCompleted();
            }
        }

        private async ValueTask<object> DeserializeInternalAsync(
            BinaryData data,
            Type dataType,
            string schemaId,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(schemaId, nameof(schemaId));

            SupportedType supportedType = GetSupportedTypeOrThrow(dataType);

            Schema writerSchema;
            try
            {
                if (async)
                {
                    writerSchema = await GetSchemaByIdAsync(schemaId, true, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    writerSchema = GetSchemaByIdAsync(schemaId, false, cancellationToken).EnsureCompleted();
                }
            }
            catch (SchemaParseException ex)
            {
                throw new Exception(
                    $"An error occurred while attempting to parse the schema (schema ID: {schemaId}) that was used to serialize the Avro. " +
                    $"Make sure that the schema represents valid Avro.",
                    ex);
            }

            Schema readerSchema;
            object returnInstance = null;
            try
            {
                if (supportedType == SupportedType.SpecificRecord)
                {
                    returnInstance = Activator.CreateInstance(dataType);
                    readerSchema = ((ISpecificRecord)returnInstance).Schema;
                }
                else
                {
                    readerSchema = writerSchema;
                }
            }
            catch (SchemaParseException ex)
            {
                throw new Exception(
                    "An error occurred while attempting to parse the schema that you are attempting to deserialize the data with. " +
                    "Make sure that the schema represents valid Avro.",
                    ex);
            }

            try
            {
                var binaryDecoder = new BinaryDecoder(data.ToStream());
                DatumReader<object> reader = GetReader(writerSchema, readerSchema, supportedType);
                return reader.Read(reuse: returnInstance, binaryDecoder);
            }
            catch (AvroException ex)
            {
                throw new Exception(
                    "An error occurred while attempting to deserialize " +
                    $"Avro that was serialized with schemaId: {schemaId}. The schema used to deserialize the data may not be compatible with the schema that was used" +
                    $"to serialize the data. Please ensure that the schemas are compatible.",
                    ex);
            }
        }

        private async Task<Schema> GetSchemaByIdAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            if (_idToSchemaMap.TryGet(schemaId, out var cachedSchema))
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
            _idToSchemaMap.AddOrUpdate(schemaId, schema, schemaDefinition.Length);
            _schemaToIdMap.AddOrUpdate(schema, schemaId, schemaDefinition.Length);
            SchemaRegistryAvroEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
            return schema;
        }

        private static DatumReader<object> GetReader(Schema writerSchema, Schema readerSchema, SupportedType supportedType)
        {
            if (supportedType == SupportedType.SpecificRecord)
            {
                return new SpecificDatumReader<object>(writerSchema, readerSchema);
            }

            return new GenericDatumReader<object>(writerSchema, readerSchema);
        }
        #endregion
    }
}
