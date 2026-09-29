// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.Network.Models
{
    // The generator emits these deserialization bodies with the inherited BaseAdminRuleData return type. Matching custom methods
    // are discovered without CodeGenSuppress and preserve the released protected signatures for API compatibility.
    public partial class NetworkDefaultAdminRule
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BaseAdminRuleData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDefaultAdminRule>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkDefaultAdminRule(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkDefaultAdminRule)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BaseAdminRuleData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkDefaultAdminRule>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkDefaultAdminRule)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkDefaultAdminRule(document.RootElement, options);
        }
    }
}
