// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the VmRecommendation class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VmRecommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VmRecommendation"/> type for compatibility with the previous public API surface.
        /// </summary>
        public VmRecommendation() { }
        /// <summary>
        /// Gets or sets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the EnforcementSupport value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterVmEnforcementSupportState? EnforcementSupport { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the RecommendationAction value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationAction? RecommendationAction { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ResourceId value preserved from the previous public API surface.
        /// </summary>
        public Azure.Core.ResourceIdentifier ResourceId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VmRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.VmRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
