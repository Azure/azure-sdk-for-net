// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the GcpCredentialsDetailsProperties class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class GcpCredentialsDetailsProperties : Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GcpCredentialsDetailsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="organizationId">The value preserved for API compatibility.</param>
        /// <param name="gcpCredentialType">The value preserved for API compatibility.</param>
        /// <param name="projectId">The value preserved for API compatibility.</param>
        /// <param name="privateKeyId">The value preserved for API compatibility.</param>
        /// <param name="privateKey">The value preserved for API compatibility.</param>
        /// <param name="clientEmail">The value preserved for API compatibility.</param>
        /// <param name="clientId">The value preserved for API compatibility.</param>
        /// <param name="authUri">The value preserved for API compatibility.</param>
        /// <param name="tokenUri">The value preserved for API compatibility.</param>
        /// <param name="authProviderX509CertUri">The value preserved for API compatibility.</param>
        /// <param name="clientX509CertUri">The value preserved for API compatibility.</param>
        public GcpCredentialsDetailsProperties(string organizationId, string gcpCredentialType, string projectId, string privateKeyId, string privateKey, string clientEmail, string clientId, System.Uri authUri, System.Uri tokenUri, System.Uri authProviderX509CertUri, System.Uri clientX509CertUri) { }
        /// <summary>
        /// Gets or sets the AuthProviderX509CertUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri AuthProviderX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the AuthUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri AuthUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ClientEmail value preserved from the previous public API surface.
        /// </summary>
        public string ClientEmail { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ClientId value preserved from the previous public API surface.
        /// </summary>
        public string ClientId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ClientX509CertUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri ClientX509CertUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the GcpCredentialType value preserved from the previous public API surface.
        /// </summary>
        public string GcpCredentialType { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the OrganizationId value preserved from the previous public API surface.
        /// </summary>
        public string OrganizationId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the PrivateKey value preserved from the previous public API surface.
        /// </summary>
        public string PrivateKey { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the PrivateKeyId value preserved from the previous public API surface.
        /// </summary>
        public string PrivateKeyId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the ProjectId value preserved from the previous public API surface.
        /// </summary>
        public string ProjectId { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Gets or sets the TokenUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri TokenUri { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.GcpCredentialsDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
