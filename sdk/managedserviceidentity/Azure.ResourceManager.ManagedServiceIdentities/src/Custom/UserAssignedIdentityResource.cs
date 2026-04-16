// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stubs: GetAssociatedResources/GetAssociatedResourcesAsync existed in
// pre-migration baseline but rely on a preview-only listAssociatedResources operation that
// is absent from the stable 2024-11-30 spec. Methods are preserved for ApiCompat but will
// throw NotSupportedException at runtime.

using System;
using System.ComponentModel;
using System.Threading;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public partial class UserAssignedIdentityResource
    {
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResources(
            string filter = null,
            string orderby = null,
            int? top = default,
            int? skip = default,
            string skiptoken = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API.");
        }

        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedServiceIdentities.Models.IdentityAssociatedResourceData> GetAssociatedResourcesAsync(
            string filter = null,
            string orderby = null,
            int? top = default,
            int? skip = default,
            string skiptoken = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API.");
        }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
