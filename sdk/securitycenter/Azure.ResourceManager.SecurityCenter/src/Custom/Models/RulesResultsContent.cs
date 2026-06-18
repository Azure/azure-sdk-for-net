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
    /// Provides a compatibility shim for the RulesResultsContent class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RulesResultsContent : IJsonModel<RulesResultsContent>, IPersistableModel<RulesResultsContent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RulesResultsContent"/> type for compatibility with the previous public API surface.
        /// </summary>
        public RulesResultsContent() { }
        /// <summary>
        /// Gets or sets the LatestScan value preserved from the previous public API surface.
        /// </summary>
        public bool? LatestScan { get; set; }
        /// <summary>
        /// Gets the Results value preserved from the previous public API surface.
        /// </summary>
        public IDictionary<string, IList<IList<string>>> Results { get; } = new Dictionary<string, IList<IList<string>>>();
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        RulesResultsContent IJsonModel<RulesResultsContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<RulesResultsContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        RulesResultsContent IPersistableModel<RulesResultsContent>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<RulesResultsContent>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<RulesResultsContent>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
