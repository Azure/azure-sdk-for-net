// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class AdaptiveApplicationControlGroupData : ResourceData
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlGroupData()
        {
            Issues = new List<AdaptiveApplicationControlIssueSummary>();
            PathRecommendations = new List<PathRecommendation>();
            VmRecommendations = new List<VmRecommendation>();
        }
        /// <summary>
        /// Gets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterConfigurationStatus? ConfigurationStatus { get; }
        /// <summary>
        /// Gets or sets the EnforcementMode value preserved from the previous public API surface.
        /// </summary>
        public AdaptiveApplicationControlEnforcementMode? EnforcementMode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the Issues value preserved from the previous public API surface.
        /// </summary>
        public IReadOnlyList<AdaptiveApplicationControlIssueSummary> Issues { get; }
        /// <summary>
        /// Gets the Location value preserved from the previous public API surface.
        /// </summary>
        public AzureLocation? Location { get; }
        /// <summary>
        /// Gets the PathRecommendations value preserved from the previous public API surface.
        /// </summary>
        public IList<PathRecommendation> PathRecommendations { get; }
        /// <summary>
        /// Gets or sets the ProtectionMode value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterFileProtectionMode ProtectionMode
        {
            get;
            set;
        }
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
        public IList<VmRecommendation> VmRecommendations { get; }
    }
}
