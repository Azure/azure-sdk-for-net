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
    public partial class CloudServiceRoleResource : ArmResource
    {
        private const string _notSupported = "CloudService operations are no longer supported in this version.";

        /// <summary> The resource type for CloudServiceRole. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/cloudServices/roles";

        /// <summary> Generate the resource identifier of a CloudServiceRoleResource instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName, string roleName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roles/{roleName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Initializes a new instance of CloudServiceRoleResource for mocking. </summary>
        protected CloudServiceRoleResource()
        {
        }

        internal CloudServiceRoleResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets the data representing this CloudServiceRole. </summary>
        public virtual CloudServiceRoleData Data => throw new NotSupportedException(_notSupported);

        /// <summary> Gets whether this resource has data. </summary>
        public virtual bool HasData => false;

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<CloudServiceRoleResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);

        /// <summary> Not supported. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<CloudServiceRoleResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(_notSupported);
    }
}
