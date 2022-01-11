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
        private enum SpecialType
        {
            Subscription,
            ResourceGroup,
            Location,
            Provider,
            None
        }

        private readonly ref struct ResourceIdentifierParts
        {
            public ResourceIdentifierParts(ReadOnlySpan<char> resourceType, ReadOnlySpan<char> resourceName, bool isProviderResource, SpecialType specialType)
            {
                ResourceType = resourceType;
                ResourceName = resourceName;
                IsProviderResource = isProviderResource;
                SpecialType = specialType;
            }

            public ReadOnlySpan<char> ResourceType { get; }
            public ReadOnlySpan<char> ResourceName { get; }
            public bool IsProviderResource { get; }
            public SpecialType SpecialType { get; }
        }

        internal const char Separator = '/';

        private const string RootStringValue = "/";
        private const string ProvidersKey = "providers";
        private const string SubscriptionsKey = "subscriptions";
        private const string LocationsKey = "locations";
        private const string ResourceGroupKey = "resourcegroups";

        private const string SubscriptionStart = "/subscriptions/";
        private const string ProviderStart = "/providers/";

        private string? _stringValue;

        /// <summary>
        /// The root of the resource hierarchy.
        /// </summary>
        public static readonly ResourceIdentifier Root = new(RootStringValue);

        private readonly int _parentIndex = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The id string to create the ResourceIdentifier from. </param>
        public ResourceIdentifier(string resourceId)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));
            _stringValue = resourceId;

            ReadOnlySpan<char> remaining = resourceId.AsSpan();

            if (resourceId == RootStringValue)
            {
                Name = String.Empty;
                ResourceType = new ResourceType(ResourceType.Tenant);
                return;
            }

            if (!remaining.StartsWith(SubscriptionStart.AsSpan()) && !remaining.StartsWith(ProviderStart.AsSpan()))
                throw new ArgumentOutOfRangeException(nameof(resourceId), $"The ResourceIdentifier must start with {SubscriptionStart} or {ProviderStart}.");

            remaining = remaining.Slice(1);

            //we know we at least have 1 ResourceIdentifier in the tree here
            ResourceIdentifierParts nextParts;
            ReadOnlySpan<char> parentResourceType = ResourceType.Tenant.AsSpan();
            do
            {
                _parentIndex = resourceId.Length - remaining.Length - 1;

                //continue to get the next ResourceIdentifier in the tree until we reach the end which will be 'this'
                nextParts = GetNextParts(parentResourceType, ref remaining);

                //check the 4 resource types so we can extract the common identifier values
                switch (nextParts.SpecialType)
                {
                    case SpecialType.ResourceGroup:
                        ResourceGroupName = nextParts.ResourceName.ToString();
                        break;
                    case SpecialType.Subscription:
                        if (!Guid.TryParse(nextParts.ResourceName.ToString(), out _))
                            throw new ArgumentOutOfRangeException(nameof(resourceId), $"The GUID for subscription is invalid {nextParts.ResourceName.ToString()}.");
                        SubscriptionId = nextParts.ResourceName.ToString();
                        break;
                    case SpecialType.Provider:
                        Provider = nextParts.ResourceName.ToString();
                        break;
                    case SpecialType.Location:
                        Location = nextParts.ResourceName.ToString();
                        break;
                }

                parentResourceType = nextParts.ResourceType;
            } while (!remaining.IsEmpty);

            Name = nextParts.ResourceName.ToString();
            ResourceType = new ResourceType(nextParts.ResourceType.ToString());
            IsProviderResource = nextParts.IsProviderResource;
        }

