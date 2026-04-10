// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceOSFamilyResource : ArmResource
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> The resource type for CloudServiceOSFamily. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/locations/cloudServiceOsFamilies";

        /// <summary> Generate the resource identifier of a CloudServiceOSFamilyResource instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, AzureLocation location, string osFamilyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsFamilies/{osFamilyName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Initializes a new instance of CloudServiceOSFamilyResource for mocking. </summary>
        protected CloudServiceOSFamilyResource()
        {
        }

        internal CloudServiceOSFamilyResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets the data representing this CloudServiceOSFamily. </summary>
        public virtual CloudServiceOSFamilyData Data => throw new NotSupportedException(_notSupported);

        /// <summary> Gets whether this resource has data. </summary>
        public virtual bool HasData => false;

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceOSFamilyResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceOSFamilyResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);
    }
}
