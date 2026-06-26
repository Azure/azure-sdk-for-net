// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the InformationProtectionPolicy class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class InformationProtectionPolicy : ResourceData, IJsonModel<InformationProtectionPolicy>, IPersistableModel<InformationProtectionPolicy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationProtectionPolicy"/> type for compatibility with the previous public API surface.
        /// </summary>
        public InformationProtectionPolicy() { }
        /// <summary>
        /// Gets the InformationTypes value preserved from the previous public API surface.
        /// </summary>
        public IDictionary<string, SecurityInformationTypeInfo> InformationTypes { get; } = new Dictionary<string, SecurityInformationTypeInfo>();
        /// <summary>
        /// Gets the Labels value preserved from the previous public API surface.
        /// </summary>
        public IDictionary<string, SensitivityLabel> Labels { get; } = new Dictionary<string, SensitivityLabel>();
        /// <summary>
        /// Gets the LastModifiedUtc value preserved from the previous public API surface.
        /// This obsolete hidden member intentionally keeps the GA name for binary/source compatibility; the generated data model uses the same LastModifiedUtc name.
        /// </summary>
        public System.DateTimeOffset? LastModifiedUtc { get; }
        /// <summary>
        /// Gets the Version value preserved from the previous public API surface.
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionPolicy IJsonModel<InformationProtectionPolicy>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<InformationProtectionPolicy>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        InformationProtectionPolicy IPersistableModel<InformationProtectionPolicy>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<InformationProtectionPolicy>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<InformationProtectionPolicy>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