#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        private static ResourceIdentifierParts GetNextParts(ReadOnlySpan<char> parentResourceType, ref ReadOnlySpan<char> remaining)
        {
            static ReadOnlySpan<char> PopNextWord(ref ReadOnlySpan<char> remaining, bool onlyIfNotProviders = false)
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
                    if (onlyIfNotProviders && result.SequenceEqual(ProvidersKey.AsSpan()))
                    {
                        return ReadOnlySpan<char>.Empty;
                    }
                    remaining = remaining.Slice(index + 1);
                    return result;
                }
            }

            bool Equals(ReadOnlySpan<char> a, string b) => a.CompareTo(b.AsSpan(), StringComparison.OrdinalIgnoreCase) == 0;

            ReadOnlySpan<char> firstWord = PopNextWord(ref remaining);

            // /resourcegroup/resourcegroupname
            if (firstWord.Equals(ResourceGroupKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                ReadOnlySpan<char> secondWord = PopNextWord(ref remaining);

                if (secondWord.IsEmpty)
                {
                    throw new ArgumentOutOfRangeException("resourceId", $"The ResourceIdentifier is missing the key for {firstWord.ToString()}.");
                }

                return new ResourceIdentifierParts(ResourceType.ResourceGroup.AsSpan(), secondWord, false, SpecialType.ResourceGroup);
            }
            // /subscription/subscriptionId
            else if (firstWord.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) &&
                    Equals(parentResourceType, ResourceType.Tenant))
            {
                ReadOnlySpan<char> subscriptionName = PopNextWord(ref remaining);

                if (subscriptionName.IsEmpty)
                {
                    throw new ArgumentOutOfRangeException("resourceId", $"The ResourceIdentifier is missing the key for {firstWord.ToString()}.");
                }

                return new ResourceIdentifierParts(ResourceType.Subscription.AsSpan(), subscriptionName, false, SpecialType.Subscription);
            }
            // /provider/Provider.Namespace
            // /provider/Provider.Namespace/resourceTypeName/resourceName
            else if (firstWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                ReadOnlySpan<char> providerNamespace = PopNextWord(ref remaining);

                ReadOnlySpan<char> secondWord = PopNextWord(ref remaining, onlyIfNotProviders: true);
                if (secondWord.IsEmpty)
                {
                    if (!Equals(parentResourceType, ResourceType.Subscription) &&
                        !Equals(parentResourceType, ResourceType.Tenant))
                    {
                        throw new ArgumentOutOfRangeException("resourceId", $"Provider resource can only come after the root or {SubscriptionsKey}.");
                    }

                    return new ResourceIdentifierParts(ResourceType.Provider.AsSpan(), providerNamespace, true, SpecialType.Provider);
                }

                ReadOnlySpan<char> resourceName = PopNextWord(ref remaining, onlyIfNotProviders: true);
                if (!resourceName.IsEmpty)
                {
                    SpecialType specialType = secondWord.Equals(LocationsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) ? SpecialType.Location : SpecialType.None;
                    return new ResourceIdentifierParts($"{providerNamespace.ToString()}/{secondWord.ToString()}".AsSpan(), resourceName, true, specialType);
                }
            }
            // /provider/Provider.Namespace/resourceTypeName/resourceName | /location/locationName/
            else if (firstWord.Equals(LocationsKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                ReadOnlySpan<char> locationName = PopNextWord(ref remaining);
                return new ResourceIdentifierParts($"{parentResourceType.ToString()}/{firstWord.ToString()}".AsSpan(), locationName, false, SpecialType.Location);
            }
            // /subscription/subscriptionId | /resourceTypeName2/resourceName2
            // /resourcegroup/resourcegroupname | /resourceTypeName2/resourceName2
            // /provider/Provider.Namespace/resourceTypeName/resourceName | /resourceTypeName2/resourceName2
            else
            {
                ReadOnlySpan<char> resourceName2 = PopNextWord(ref remaining, onlyIfNotProviders: true);

                return new ResourceIdentifierParts($"{parentResourceType.ToString()}/{firstWord.ToString()}".AsSpan(), resourceName2, false, SpecialType.None);
            }

            throw new ArgumentOutOfRangeException("resourceId", "Invalid resource id.");
        }
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

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
        public ResourceIdentifier? Parent {
            get
            {
                if (_parentIndex > 0)
                {
                    return new ResourceIdentifier(_stringValue!.Substring(0, _parentIndex));
                }

                if (string.Equals(_stringValue, RootStringValue, StringComparison.Ordinal))
                {
                    return null;
                }

                return Root;
            }
        }

        /// <summary>
        /// Determines whether this resource is in the same namespace as its parent.
        /// </summary>
        internal bool IsProviderResource { get; }

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
#pragma warning disable CA1822
        public ResourceIdentifier AppendProviderResource(string providerNamespace, string resourceType, string resourceName)
        {
            ValidateProviderResourceParameters(providerNamespace, resourceType, resourceName);
            return new ResourceIdentifier($"{_stringValue}/providers/{providerNamespace}/{resourceType}/{resourceName}");
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
            return new ResourceIdentifier($"{_stringValue}/{childResourceType}/{childResourceName}");
        }
#pragma warning restore CA1822

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
