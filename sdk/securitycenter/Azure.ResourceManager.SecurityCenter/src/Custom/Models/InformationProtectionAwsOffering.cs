// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the InformationProtectionAwsOffering class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class InformationProtectionAwsOffering : Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudOffering, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationProtectionAwsOffering"/> type for compatibility with the previous public API surface.
        /// </summary>
        public InformationProtectionAwsOffering() { }
        /// <summary>
        /// Gets or sets the InformationProtectionCloudRoleArn value preserved from the previous public API surface.
        /// </summary>
        public string InformationProtectionCloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionAwsOffering>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
