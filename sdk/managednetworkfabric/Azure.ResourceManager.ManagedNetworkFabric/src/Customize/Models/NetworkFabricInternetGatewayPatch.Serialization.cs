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
    public partial class NetworkFabricInternetGatewayPatch
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
        private static NetworkFabricInternetGatewayPatch Deserialize(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricInternetGatewayPatch>)new NetworkFabricInternetGatewayPatch()).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricInternetGatewayPatch)} does not support reading '{options.Format}' format.");
            }
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNetworkFabricInternetGatewayPatch(document.RootElement, options);
        }
        private static NetworkFabricInternetGatewayPatch Deserialize(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricInternetGatewayPatch>)new NetworkFabricInternetGatewayPatch()).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricInternetGatewayPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricInternetGatewayPatch(document.RootElement, options);
        }
    }
}
