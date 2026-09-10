// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits models and members described by the current TypeSpec shape; this previous GA signature was removed, renamed, or folded into a different model, so there is no generated backing member or serialization path to implement it. Keep a hidden ApiCompat shim and fail unsupported wire operations explicitly.
    /// <summary>
    /// Provides a compatibility shim for the UserRecommendation class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UserRecommendation : IJsonModel<UserRecommendation>, IPersistableModel<UserRecommendation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRecommendation"/> type for compatibility with the previous public API surface.
        /// </summary>
        public UserRecommendation() { }
        /// <summary>
        /// Gets or sets the RecommendationAction value preserved from the previous public API surface.
        /// </summary>
        public RecommendationAction? RecommendationAction { get; set; }
        /// <summary>
        /// Gets or sets the Username value preserved from the previous public API surface.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        UserRecommendation IJsonModel<UserRecommendation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<UserRecommendation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        UserRecommendation IPersistableModel<UserRecommendation>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<UserRecommendation>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<UserRecommendation>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
