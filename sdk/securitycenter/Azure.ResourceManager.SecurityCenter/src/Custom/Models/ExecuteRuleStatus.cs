// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The latest TypeSpec removed or reshaped this legacy model/member, so the generator cannot recreate the previous GA signature; keep a hidden shim for ApiCompat and throw because the wire shape is no longer supported.
    /// <summary>
    /// Provides a compatibility shim for the ExecuteRuleStatus class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ExecuteRuleStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>
    {
        internal ExecuteRuleStatus() { }
        /// <summary>
        /// Gets the OperationId value preserved from the previous public API surface.
        /// </summary>
        public string OperationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.ExecuteRuleStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
