// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// The identifier for a resource that is contained in a location. 
    /// </summary>
    public sealed class LocationResourceIdentifier : SubscriptionResourceIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationResourceIdentifier"/> class.
        /// </summary>
        /// <param name="parent"> The identifier of the subscription that is the parent of this resource. </param>
        /// <param name="location"> The name of the location. </param>
        internal LocationResourceIdentifier(SubscriptionResourceIdentifier parent, LocationData location)
            : base(parent, ResourceIdentifier.LocationsKey, location.Name)
        {
            Location = location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> A string representation of a location resource identifier. </param>
        public LocationResourceIdentifier(string resourceId)
        {
            var id = ResourceIdentifier.Create(resourceId) as LocationResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid location level resource", nameof(resourceId));
            Name = id.Name;
            ResourceType = id.ResourceType;
            Parent = id.Parent;
            IsChild = id.IsChild;
            Location = id.Location;
            SubscriptionId = id.SubscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationResourceIdentifier"/> class. 
        /// Used to initialize resources in the same namespace as the parent resource.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="resourceType"></param>
        /// <param name="resourceName"></param>
        internal LocationResourceIdentifier(LocationResourceIdentifier parent, string resourceType, string resourceName)
            : base(parent, resourceType, resourceName)
        {
            Location = parent.Location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationResourceIdentifier"/> class.
        /// Used to initialize resource in a different namespace than the parent resource.
        /// </summary>
        /// <param name="target"> The identifier of the parent resource.</param>
        /// <param name="providerNamespace"> The namespace of the resource, for example 'Microsoft.Compute'. </param>
        /// <param name="resourceType"> The simple type name of the resource, for example 'virtualMachines'. </param>
        /// <param name="resourceName"> The name of this resource. </param>
        internal LocationResourceIdentifier(LocationResourceIdentifier target, string providerNamespace, string resourceType, string resourceName)
            : base(target, providerNamespace, resourceType, resourceName)
        {
            Location = target.Location;
        }

        /// <summary>
        /// The location of the resource.
        /// </summary>
        public LocationData Location { get; }

        /// <inheritdoc/>
        public override bool TryGetLocation(out LocationData location)
        {
            location = Location;
            return true;
        }

        /// <inheritdoc/>
        public override bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = SubscriptionId;
            return true;
        }

        /// <summary>
        /// Convert resourceId string to LocationResourceIdentifier.
        /// </summary>
        /// <param name="other">A string representation of a resource id.</param>
        public static implicit operator LocationResourceIdentifier(string other)
        {
            if (other is null)
                return null;
            LocationResourceIdentifier id = ResourceIdentifier.Create(other) as LocationResourceIdentifier;
            if (id is null)
                throw new ArgumentException("Not a valid location level resource", nameof(other));
            return id;
        }
    }
}
