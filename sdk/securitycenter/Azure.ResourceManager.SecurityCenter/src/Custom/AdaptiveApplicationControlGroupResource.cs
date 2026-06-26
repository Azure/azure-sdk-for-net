// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated code only emits operations whose resource scope and request path still exist in TypeSpec; this previous GA method used an old operation path, scope, or overload that no longer maps to a generated request. Keep a hidden ApiCompat shim and fail the unsupported operation explicitly.
    /// <summary>
    /// Provides a compatibility shim for the AdaptiveApplicationControlGroupResource class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AdaptiveApplicationControlGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>
    {
        private const string UnsupportedMessage = "This API is no longer supported by the service. No direct replacement is available.";

        /// <summary>
        /// Gets the ResourceType value preserved from the previous public API surface.
        /// </summary>
        public static readonly Azure.Core.ResourceType ResourceType = "Microsoft.Security/locations/applicationWhitelistings";
        /// <summary>
        /// Initializes a new instance of the <see cref="AdaptiveApplicationControlGroupResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected AdaptiveApplicationControlGroupResource() { throw new System.NotSupportedException(UnsupportedMessage); }
        /// <summary>
        /// Gets the Data value preserved from the previous public API surface.
        /// </summary>
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData Data { get; }
        /// <summary>
        /// Gets the HasData value preserved from the previous public API surface.
        /// </summary>
        public virtual bool HasData { get; }
        /// <summary>
        /// Provides a compatibility shim for the CreateResourceIdentifier operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="subscriptionId">The value preserved for API compatibility.</param>
        /// <param name="ascLocation">The value preserved for API compatibility.</param>
        /// <param name="groupName">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation ascLocation, string groupName) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Delete operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the DeleteAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the Get operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the GetAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException(UnsupportedMessage); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException(UnsupportedMessage); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException(UnsupportedMessage); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException(UnsupportedMessage); }
        /// <summary>
        /// Provides a compatibility shim for the Update operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
        /// <summary>
        /// Provides a compatibility shim for the UpdateAsync operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="waitUntil">The value preserved for API compatibility.</param>
        /// <param name="data">The value preserved for API compatibility.</param>
        /// <param name="cancellationToken">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.AdaptiveApplicationControlGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveApplicationControlGroupResource(ResourceIdentifier id) instead."); }
    }
}
