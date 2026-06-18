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
