// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Messaging;

namespace Azure.Data.SchemaRegistry.Serialization
{
    /// <summary>
    /// The Schema Registry serializer serializes and deserializes payloads using the <see cref="SchemaRegistrySerializerOptions.Serializer"/>.
    /// By default, this is a JSON object serializer. It uses an implemented <see cref="SchemaValidator"/> and a <see cref="SchemaRegistryClient"/>
    /// to enrich messages inheriting from <see cref="MessageContent"/> with a Schema Id.
    /// </summary>
    /// <seealso cref="SchemaValidator"/>
    public class SchemaRegistrySerializer
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaValidator _schemaValidator;
        private readonly SchemaRegistrySerializerOptions _serializerOptions;
        private readonly string _mimeType;
        private const string JsonMimeType = "application/json";
        private const string AvroMimeType = "avro/binary";
        private const string CustomMimeType = "text/plain";
        private const int CacheCapacity = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistrySerializer"/>. This constructor can only be used to create an
        /// instance which will be used for deserialization. In order to serialize (or both serialize and deserialize) you will need to use
        /// one of the constructors that have a <c>groupName</c> parameter.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="schemaValidator">The instance inherited from <see cref="SchemaValidator"/> to use to generate and validate schemas.</param>
        public SchemaRegistrySerializer(SchemaRegistryClient client, SchemaValidator schemaValidator)
            : this(client, schemaValidator, groupName: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistrySerializer"/>. This constructor can only be used to create an
        /// instance which will be used for deserialization. In order to serialize (or both serialize and deserialize) you will need to use
        /// one of the constructors that have a <c>groupName</c> parameter.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="schemaValidator">The instance inherited from <see cref="SchemaValidator"/> to use to generate and validate schemas.</param>
        /// <param name="serializerOptions">The set of <see cref="SchemaRegistrySerializerOptions"/> to use when configuring the serializer.</param>
        public SchemaRegistrySerializer(SchemaRegistryClient client, SchemaValidator schemaValidator, SchemaRegistrySerializerOptions serializerOptions)
            : this(client, schemaValidator, null, serializerOptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistrySerializer"/>. This constructor can be used to create an instance
        /// that will work for both serialization and deserialization.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="groupName">The Schema Registry group name that contains the schemas that will be used to serialize.</param>
        /// <param name="schemaValidator">The instance inherited from <see cref="SchemaValidator"/> to use to generate and validate schemas.</param>
        public SchemaRegistrySerializer(SchemaRegistryClient client, SchemaValidator schemaValidator, string groupName)
            : this(client, schemaValidator, groupName, default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistrySerializer"/>. This constructor can be used to create an instance
        /// that will work for both serialization and deserialization.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="groupName">The Schema Registry group name that contains the schemas that will be used to serialize.</param>
        /// <param name="schemaValidator">The instance inherited from <see cref="SchemaValidator"/> to use to generate and validate schemas.</param>
        /// <param name="serializerOptions">The set of <see cref="SchemaRegistrySerializerOptions"/> to use when configuring the serializer.</param>
        public SchemaRegistrySerializer(SchemaRegistryClient client, SchemaValidator schemaValidator, string groupName, SchemaRegistrySerializerOptions serializerOptions)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName;
            _schemaValidator = schemaValidator ?? throw new ArgumentNullException(nameof(schemaValidator));
            _serializerOptions = serializerOptions?.Clone() ?? new SchemaRegistrySerializerOptions();

            if (_serializerOptions.Format != SchemaFormat.Json && _serializerOptions.Serializer is JsonObjectSerializer)
            {
                throw new ArgumentException("A schema format other than JSON was specified, but the default JsonObjectSerializer is being used.", nameof(serializerOptions));
            }

            if (_serializerOptions.Format == SchemaFormat.Avro)
            {
                _mimeType = AvroMimeType;
            }
            else if (_serializerOptions.Format == SchemaFormat.Json)
            {
                _mimeType = JsonMimeType;
            }
            else
            {
                _mimeType = CustomMimeType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistrySerializer"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected SchemaRegistrySerializer()
        {
        }

        private readonly LruCache<string, string> _idToSchemaMap = new(CacheCapacity);
        private readonly LruCache<string, string> _schemaToIdMap = new(CacheCapacity);

        #region Serialize
        /// <summary>
        /// Serializes the message data and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" if serializing with JSON, "avro/binary" if serializing with Avro, and "text/plain+schemaId"
        /// otherwise, where schemaId is the Id of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to hold the serialized data.</typeparam>
        /// <typeparam name="TData">The type of the data being serialized.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistrySerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the specified schema, or the schema itself was invalid. The inner exception will hold more detailed information about
        ///   the exception.
        /// </exception>
        public TMessage Serialize<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage)SerializeInternalAsync(data, typeof(TData), typeof(TMessage), false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Serializes the message data and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" if serializing with JSON, "avro/binary" if serializing with Avro, and "text/plain+schemaId"
        /// otherwise, where schemaId is the Id of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to hold the serialized data.</typeparam>
        /// <typeparam name="TData">The type of the data being serialized.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistrySerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the specified schema, or the schema itself was invalid. The inner exception will hold more detailed information about
        ///   the exception.
        /// </exception>
        public async ValueTask<TMessage> SerializeAsync<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage)await SerializeInternalAsync(data, typeof(TData), typeof(TMessage), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Serializes the message data and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" if serializing with JSON, "avro/binary" if serializing with Avro, and "text/plain+schemaId"
        /// otherwise, where schemaId is the Id of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize into the message.</param>
        /// <param name="dataType">The type of the data being serialized. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to hold the serialized data. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the serialized data will be set in a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistrySerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the specified schema, or the schema itself was invalid. The inner exception will hold more detailed information about
        ///   the exception.
        /// </exception>
        public MessageContent Serialize(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => SerializeInternalAsync(data, dataType, messageType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Serializes the message data and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" if serializing with JSON, "avro/binary" if serializing with Avro, and "text/plain+schemaId"
        /// otherwise, where schemaId is the Id of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize into the message.</param>
        /// <param name="dataType">The type of the data being serialized. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to hold the serialized data. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the serialized data will be set in a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistrySerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the specified schema, or the schema itself was invalid. The inner exception will hold more detailed information about
        ///   the exception.
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
                    "A group name must be specified in the 'SchemaRegistryJsonSerializer' constructor if you will be attempting to serialize. " +
                    "The group name can be omitted if only deserializing.");
            }

            messageType ??= typeof(MessageContent);
            if (messageType.GetConstructor(Type.EmptyTypes) == null)
            {
                throw new InvalidOperationException(
                    $"The type {messageType} must have a public parameterless constructor in order to use it as the 'MessageContent' type to serialize to.");
            }

            var message = (MessageContent)Activator.CreateInstance(messageType);

            (string retrievedSchemaId, BinaryData bd) = async
                ? await SerializeInternalAsync(data, dataType, true, cancellationToken).ConfigureAwait(false)
                : SerializeInternalAsync(data, dataType, false, cancellationToken).EnsureCompleted();

            message.Data = bd;
            message.ContentType = $"{_mimeType}+{retrievedSchemaId}";
            return message;
        }

        private async ValueTask<(string SchemaId, BinaryData Data)> SerializeInternalAsync(
            object value,
            Type dataType,
            bool async,
            CancellationToken cancellationToken)
        {
            string schemaString;
            BinaryData data;

            try
            {
                // Serialize the data
                dataType ??= value?.GetType() ?? typeof(object);
                var serializer = _serializerOptions.Serializer;

                using Stream stream = new MemoryStream();
                if (async)
                {
                    await serializer.SerializeAsync(stream, value, dataType, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    serializer.Serialize(stream, value, dataType, cancellationToken);
                }

                stream.Position = 0;
                data = BinaryData.FromStream(stream);

                // Generate the schema from the type
                schemaString = _schemaValidator.GenerateSchema(dataType);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while attempting to serialize the data.", ex);
            }

            // Attempt to validate
            var isValid = _schemaValidator.TryValidate(value, dataType, schemaString, out var validationErrors);
            if (!isValid)
            {
                throw new AggregateException(validationErrors);
            }

            try
            {
                // Try to get the schema Id for the schema
                if (async)
                {
                    return (await GetSchemaIdAsync(schemaString, dataType.Name, true, cancellationToken).ConfigureAwait(false), data);
                }
                else
                {
                    return (GetSchemaIdAsync(schemaString, dataType.Name, false, cancellationToken).EnsureCompleted(), data);
                }
            }
            catch (Exception ex) when (ex is not RequestFailedException)
            {
                throw new Exception("An error occurred while attempting to get the Id for the schema.", ex);
            }
        }

        private async Task<string> GetSchemaIdAsync(string schema, string schemaName, bool async, CancellationToken cancellationToken)
        {
            // Check the cache
            if (_schemaToIdMap.TryGet(schema, out var value))
            {
                return value;
            }

            var schemaProperties = (async) ?
                await _client.GetSchemaPropertiesAsync(_groupName, schemaName, schema, _serializerOptions.Format, cancellationToken).ConfigureAwait(false) :
                _client.GetSchemaProperties(_groupName, schemaName, schema, _serializerOptions.Format, cancellationToken);

            string id = schemaProperties.Value.Id;

            _schemaToIdMap.AddOrUpdate(schema, id, schema.Length);
            _idToSchemaMap.AddOrUpdate(id, schema, schema.Length);
            SchemaRegistrySerializationEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
            return id;
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
        ///   The ContentType is not in the expected format. The ContentType is expected to be "application/json+schema-id" if serializing with JSON,
        ///   "text/plain+schemaId" otherwise, where "schema-id" is the Schema Registry schema Id.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data. The <see cref="Exception.InnerException"/>
        ///   will contain more information.
        /// </exception>
        public TData Deserialize<TData>(
            MessageContent content,
            CancellationToken cancellationToken = default)
            => (TData)DeserializeMessageDataInternalAsync(content.Data, typeof(TData), content.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The content to deserialize.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to deserialize the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be "application/json+schema-id" if serializing with JSON,
        ///   "text/plain+schemaId" otherwise, where "schema-id" is the Schema Registry schema Id.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data. The <see cref="Exception.InnerException"/>
        ///   will contain more information.
        /// </exception>
        public async ValueTask<TData> DeserializeAsync<TData>(
            MessageContent content,
            CancellationToken cancellationToken = default)
            => (TData)await DeserializeMessageDataInternalAsync(content.Data, typeof(TData), content.ContentType, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The message containing the data to deserialize.</param>
        /// <param name="dataType">The type to deserialize the message data into.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be "application/json+schema-id" if serializing with JSON,
        ///   "text/plain+schemaId" otherwise, where "schema-id" is the Schema Registry schema Id.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data. The <see cref="Exception.InnerException"/>
        ///   will contain more information.
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
        ///   The ContentType is not in the expected format. The ContentType is expected to be "application/json+schema-id" if serializing with JSON,
        ///   "text/plain+schemaId" otherwise, where "schema-id" is the Schema Registry schema Id.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service. This can occur if the schema generated from the type
        ///   does not exist in the registry.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data. The <see cref="Exception.InnerException"/>
        ///   will contain more information.
        /// </exception>
        public async ValueTask<object> DeserializeAsync(
            MessageContent content,
            Type dataType,
            CancellationToken cancellationToken = default)
            => await DeserializeMessageDataInternalAsync(content.Data, dataType, content.ContentType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<object> DeserializeMessageDataInternalAsync(
            BinaryData data,
            Type dataType,
            Azure.Core.ContentType? contentType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(contentType, nameof(contentType));

            string[] contentTypeArray = contentType.ToString().Split('+');
            if (contentTypeArray.Length != 2 || contentTypeArray[0] != _mimeType)
            {
                throw new FormatException($"Content type was not in the expected format of '{_mimeType}+schema-id', where 'schema-id' " +
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

            string schemaDefinition;
            try
            {
                // Attempt to get the schema definition using the schema Id from the Content Type
                if (async)
                {
                    schemaDefinition = await GetSchemaByIdAsync(schemaId, true, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    schemaDefinition = GetSchemaByIdAsync(schemaId, false, cancellationToken).EnsureCompleted();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while attempting to retrieve the schema with id {schemaId}.", ex);
            }

            var deserializer = _serializerOptions.Serializer;
            object objectToReturn;
            try
            {
                // Attempt to deserialize
                using var dataStream = data.ToStream();
                if (async)
                {
                    objectToReturn = await deserializer.DeserializeAsync(dataStream, dataType, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    objectToReturn = deserializer.Deserialize(dataStream, dataType, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while attempting to deserialize the data.", ex);
            }

            // Attempt to validate
            var isValid = _schemaValidator.TryValidate(objectToReturn, dataType, schemaDefinition, out var validationErrors);
            if (!isValid)
            {
                throw new AggregateException(validationErrors);
            }

            return objectToReturn;
        }

        private async Task<string> GetSchemaByIdAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            // Check the cache
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

            _idToSchemaMap.AddOrUpdate(schemaId, schemaDefinition, schemaDefinition.Length);
            _schemaToIdMap.AddOrUpdate(schemaDefinition, schemaId, schemaDefinition.Length);

            SchemaRegistrySerializationEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
            return schemaDefinition;
        }
        #endregion
    }
}
