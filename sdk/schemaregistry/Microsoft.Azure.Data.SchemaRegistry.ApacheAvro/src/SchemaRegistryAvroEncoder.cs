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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

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
        private readonly SchemaRegistryAvroEncoderOptions _options;
        private const string AvroMimeType = "avro/binary";
        private const int CacheCapacity = 128;
        private static readonly Encoding Utf8Encoding = new UTF8Encoding(false);

        /// <summary>
        /// Initializes new instance of <see cref="SchemaRegistryAvroEncoder"/>.
        /// </summary>
        public SchemaRegistryAvroEncoder(SchemaRegistryClient client, string groupName, SchemaRegistryAvroEncoderOptions options = null)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;
        }

        private static readonly byte[] EmptyRecordFormatIndicator = { 0, 0, 0, 0 };
        private const int RecordFormatIndicatorLength = 4;
        private const int SchemaIdLength = 32;
        private const int PayloadStartPosition = RecordFormatIndicatorLength + SchemaIdLength;
        private readonly LruCache<string, Schema> _idToSchemaMap = new(CacheCapacity);
        private readonly LruCache<Schema, string> _schemaToIdMap = new(CacheCapacity);

        private enum SupportedType
        {
            SpecificRecord,
            GenericRecord
        }

        #region Encode

        /// <summary>
        /// Encodes the message data as Avro and stores it in <see cref="MessageWithMetadata.Data"/>. The <see cref="MessageWithMetadata.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageWithMetadata"/> type to encode the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to encode.</typeparam>
        public TMessage EncodeMessageData<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageWithMetadata, new()
            => (TMessage) EncodeMessageDataInternalAsync(data, typeof(TData), typeof(TMessage), false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Encodes the message data as Avro and stores it in <see cref="MessageWithMetadata.Data"/>. The <see cref="MessageWithMetadata.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TMessage">The <see cref="MessageWithMetadata"/> type to encode the data into.</typeparam>
        /// <typeparam name="TData">The type of the data to encode.</typeparam>
        public async ValueTask<TMessage> EncodeMessageDataAsync<TMessage, TData>(
            TData data,
            CancellationToken cancellationToken = default) where TMessage : MessageWithMetadata, new()
            => (TMessage) await EncodeMessageDataInternalAsync(data, typeof(TData), typeof(TMessage), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Encodes the message data as Avro and stores it in <see cref="MessageWithMetadata.Data"/>. The <see cref="MessageWithMetadata.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="dataType">The type of the data to encode. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to encode the data into. Must extend from <see cref="MessageWithMetadata"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be encoded into a <see cref="MessageWithMetadata"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public MessageWithMetadata EncodeMessageData(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => EncodeMessageDataInternalAsync(data, dataType, messageType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Encodes the message data as Avro and stores it in <see cref="MessageWithMetadata.Data"/>. The <see cref="MessageWithMetadata.ContentType"/>
        /// will be set to "avro/binary+schemaId" where schemaId is the ID of the schema used to encode the data.
        /// </summary>
        /// <param name="data">The data to serialize to Avro and encode into the message.</param>
        /// <param name="dataType">The type of the data to encode. If left blank, the type will be determined at runtime by
        /// calling <see cref="Object.GetType"/>.</param>
        /// <param name="messageType">The type of message to encode the data into. Must extend from <see cref="MessageWithMetadata"/>, and
        /// have a parameterless constructor.
        /// If left blank, the data will be encoded into a <see cref="MessageWithMetadata"/> instance.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public async ValueTask<MessageWithMetadata> EncodeMessageDataAsync(
            object data,
            Type dataType = default,
            Type messageType = default,
            CancellationToken cancellationToken = default)
            => await EncodeMessageDataInternalAsync(data, dataType, messageType, true, cancellationToken).ConfigureAwait(false);

        internal async ValueTask<MessageWithMetadata> EncodeMessageDataInternalAsync(
            object data,
            Type dataType,
            Type messageType,
            bool async,
            CancellationToken cancellationToken)
        {
            (string schemaId, BinaryData bd) = async
                ? await EncodeInternalAsync(data, dataType, true, cancellationToken).ConfigureAwait(false)
                : EncodeInternalAsync(data, dataType, false, cancellationToken).EnsureCompleted();

            messageType ??= typeof(MessageWithMetadata);
            var message = (MessageWithMetadata)Activator.CreateInstance(messageType);
            message.Data = bd;
            message.ContentType = $"{AvroMimeType}+{schemaId}";
            return message;
        }

        private async ValueTask<(string SchemaId, BinaryData Data)> EncodeInternalAsync(
            object value,
            Type dataType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(value, nameof(value));
            dataType ??= value?.GetType() ?? typeof(object);

            var supportedType = GetSupportedTypeOrThrow(dataType);
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

        private async Task<string> GetSchemaIdAsync(Schema schema, bool async, CancellationToken cancellationToken)
        {
            if (_schemaToIdMap.TryGet(schema, out string schemaId))
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

            _schemaToIdMap.AddOrUpdate(schema, id);
            _idToSchemaMap.AddOrUpdate(id, schema);
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
        #endregion

        #region Decode
        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="MessageWithMetadata.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to decode the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public TData DecodeMessageData<TData>(
            MessageWithMetadata message,
            CancellationToken cancellationToken = default)
            => (TData) DecodeMessageDataInternalAsync(message.Data, typeof(TData), message.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="MessageWithMetadata.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <typeparam name="TData">The type to decode the message data into.</typeparam>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public async ValueTask<TData> DecodeMessageDataAsync<TData>(
            MessageWithMetadata message,
            CancellationToken cancellationToken = default)
            => (TData) await DecodeMessageDataInternalAsync(message.Data, typeof(TData), message.ContentType, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="MessageWithMetadata.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="dataType">The type to decode the message data into.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public object DecodeMessageData(
            MessageWithMetadata message,
            Type dataType,
            CancellationToken cancellationToken = default)
            => DecodeMessageDataInternalAsync(message.Data, dataType, message.ContentType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Decodes the message data into the specified type using the schema information populated in <see cref="MessageWithMetadata.ContentType"/>.
        /// </summary>
        /// <param name="message">The message containing the data to decode.</param>
        /// <param name="dataType">The type to decode the message data into.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>The deserialized data.</returns>
        /// <exception cref="FormatException">Thrown if the content type is not in the expected format.</exception>
        /// <exception cref="InvalidOperationException">Thrown if an attempt is made to decode non-Avro data.</exception>
        public async ValueTask<object> DecodeMessageDataAsync(
            MessageWithMetadata message,
            Type dataType,
            CancellationToken cancellationToken = default)
            => await DecodeMessageDataInternalAsync(message.Data, dataType, message.ContentType, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<object> DecodeMessageDataInternalAsync(
            BinaryData data,
            Type dataType,
            ContentType? contentType,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNull(contentType, nameof(contentType));

            string schemaId;
            // Back Compat for first preview
            ReadOnlyMemory<byte> memory = data.ToMemory();
            byte[] recordFormatIdentifier = null;
            if (memory.Length >= RecordFormatIndicatorLength)
            {
                recordFormatIdentifier = memory.Slice(0, RecordFormatIndicatorLength).ToArray();
            }
            if (recordFormatIdentifier != null && recordFormatIdentifier.SequenceEqual(EmptyRecordFormatIndicator))
            {
                byte[] schemaIdBytes = memory.Slice(RecordFormatIndicatorLength, SchemaIdLength).ToArray();
                schemaId = Utf8Encoding.GetString(schemaIdBytes);
                data = new BinaryData(memory.Slice(PayloadStartPosition, memory.Length - PayloadStartPosition));
            }
            else
            {
                string[] contentTypeArray = contentType.ToString().Split('+');
                if (contentTypeArray.Length != 2)
                {
                    throw new FormatException("Content type was not in the expected format of MIME type + schema ID");
                }

                if (contentTypeArray[0] != AvroMimeType)
                {
                    throw new InvalidOperationException("An avro encoder may only be used on content that is of 'avro/binary' type");
                }

                schemaId = contentTypeArray[1];
            }

            if (async)
            {
                return await DecodeInternalAsync(data, dataType, schemaId, true, cancellationToken).ConfigureAwait(false);            }
            else
            {
                return DecodeInternalAsync(data, dataType, schemaId, false, cancellationToken).EnsureCompleted();
            }
        }

        private async ValueTask<object> DecodeInternalAsync(
            BinaryData data,
            Type dataType,
            string schemaId,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(schemaId, nameof(schemaId));

            SupportedType supportedType = GetSupportedTypeOrThrow(dataType);

            Schema writerSchema;
            if (async)
            {
                writerSchema = await GetSchemaByIdAsync(schemaId, true, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                writerSchema = GetSchemaByIdAsync(schemaId, false, cancellationToken).EnsureCompleted();
            }

            var binaryDecoder = new BinaryDecoder(data.ToStream());

            if (supportedType == SupportedType.SpecificRecord)
            {
                object returnInstance = Activator.CreateInstance(dataType);
                DatumReader<object> reader = GetReader(writerSchema, ((ISpecificRecord)returnInstance).Schema, SupportedType.SpecificRecord);
                return reader.Read(reuse: returnInstance, binaryDecoder);
            }
            else
            {
                DatumReader<object> reader = GetReader(writerSchema, writerSchema, supportedType);
                return reader.Read(reuse: null, binaryDecoder);
            }
        }

        private async Task<Schema> GetSchemaByIdAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            if (_idToSchemaMap.TryGet(schemaId, out Schema cachedSchema))
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
            _idToSchemaMap.AddOrUpdate(schemaId, schema);
            _schemaToIdMap.AddOrUpdate(schema, schemaId);
            return schema;
        }

        private static DatumReader<object> GetReader(Schema writerSchema, Schema readerSchema, SupportedType supportedType)
        {
            switch (supportedType)
            {
                case SupportedType.SpecificRecord:
                    return new SpecificDatumReader<object>(writerSchema, readerSchema);
                case SupportedType.GenericRecord:
                    return new GenericDatumReader<object>(writerSchema, readerSchema);
                default:
                    throw new ArgumentException($"Invalid supported type value: {supportedType}");
            }
        }
        #endregion
    }
}
