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
    /// Backward-compat type alias. Old name was ExtensionUpgradeContent, renamed to ArcExtensionUpgradeContent.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionUpgradeContent` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionUpgradeContent : ArcExtensionUpgradeContent,
        IJsonModel<ExtensionUpgradeContent>,
        IPersistableModel<ExtensionUpgradeContent>
    {
        /// <summary> Initializes a new instance of <see cref="ExtensionUpgradeContent"/>. </summary>
        public ExtensionUpgradeContent() : base() { }

        internal ExtensionUpgradeContent(string targetVersion,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(targetVersion, additionalBinaryDataProperties) { }

        ExtensionUpgradeContent IJsonModel<ExtensionUpgradeContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtensionUpgradeContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionUpgradeContent)} does not support reading '{format}' format.");
            }
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtensionUpgradeContent(document.RootElement, options);
        }

        void IJsonModel<ExtensionUpgradeContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ArcExtensionUpgradeContent>)this).Write(writer, options);

        ExtensionUpgradeContent IPersistableModel<ExtensionUpgradeContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtensionUpgradeContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionUpgradeContent)} does not support reading '{options.Format}' format.");
            }
            using var document = JsonDocument.Parse(data);
            return DeserializeExtensionUpgradeContent(document.RootElement, options);
        }

        BinaryData IPersistableModel<ExtensionUpgradeContent>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ArcExtensionUpgradeContent>)this).Write(options);

        string IPersistableModel<ExtensionUpgradeContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ExtensionUpgradeContent DeserializeExtensionUpgradeContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string targetVersion = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("targetVersion"u8))
                {
                    targetVersion = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ExtensionUpgradeContent(targetVersion, additionalBinaryDataProperties);
        }
    }
}
