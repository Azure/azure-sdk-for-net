// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier of a resource that is contained in a subscription.
    /// </summary>
    public class SubscriptionResourceIdentifier : TenantResourceIdentifier
    {
        /// <summary>
        /// Internal use only.
        /// </summary>
        internal SubscriptionResourceIdentifier()
        {
        }

        /// <summary>
        /// Internal use only.
        /// </summary>
        /// <param name="id"> The subscription GUID. </param>
        internal SubscriptionResourceIdentifier(Guid id)
        {
            Name = id.ToString();
            ResourceType = ResourceIdentifier.SubscriptionType;
            Parent = ResourceIdentifier.RootResourceIdentifier;
            IsChild = false;
            SubscriptionId = Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResourceIdentifier"/> class 
        /// for resources in the sanem namespace as their parent resource.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="childResourceType"> The simple type of this resource, for example 'subnets'. </param>
        /// <param name="childResourceName"> The name of this resource. </param>
        /// <returns> The resource identifier for the given child resource. </returns>
        internal SubscriptionResourceIdentifier(SubscriptionResourceIdentifier parent, string childResourceType, string childResourceName)
            : base(parent, childResourceType, childResourceName)
        {
            SubscriptionId = parent.SubscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResourceIdentifier"/> class 
        /// for resources in a different namespace than their parent resource.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="providerNamespace"> The namespace of this resource, for example 'Microsoft.Compute'. </param>
        /// <param name="resourceType"> The simple tyoe of this resource, with no slashes.  For example, 'virtualMachines'. </param>
        /// <param name="resourceName"> Thge name of this resource. </param>
        /// <returns> The resource identifier for the given resource. </returns>
        internal SubscriptionResourceIdentifier(SubscriptionResourceIdentifier parent, string providerNamespace, string resourceType, string resourceName)
            : base(parent, providerNamespace, resourceType, resourceName)
        {
            SubscriptionId = parent.SubscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceIdOrSubscriptionId"> The string representation of the subscription id.  This can be in the form of a GUID, 
        /// or a full resource id like '/subscriptions/xxxxx-yyyy-zzzz-wwwwww'. </param>
        public SubscriptionResourceIdentifier(string resourceIdOrSubscriptionId)
        {
            Guid subscriptionGuid;
            if (Guid.TryParse(resourceIdOrSubscriptionId, out subscriptionGuid))
            {
                Name = resourceIdOrSubscriptionId;
                ResourceType = ResourceIdentifier.SubscriptionType;
                Parent = ResourceIdentifier.RootResourceIdentifier;
                IsChild = false;
                SubscriptionId = resourceIdOrSubscriptionId;
            }
            else
            {
                ResourceIdentifier rawId = ResourceIdentifier.Create(resourceIdOrSubscriptionId);
                SubscriptionResourceIdentifier id =  rawId as SubscriptionResourceIdentifier;
                if (id is null || rawId.TryGetLocation(out _) || rawId.TryGetResourceGroupName(out _))
                    throw new ArgumentException("Not a valid subscription level resource", nameof(resourceIdOrSubscriptionId));
                Name = id.Name;
                ResourceType = id.ResourceType;
                Parent = id.Parent;
                IsChild = id.IsChild;
                SubscriptionId = id.SubscriptionId;
            }
        }

        /// <summary>
        /// The subscription id (Guid) for this resource.
        /// </summary>
        public string SubscriptionId { get; internal set; }

        /// <inheritdoc/>
        public override bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = SubscriptionId;
            return true;
        }

        /// <summary>
        /// Convert a string resource id into a subscription resource identifier.
        /// </summary>
        /// <param name="other"> The string representation of a resource identifier. </param>
        public static implicit operator SubscriptionResourceIdentifier(string other)
        {
            if (other is null)
                return null;
            SubscriptionResourceIdentifier id = ResourceIdentifier.Create(other) as SubscriptionResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid subscription level resource", nameof(other));
            return id;
        }

        internal override string ToResourceString()
        {
            if (Parent is RootResourceIdentifier)
                return $"/subscriptions/{SubscriptionId}";
            return base.ToResourceString();
        }
    }
}
