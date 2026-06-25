// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SecurityCloudConnectorResource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [System.Obsolete("This API is no longer supported by the service. No direct replacement is available.")]
    public partial class SecurityCloudConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Gets the ResourceType value preserved from the previous public API surface.
        /// </summary>
        public static readonly Azure.Core.ResourceType ResourceType = "Microsoft.Security/securityConnectors";
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityCloudConnectorResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SecurityCloudConnectorResource() { throw new System.NotSupportedException(UnsupportedMessage); }
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        public virtual Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData Data { get; }
        /// <summary>
        /// Gets the HasData value preserved from the previous public API surface.
        /// </summary>
        public virtual bool HasData { get; }
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="connectorName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Delete operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the DeleteAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        /// <summary>
        /// Provides a compatibility shim for the Update operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the UpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        [System.Obsolete("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.SecurityCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetSecurityCloudConnectorResource(ResourceIdentifier id) instead."); }
    }
}
