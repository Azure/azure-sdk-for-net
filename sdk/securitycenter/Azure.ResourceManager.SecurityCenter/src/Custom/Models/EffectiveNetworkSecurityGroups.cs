// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the EffectiveNetworkSecurityGroups class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class EffectiveNetworkSecurityGroups : IJsonModel<EffectiveNetworkSecurityGroups>, IPersistableModel<EffectiveNetworkSecurityGroups>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectiveNetworkSecurityGroups"/> type for compatibility with the previous public API surface.
        /// </summary>
        public EffectiveNetworkSecurityGroups() { }
        /// <summary>
        /// Gets or sets the NetworkInterface value preserved from the previous public API surface.
        /// </summary>
        public string NetworkInterface { get; set; }
        /// <summary>
        /// Gets the NetworkSecurityGroups value preserved from the previous public API surface.
        /// </summary>
        public IList<string> NetworkSecurityGroups { get; } = new List<string>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        EffectiveNetworkSecurityGroups IJsonModel<EffectiveNetworkSecurityGroups>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<EffectiveNetworkSecurityGroups>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        EffectiveNetworkSecurityGroups IPersistableModel<EffectiveNetworkSecurityGroups>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<EffectiveNetworkSecurityGroups>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<EffectiveNetworkSecurityGroups>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
