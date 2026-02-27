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
    /// Backward-compat type alias. Old name was UpdatePrerequisite, renamed to HciClusterUpdatePrerequisite.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdatePrerequisite` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class UpdatePrerequisite : HciClusterUpdatePrerequisite,
        IJsonModel<UpdatePrerequisite>,
        IPersistableModel<UpdatePrerequisite>
    {
        /// <summary> Initializes a new instance of <see cref="UpdatePrerequisite"/>. </summary>
        public UpdatePrerequisite() : base() { }

        internal UpdatePrerequisite(string updateType, string version, string packageName,
            IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(updateType, version, packageName, additionalBinaryDataProperties) { }

        UpdatePrerequisite IJsonModel<UpdatePrerequisite>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpdatePrerequisite>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UpdatePrerequisite)} does not support reading '{format}' format.");
            }
            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeUpdatePrerequisite(document.RootElement, options);
        }

        void IJsonModel<UpdatePrerequisite>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<HciClusterUpdatePrerequisite>)this).Write(writer, options);

        UpdatePrerequisite IPersistableModel<UpdatePrerequisite>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UpdatePrerequisite>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UpdatePrerequisite)} does not support reading '{options.Format}' format.");
            }
            using var document = JsonDocument.Parse(data);
            return DeserializeUpdatePrerequisite(document.RootElement, options);
        }

        BinaryData IPersistableModel<UpdatePrerequisite>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<HciClusterUpdatePrerequisite>)this).Write(options);

        string IPersistableModel<UpdatePrerequisite>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static UpdatePrerequisite DeserializeUpdatePrerequisite(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string updateType = default;
            string version = default;
            string packageName = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("updateType"u8))
                {
                    updateType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("version"u8))
                {
                    version = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("packageName"u8))
                {
                    packageName = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new UpdatePrerequisite(updateType, version, packageName, additionalBinaryDataProperties);
        }
    }
}
