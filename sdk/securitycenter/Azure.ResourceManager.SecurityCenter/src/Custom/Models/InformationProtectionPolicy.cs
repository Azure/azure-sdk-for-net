// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class InformationProtectionPolicy : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>
    {
        public InformationProtectionPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SecurityInformationTypeInfo> InformationTypes { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.SecurityCenter.Models.SensitivityLabel> Labels { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string Version { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.InformationProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
