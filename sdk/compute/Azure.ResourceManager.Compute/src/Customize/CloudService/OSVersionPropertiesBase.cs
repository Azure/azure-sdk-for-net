// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class OSVersionPropertiesBase : IJsonModel<OSVersionPropertiesBase>, IPersistableModel<OSVersionPropertiesBase>
    {
        /// <summary> Initializes a new instance of OSVersionPropertiesBase for deserialization. </summary>
        internal OSVersionPropertiesBase()
        {
        }

        /// <summary> The version. </summary>
        public string Version { get; }

        /// <summary> The label. </summary>
        public string Label { get; }

        /// <summary> Whether this version is default. </summary>
        public bool? IsDefault { get; }

        /// <summary> Whether this version is active. </summary>
        public bool? IsActive { get; }

        OSVersionPropertiesBase IJsonModel<OSVersionPropertiesBase>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<OSVersionPropertiesBase>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        OSVersionPropertiesBase IPersistableModel<OSVersionPropertiesBase>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<OSVersionPropertiesBase>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<OSVersionPropertiesBase>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
