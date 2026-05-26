// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // The generated patch deserializer returns the base NetworkRackPatch shape for this hierarchy.
    // These overrides deserialize the concrete patch type; removing them would make model reading
    // produce the wrong type or invalid override code for the migrated patch model.
    [CodeGenSuppress("PersistableModelCreateCore")]
    [CodeGenSuppress("JsonModelCreateCore")]
    public partial class NetworkFabricControllerPatch
    {
        /// <summary> Creates a model instance from persistable data. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        /// <returns> The deserialized model. </returns>
        protected override NetworkRackPatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => Deserialize(data, options);

        /// <summary> Creates a model instance from JSON. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        /// <returns> The deserialized model. </returns>
        protected override NetworkRackPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => Deserialize(ref reader, options);
        private static NetworkFabricControllerPatch Deserialize(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)new NetworkFabricControllerPatch()).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support reading '{options.Format}' format.");
            }
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNetworkFabricControllerPatch(document.RootElement, options);
        }
        private static NetworkFabricControllerPatch Deserialize(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricControllerPatch>)new NetworkFabricControllerPatch()).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricControllerPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricControllerPatch(document.RootElement, options);
        }
    }
}
