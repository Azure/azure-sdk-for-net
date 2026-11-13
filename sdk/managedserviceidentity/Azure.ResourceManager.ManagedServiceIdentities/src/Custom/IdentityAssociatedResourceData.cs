// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat stub: listAssociatedResources is a preview-only operation absent from the
// stable 2024-11-30 TypeSpec spec. This type is retained so existing code that references
// IdentityAssociatedResourceData continues to compile.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Azure.ResourceManager.ManagedServiceIdentities.Models
{
    [System.Obsolete("This model was the return type of the preview-only listAssociatedResources operation, which is no longer supported.")]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class IdentityAssociatedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal IdentityAssociatedResourceData() { }

        public string ResourceGroup { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }

        public string SubscriptionDisplayName { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }

        public string SubscriptionId { get { throw new System.NotSupportedException("listAssociatedResources is a preview-only operation and is no longer supported in the stable API."); } }
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
