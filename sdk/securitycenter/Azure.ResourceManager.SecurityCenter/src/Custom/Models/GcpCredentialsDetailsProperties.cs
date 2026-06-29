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
    /// Provides a compatibility shim for the GcpCredentialsDetailsProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class GcpCredentialsDetailsProperties : AuthenticationDetailsProperties, IJsonModel<GcpCredentialsDetailsProperties>, IPersistableModel<GcpCredentialsDetailsProperties>
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
        public System.Uri AuthProviderX509CertUri { get; set; }
        /// <summary>
        /// Gets or sets the AuthUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri AuthUri { get; set; }
        /// <summary>
        /// Gets or sets the ClientEmail value preserved from the previous public API surface.
        /// </summary>
        public string ClientEmail { get; set; }
        /// <summary>
        /// Gets or sets the ClientId value preserved from the previous public API surface.
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the ClientX509CertUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri ClientX509CertUri { get; set; }
        /// <summary>
        /// Gets or sets the GcpCredentialType value preserved from the previous public API surface.
        /// </summary>
        public string GcpCredentialType { get; set; }
        /// <summary>
        /// Gets or sets the OrganizationId value preserved from the previous public API surface.
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the PrivateKey value preserved from the previous public API surface.
        /// </summary>
        public string PrivateKey { get; set; }
        /// <summary>
        /// Gets or sets the PrivateKeyId value preserved from the previous public API surface.
        /// </summary>
        public string PrivateKeyId { get; set; }
        /// <summary>
        /// Gets or sets the ProjectId value preserved from the previous public API surface.
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the TokenUri value preserved from the previous public API surface.
        /// </summary>
        public System.Uri TokenUri { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        GcpCredentialsDetailsProperties IJsonModel<GcpCredentialsDetailsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<GcpCredentialsDetailsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        GcpCredentialsDetailsProperties IPersistableModel<GcpCredentialsDetailsProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<GcpCredentialsDetailsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<GcpCredentialsDetailsProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
