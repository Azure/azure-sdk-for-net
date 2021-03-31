// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// An Azure Resource Manager resource identifier.
    /// </summary>
    public abstract class ResourceIdentifier : IEquatable<ResourceIdentifier>, IComparable<ResourceIdentifier>
    {
        internal const string ProvidersKey = "providers", SubscriptionsKey = "subscriptions",
            ResourceGroupsKey = "resourceGroups", LocationsKey = "locations";

        internal const string ResourceGroupsLowerKey = "resourcegroups"; 

        internal const string BuiltInResourceNamespace = "Microsoft.Resources";

        internal static ResourceType SubscriptionType => new ResourceType(BuiltInResourceNamespace, SubscriptionsKey);
        internal static ResourceType LocationsType =>
            new ResourceType(BuiltInResourceNamespace, $"{SubscriptionsKey}/{LocationsKey}");
        internal static ResourceType ResourceGroupsType =>
            new ResourceType(BuiltInResourceNamespace, $"{SubscriptionsKey}/{ResourceGroupsKey}");

        /// <summary>
        /// The root of the resource hierarchy
        /// </summary>
        public static ResourceIdentifier RootResourceIdentifier => new RootResourceIdentifier();

        /// <summary>
        /// For internal use only.
        /// </summary>
        internal ResourceIdentifier()
        {
            _stringValue = null;
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        /// <param name="resourceType"> The type of the resource.</param>
        /// <param name="name"> The name of the resource.</param>
        internal ResourceIdentifier(ResourceType resourceType, string name)
        {
            ResourceType = resourceType;
            Name = name;
            _stringValue = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The string representation of a resource Id. </param>
        /// <returns> The resource identifier. </returns>
        public static ResourceIdentifier Create(string resourceId)
        {
            if (resourceId is null)
                throw new ArgumentNullException(nameof(resourceId));
            if (!resourceId.StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            var parts = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (parts.Count < 2)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            switch (parts[0].ToLowerInvariant())
            {
                case SubscriptionsKey:
                    {
                        ResourceIdentifier id = CreateBaseSubscriptionIdentifier(parts[1], parts.Trim(2));
                        id.StringValue = resourceId;
                        return id;
                    }
                case ProvidersKey:
                    {
                        if (parts.Count > 3)
                        {
                            ResourceIdentifier id = CreateTenantIdentifier(new TenantResourceIdentifier(new ResourceType(parts[1], parts[2]), parts[3]), parts.Trim(4));
                            id.StringValue = resourceId;
                            return id;
                        }
                        throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");
            }
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are contained in a subscription.
        /// </summary>
        /// <param name="subscriptionId"> The GUID string representing the resource. </param>
        /// <param name="parts"> The path segments in the resource id following the subscription Guid. </param>
        /// <returns> The resource identifier for the given resource path. </returns>
        internal static ResourceIdentifier CreateBaseSubscriptionIdentifier(string subscriptionId, List<string> parts)
        {
            Guid subscriptionGuid;
            if (!Guid.TryParse(subscriptionId, out subscriptionGuid))
                throw new ArgumentOutOfRangeException(nameof(subscriptionId), "Invalid subscription id.");
            var subscription = new SubscriptionResourceIdentifier( subscriptionGuid);
            if (parts.Count == 0)
                return subscription;
            if (parts.Count > 1)
            {
                switch (parts[0].ToLowerInvariant())
                {
                    case LocationsKey:
                        return CreateBaseLocationIdentifier(subscription, parts[1], parts.Trim(2));
                    case ResourceGroupsLowerKey:
                        return CreateBaseResourceGroupIdentifier(subscription, parts[1], parts.Trim(2));
                    case ProvidersKey:
                        {
                            if (parts.Count > 3)
                                return CreateSubscriptionIdentifier(new SubscriptionResourceIdentifier(subscription,
                                    parts[1], parts[2], parts[3]), parts.Skip(4).ToList());
                            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource string");
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
                        }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are contained in a location.
        /// </summary>
        /// <param name="subscription"> The resource id of the subscription for this resource. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <param name="parts"> The path segments in the resource id following the location. </param>
        /// <returns> The resource identifier for the given resource path. </returns>
        internal static ResourceIdentifier CreateBaseLocationIdentifier(SubscriptionResourceIdentifier subscription, LocationData location, List<string> parts)
        {
            var parent = new LocationResourceIdentifier(subscription, location);
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
            switch (parts[0].ToLowerInvariant())
            {
                case ProvidersKey:
                    {
                        if (parts.Count > 3)
                            return CreateLocationIdentifier(new LocationResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
                        throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
                    }
                default:
                    return CreateLocationIdentifier(new LocationResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));
            }
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are contained in a resource group.
        /// </summary>
        /// <param name="subscription"> The resource id of the subscription for this resource. </param>
        /// <param name="resourceGroupName"> The resource group containing the resource. </param>
        /// <param name="parts"> The path segments in the resource id following the resource group name. </param>
        /// <returns> The resource identifier for the given resource path. </returns>
        internal static ResourceIdentifier CreateBaseResourceGroupIdentifier(SubscriptionResourceIdentifier subscription, string resourceGroupName, List<string> parts)
        {
            var parent = new ResourceGroupResourceIdentifier(subscription, resourceGroupName);
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
            switch (parts[0].ToLowerInvariant())
            {
                case ProvidersKey:
                    {
                        if (parts.Count > 3)
                            return CreateResourceGroupIdentifier(new ResourceGroupResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
                        throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
            }
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are based in the tenant.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="parts"> The path segments in the resource path after the parent. </param>
        /// <returns> A resource identifier for a resource contained in the tenant. </returns>
        internal static ResourceIdentifier CreateTenantIdentifier(TenantResourceIdentifier parent, List<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new TenantResourceIdentifier(parent, parts[0], string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateTenantIdentifier(new TenantResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateTenantIdentifier(new TenantResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));
            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are based in a subscription.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="parts"> The path segments in the resource path after the parent. </param>
        /// <returns> A resource identifier for a resource contained in the subscription. </returns>
        internal static ResourceIdentifier CreateSubscriptionIdentifier(SubscriptionResourceIdentifier parent, List<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new SubscriptionResourceIdentifier(parent, parts[0], string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateSubscriptionIdentifier(new SubscriptionResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateSubscriptionIdentifier(new SubscriptionResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));
            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are contained in a location.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="parts"> The path segments in the resource path after the parent. </param>
        /// <returns> A resource identifier for a resource contained in a location. </returns>
        internal static ResourceIdentifier CreateLocationIdentifier(LocationResourceIdentifier parent, List<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new LocationResourceIdentifier(parent, parts[0], string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateLocationIdentifier(new LocationResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateLocationIdentifier(new LocationResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));
            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Create a new instance of the <see cref="ResourceIdentifier"/> class for resource identifiers 
        /// that are contained in a resource group.
        /// </summary>
        /// <param name="parent"> The resource id of the parent resource. </param>
        /// <param name="parts"> The path segments in the resource path after the parent. </param>
        /// <returns> A resource identifier for a resource contained in a resource group. </returns>
        internal static ResourceIdentifier CreateResourceGroupIdentifier(ResourceGroupResourceIdentifier parent, List<string> parts)
        {
            if (parts.Count == 0)
                return parent;
            if (parts.Count == 1)
                return new ResourceGroupResourceIdentifier(parent, parts[0], string.Empty);
            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateResourceGroupIdentifier(new ResourceGroupResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));
            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return CreateResourceGroupIdentifier(new ResourceGroupResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));
            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        private object lockObject = new object();
        private string _stringValue;

        /// <summary>
        /// Cache the string representation of this resource, so traversal only needs to occur once.
        /// </summary>
        internal string StringValue
        {
            get
            {
                lock (lockObject)
                {
                    if (_stringValue is null)
                    {
                        _stringValue = ToResourceString();
                    }

                    return _stringValue;
                }
            }

            set
            {
                lock (lockObject)
                {
                    _stringValue = value;
                }
            }
        }

        /// <summary>
        /// The resource type of the resource.
        /// </summary>
        public virtual ResourceType ResourceType { get; internal set; }

        /// <summary>
        /// The name of the resource.
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// The immediate parent containing this resource.
        /// </summary>
        public virtual ResourceIdentifier Parent { get; internal set; }

        /// <summary>
        /// Determines whether this resource is in the same namespace as its parent.
        /// </summary>
        internal virtual bool IsChild { get; set; }

        /// <summary>
        /// Tries to get the resource identifier of the parent of this resource.
        /// </summary>
        /// <param name="containerId"> The resource id of the parent resource. </param>
        /// <returns> True if the resource has a parent, otherwise false. </returns>
        public virtual bool TryGetParent(out ResourceIdentifier containerId)
        {
            containerId = default(ResourceIdentifier);
            if (this.Parent is RootResourceIdentifier)
                return false;
            containerId = this.Parent;
            return true;
        }

        /// <summary>
        /// Tries to get the subscription associated with this resource.
        /// </summary>
        /// <param name="subscriptionId"> The resource Id of the subscription for this resource. </param>
        /// <returns> True if the resource is contained in a subscription, otherwise false. </returns>
        public virtual bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = default(string);
            return false;
        }

        /// <summary>
        /// Tries to get the resource group associated with this resource.
        /// </summary>
        /// <param name="resourceGroupName"> The resource group for this resource. </param>
        /// <returns> True if the resource is contained in a resource group, otherwise false. </returns>
        public virtual bool TryGetResourceGroupName(out string resourceGroupName)
        {
            resourceGroupName = default(string);
            return false;
        }

        /// <summary>
        /// Tries to get the location associated with this resource.
        /// </summary>
        /// <param name="location"> The location for thsi resource. </param>
        /// <returns> True if the resource is contained in a location, otherwise false. </returns>
        public virtual bool TryGetLocation(out LocationData location)
        {
            location = default(LocationData);
            return false;
        }

        /// <summary>
        /// Create the resource id string based on the resource id string of the parent resource.
        /// </summary>
        /// <returns> The string representation of this resource id. </returns>
        internal virtual string ToResourceString()
        {
            StringBuilder builder = new StringBuilder(Parent.ToResourceString());
            if (IsChild)
            {
                builder.Append($"/{ResourceType.Types.Last()}");
                if (!string.IsNullOrWhiteSpace(Name))
                    builder.Append($"/{Name}");
            }
            else
            {
                builder.Append($"/providers/{ResourceType.Namespace}/{ResourceType.Type}/{Name}");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Return the string representation of the resource identifier.
        /// </summary>
        /// <returns> The string representation of this resource identifier. </returns>
        public override string ToString()
        {
            return StringValue;
        }

        /// <summary>
        /// Determine if this resource identifier is equivalent to the given resource identifier.
        /// </summary>
        /// <param name="other"> The resource identifier to compare to. </param>
        /// <returns>True if the resource identifiers are equivalent, otherwise false. </returns>
        public bool Equals(ResourceIdentifier other)
        {
            if (other is null)
                return false;
            return string.Equals(this.ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compre this resource identifier to the given resource identifier.
        /// </summary>
        /// <param name="other"> The resource identifier to compare to. </param>
        /// <returns> 0 if the resource identifiers are equivalent, -1 if this resource identifier 
        /// should be ordered before the given resource identifier, 1 if this resource identifier 
        /// should be ordered after the given resource identifier. </returns>
        public int CompareTo(ResourceIdentifier other)
        {
            if (other is null)
                return 1;
            return string.Compare(this.ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            ResourceIdentifier resourceObj = obj as ResourceIdentifier;
            if (!(resourceObj is null))
                return resourceObj.Equals(this);
            string stringObj = obj as string;
            if (!(stringObj is null))
                return this.Equals(ResourceIdentifier.Create(stringObj));
            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Convert a string into a resource identifier.
        /// </summary>
        /// <param name="other"> The string representation of a resource identifier. </param>
        public static implicit operator ResourceIdentifier(string other) => (other is null ? null : ResourceIdentifier.Create(other));

        /// <summary>
        /// Convert a resource identifier to a string 
        /// </summary>
        /// <param name="id"> The resource identifier. </param>
        public static implicit operator string(ResourceIdentifier id) => id?.ToString();
    }
}
