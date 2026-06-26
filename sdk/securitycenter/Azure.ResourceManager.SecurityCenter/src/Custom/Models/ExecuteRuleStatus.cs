// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // GA exposed GetRuleExecutionStatus as ArmOperation<ExecuteRuleStatus> where ExecuteRuleStatus only carried OperationId. Current TypeSpec splits the governance rule flow into Execute, which returns a non-generic ArmOperation, and OperationResults, which returns SecurityCenterOperationResult with Status. This is unrelated to the SQL vulnerability assessment scan operation result models. Keep the old type as a hidden ApiCompat shim and fail unsupported wire operations explicitly because there is no generated model with matching semantics.
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
