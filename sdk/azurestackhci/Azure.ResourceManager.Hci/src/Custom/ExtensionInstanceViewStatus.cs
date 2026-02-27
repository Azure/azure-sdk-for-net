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
    /// Backward-compat type alias for ExtensionInstanceViewStatus (old autorest name).
    /// The TypeSpec migration renamed it to ArcExtensionInstanceViewStatus.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionInstanceViewStatus` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExtensionInstanceViewStatus : ArcExtensionInstanceViewStatus,
        IJsonModel<ExtensionInstanceViewStatus>,
        IPersistableModel<ExtensionInstanceViewStatus>
    {
        internal ExtensionInstanceViewStatus() : base() { }

        internal ExtensionInstanceViewStatus(string code, HciStatusLevelType? level,
            string displayStatus, string message, DateTimeOffset? time,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(code, level, displayStatus, message, time, additionalBinaryDataProperties) { }

        ExtensionInstanceViewStatus IJsonModel<ExtensionInstanceViewStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtensionInstanceViewStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionInstanceViewStatus)} does not support reading '{format}' format.");
            }
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtensionInstanceViewStatus(document.RootElement, options);
        }

        void IJsonModel<ExtensionInstanceViewStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ArcExtensionInstanceViewStatus>)this).Write(writer, options);

        ExtensionInstanceViewStatus IPersistableModel<ExtensionInstanceViewStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtensionInstanceViewStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionInstanceViewStatus)} does not support reading '{options.Format}' format.");
            }
            using var document = JsonDocument.Parse(data);
            return DeserializeExtensionInstanceViewStatus(document.RootElement, options);
        }

        BinaryData IPersistableModel<ExtensionInstanceViewStatus>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ArcExtensionInstanceViewStatus>)this).Write(options);

        string IPersistableModel<ExtensionInstanceViewStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ExtensionInstanceViewStatus DeserializeExtensionInstanceViewStatus(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string code = default;
            HciStatusLevelType? level = default;
            string displayStatus = default;
            string message = default;
            DateTimeOffset? time = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("code"u8))
                {
                    code = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("level"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    level = new HciStatusLevelType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("displayStatus"u8))
                {
                    displayStatus = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("message"u8))
                {
                    message = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("time"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    time = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ExtensionInstanceViewStatus(code, level, displayStatus, message, time, additionalBinaryDataProperties);
        }
    }
}
