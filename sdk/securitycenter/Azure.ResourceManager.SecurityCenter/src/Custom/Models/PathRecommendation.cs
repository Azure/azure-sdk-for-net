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
    /// Provides a compatibility shim for the PathRecommendation class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class PathRecommendation : IJsonModel<PathRecommendation>, IPersistableModel<PathRecommendation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PathRecommendation"/> type for compatibility with the previous public API surface.
        /// </summary>
        public PathRecommendation() { }
        /// <summary>
        /// Gets or sets the Action value preserved from the previous public API surface.
        /// </summary>
        public RecommendationAction? Action { get; set; }
        /// <summary>
        /// Gets or sets the ConfigurationStatus value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterConfigurationStatus? ConfigurationStatus { get; set; }
        /// <summary>
        /// Gets or sets the FileType value preserved from the previous public API surface.
        /// </summary>
        public PathRecommendationFileType? FileType { get; set; }
        /// <summary>
        /// Gets or sets the IotSecurityRecommendationType value preserved from the previous public API surface.
        /// </summary>
        public IotSecurityRecommendationType? IotSecurityRecommendationType { get; set; }
        /// <summary>
        /// Gets or sets the IsCommon value preserved from the previous public API surface.
        /// </summary>
        public bool? IsCommon { get; set; }
        /// <summary>
        /// Gets or sets the Path value preserved from the previous public API surface.
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Gets or sets the PublisherInfo value preserved from the previous public API surface.
        /// </summary>
        public SecurityCenterPublisherInfo PublisherInfo { get; set; }
        /// <summary>
        /// Gets the Usernames value preserved from the previous public API surface.
        /// </summary>
        public IList<UserRecommendation> Usernames { get; } = new List<UserRecommendation>();
        /// <summary>
        /// Gets the UserSids value preserved from the previous public API surface.
        /// </summary>
        public IList<string> UserSids { get; } = new List<string>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        PathRecommendation IJsonModel<PathRecommendation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<PathRecommendation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        PathRecommendation IPersistableModel<PathRecommendation>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<PathRecommendation>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<PathRecommendation>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
