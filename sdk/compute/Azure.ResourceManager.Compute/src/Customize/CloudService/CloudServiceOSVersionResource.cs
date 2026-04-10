// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceOSVersionResource : ArmResource, IJsonModel<CloudServiceOSVersionData>, IPersistableModel<CloudServiceOSVersionData>
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> The resource type for CloudServiceOSVersion. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/cloudServiceOsVersions";

        /// <summary> Generate the resource identifier of a CloudServiceOSVersionResource instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string osVersionName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Initializes a new instance of CloudServiceOSVersionResource for mocking. </summary>
        protected CloudServiceOSVersionResource()
        {
        }

        internal CloudServiceOSVersionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets the data representing this CloudServiceOSVersion. </summary>
        public virtual CloudServiceOSVersionData Data => throw new NotSupportedException(_notSupported);

        /// <summary> Gets whether this resource has data. </summary>
        public virtual bool HasData => false;

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceOSVersionResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceOSVersionResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        CloudServiceOSVersionData IJsonModel<CloudServiceOSVersionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<CloudServiceOSVersionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        CloudServiceOSVersionData IPersistableModel<CloudServiceOSVersionData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<CloudServiceOSVersionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<CloudServiceOSVersionData>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
