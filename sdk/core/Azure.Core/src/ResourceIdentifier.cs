// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// An Azure Resource Manager resource identifier.
    /// </summary>
    public sealed class ResourceIdentifier : IEquatable<ResourceIdentifier>, IComparable<ResourceIdentifier>
    {
        private const char Separator = '/';

        private static ResourceType TenantResourceType = new ResourceType("Microsoft.Resources/tenants");
        private static ResourceType SubscriptionResourceType = new ResourceType("Microsoft.Resources/subscriptions");
        private static ResourceType ResourceGroupResourceType = new ResourceType("Microsoft.Resources/resourceGroups");
        private static ResourceType ProviderResourceType = new ResourceType("Microsoft.Resources/providers");
        private const string RootStringValue = "/";
        private const string ProvidersKey = "providers";
        private const string SubscriptionsKey = "subscriptions";
        private const string LocationsKey = "locations";
        private const string ResourceGroupsLowerKey = "resourcegroups";

        private string? _stringValue;

        /// <summary>
        /// The root of the resource hierarchy.
        /// </summary>
        public static readonly ResourceIdentifier Root = new ResourceIdentifier(null, TenantResourceType, string.Empty);

        /// <summary>
        /// For internal use only.
        /// </summary>
        /// <param name="parent"> The parent resource for this resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        internal ResourceIdentifier(ResourceIdentifier? parent, ResourceType resourceType, string name)
        {
            Init(parent, resourceType, name);
            ResourceType = resourceType;
            Name = name;
            Parent = parent ?? Root;
            if (parent is null)
                _stringValue = RootStringValue;
            IsChild = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The id string to create the ResourceIdentifier from. </param>
        public ResourceIdentifier(string resourceId)
        {
            var id = Create(resourceId);
            Init(id.Parent, id.ResourceType, id.Name);
            ResourceType = id.ResourceType;
            Name = id.Name;
            Parent = id.Parent;
            IsChild = id.IsChild;
        }

        private ResourceIdentifier(ResourceIdentifier parent, string resourceTypeName, string resourceName)
        {
            ResourceType resourceType = ChooseResourceType(resourceTypeName, parent);
            Init(parent, resourceType, resourceName);
            ResourceType = resourceType;
            Name = resourceName;
            Parent = parent;
            IsChild = true;
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
            ResourceType resourceType = new ResourceType(providerNamespace, resourceTypeName);
            Init(parent, resourceType, resourceName);
            ResourceType = resourceType;
            Name = resourceName;
            Parent = parent;
            IsChild = false;
        }

        private void Init(ResourceIdentifier? parent, ResourceType resourceType, string name)
        {
            if (parent is not null)
            {
                Provider = parent.Provider;
                SubscriptionId = parent.SubscriptionId;
                Location = parent.Location;
                ResourceGroupName = parent.ResourceGroupName;
            }

            if (resourceType == SubscriptionResourceType)
            {
                if (!Guid.TryParse(name, out _))
                    throw new ArgumentOutOfRangeException(nameof(name), $"The GUID for subscription is invalid {name}.");
                SubscriptionId = name;
            }

            if (resourceType.GetLastType() == LocationsKey)
                Location = name;

            if (resourceType == ResourceGroupResourceType)
                ResourceGroupName = name;

            if (resourceType == ProviderResourceType)
                Provider = name;
        }

        private static ResourceType ChooseResourceType(string resourceTypeName, ResourceIdentifier parent) => resourceTypeName.ToLowerInvariant() switch
        {
            ResourceGroupsLowerKey => ResourceGroupResourceType,
            //subscriptions' type is Microsoft.Resources/subscriptions only when its parent is Tenant
            SubscriptionsKey when parent.ResourceType == TenantResourceType => SubscriptionResourceType,
            _ => parent.ResourceType.AppendChild(resourceTypeName)
        };

        private static ResourceIdentifier Create(string resourceId)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            if (!resourceId.StartsWith(RootStringValue, StringComparison.InvariantCultureIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier must start with '/'.");

            if (resourceId.Length == 1)
                return Root;

            var parts = resourceId.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier is too short it must have at least 2 path segments.");

            if (!parts[0].Equals(SubscriptionsKey, StringComparison.OrdinalIgnoreCase) && !parts[0].Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), $"The ResourceIdentifier must start with either '/{SubscriptionsKey}' or '/{ProvidersKey}'.");

            return AppendNext(Root, parts, 0);
        }

        private static ResourceIdentifier AppendNext(ResourceIdentifier parent, string[] parts, int startIndex)
        {
            int partsCount = parts.Length - startIndex;

            if (partsCount == 0)
                return parent;

            if (partsCount == 1)
            {
                //subscriptions and resourceGroups aren't valid ids without their name
                if (parts[startIndex].Equals(SubscriptionsKey, StringComparison.OrdinalIgnoreCase) || parts[startIndex].Equals(ResourceGroupsLowerKey, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentOutOfRangeException(nameof(parts), $"The ResourceIdentifier is missing the key for {parts[startIndex]}.");

                //resourceGroup must contain either child or provider resource type
                if (parent.ResourceType == ResourceGroupResourceType)
                    throw new ArgumentOutOfRangeException(nameof(parts), $"Expected {ProvidersKey} path segment after {ResourceGroupsLowerKey}.");

                return new ResourceIdentifier(parent, parts[startIndex], string.Empty);
            }

            bool isFirstProvider = parts[startIndex].Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase);

            if (isFirstProvider && (partsCount == 2 || parts[startIndex+2].Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase)))
            {
                //provider resource can only be on a tenant or a subscription parent
                if (parent.ResourceType != SubscriptionResourceType && parent.ResourceType != TenantResourceType)
                    throw new ArgumentOutOfRangeException(nameof(parts), $"Provider resource can only come after the root or {SubscriptionsKey}.");

                return AppendNext(new ResourceIdentifier(parent, ProviderResourceType, parts[startIndex + 1]), parts, startIndex + 2);
            }

            if (partsCount > 3 && isFirstProvider)
            {
                return AppendNext(new ResourceIdentifier(parent, parts[startIndex + 1], parts[startIndex + 2], parts[startIndex + 3]), parts, startIndex+4);
            }

            if (partsCount > 1 && !isFirstProvider)
            {
                return AppendNext(new ResourceIdentifier(parent, parts[startIndex], parts[startIndex + 1]), parts, startIndex+2);
            }

            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Cache the string representation of this resource, so traversal only needs to occur once.
        /// </summary>
        internal string StringValue => _stringValue ??= ToResourceString();

        /// <summary>
        /// The resource type of the resource.
        /// </summary>
        public ResourceType ResourceType { get; }

        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The immediate parent containing this resource.
        /// </summary>
        public ResourceIdentifier Parent { get; }

        /// <summary>
        /// Determines whether this resource is in the same namespace as its parent.
        /// </summary>
        internal bool IsChild { get; }

        /// <summary>
        /// Gets the subscription id if it exists otherwise null.
        /// </summary>
        public string? SubscriptionId { get; private set; }

        /// <summary>
        /// Gets the provider namespace if it exists otherwise null.
        /// </summary>
        public string? Provider { get; private set; }

        /// <summary>
        /// Gets the location if it exists otherwise null.
        /// </summary>
        public AzureLocation? Location { get; private set; }

        /// <summary>
        /// The name of the resource group if it exists otherwise null.
        /// </summary>
        public string? ResourceGroupName { get; private set; }

        private string ToResourceString()
        {
            if (Parent is null)
                return string.Empty;

            StringBuilder builder = new StringBuilder(Parent.ToResourceString());
            if (IsChild)
            {
                builder.Append($"/{ResourceType.GetLastType()}");
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
        public bool Equals(ResourceIdentifier? other)
        {
            if (other is null)
                return false;
            return string.Equals(ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compre this resource identifier to the given resource identifier.
        /// </summary>
        /// <param name="other"> The resource identifier to compare to. </param>
        /// <returns> 0 if the resource identifiers are equivalent, -1 if this resource identifier
        /// should be ordered before the given resource identifier, 1 if this resource identifier
        /// should be ordered after the given resource identifier. </returns>
        public int CompareTo(ResourceIdentifier? other)
        {
            if (other is null)
                return 1;
            return string.Compare(ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            ResourceIdentifier? resourceObj = obj as ResourceIdentifier;
            if (resourceObj is not null)
                return resourceObj.Equals(this);
            string? stringObj = obj as string;
            if (stringObj is not null)
                return Equals(new ResourceIdentifier(stringObj));
            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Convert a resource identifier to a string.
        /// </summary>
        /// <param name="id"> The resource identifier. </param>
        public static implicit operator string?(ResourceIdentifier id) => id?.ToString();

        /// <summary>
        /// Operator overloading for '=='.
        /// </summary>
        /// <param name="left"> Left ResourceIdentifier object to compare. </param>
        /// <param name="right"> Right ResourceIdentifier object to compare. </param>
        /// <returns></returns>
        public static bool operator ==(ResourceIdentifier left, ResourceIdentifier right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        /// <summary>
        /// Operator overloading for '!='.
        /// </summary>
        /// <param name="left"> Left ResourceIdentifier object to compare. </param>
        /// <param name="right"> Right ResourceIdentifier object to compare. </param>
        /// <returns></returns>
        public static bool operator !=(ResourceIdentifier left, ResourceIdentifier right)
        {
            if (left is null)
                return right is not null;

            return !left.Equals(right);
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(ResourceIdentifier left, ResourceIdentifier right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(ResourceIdentifier left, ResourceIdentifier right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(ResourceIdentifier left, ResourceIdentifier right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceIdentifier"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(ResourceIdentifier left, ResourceIdentifier right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Add a provider resource to an existing resource id.
        /// </summary>
        /// <param name="providerNamespace"> The provider namespace of the added resource. </param>
        /// <param name="resourceType"> The simple type of the added resource, without slashes (/),
        /// for example, 'virtualMachines'. </param>
        /// <param name="resourceName"> The name of the resource.</param>
        /// <returns> The combined resource id. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier AppendProviderResource(string providerNamespace, string resourceType, string resourceName)
        {
            ValidateProviderResourceParameters(providerNamespace, resourceType, resourceName);
            return new ResourceIdentifier(this, providerNamespace, resourceType, resourceName);
        }

        /// <summary>
        /// Add a provider resource to an existing resource id.
        /// </summary>
        /// <param name="childResourceType"> The simple type of the child resource, without slashes (/),
        /// for example, 'subnets'. </param>
        /// <param name="childResourceName"> The name of the resource. </param>
        /// <returns> The combined resource id. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier AppendChildResource(string childResourceType, string childResourceName)
        {
            ValidateChildResourceParameters(childResourceType, childResourceName);
            return new ResourceIdentifier(this, childResourceType, childResourceName);
        }

        private static void ValidateProviderResourceParameters(string providerNamespace, string resourceType, string resourceName)
        {
            ValidatePathSegment(providerNamespace, nameof(providerNamespace));
            ValidatePathSegment(resourceType, nameof(resourceType));
            ValidatePathSegment(resourceName, nameof(resourceName));
        }

        private static void ValidateChildResourceParameters(string childResourceType, string childResourceName)
        {
            ValidatePathSegment(childResourceType, nameof(childResourceType));
            ValidatePathSegment(childResourceName, nameof(childResourceName));
        }

        private static void ValidatePathSegment(string segment, string parameterName)
        {
            Argument.AssertNotNullOrWhiteSpace(segment, nameof(segment));
            if (segment.Contains("/"))
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be a single path segment");
        }
    }
}
