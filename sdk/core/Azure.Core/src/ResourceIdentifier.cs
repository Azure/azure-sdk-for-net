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
        public static readonly ResourceIdentifier Root = new ResourceIdentifier(null, TenantResourceType, string.Empty, true);

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
            _stringValue = resourceId;
        }

        private ResourceIdentifier(ResourceIdentifier? parent, ResourceType resourceType, string resourceName, bool isChild)
        {
            Init(parent, resourceType, resourceName);
            ResourceType = resourceType;
            Name = resourceName;
            Parent = parent ?? Root;
            IsChild = isChild;
            if (parent is null)
                _stringValue = RootStringValue;
        }

        private ResourceIdentifier(ResourceIdentifier parent, string resourceTypeName, string resourceName)
            : this(parent, ChooseResourceType(resourceTypeName, parent), resourceName, true)
        {
        }

        private ResourceIdentifier(ResourceIdentifier parent, string providerNamespace, string resourceTypeName, string resourceName)
            : this(parent, new ResourceType(providerNamespace, resourceTypeName), resourceName, false)
        {
        }

        private void Init(ResourceIdentifier? parent, ResourceType resourceType, string resourceName)
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
                if (!Guid.TryParse(resourceName, out _))
                    throw new ArgumentOutOfRangeException(nameof(resourceName), $"The GUID for subscription is invalid {resourceName}.");
                SubscriptionId = resourceName;
            }

            if (resourceType.GetLastType() == LocationsKey)
                Location = resourceName;

            if (resourceType == ResourceGroupResourceType)
                ResourceGroupName = resourceName;

            if (resourceType == ProviderResourceType)
                Provider = resourceName;
        }

        private static ResourceType ChooseResourceType(string resourceTypeName, ResourceIdentifier parent)
        {
            if (resourceTypeName.Equals(ResourceGroupsLowerKey, StringComparison.OrdinalIgnoreCase))
                return ResourceGroupResourceType;

            //subscriptions' type is Microsoft.Resources/subscriptions only when its parent is Tenant
            if (resourceTypeName.Equals(SubscriptionsKey, StringComparison.OrdinalIgnoreCase) && parent.ResourceType == TenantResourceType)
                return SubscriptionResourceType;

            return parent.ResourceType.AppendChild(resourceTypeName);
        }

        private static ResourceIdentifier Create(string resourceId)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));

            if (resourceId[0] != Separator)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier must start with '/'.");

            if (resourceId.Length == 1)
                return Root;

            string[] parts = resourceId.Split(Separator);
            if (parts.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier is too short it must have at least 2 path segments.");

            if (!parts[1].Equals(SubscriptionsKey, StringComparison.OrdinalIgnoreCase) && !parts[1].Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), $"The ResourceIdentifier must start with either '/{SubscriptionsKey}' or '/{ProvidersKey}'.");

            int validLength = string.IsNullOrEmpty(parts[parts.Length - 1]) ? parts.Length - 1 : parts.Length;
            return AppendNext(Root, parts, 1, validLength);
        }

        private static ResourceIdentifier AppendNext(ResourceIdentifier parent, string[] parts, int startIndex, int length)
        {
            int partsCount = length - startIndex;

            if (partsCount == 0)
                return parent;

            string firstElement = parts[startIndex];

            if (partsCount == 1)
            {
                //subscriptions and resourceGroups aren't valid ids without their name
                if (firstElement.Equals(SubscriptionsKey, StringComparison.OrdinalIgnoreCase) || firstElement.Equals(ResourceGroupsLowerKey, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentOutOfRangeException(nameof(parts), $"The ResourceIdentifier is missing the key for {firstElement}.");

                //resourceGroup must contain either child or provider resource type
                if (parent.ResourceType == ResourceGroupResourceType)
                    throw new ArgumentOutOfRangeException(nameof(parts), $"Expected {ProvidersKey} path segment after {ResourceGroupsLowerKey}.");

                return new ResourceIdentifier(parent, firstElement, string.Empty);
            }

            if (firstElement.Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase))
            {
                if (partsCount == 2 || parts[startIndex + 2].Equals(ProvidersKey, StringComparison.OrdinalIgnoreCase))
                {
                    //provider resource can only be on a tenant or a subscription parent
                    if (parent.ResourceType == SubscriptionResourceType || parent.ResourceType == TenantResourceType)
                        return AppendNext(new ResourceIdentifier(parent, ProviderResourceType, parts[startIndex + 1], true), parts, startIndex + 2, length);

                    throw new ArgumentOutOfRangeException(nameof(parts), $"Provider resource can only come after the root or {SubscriptionsKey}.");
                }

                if (partsCount > 3)
                    return AppendNext(new ResourceIdentifier(parent, parts[startIndex + 1], parts[startIndex + 2], parts[startIndex + 3]), parts, startIndex + 4, length);
            }
            else
            {
                return AppendNext(new ResourceIdentifier(parent, firstElement, parts[startIndex + 1]), parts, startIndex + 2, length);
            }

            throw new ArgumentOutOfRangeException(nameof(parts), "Invalid resource id.");
        }

        /// <summary>
        /// Cache the string representation of this resource, so traversal only needs to occur once.
        /// </summary>
        private string StringValue => _stringValue ??= ToResourceString();

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

            var initial = Parent == Root ? string.Empty : Parent.StringValue;

            StringBuilder builder = new StringBuilder(initial);
            if (IsChild)
            {
                builder.Append($"/{ResourceType.GetLastType()}");
                if (!string.IsNullOrWhiteSpace(Name))
                    builder.Append($"/{Name}");
            }
            else
            {
                builder.Append($"/providers/{ResourceType}/{Name}");
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

            return StringValue.Equals(other.StringValue, StringComparison.OrdinalIgnoreCase);
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

            return string.Compare(StringValue, other.StringValue, StringComparison.OrdinalIgnoreCase);
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
            return StringComparer.OrdinalIgnoreCase.GetHashCode(StringValue);
        }

        /// <summary>
        /// Convert a resource identifier to a string.
        /// </summary>
        /// <param name="id"> The resource identifier. </param>
        public static implicit operator string?(ResourceIdentifier id) => id?.StringValue;

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
            if (segment.Contains(Separator))
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be a single path segment");
        }
    }
}
