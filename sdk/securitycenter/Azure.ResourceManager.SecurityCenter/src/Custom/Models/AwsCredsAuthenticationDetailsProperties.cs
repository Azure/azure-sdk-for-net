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
    /// Provides a compatibility shim for the AwsCredsAuthenticationDetailsProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class AwsCredsAuthenticationDetailsProperties : AuthenticationDetailsProperties, IJsonModel<AwsCredsAuthenticationDetailsProperties>, IPersistableModel<AwsCredsAuthenticationDetailsProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsCredsAuthenticationDetailsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="awsAccessKeyId">The value preserved for API compatibility.</param>
        /// <param name="awsSecretAccessKey">The value preserved for API compatibility.</param>
        public AwsCredsAuthenticationDetailsProperties(string awsAccessKeyId, string awsSecretAccessKey) { }
        /// <summary>
        /// Gets the AccountId value preserved from the previous public API surface.
        /// </summary>
        public string AccountId { get; }
        /// <summary>
        /// Gets or sets the AwsAccessKeyId value preserved from the previous public API surface.
        /// </summary>
        public string AwsAccessKeyId { get; set; }
        /// <summary>
        /// Gets or sets the AwsSecretAccessKey value preserved from the previous public API surface.
        /// </summary>
        public string AwsSecretAccessKey { get; set; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AwsCredsAuthenticationDetailsProperties IJsonModel<AwsCredsAuthenticationDetailsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AwsCredsAuthenticationDetailsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AwsCredsAuthenticationDetailsProperties IPersistableModel<AwsCredsAuthenticationDetailsProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AwsCredsAuthenticationDetailsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AwsCredsAuthenticationDetailsProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
