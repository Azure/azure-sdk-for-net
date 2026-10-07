// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The current status of an async operation. </summary>
    public partial class NetworkFabricOperationStatusResult : IJsonModel<NetworkFabricOperationStatusResult>, IPersistableModel<NetworkFabricOperationStatusResult>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricOperationStatusResult"/>. </summary>
        /// <param name="status"> Operation status. </param>
        public NetworkFabricOperationStatusResult(string status)
        {
            Status = status;
            Operations = new ChangeTrackingList<NetworkFabricOperationStatusResult>();
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricOperationStatusResult"/>. </summary>
        /// <param name="id"> Fully qualified ID for the async operation. </param>
        /// <param name="name"> Name of the async operation. </param>
        /// <param name="status"> Operation status. </param>
        /// <param name="percentComplete"> Percent of the operation that is complete. </param>
        /// <param name="startOn"> The start time of the operation. </param>
        /// <param name="endOn"> The end time of the operation. </param>
        /// <param name="operations"> The operations list. </param>
        /// <param name="error"> If present, details of the operation error. </param>
        /// <param name="resourceId"> Fully qualified ID of the resource against which the original async operation was started. </param>
        internal NetworkFabricOperationStatusResult(ResourceIdentifier id, string name, string status, float? percentComplete, DateTimeOffset? startOn, DateTimeOffset? endOn, IReadOnlyList<NetworkFabricOperationStatusResult> operations, ResponseError error, ResourceIdentifier resourceId)
        {
            Id = id;
            Name = name;
            Status = status;
            PercentComplete = percentComplete;
            StartOn = startOn;
            EndOn = endOn;
            Operations = operations;
            Error = error;
            ResourceId = resourceId;
        }

        /// <summary> Fully qualified ID for the async operation. </summary>
        public ResourceIdentifier Id { get; }
        /// <summary> Name of the async operation. </summary>
        public string Name { get; }
        /// <summary> Operation status. </summary>
        public string Status { get; }
        /// <summary> Percent of the operation that is complete. </summary>
        public float? PercentComplete { get; }
        /// <summary> The start time of the operation. </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary> The end time of the operation. </summary>
        public DateTimeOffset? EndOn { get; }
        /// <summary> The operations list. </summary>
        public IReadOnlyList<NetworkFabricOperationStatusResult> Operations { get; }
        /// <summary> If present, details of the operation error. </summary>
        public ResponseError Error { get; }
        /// <summary> Fully qualified ID of the resource against which the original async operation was started. </summary>
        public ResourceIdentifier ResourceId { get; }

        void IJsonModel<NetworkFabricOperationStatusResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status);
            if (Optional.IsDefined(PercentComplete))
            {
                writer.WritePropertyName("percentComplete"u8);
                writer.WriteNumberValue(PercentComplete.Value);
            }
            if (Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (Optional.IsDefined(EndOn))
            {
                writer.WritePropertyName("endTime"u8);
                writer.WriteStringValue(EndOn.Value, "O");
            }
            if (Optional.IsCollectionDefined(Operations))
            {
                writer.WritePropertyName("operations"u8);
                writer.WriteStartArray();
                foreach (NetworkFabricOperationStatusResult item in Operations)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Error))
            {
                writer.WritePropertyName("error"u8);
                ((IJsonModel<ResponseError>)Error).Write(writer, options);
            }
            if (options.Format != "W" && Optional.IsDefined(ResourceId))
            {
                writer.WritePropertyName("resourceId"u8);
                writer.WriteStringValue(ResourceId);
            }
        }

        NetworkFabricOperationStatusResult IJsonModel<NetworkFabricOperationStatusResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricOperationStatusResult(document.RootElement, options);
        }

        BinaryData IPersistableModel<NetworkFabricOperationStatusResult>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);

        NetworkFabricOperationStatusResult IPersistableModel<NetworkFabricOperationStatusResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNetworkFabricOperationStatusResult(document.RootElement, options);
        }

        string IPersistableModel<NetworkFabricOperationStatusResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static NetworkFabricOperationStatusResult DeserializeNetworkFabricOperationStatusResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            string status = default;
            float? percentComplete = default;
            DateTimeOffset? startTime = default;
            DateTimeOffset? endTime = default;
            IReadOnlyList<NetworkFabricOperationStatusResult> operations = default;
            ResponseError error = default;
            ResourceIdentifier resourceId = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("percentComplete"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        percentComplete = property.Value.GetSingle();
                    }
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        startTime = property.Value.GetDateTimeOffset("O");
                    }
                    continue;
                }
                if (property.NameEquals("endTime"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        endTime = property.Value.GetDateTimeOffset("O");
                    }
                    continue;
                }
                if (property.NameEquals("operations"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        List<NetworkFabricOperationStatusResult> array = new List<NetworkFabricOperationStatusResult>();
                        foreach (JsonElement item in property.Value.EnumerateArray())
                        {
                            array.Add(ModelReaderWriter.Read<NetworkFabricOperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(item.GetRawText())), options, AzureResourceManagerManagedNetworkFabricContext.Default));
                        }
                        operations = array;
                    }
                    continue;
                }
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        error = ModelReaderWriter.Read<ResponseError>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), options, AzureResourceManagerManagedNetworkFabricContext.Default);
                    }
                    continue;
                }
                if (property.NameEquals("resourceId"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceId = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }
            }

            return new NetworkFabricOperationStatusResult(id, name, status, percentComplete, startTime, endTime, operations ?? new ChangeTrackingList<NetworkFabricOperationStatusResult>(), error, resourceId);
        }
    }
}
