// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenSuppress("PersistableModelCreateCore")]
    [CodeGenSuppress("JsonModelCreateCore")]
    public partial class NetworkFabricRoutePolicyPatch
    {
        /// <summary> Creates a model instance from persistable data. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        /// <returns> The deserialized model. </returns>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricRoutePolicyPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricRoutePolicyPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricRoutePolicyPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Creates a model instance from JSON. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        /// <returns> The deserialized model. </returns>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricRoutePolicyPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricRoutePolicyPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricRoutePolicyPatch(document.RootElement, options);
        }
    }
}
