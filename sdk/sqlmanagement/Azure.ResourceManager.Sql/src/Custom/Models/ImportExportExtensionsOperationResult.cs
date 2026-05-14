// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ImportExportExtensionsOperationResult : ResourceData, IJsonModel<ImportExportExtensionsOperationResult>
    {
        public ImportExportExtensionsOperationResult()
        {
        }

        [WirePath("properties.requestId")]
        public Guid? RequestId { get; set; }
        [WirePath("properties.requestType")]
        public string RequestType { get; set; }
        [WirePath("properties.lastModifiedTime")]
        public string LastModifiedTime { get; set; }
        [WirePath("properties.serverName")]
        public string ServerName { get; set; }
        [WirePath("properties.databaseName")]
        public string DatabaseName { get; set; }
        [WirePath("properties.status")]
        public string Status { get; set; }
        [WirePath("properties.errorMessage")]
        public string ErrorMessage { get; set; }
        [WirePath("properties.queuedTime")]
        public string QueuedTime { get; set; }
        [WirePath("properties.blobUri")]
        public Uri BlobUri { get; set; }
        [WirePath("properties.privateEndpointConnections")]
        public IReadOnlyList<PrivateEndpointConnectionRequestStatus> PrivateEndpointConnections { get; set; }

        void IJsonModel<ImportExportExtensionsOperationResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (((IPersistableModel<ImportExportExtensionsOperationResult>)this).GetFormatFromOptions(options) != "J")
            {
                throw new FormatException($"The model {nameof(ImportExportExtensionsOperationResult)} does not support writing '{options.Format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (RequestId.HasValue)
            {
                writer.WritePropertyName("requestId"u8);
                writer.WriteStringValue(RequestId.Value);
            }
            if (RequestType is not null)
            {
                writer.WritePropertyName("requestType"u8);
                writer.WriteStringValue(RequestType);
            }
            if (LastModifiedTime is not null)
            {
                writer.WritePropertyName("lastModifiedTime"u8);
                writer.WriteStringValue(LastModifiedTime);
            }
            if (ServerName is not null)
            {
                writer.WritePropertyName("serverName"u8);
                writer.WriteStringValue(ServerName);
            }
            if (DatabaseName is not null)
            {
                writer.WritePropertyName("databaseName"u8);
                writer.WriteStringValue(DatabaseName);
            }
            if (Status is not null)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status);
            }
            if (ErrorMessage is not null)
            {
                writer.WritePropertyName("errorMessage"u8);
                writer.WriteStringValue(ErrorMessage);
            }
            if (QueuedTime is not null)
            {
                writer.WritePropertyName("queuedTime"u8);
                writer.WriteStringValue(QueuedTime);
            }
            if (BlobUri is not null)
            {
                writer.WritePropertyName("blobUri"u8);
                writer.WriteStringValue(BlobUri.AbsoluteUri);
            }
            if (PrivateEndpointConnections is not null)
            {
                writer.WritePropertyName("privateEndpointConnections"u8);
                writer.WriteObjectValue(PrivateEndpointConnections, options);
            }
            writer.WriteEndObject();
        }

        ImportExportExtensionsOperationResult IJsonModel<ImportExportExtensionsOperationResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            ImportExportExtensionsOperationResult result = new ImportExportExtensionsOperationResult();
            if (document.RootElement.TryGetProperty("properties", out JsonElement properties))
            {
                if (properties.TryGetProperty("requestId", out JsonElement requestId) && requestId.ValueKind != JsonValueKind.Null)
                {
                    result.RequestId = requestId.GetGuid();
                }
                if (properties.TryGetProperty("requestType", out JsonElement requestType))
                {
                    result.RequestType = requestType.GetString();
                }
                if (properties.TryGetProperty("lastModifiedTime", out JsonElement lastModifiedTime))
                {
                    result.LastModifiedTime = lastModifiedTime.GetString();
                }
                if (properties.TryGetProperty("serverName", out JsonElement serverName))
                {
                    result.ServerName = serverName.GetString();
                }
                if (properties.TryGetProperty("databaseName", out JsonElement databaseName))
                {
                    result.DatabaseName = databaseName.GetString();
                }
                if (properties.TryGetProperty("status", out JsonElement status))
                {
                    result.Status = status.GetString();
                }
                if (properties.TryGetProperty("errorMessage", out JsonElement errorMessage))
                {
                    result.ErrorMessage = errorMessage.GetString();
                }
                if (properties.TryGetProperty("queuedTime", out JsonElement queuedTime))
                {
                    result.QueuedTime = queuedTime.GetString();
                }
                if (properties.TryGetProperty("blobUri", out JsonElement blobUri) && Uri.TryCreate(blobUri.GetString(), UriKind.RelativeOrAbsolute, out Uri uri))
                {
                    result.BlobUri = uri;
                }
                if (properties.TryGetProperty("privateEndpointConnections", out JsonElement privateEndpointConnections))
                {
                    result.PrivateEndpointConnections = ModelReaderWriter.Read<IReadOnlyList<PrivateEndpointConnectionRequestStatus>>(new BinaryData(Encoding.UTF8.GetBytes(privateEndpointConnections.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerSqlContext.Default);
                }
            }
            return result;
        }

        BinaryData IPersistableModel<ImportExportExtensionsOperationResult>.Write(ModelReaderWriterOptions options)
        {
            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<ImportExportExtensionsOperationResult>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        ImportExportExtensionsOperationResult IPersistableModel<ImportExportExtensionsOperationResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            Utf8JsonReader reader = new Utf8JsonReader(data.ToArray());
            return ((IJsonModel<ImportExportExtensionsOperationResult>)this).Create(ref reader, options);
        }

        string IPersistableModel<ImportExportExtensionsOperationResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
