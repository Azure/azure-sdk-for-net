// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier for a resource contained in a resource group.
    /// </summary>
    public sealed class ResourceGroupResourceIdentifier : SubscriptionResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupResourceIdentifier"/> class for a resource group.
        /// </summary>
        /// <param name="parent">The <see cref="ResourceGroupResourceIdentifier"/> of the parent of this child resource.</param>
        /// <param name="resourceGroupName">The name of the resourceGroup.</param>
        internal ResourceGroupResourceIdentifier(SubscriptionResourceIdentifier parent, string resourceGroupName)
            : base(parent, ResourceIdentifier.ResourceGroupsKey, resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentOutOfRangeException(nameof(resourceGroupName), "Invalid resource group name.");
            ResourceGroupName = resourceGroupName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupResourceIdentifier"/> class 
        /// for a resource in a different namespace than its parent.
        /// </summary>
        /// <param name="target">he <see cref="ResourceGroupResourceIdentifier"/> of the target of this extension resource.</param>
        /// <param name="providerNamespace">The provider namespace of the extension.</param>
        /// <param name="resourceType">The full ARM resource type of the extension.</param>
        /// <param name="resourceName">The name of the extension resource.</param>
        internal ResourceGroupResourceIdentifier(ResourceGroupResourceIdentifier target, string providerNamespace, string resourceType, string resourceName)
            : base(target, providerNamespace, resourceType, resourceName)
        {
            ResourceGroupName = target.ResourceGroupName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupResourceIdentifier"/> class 
        /// for a resource in the same namespace as its parent.
        /// </summary>
        /// <param name="target">he <see cref="ResourceGroupResourceIdentifier"/> of the target of this extension resource.</param>
        /// <param name="childResourceType">The full ARM resource type of the extension.</param>
        /// <param name="childResourceName">The name of the extension resource.</param>
        internal ResourceGroupResourceIdentifier(ResourceGroupResourceIdentifier target, string childResourceType, string childResourceName)
            : base(target, childResourceType, childResourceName)
        {
            ResourceGroupName = target.ResourceGroupName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupResourceIdentifier"/> class 
        /// </summary>
        /// <param name="resourceId"> The string representation of a resource id. </param>
        public ResourceGroupResourceIdentifier(string resourceId)
        {
            var id = ResourceIdentifier.Create(resourceId) as ResourceGroupResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            ResourceGroupName = id.ResourceGroupName;
            SubscriptionId = id.SubscriptionId;
        }

        /// <summary>
        /// The name of the resource group for this resource.
        /// </summary>
        public string ResourceGroupName { get; }

        /// <inheritdoc/>
        public override bool TryGetResourceGroupName(out string resourceGroupName)
        {
            resourceGroupName = ResourceGroupName;
            return true;
        }

        /// <summary>
        /// Convert a string into a resource group resource identifier.
        /// </summary>
        /// <param name="other">The string representation of a resource Id.</param>
        public static implicit operator ResourceGroupResourceIdentifier(string other)
        {
            if (other is null)
                return null;
            ResourceGroupResourceIdentifier id = ResourceIdentifier.Create(other) as ResourceGroupResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid resource group level resource", nameof(other));
            return id;
        }
    }
}
