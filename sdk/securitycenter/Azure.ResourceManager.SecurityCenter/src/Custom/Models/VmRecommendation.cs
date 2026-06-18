// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the VmRecommendation class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VmRecommendation : IJsonModel<VmRecommendation>, IPersistableModel<VmRecommendation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VmRecommendation"/> type for compatibility with the previous public API surface.
        /// </summary>
        public VmRecommendation() { }
        /// <summary>
        /// Gets or sets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterConfigurationStatus? ConfigurationStatus { get; set; }
        /// <summary>
        /// Gets or sets the EnforcementSupport value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterVmEnforcementSupportState? EnforcementSupport { get; set; }
        /// <summary>
        /// Gets or sets the RecommendationAction value preserved from the previous public API surface.
        /// </summary>
        public RecommendationAction? RecommendationAction { get; set; }
        /// <summary>
        /// Gets or sets the ResourceId value preserved from the previous public API surface.
        /// </summary>
        public Azure.Core.ResourceIdentifier ResourceId { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        VmRecommendation IJsonModel<VmRecommendation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<VmRecommendation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        VmRecommendation IPersistableModel<VmRecommendation>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<VmRecommendation>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<VmRecommendation>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
