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
    /// Provides a compatibility shim for the AdaptiveNetworkHardeningEnforceContent class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningEnforceContent : IJsonModel<AdaptiveNetworkHardeningEnforceContent>, IPersistableModel<AdaptiveNetworkHardeningEnforceContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveNetworkHardeningEnforceContent"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="rules">The value preserved for API compatibility.</param>
        /// <param name="networkSecurityGroups">The value preserved for API compatibility.</param>
        public AdaptiveNetworkHardeningEnforceContent(IEnumerable<RecommendedSecurityRule> rules, IEnumerable<string> networkSecurityGroups) { }
        /// <summary>
        /// Gets the NetworkSecurityGroups value preserved from the previous public API surface.
        /// </summary>
        public IList<string> NetworkSecurityGroups { get; } = new List<string>();
        /// <summary>
        /// Gets the Rules value preserved from the previous public API surface.
        /// </summary>
        public IList<RecommendedSecurityRule> Rules { get; } = new List<RecommendedSecurityRule>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningEnforceContent IJsonModel<AdaptiveNetworkHardeningEnforceContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AdaptiveNetworkHardeningEnforceContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningEnforceContent IPersistableModel<AdaptiveNetworkHardeningEnforceContent>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AdaptiveNetworkHardeningEnforceContent>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AdaptiveNetworkHardeningEnforceContent>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
