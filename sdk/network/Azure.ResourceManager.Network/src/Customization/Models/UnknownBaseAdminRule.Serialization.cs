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
    internal partial class UnknownBaseAdminRule
    {
        protected override BaseAdminRuleData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BaseAdminRuleData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeBaseAdminRuleData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BaseAdminRuleData)} does not support reading '{options.Format}' format.");
            }
        }

        protected override BaseAdminRuleData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BaseAdminRuleData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BaseAdminRuleData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseAdminRuleData(document.RootElement, options);
        }
    }
}
