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
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the RecommendedSecurityRule class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RecommendedSecurityRule : IJsonModel<RecommendedSecurityRule>, IPersistableModel<RecommendedSecurityRule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendedSecurityRule"/> type for compatibility with the previous public API surface.
        /// </summary>
        public RecommendedSecurityRule() { }
        /// <summary>
        /// Gets or sets the DestinationPort value preserved from the previous public API surface.
        /// </summary>
        public int? DestinationPort { get; set; }
        /// <summary>
        /// Gets or sets the Direction value preserved from the previous public API surface.
        /// </summary>
        public SecurityTrafficDirection? Direction { get; set; }
        /// <summary>
        /// Gets the IPAddresses value preserved from the previous public API surface.
        /// </summary>
        public IList<string> IPAddresses { get; } = new List<string>();
        /// <summary>
        /// Gets or sets the Name value preserved from the previous public API surface.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets the Protocols value preserved from the previous public API surface.
        /// </summary>
        public IList<SecurityTransportProtocol> Protocols { get; } = new List<SecurityTransportProtocol>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        RecommendedSecurityRule IJsonModel<RecommendedSecurityRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<RecommendedSecurityRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        RecommendedSecurityRule IPersistableModel<RecommendedSecurityRule>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<RecommendedSecurityRule>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<RecommendedSecurityRule>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
