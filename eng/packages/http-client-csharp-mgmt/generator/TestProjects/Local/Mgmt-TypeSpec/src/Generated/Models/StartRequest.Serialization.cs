// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtTypeSpec;

namespace MgmtTypeSpec.Models
{
    /// <summary> Start SAP instance(s) request body. </summary>
    public partial class StartRequest : IJsonModel<StartRequest>
    {
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<StartRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StartRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StartRequest)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(StartVm))
            {
                writer.WritePropertyName("startVm"u8);
                writer.WriteBooleanValue(StartVm.Value);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        StartRequest IJsonModel<StartRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual StartRequest JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StartRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StartRequest)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStartRequest(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static StartRequest DeserializeStartRequest(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? startVm = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("startVm"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startVm = prop.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new StartRequest(startVm, additionalBinaryDataProperties);
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<StartRequest>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StartRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, MgmtTypeSpecContext.Default);
                default:
                    throw new FormatException($"The model {nameof(StartRequest)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        StartRequest IPersistableModel<StartRequest>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual StartRequest PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<StartRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeStartRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(StartRequest)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<StartRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="startRequest"> The <see cref="StartRequest"/> to serialize into <see cref="RequestContent"/>. </param>
        public static implicit operator RequestContent(StartRequest startRequest)
        {
            if (startRequest == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(startRequest, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
