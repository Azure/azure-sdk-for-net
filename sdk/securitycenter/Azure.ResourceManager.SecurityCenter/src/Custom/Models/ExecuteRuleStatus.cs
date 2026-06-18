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
    /// Provides a compatibility shim for the ExecuteRuleStatus class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExecuteRuleStatus : IJsonModel<ExecuteRuleStatus>, IPersistableModel<ExecuteRuleStatus>
    {
        internal ExecuteRuleStatus() { }
        /// <summary>
        /// Gets the OperationId value preserved from the previous public API surface.
        /// </summary>
        public string OperationId { get; }
        ExecuteRuleStatus IJsonModel<ExecuteRuleStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<ExecuteRuleStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        ExecuteRuleStatus IPersistableModel<ExecuteRuleStatus>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<ExecuteRuleStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<ExecuteRuleStatus>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
