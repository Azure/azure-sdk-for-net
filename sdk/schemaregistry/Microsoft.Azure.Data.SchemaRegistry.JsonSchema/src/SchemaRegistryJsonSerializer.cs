// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Data.SchemaRegistry;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Messaging;
using System.Text.Json;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// A <see cref="SchemaRegistryJsonSerializer"/> serializes and deserializes JSON payloads using <see cref="System.Text.Json"/>.
    /// It requires an implemented <see cref="SchemaRegistryJsonSchemaGenerator"/> and a <see cref="SchemaRegistryClient"/> in order
    /// to enrich messages inheriting from <see cref="MessageContent"/> with the Schema ID.
    /// </summary>
    /// <remarks>
    /// Taking in an implementation of <see cref="SchemaRegistryJsonSchemaGenerator"/> allows any JSON schema generation or validation
    /// library to be used.
    /// </remarks>
    public class SchemaRegistryJsonSerializer
    {
        private readonly SchemaRegistryClient _client;
        private readonly string _groupName;
        private readonly SchemaRegistryJsonSchemaGenerator _jsonSchemaGenerator;
        private const string JsonMimeType = "application/json";
        private const int CacheCapacity = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryJsonSerializer"/>. This constructor can only be used to create an
        /// instance which will be used for deserialization. In order to serialize (or both serialize and deserialize) you will need to use
        /// one of the constructors that have a <c>groupName</c> parameter.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="jsonSchemaGenerator">The instance inherited from <see cref="SchemaRegistryJsonSchemaGenerator"/> to use to generate and validate JSON schemas.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SchemaRegistryJsonSerializer(SchemaRegistryClient client, SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator)
            : this(client, null, jsonSchemaGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryJsonSerializer"/>. This constructor can be used to create an instance
        /// that will work for both serialization and deserialization.
        /// </summary>
        /// <param name="client">The <see cref="SchemaRegistryClient"/> instance to use for looking up schemas.</param>
        /// <param name="groupName">The Schema Registry group name that contains the schemas that will be used to serialize.</param>
        /// <param name="jsonSchemaGenerator">The instance inherited from <see cref="SchemaRegistryJsonSchemaGenerator"/> to use to generate and validate JSON schemas.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SchemaRegistryJsonSerializer(SchemaRegistryClient client, string groupName, SchemaRegistryJsonSchemaGenerator jsonSchemaGenerator)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName;
            _jsonSchemaGenerator = jsonSchemaGenerator ?? throw new ArgumentNullException(nameof(jsonSchemaGenerator));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryJsonSerializer"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected SchemaRegistryJsonSerializer()
        {
        }

        private readonly LruCache<string, string> _idToSchemaMap = new(CacheCapacity);
        private readonly LruCache<string, string> _schemaToIdMap = new(CacheCapacity);

        #region Serialize
        /// <summary>
        /// Serializes the message data as JSON and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" where schemaId is the ID of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize to JSON and serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to serialize the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to serialize.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistryJsonSerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the JSON schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
        /// </exception>
        public TMessage Serialize<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage) SerializeInternalAsync(data, typeof(TData), typeof(TMessage), false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Serializes the message data as JSON and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" where schemaId is the ID of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize to JSON and serialize into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageContent"/> type to serialize the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to serialize.</typeparam>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistryJsonSerializer"/>.
        ///   It can also occur if the <typeparamref name="TMessage"/> type does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the JSON schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
        /// </exception>
        public async ValueTask<TMessage> SerializeAsync<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageContent, new()
            => (TMessage) await SerializeInternalAsync(data, typeof(TData), typeof(TMessage), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Serializes the message data as JSON and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" where schemaId is the ID of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize to JSON and serialize into the message.</param>
        /// <param name="dataType">The type of the data to serialize. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to serialize the data into. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be serialized into a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistryJsonSerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the JSON schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
        /// </exception>
        public MessageContent Serialize(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => SerializeInternalAsync(data, dataType, messageType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Serializes the message data as JSON and stores it in <see cref="MessageContent.Data"/>. The <see cref="MessageContent.ContentType"/>
        /// will be set to "application/json+schemaId" where schemaId is the ID of the schema that was generated from the type.
        /// </summary>
        /// <param name="data">The data to serialize to JSON and serialize into the message.</param>
        /// <param name="dataType">The type of the data to serialize. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to serialize the data into. Must extend from <see cref="MessageContent"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be serialized into a <see cref="MessageContent"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the <c>groupName</c> was not specified when constructing the <see cref="SchemaRegistryJsonSerializer"/>.
        ///   It can also occur if the <paramref name="messageType"/> does not have a public parameterless constructor.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The data did not adhere to the JSON schema, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
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
            message.ContentType = $"{JsonMimeType}+{retrievedSchemaId}";
            return message;
        }

        private async ValueTask<(string SchemaId, BinaryData Data)> SerializeInternalAsync(
            object value,
            Type dataType,
            bool async,
            CancellationToken cancellationToken)
        {
            try
            {
                // Serialize the data
                dataType ??= value?.GetType() ?? typeof(object);

                using Stream stream = new MemoryStream();
                BinaryData data;
                if (async)
                {
                    await JsonSerializer.SerializeAsync(stream, value, dataType, new JsonSerializerOptions(), cancellationToken).ConfigureAwait(false);

                    stream.Position = 0;
                    data = BinaryData.FromStream(stream);
                }
                else
                {
                    var jsonString = JsonSerializer.Serialize(value, dataType);
                    data = BinaryData.FromString(jsonString);
                }

                // Use the given schema string definition or generate one from the type
                string schemaString = _jsonSchemaGenerator.GenerateSchemaFromType(dataType);

                // Attempt to validate
                _jsonSchemaGenerator.ThrowIfNotValidAgainstSchema(data, dataType, schemaString);

                if (async)
                {
                    return (await GetSchemaIdAsync(schemaString, dataType.Name, true, cancellationToken).ConfigureAwait(false), data);
                }
                else
                {
                    return (GetSchemaIdAsync(schemaString, dataType.Name, false, cancellationToken).EnsureCompleted(), data);
                }
            }
            catch (RequestFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "An error occurred while attempting to parse the schema to use when serializing to Json. " +
                    $"Make sure that the schema represents valid Json.",
                    ex);
            }
        }

        private async Task<string> GetSchemaIdAsync(string schema, string schemaName, bool async, CancellationToken cancellationToken)
        {
            if (_schemaToIdMap.TryGet(schema, out var value))
            {
                return value;
            }

            var schemaProperties = (async) ?
                await _client.GetSchemaPropertiesAsync(_groupName, schemaName, schema, SchemaFormat.Json, cancellationToken).ConfigureAwait(false) :
                _client.GetSchemaProperties(_groupName, schemaName, schema, SchemaFormat.Json, cancellationToken);

            string id = schemaProperties.Value.Id;

            _schemaToIdMap.AddOrUpdate(schema, id, schema.Length);
            _idToSchemaMap.AddOrUpdate(id, schema, schema.Length);
            SchemaRegistryJsonEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
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
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'application/json+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
        /// </exception>
        public TData Deserialize<TData>(
            MessageContent content,
            CancellationToken cancellationToken = default)
            => (TData) DeserializeMessageDataInternalAsync(content.Data, typeof(TData), content.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Deserializes the message data into the specified type using the schema information populated in <see cref="MessageContent.ContentType"/>.
        /// </summary>
        /// <param name="content">The content to deserialize.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to deserialize the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'application/json+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <typeparamref name="TData"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
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
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'application/json+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
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
        ///   The ContentType is not in the expected format. The ContentType is expected to be 'application/json+schema-id', where 'schema-id' is
        ///   the Schema Registry schema ID.
        /// </exception>
        /// <exception cref="RequestFailedException">
        ///   An error occurred while attempting to communicate with the Schema Registry service.
        /// </exception>
        /// <exception cref="Exception">
        ///   The schema from <paramref name="dataType"/> was not compatible with the schema used to serialize the data, or the schema itself was invalid.
        ///   The <see cref="Exception.InnerException"/> will contain the underlying exception from the <see cref="SchemaRegistryJsonSchemaGenerator"/> class.
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
            if (contentTypeArray.Length != 2 || contentTypeArray[0] != JsonMimeType)
            {
                throw new FormatException($"Content type was not in the expected format of '{JsonMimeType}+schema-id', where 'schema-id' " +
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

            object objectToReturn;
            try
            {
                var dataStream = data.ToStream();
                if (async)
                {
                    objectToReturn = await JsonSerializer.DeserializeAsync(dataStream, dataType, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    objectToReturn = JsonSerializer.Deserialize(data, dataType);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while attempting to deserialize the data.", ex);
            }

            try
            {
                _jsonSchemaGenerator.ThrowIfNotValidAgainstSchema(objectToReturn, dataType, schemaDefinition);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while attempting to validate the deserialized object.", ex);
            }

            return objectToReturn;
        }

        private async Task<string> GetSchemaByIdAsync(string schemaId, bool async, CancellationToken cancellationToken)
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

            _idToSchemaMap.AddOrUpdate(schemaId, schemaDefinition, schemaDefinition.Length);
            _schemaToIdMap.AddOrUpdate(schemaDefinition, schemaId, schemaDefinition.Length);

            SchemaRegistryJsonEventSource.Log.CacheUpdated(_idToSchemaMap, _schemaToIdMap);
            return schemaDefinition;
        }
        #endregion
    }
}
