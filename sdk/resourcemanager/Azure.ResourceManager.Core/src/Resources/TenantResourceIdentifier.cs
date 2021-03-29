// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of any resource
    /// </summary>
    public class TenantResourceIdentifier : ResourceIdentifier
    {
        internal TenantResourceIdentifier()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantResourceIdentifier"/> class 
        /// </summary>
        /// <param name="resourceType"> The resource type (including namespace and type). </param>
        /// <param name="name"> The name of the resource. </param>
        internal TenantResourceIdentifier(ResourceType resourceType, string name) : base(resourceType, name)
        {
            Parent = ResourceIdentifier.RootResourceIdentifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantResourceIdentifier"/> class 
        /// for resources in the same namespace as their parent.
        /// </summary>
        /// <param name="parent"> The parent resource id. </param>
        /// <param name="typeName"> The simple type name of the resource without slashes (/), for example 'virtualMachines'.</param>
        /// <param name="resourceName"> The name of the resource. </param>
        internal TenantResourceIdentifier(TenantResourceIdentifier parent, string typeName, string resourceName)
            : base(new ResourceType(parent.ResourceType, typeName), resourceName)
        {
            Parent = parent;
            IsChild = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantResourceIdentifier"/> class 
        /// for resources in a different namespace than their parent.
        /// </summary>
        /// <param name="parent"> The parent resource id. </param>
        /// <param name="providerNamespace"> The namespace of the resource type, for example, 'Microsoft.Compute'. </param>
        /// <param name="typeName"> The simple type name of the resource, without slashes (/).  For example, 'virtualMachines'. </param>
        /// <param name="resourceName"> The name of the resource. </param>
        internal TenantResourceIdentifier(TenantResourceIdentifier parent, string providerNamespace, string typeName, string resourceName)
            : base(new ResourceType(providerNamespace, typeName), resourceName)
        {
            Parent = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The string representation of a resource identifier. </param>
        public TenantResourceIdentifier(string resourceId)
        {
            var rawId = ResourceIdentifier.Create(resourceId);
            TenantResourceIdentifier id = rawId as TenantResourceIdentifier;
            if (id is null || rawId.TryGetSubscriptionId(out _))
                throw new ArgumentException("Not a valid tenant level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
        }

        /// <summary>
        /// Convert a string resource identifier into a TenantResourceIdentifier.
        /// </summary>
        /// <param name="other"> The string representation of a subscription resource identifier. </param>
        public static implicit operator TenantResourceIdentifier(string other)
        {
            if (other is null)
                return null;
            TenantResourceIdentifier id = ResourceIdentifier.Create(other) as TenantResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid tenant level resource", nameof(other));
            return id;
        }
    }
}
