// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AdaptiveNetworkHardeningResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdaptiveNetworkHardeningResource() { }
        public virtual Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData Data { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.ResourceManager.ArmOperation Enforce(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnforceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityCenter.Models.AdaptiveNetworkHardeningEnforceContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.AdaptiveNetworkHardeningData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
