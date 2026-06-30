// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.FrontDoor.Models
{
    // The shipped SDK inherited TrackedResourceData. This partial restores that base type after
    // removing the spec-side alternateType for Microsoft.Network.Resource.
    public partial class LatencyScorecard : TrackedResourceData
    {
        // The generated public parameterless constructor was not part of the shipped API. Keep this
        // constructor internal so generation has an implementation hook without expanding public API.
        internal LatencyScorecard()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LatencyScorecard"/>. </summary>
        /// <param name="location"> The location. </param>
        public LatencyScorecard(AzureLocation location) : base(location)
        {
        }

        // This method body is copied from the generated PersistableModelCreateCore; the customization changes
        // only the return type from LatencyScorecard to ResourceData so it matches TrackedResourceData.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LatencyScorecard>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeLatencyScorecard(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LatencyScorecard)} does not support reading '{options.Format}' format.");
            }
        }

        // This method body is copied from the generated JsonModelWriteCore; the customization changes
        // the method modifier from "virtual" to "override" and calls the restored TrackedResourceData
        // base writer so inherited resource fields keep their previous wire shape.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LatencyScorecard>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LatencyScorecard)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
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

        // This method body is copied from the generated JsonModelCreateCore; the customization changes
        // only the return type from LatencyScorecard to ResourceData so it matches TrackedResourceData.
        // Remove this workaround after https://github.com/Azure/azure-sdk-for-net/issues/60297 is fixed.
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<LatencyScorecard>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LatencyScorecard)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLatencyScorecard(document.RootElement, options);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        LatencyScorecard IPersistableModel<LatencyScorecard>.Create(BinaryData data, ModelReaderWriterOptions options) => (LatencyScorecard)PersistableModelCreateCore(data, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        LatencyScorecard IJsonModel<LatencyScorecard>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (LatencyScorecard)JsonModelCreateCore(ref reader, options);
    }
}
