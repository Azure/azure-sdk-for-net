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
    public partial class GcpCredentialsDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>
    {
        public GcpCredentialsDetailsProperties(string organizationId, string gcpCredentialType, string projectId, string privateKeyId, string privateKey, string clientEmail, string clientId, System.Uri authUri, System.Uri tokenUri, System.Uri authProviderX509CertUri, System.Uri clientX509CertUri) { }
        public System.Uri AuthProviderX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri AuthUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ClientEmail { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ClientId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri ClientX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string GcpCredentialType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string OrganizationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PrivateKey { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string PrivateKeyId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public string ProjectId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Uri TokenUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
