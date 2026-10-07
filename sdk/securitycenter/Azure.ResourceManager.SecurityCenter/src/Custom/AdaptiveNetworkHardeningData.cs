// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated resource data now follows the current TypeSpec model, constructor, and property graph; this previous GA data shape is no longer described, so the generator cannot emit its old public setters and constructor. Keep a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveNetworkHardeningData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningData : ResourceData, IJsonModel<AdaptiveNetworkHardeningData>, IPersistableModel<AdaptiveNetworkHardeningData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveNetworkHardeningData"/> type for compatibility with the previous public API surface.
        /// </summary>
        public AdaptiveNetworkHardeningData()
        {
            EffectiveNetworkSecurityGroups = new List<EffectiveNetworkSecurityGroups>();
            Rules = new List<RecommendedSecurityRule>();
        }
        /// <summary>
        /// Gets the EffectiveNetworkSecurityGroups value preserved from the previous public API surface.
        /// </summary>
        public IList<EffectiveNetworkSecurityGroups> EffectiveNetworkSecurityGroups { get; }
        /// <summary>
        /// Gets the Rules value preserved from the previous public API surface.
        /// </summary>
        public IList<RecommendedSecurityRule> Rules { get; }
        /// <summary>
        /// Gets or sets the RulesCalculatedOn value preserved from the previous public API surface.
        /// </summary>
        public DateTimeOffset? RulesCalculatedOn
        {
            get;
            set;
        }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningData IJsonModel<AdaptiveNetworkHardeningData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AdaptiveNetworkHardeningData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AdaptiveNetworkHardeningData IPersistableModel<AdaptiveNetworkHardeningData>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AdaptiveNetworkHardeningData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AdaptiveNetworkHardeningData>.Write(ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
