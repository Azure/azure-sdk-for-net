// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary>
    /// Backward-compat type alias for ArcExtensionInstanceView (old autorest name).
    /// The TypeSpec migration renamed ExtensionInstanceView to HciExtensionInstanceView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ArcExtensionInstanceView : HciExtensionInstanceView,
        IJsonModel<ArcExtensionInstanceView>,
        IPersistableModel<ArcExtensionInstanceView>
    {
        internal ArcExtensionInstanceView() : base() { }

        internal ArcExtensionInstanceView(string name, string type, string typeHandlerVersion,
            ArcExtensionInstanceViewStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(name, type, typeHandlerVersion, status, additionalBinaryDataProperties) { }

        ArcExtensionInstanceView IJsonModel<ArcExtensionInstanceView>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ArcExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcExtensionInstanceView)} does not support reading '{format}' format.");
            }
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeArcExtensionInstanceView(document.RootElement, options);
        }

        void IJsonModel<ArcExtensionInstanceView>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<HciExtensionInstanceView>)this).Write(writer, options);

        ArcExtensionInstanceView IPersistableModel<ArcExtensionInstanceView>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ArcExtensionInstanceView>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcExtensionInstanceView)} does not support reading '{options.Format}' format.");
            }
            using var document = JsonDocument.Parse(data);
            return DeserializeArcExtensionInstanceView(document.RootElement, options);
        }

        BinaryData IPersistableModel<ArcExtensionInstanceView>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<HciExtensionInstanceView>)this).Write(options);

        string IPersistableModel<ArcExtensionInstanceView>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ArcExtensionInstanceView DeserializeArcExtensionInstanceView(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string type = default;
            string typeHandlerVersion = default;
            ArcExtensionInstanceViewStatus status = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    type = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("typeHandlerVersion"u8))
                {
                    typeHandlerVersion = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = ArcExtensionInstanceViewStatus.DeserializeArcExtensionInstanceViewStatus(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ArcExtensionInstanceView(name, type, typeHandlerVersion, status, additionalBinaryDataProperties);
        }
    }
}
