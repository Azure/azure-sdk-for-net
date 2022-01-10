// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private readonly ref struct ResourceIdentifierParts
        {
            public ResourceIdentifierParts(ResourceIdentifier parent, ResourceType resourceType, ReadOnlySpan<char> resourceName, bool isProviderResource) : this()
            {
                Parent = parent;
                ResourceType = resourceType;
                ResourceName = resourceName;
                IsProviderResource = isProviderResource;
            }

            public ResourceIdentifier Parent { get; }
            public ResourceType ResourceType { get; }
            public ReadOnlySpan<char> ResourceName { get; }
            public bool IsProviderResource { get; }
        }

        internal const char Separator = '/';

        private const string RootStringValue = "/";
        private const string ProvidersKey = "providers";
        private const string SubscriptionsKey = "subscriptions";
        private const string LocationsKey = "locations";
        private const string ResourceGroupKey = "resourcegroups";

        private string? _stringValue;

        /// <summary>
        /// The root of the resource hierarchy.
        /// </summary>
        public static readonly ResourceIdentifier Root = new ResourceIdentifier(null, ResourceType.Tenant, ReadOnlySpan<char>.Empty, false);

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The id string to create the ResourceIdentifier from. </param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ResourceIdentifier(string resourceId)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));

            if (resourceId[0] != Separator)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier must start with '/'.");

            if (resourceId.Length == 1)
            {
                //this is the same as Root but can't return that since this is a ctor
                Init(null, ResourceType.Tenant, string.Empty, false);
            }

            ReadOnlySpan<char> remaining = resourceId.AsSpan(1);
            //trim trailing '/' off the end if it exists
            if (remaining[remaining.Length - 1] == Separator)
                remaining = remaining.Slice(0, remaining.Length - 1);

            ReadOnlySpan<char> nextWord = GetNextWord(ref remaining);
            //this can occur if someone passes in '/foobar' or '/foobar/'
            if (remaining.IsEmpty)
                throw new ArgumentOutOfRangeException(nameof(resourceId), "The ResourceIdentifier is too short it must have at least 2 path segments.");

            if (!nextWord.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) && !nextWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                throw new ArgumentOutOfRangeException(nameof(resourceId), $"The ResourceIdentifier must start with either '/{SubscriptionsKey}' or '/{ProvidersKey}'.");

            //we know we at least have 1 ResourceIdentifier in the tree here
            ResourceIdentifierParts nextParts = GetNextPieces(Root, ref remaining, ref nextWord);
            while (!nextWord.IsEmpty)
            {
                //continue to get the next ResourceIdentifier in the tree until we reach the end which will be 'this'
                nextParts = GetNextPieces(new ResourceIdentifier(nextParts.Parent, nextParts.ResourceType, nextParts.ResourceName, nextParts.IsProviderResource), ref remaining, ref nextWord);
            }

            //initialize ourselves last
            Init(nextParts.Parent, nextParts.ResourceType, nextParts.ResourceName.ToString(), nextParts.IsProviderResource);
            _stringValue = resourceId;
        }

        private ResourceIdentifier(ResourceIdentifier? parent, ResourceType resourceType, ReadOnlySpan<char> resourceName, bool idProviderResource)
        {
            Init(parent, resourceType, resourceName.ToString(), idProviderResource);
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private void Init(ResourceIdentifier? parent, ResourceType resourceType, string resourceName, bool isProviderResource)
        {
            if (parent is not null)
            {
                //if our parent is not null set the same common identifier values
                Provider = parent.Provider;
                SubscriptionId = parent.SubscriptionId;
                Location = parent.Location;
                ResourceGroupName = parent.ResourceGroupName;
            }

            //check the 3 resource types so we can extract the common identifier values
            if (resourceType.Namespace == ResourceType.ResourceNamespace)
            {
                if (resourceType.Type == SubscriptionsKey)
                {
                    if (!Guid.TryParse(resourceName, out _))
                        throw new ArgumentOutOfRangeException(nameof(resourceName), $"The GUID for subscription is invalid {resourceName}.");
                    SubscriptionId = resourceName;
                }

                if (resourceType.Type.Equals(ResourceGroupKey, StringComparison.OrdinalIgnoreCase))
                    ResourceGroupName = resourceName;

                if (resourceType.Type == ProvidersKey)
                    Provider = resourceName;
            }

            //check for location
            if (resourceType.GetLastType() == LocationsKey)
                Location = resourceName;

            ResourceType = resourceType;
            Name = resourceName;
            IsProviderResource = isProviderResource;
            Parent = parent!;

            if (parent is null)
                _stringValue = RootStringValue;
        }

        private static ResourceType ChooseResourceType(ReadOnlySpan<char> resourceTypeName, ResourceIdentifier parent)
        {
            if (resourceTypeName.Equals(ResourceGroupKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                return ResourceType.ResourceGroup;

            //subscriptions' type is Microsoft.Resources/subscriptions only when its parent is Tenant
            if (resourceTypeName.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) && parent.ResourceType == ResourceType.Tenant)
                return ResourceType.Subscription;

            return parent.ResourceType.AppendChild(resourceTypeName.ToString());
        }

#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        private static ResourceIdentifierParts GetNextPieces(ResourceIdentifier parent, ref ReadOnlySpan<char> remaining, ref ReadOnlySpan<char> nextWord)
        {
            ReadOnlySpan<char> firstWord = nextWord;

            ReadOnlySpan<char> secondWord = GetNextWord(ref remaining);
            if (secondWord.IsEmpty)
            {
                //subscriptions and resourceGroups aren't valid ids without their name
                if (firstWord.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) || firstWord.Equals(ResourceGroupKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentOutOfRangeException("resourceId", $"The ResourceIdentifier is missing the key for {firstWord.ToString()}.");

                //resourceGroup must contain either child or provider resource type
                if (parent.ResourceType == ResourceType.ResourceGroup)
                    throw new ArgumentOutOfRangeException("resourceId", $"Expected {ProvidersKey} path segment after {ResourceGroupKey}.");

                nextWord = secondWord;
                return new ResourceIdentifierParts(parent, ChooseResourceType(firstWord, parent), ReadOnlySpan<char>.Empty, false);
            }

            ReadOnlySpan<char> thirdWord = GetNextWord(ref remaining);
            if (firstWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                if (thirdWord.IsEmpty || thirdWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    //provider resource can only be on a tenant or a subscription parent
                    if (parent.ResourceType == ResourceType.Subscription || parent.ResourceType == ResourceType.Tenant)
                    {
                        nextWord = thirdWord;
                        return new ResourceIdentifierParts(parent, ResourceType.Provider, secondWord, true);
                    }

                    throw new ArgumentOutOfRangeException("resourceId", $"Provider resource can only come after the root or {SubscriptionsKey}.");
                }

                ReadOnlySpan<char> fourthWord = GetNextWord(ref remaining);
                if (!fourthWord.IsEmpty)
                {
                    nextWord = GetNextWord(ref remaining);
                    return new ResourceIdentifierParts(parent, new ResourceType(secondWord.ToString(), thirdWord.ToString()), fourthWord, true);
                }
            }
            else
            {
                nextWord = thirdWord;
                return new ResourceIdentifierParts(parent, ChooseResourceType(firstWord, parent), secondWord, false);
            }

            throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");
        }
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

        private static ReadOnlySpan<char> GetNextWord(ref ReadOnlySpan<char> remaining)
        {
            int index = remaining.IndexOf(Separator);
            if (index < 0)
            {
                ReadOnlySpan<char> result = remaining.Slice(0);
                remaining = ReadOnlySpan<char>.Empty;
                return result;
            }
            else
            {
                ReadOnlySpan<char> result = remaining.Slice(0, index);
                remaining = remaining.Slice(index + 1);
                return result;
            }
        }

        /// <summary>
        /// Cache the string representation of this resource, so traversal only needs to occur once.
        /// </summary>
        private string StringValue => _stringValue ??= ToResourceString();

        /// <summary>
        /// The resource type of the resource.
        /// </summary>
        public ResourceType ResourceType { get; private set; }

        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The immediate parent containing this resource.
        /// </summary>
        public ResourceIdentifier Parent { get; private set; }

        /// <summary>
        /// Determines whether this resource is in the same namespace as its parent.
        /// </summary>
        internal bool IsProviderResource { get; private set; }

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

            string initial = Parent == Root ? string.Empty : Parent.StringValue;

            StringBuilder builder = new StringBuilder(initial);
            if (!IsProviderResource)
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
            return new ResourceIdentifier(this, new ResourceType(providerNamespace, resourceType), resourceName.AsSpan(), true);
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
            return new ResourceIdentifier(this, ChooseResourceType(childResourceType.AsSpan(), this), childResourceName.AsSpan(), false);
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
