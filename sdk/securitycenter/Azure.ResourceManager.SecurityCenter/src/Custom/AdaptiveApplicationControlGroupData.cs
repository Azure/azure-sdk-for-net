// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupData class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlGroupData() { }
        /// <summary>
        /// Gets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterConfigurationStatus? ConfigurationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the EnforcementMode value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlEnforcementMode? EnforcementMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Issues value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlIssueSummary> Issues { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the Location value preserved from the previous public API surface.
        /// </summary>
        public Azure.Core.AzureLocation? Location { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the PathRecommendations value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.PathRecommendation> PathRecommendations { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ProtectionMode value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityCenterFileProtectionMode ProtectionMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the RecommendationStatus value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.RecommendationStatus? RecommendationStatus { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the SourceSystem value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.AdaptiveApplicationControlGroupSourceSystem? SourceSystem { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets the VmRecommendations value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.VmRecommendation> VmRecommendations { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
