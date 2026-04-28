// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class UserAssignedIdentityResource : Azure.ResourceManager.ArmResource
    {
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResources(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResourcesAsync(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
