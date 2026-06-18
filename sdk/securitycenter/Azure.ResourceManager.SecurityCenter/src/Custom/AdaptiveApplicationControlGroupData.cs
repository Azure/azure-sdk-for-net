// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // The latest TypeSpec no longer describes this legacy resource data shape, so the generator cannot emit the previous GA model. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupData : ResourceData, IJsonModel<AdaptiveApplicationControlGroupData>, IPersistableModel<AdaptiveApplicationControlGroupData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlGroupData() { }
        /// <summary>
        /// Gets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterConfigurationStatus? ConfigurationStatus { get; }
        /// <summary>
        /// Gets or sets the EnforcementMode value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? EnforcementMode { get; set; }
        /// <summary>
        /// Gets the Issues value preserved from the previous public API surface.
        /// </summary>
        public IReadOnlyList<AdaptiveApplicationControlIssueSummary> Issues { get; } = new List<AdaptiveApplicationControlIssueSummary>();
        /// <summary>
        /// Gets the Location value preserved from the previous public API surface.
        /// </summary>
        public AzureLocation? Location { get; }
        /// <summary>
        /// Gets the PathRecommendations value preserved from the previous public API surface.
        /// </summary>
        public IList<PathRecommendation> PathRecommendations { get; } = new List<PathRecommendation>();
        /// <summary>
        /// Gets or sets the ProtectionMode value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterFileProtectionMode ProtectionMode { get; set; }
        /// <summary>
        /// Gets the RecommendationStatus value preserved from the previous public API surface.
        /// </summary>
        public RecommendationStatus? RecommendationStatus { get; }
        /// <summary>
        /// Gets the SourceSystem value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlGroupSourceSystem? SourceSystem { get; }
        /// <summary>
        /// Gets the VmRecommendations value preserved from the previous public API surface.
        /// </summary>
        public IList<VmRecommendation> VmRecommendations { get; } = new List<VmRecommendation>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveApplicationControlGroupData IJsonModel<AdaptiveApplicationControlGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AdaptiveApplicationControlGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveApplicationControlGroupData IPersistableModel<AdaptiveApplicationControlGroupData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AdaptiveApplicationControlGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AdaptiveApplicationControlGroupData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
