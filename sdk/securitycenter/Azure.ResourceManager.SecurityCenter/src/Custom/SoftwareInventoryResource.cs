// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the SoftwareInventoryResource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SoftwareInventoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Gets the ResourceType value preserved from the previous public API surface.
        /// </summary>
        public static readonly Azure.Core.ResourceType ResourceType = "Microsoft.Security/softwareInventories";
        /// <summary>
        /// Initializes a new instance of the <see cref="SoftwareInventoryResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SoftwareInventoryResource() { }
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        public virtual Azure.ResourceManager.SecurityCenter.SoftwareInventoryData Data { get; }
        /// <summary>
        /// Gets the HasData value preserved from the previous public API surface.
        /// </summary>
        public virtual bool HasData { get; }
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="resourceGroupName">The value preserved for API compatibility.</param>
        /// <param name="resourceNamespace">The value preserved for API compatibility.</param>
        /// <param name="resourceType">The value preserved for API compatibility.</param>
        /// <param name="resourceName">The value preserved for API compatibility.</param>
        /// <param name="softwareName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string softwareName) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.SoftwareInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. No direct replacement is available."); }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.SoftwareInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.SoftwareInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
