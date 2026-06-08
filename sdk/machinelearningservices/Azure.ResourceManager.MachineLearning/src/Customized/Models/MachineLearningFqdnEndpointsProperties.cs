// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy factory overload parameter type during TypeSpec migration.
    public partial class MachineLearningFqdnEndpointsProperties : FQDNEndpointsPropertyBag, IJsonModel<MachineLearningFqdnEndpointsProperties>
    {
        internal MachineLearningFqdnEndpointsProperties(MachineLearningFqdnEndpoints properties) : base(properties, additionalBinaryDataProperties: null)
        {
        }

        /// <summary> Gets the category. </summary>
        [WirePath("category")]
        public string Category => Properties?.Category;

        /// <summary> Gets the FQDN endpoints. </summary>
        [WirePath("endpoints")]
        public IReadOnlyList<MachineLearningFqdnEndpoint> Endpoints => Properties?.Endpoints is null ? null : new List<MachineLearningFqdnEndpoint>(Properties.Endpoints);

        void IJsonModel<MachineLearningFqdnEndpointsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<FQDNEndpointsPropertyBag>)this).Write(writer, options);
        }

        MachineLearningFqdnEndpointsProperties IJsonModel<MachineLearningFqdnEndpointsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            FQDNEndpointsPropertyBag propertyBag = FQDNEndpointsPropertyBag.DeserializeFQDNEndpointsPropertyBag(document.RootElement, options);
            return propertyBag is null ? null : new MachineLearningFqdnEndpointsProperties(propertyBag.Properties);
        }

        BinaryData IPersistableModel<MachineLearningFqdnEndpointsProperties>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<FQDNEndpointsPropertyBag>)this).Write(options);
        }

        MachineLearningFqdnEndpointsProperties IPersistableModel<MachineLearningFqdnEndpointsProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningFqdnEndpointsProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        FQDNEndpointsPropertyBag propertyBag = FQDNEndpointsPropertyBag.DeserializeFQDNEndpointsPropertyBag(document.RootElement, options);
                        return propertyBag is null ? null : new MachineLearningFqdnEndpointsProperties(propertyBag.Properties);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningFqdnEndpointsProperties)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningFqdnEndpointsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
