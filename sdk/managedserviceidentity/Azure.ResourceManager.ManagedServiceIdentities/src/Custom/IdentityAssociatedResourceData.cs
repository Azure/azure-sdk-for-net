// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stub: listAssociatedResources is a preview-only operation absent from the
// stable 2024-11-30 TypeSpec spec. This type is retained so existing code that references
// IdentityAssociatedResourceData continues to compile.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.ResourceManager.ManagedServiceIdentities.Models
{
    [System.Obsolete("listAssociatedResources is a preview-only operation and is no longer supported.")]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class IdentityAssociatedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal IdentityAssociatedResourceData() { }

        [System.Obsolete("listAssociatedResources is a preview-only operation and is no longer supported.")]
        public string ResourceGroup { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }

        [System.Obsolete("listAssociatedResources is a preview-only operation and is no longer supported.")]
        public string SubscriptionDisplayName { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }

        [System.Obsolete("listAssociatedResources is a preview-only operation and is no longer supported.")]
        public string SubscriptionId { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
