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
using Azure.ResourceManager.DevCenter;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DevCenter.Models
{
    // Backward compatibility: full serialization for DevCenterOperationStatus
    // to match the baseline SDK's OperationStatusResult inheritance and BinaryData Properties type.
    public partial class DevCenterOperationStatus : IJsonModel<DevCenterOperationStatus>
    {
        /// <summary> Initializes a new instance of <see cref="DevCenterOperationStatus"/> for deserialization. </summary>
        internal DevCenterOperationStatus()
        {
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<DevCenterOperationStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DevCenterOperationStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevCenterOperationStatus)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (options.Format != "W" && Properties != null)
            {
                writer.WritePropertyName("properties"u8);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(Properties);
#else
                using (JsonDocument document = JsonDocument.Parse(Properties))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DevCenterOperationStatus IJsonModel<DevCenterOperationStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (DevCenterOperationStatus)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual OperationStatusResult JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DevCenterOperationStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DevCenterOperationStatus)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDevCenterOperationStatus(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static DevCenterOperationStatus DeserializeDevCenterOperationStatus(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            string status = default;
            float? percentComplete = default;
            DateTimeOffset? startOn = default;
            DateTimeOffset? endOn = default;
            IReadOnlyList<OperationStatusResult> operations = default;
            ResponseError error = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            BinaryData properties = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("percentComplete"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    percentComplete = (float?)prop.Value.GetDouble();
                    continue;
                }
                if (prop.NameEquals("startTime"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startOn = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (prop.NameEquals("endTime"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endOn = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (prop.NameEquals("operations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<OperationStatusResult> array = new List<OperationStatusResult>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ModelReaderWriter.Read<OperationStatusResult>(BinaryData.FromString(item.GetRawText()), options, AzureResourceManagerDevCenterContext.Default));
                    }
                    operations = array;
                    continue;
                }
                if (prop.NameEquals("error"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    error = ModelReaderWriter.Read<ResponseError>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), options, AzureResourceManagerDevCenterContext.Default);
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new DevCenterOperationStatus(
                id,
                name,
                status,
                percentComplete,
                startOn,
                endOn,
                operations ?? new ChangeTrackingList<OperationStatusResult>(),
                error,
                additionalBinaryDataProperties,
                properties);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual OperationStatusResult PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DevCenterOperationStatus>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeDevCenterOperationStatus(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DevCenterOperationStatus)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<DevCenterOperationStatus>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDevCenterContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DevCenterOperationStatus)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<DevCenterOperationStatus>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        DevCenterOperationStatus IPersistableModel<DevCenterOperationStatus>.Create(BinaryData data, ModelReaderWriterOptions options) => (DevCenterOperationStatus)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<DevCenterOperationStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="DevCenterOperationStatus"/> from. </param>
        internal static DevCenterOperationStatus FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeDevCenterOperationStatus(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
