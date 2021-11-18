// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager
{
    /// <summary>
    /// An Azure Resource Manager resource identifier.
    /// </summary>
    public class ResourceIdentifier : IEquatable<ResourceIdentifier>, IComparable<ResourceIdentifier>
    {
        private const string RootStringValue = "/";

        internal const string ProvidersKey = "providers";
        internal const string SubscriptionsKey = "subscriptions";
        internal const string LocationsKey = "locations";
        internal const string ResourceGroupsLowerKey = "resourcegroups";
        internal const string BuiltInResourceNamespace = "Microsoft.Resources";

        /// <summary>
        /// The root of the resource hierarchy.
        /// </summary>
        public static readonly ResourceIdentifier RootResourceIdentifier = new ResourceIdentifier(null, Tenant.ResourceType, string.Empty);

        /// <summary>
        /// For internal use only.
        /// </summary>
        /// <param name="parent"> The parent resource for this resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        internal ResourceIdentifier(ResourceIdentifier parent, ResourceType resourceType, string name)
        {
            Init(parent, resourceType, name, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The id string to create the ResourceIdentifier from. </param>
        public ResourceIdentifier(string resourceId)
        {
            var id = Create(resourceId);
            Init(id.Parent, id.ResourceType, id.Name, id.IsChild);
        }

        private ResourceIdentifier(ResourceIdentifier parent, string resourceTypeName, string resourceName)
        {
            Init(parent, ChooseResourceType(resourceTypeName, parent), resourceName, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class for a resource in a different namespace than its parent.
        /// </summary>
        /// <param name="parent"> The <see cref="ResourceIdentifier"/> of the target of this extension resource. </param>
        /// <param name="providerNamespace"> The provider namespace of the extension. </param>
        /// <param name="resourceTypeName"> The full ARM resource type of the extension. </param>
        /// <param name="resourceName"> The name of the extension resource. </param>
        internal ResourceIdentifier(ResourceIdentifier parent, string providerNamespace, string resourceTypeName, string resourceName)
        {
            Init(parent, new ResourceType(providerNamespace, resourceTypeName), resourceName, false);
        }

        private void Init(ResourceIdentifier parent, ResourceType resourceType, string name, bool isChild)
        {
            if (parent != null)
            {
                Provider = parent.Provider;
                SubscriptionId = parent.SubscriptionId;
                Location = parent.Location;
                ResourceGroupName = parent.ResourceGroupName;
            }

            if (resourceType == Subscription.ResourceType)
            {
                Guid output;
                if (!Guid.TryParse(name, out output))
                    throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");
                SubscriptionId = name;
            }

            if (resourceType.LastType == LocationsKey)
                Location = name;

            if (resourceType == ResourceGroup.ResourceType)
                ResourceGroupName = name;

            if (resourceType == Resources.Provider.ResourceType)
                Provider = name;

            Parent = parent ?? RootResourceIdentifier;
            IsChild = isChild;
            ResourceType = resourceType;
            Name = name;
            _stringValue = parent == null ? RootStringValue : null;
        }

        private static ResourceType ChooseResourceType(string resourceTypeName, ResourceIdentifier parent) => resourceTypeName.ToLowerInvariant() switch
        {
            ResourceGroupsLowerKey => ResourceGroup.ResourceType,
            //subscriptions' type is Microsoft.Resources/subscriptions only when its parent is Tenant
            SubscriptionsKey when parent.ResourceType==Tenant.ResourceType => Subscription.ResourceType,
            _ => new ResourceType(parent.ResourceType, resourceTypeName)
        };

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

            var firstToLower = parts[0].ToLowerInvariant();
            if (firstToLower != SubscriptionsKey && firstToLower != ProvidersKey)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "Invalid resource id.");

            return AppendNext(RootResourceIdentifier, parts);
        }

        private static ResourceIdentifier AppendNext(ResourceIdentifier parent, List<string> parts)
        {
            if (parts.Count == 0)
                return parent;

            var lowerFirstPart = parts[0].ToLowerInvariant();

            if (parts.Count == 1)
            {
                //subscriptions and resourceGroups aren't valid ids without their name
                if (lowerFirstPart == SubscriptionsKey || lowerFirstPart == ResourceGroupsLowerKey)
                    throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");

                //resourceGroup must contain either child or provider resource type
                if (parent.ResourceType == ResourceGroup.ResourceType)
                    throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");

                return new ResourceIdentifier(parent, parts[0], string.Empty);
            }

            if (lowerFirstPart == ProvidersKey && (parts.Count == 2 || parts[2].ToLowerInvariant() == ProvidersKey))
            {
                //provider resource can only be on a tenant or a subscription parent
                if (parent.ResourceType != Subscription.ResourceType && parent.ResourceType != Tenant.ResourceType)
                    throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");

                return AppendNext(new ResourceIdentifier(parent, Resources.Provider.ResourceType, parts[1]), parts.Trim(2));
            }

            if (parts.Count > 3 && string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return AppendNext(new ResourceIdentifier(parent, parts[1], parts[2], parts[3]), parts.Trim(4));

            if (parts.Count > 1 && !string.Equals(parts[0], ProvidersKey, StringComparison.InvariantCultureIgnoreCase))
                return AppendNext(new ResourceIdentifier(parent, parts[0], parts[1]), parts.Trim(2));

            throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");
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
        /// Gets the subscription id if it exists otherwise null.
        /// </summary>
        public string SubscriptionId { get; protected set; }

        /// <summary>
        /// Gets the provider namespace if it exists otherwise null.
        /// </summary>
        public string Provider { get; protected set; }

        /// <summary>
        /// Gets the location if it exists otherwise null.
        /// </summary>
        public string Location { get; protected set; }

        /// <summary>
        /// The name of the resource group if it exists otherwise null.
        /// </summary>
        public string ResourceGroupName { get; protected set; }

        /// <summary>
        /// Tries to get the resource identifier of the parent of this resource.
        /// </summary>
        /// <param name="resourceId"> The resource id of the parent resource. </param>
        /// <returns> True if the resource has a parent, otherwise false. </returns>
        public virtual bool TryGetParent(out ResourceIdentifier resourceId)
        {
            resourceId = Parent;
            return resourceId != null;
        }

        /// <summary>
        /// Tries to get the subscription associated with this resource.
        /// </summary>
        /// <param name="subscriptionId"> The resource Id of the subscription for this resource. </param>
        /// <returns> True if the resource is contained in a subscription, otherwise false. </returns>
        public virtual bool TryGetSubscriptionId(out string subscriptionId)
        {
            subscriptionId = SubscriptionId;
            return subscriptionId != null;
        }

        /// <summary>
        /// Tries to get the resource group associated with this resource.
        /// </summary>
        /// <param name="resourceGroupName"> The resource group for this resource. </param>
        /// <returns> True if the resource is contained in a resource group, otherwise false. </returns>
        public virtual bool TryGetResourceGroupName(out string resourceGroupName)
        {
            resourceGroupName = ResourceGroupName;
            return resourceGroupName != null;
        }

        /// <summary>
        /// Tries to get the location associated with this resource.
        /// </summary>
        /// <param name="location"> The location for thsi resource. </param>
        /// <returns> True if the resource is contained in a location, otherwise false. </returns>
        public virtual bool TryGetLocation(out Location location)
        {
            location = Location;
            return location != null;
        }

        /// <summary>
        /// Create the resource id string based on the resource id string of the parent resource.
        /// </summary>
        /// <returns> The string representation of this resource id. </returns>
        internal virtual string ToResourceString()
        {
            if (Parent == null)
                return string.Empty;

            StringBuilder builder = new StringBuilder(Parent.ToResourceString());
            if (IsChild)
            {
                builder.Append($"/{ResourceType.LastType}");
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Operator overloading for '=='.
        /// </summary>
        /// <param name="id1">Left ResourceIdentifier object to compare.</param>
        /// <param name="id2">Right ResourceIdentifier object to compare.</param>
        /// <returns></returns>
        public static bool operator ==(ResourceIdentifier id1, ResourceIdentifier id2)
        {
            return ResourceIdentifier.Equals(id1, id2);
        }

        /// <summary>
        /// Operator overloading for '!='.
        /// </summary>
        /// <param name="id1">Left ResourceIdentifier object to compare.</param>
        /// <param name="id2">Right ResourceIdentifier object to compare.</param>
        /// <returns></returns>
        public static bool operator !=(ResourceIdentifier id1, ResourceIdentifier id2)
        {
            return !ResourceIdentifier.Equals(id1, id2);
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(ResourceIdentifier left, ResourceIdentifier right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(ResourceIdentifier left, ResourceIdentifier right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(ResourceIdentifier left, ResourceIdentifier right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(ResourceIdentifier left, ResourceIdentifier right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
