// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network
{
    // The generator emits these deserialization bodies with ResourceData return types. Matching custom methods are discovered
    // without CodeGenSuppress and preserve the released NetworkGroupData protected return signatures for API compatibility.
    public partial class NetworkGroupData
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NetworkGroupData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkGroupData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkGroupData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkGroupData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NetworkGroupData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkGroupData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkGroupData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkGroupData(document.RootElement, options);
        }
    }
}
