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
            None,
            Subscription,
            ResourceGroup,
            Location,
            Provider,
        }

        private readonly struct ResourceIdentifierParts
        {
            public ResourceIdentifierParts(ResourceIdentifier parent, ResourceType resourceType, string resourceName, bool isProviderResource, SpecialType specialType)
            {
                Parent = parent;
                ResourceType = resourceType;
                ResourceName = resourceName;
                IsProviderResource = isProviderResource;
                SpecialType = specialType;
            }

            public ResourceIdentifier Parent { get; }
            public ResourceType ResourceType { get; }
            public string ResourceName { get; }
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

        private bool _initialized;
        private string? _stringValue;
        private ResourceType _resourceType;
        private string _name = null!;
        private ResourceIdentifier? _parent;
        private bool _isProviderResource;
        private string? _subscriptionId;
        private string? _provider;
        private AzureLocation? _location;
        private string? _resourceGroupName;

        /// <summary>
        /// The root of the resource hierarchy.
        /// </summary>
        public static readonly ResourceIdentifier Root = new ResourceIdentifier(null, ResourceType.Tenant, string.Empty, false, SpecialType.None);

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceIdentifier"/> class.
        /// </summary>
        /// <param name="resourceId"> The id string to create the ResourceIdentifier from. </param>
        /// <remarks>
        /// For more information on ResourceIdentifier format see the following.
        /// ResourceGroup level id https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-functions-resource#resourceid
        /// Subscription level id https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-functions-resource#subscriptionresourceid
        /// Tenant level id https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-functions-resource#tenantresourceid
        /// Extension id https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-functions-resource#extensionresourceid
        /// </remarks>
        public ResourceIdentifier(string resourceId)
        {
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));

            _stringValue = resourceId;

            if (resourceId.Length == 1 && resourceId[0] == Separator)
            {
                //this is the same as Root but can't return that since this is a ctor
                Init(null, ResourceType.Tenant, string.Empty, false, SpecialType.None);
            }
        }

        private ResourceIdentifier(ResourceIdentifier? parent, ResourceType resourceType, string resourceName, bool isProviderResource, SpecialType specialType)
        {
            Init(parent, resourceType, resourceName, isProviderResource, specialType);
        }

        private void Init(ResourceIdentifier? parent, ResourceType resourceType, string resourceName, bool isProviderResource, SpecialType specialType)
        {
            if (parent is not null)
            {
                //if our parent is not null set the same common identifier values
                _provider = parent.Provider;
                _subscriptionId = parent.SubscriptionId;
                _location = parent.Location;
                _resourceGroupName = parent.ResourceGroupName;
            }

            //check the 4 resource types so we can extract the common identifier values
            switch (specialType)
            {
                case SpecialType.ResourceGroup:
                    _resourceGroupName = resourceName;
                    break;
                case SpecialType.Subscription:
                    _subscriptionId = resourceName;
                    break;
                case SpecialType.Provider:
                    _provider = resourceName;
                    break;
                case SpecialType.Location:
                    _location = resourceName;
                    break;
            }

            _resourceType = resourceType;
            _name = resourceName;
            _isProviderResource = isProviderResource;
            _parent = parent;

            if (parent is null)
            {
                _stringValue = RootStringValue;
            }

            _initialized = true;
        }

        private string? Parse()
        {
            ReadOnlySpan<char> remaining = _stringValue.AsSpan();

            if (!remaining.StartsWith(SubscriptionStart.AsSpan(), StringComparison.OrdinalIgnoreCase) &&
                !remaining.StartsWith(ProviderStart.AsSpan(), StringComparison.OrdinalIgnoreCase))
                return $"The ResourceIdentifier must start with {SubscriptionStart} or {ProviderStart}.";

            //trim trailing '/' off the end if it exists
            remaining = remaining[remaining.Length - 1] == Separator ? remaining.Slice(1, remaining.Length - 2) : remaining.Slice(1);

            ReadOnlySpan<char> nextWord = PopNextWord(ref remaining);

            //we know we at least have 1 ResourceIdentifier in the tree here
            var errorMessage = GetNextParts(Root, ref remaining, ref nextWord, out ResourceIdentifierParts? result);
            if (errorMessage is not null)
                return errorMessage;
            ResourceIdentifierParts nextParts = result!.Value;

            while (!nextWord.IsEmpty)
            {
                //continue to get the next ResourceIdentifier in the tree until we reach the end which will be 'this'
                ResourceIdentifier newParent = new ResourceIdentifier(nextParts.Parent, nextParts.ResourceType, nextParts.ResourceName, nextParts.IsProviderResource, nextParts.SpecialType);
                if (nextParts.SpecialType == SpecialType.Subscription)
                {
                    errorMessage = newParent.CheckSubscriptionFormat();
                    if (errorMessage is not null)
                        return errorMessage;
                }
                errorMessage = GetNextParts(newParent, ref remaining, ref nextWord, out result);
                if (errorMessage is not null)
                    return errorMessage;
                nextParts = result!.Value;
            }

            //initialize ourselves last
            Init(nextParts.Parent, nextParts.ResourceType, nextParts.ResourceName, nextParts.IsProviderResource, nextParts.SpecialType);
            return nextParts.SpecialType == SpecialType.Subscription ? CheckSubscriptionFormat() : null;
        }

        private string? CheckSubscriptionFormat()
        {
            if (_subscriptionId is not null && !Guid.TryParse(_subscriptionId, out _))
                return $"The GUID for subscription is invalid {_subscriptionId}.";
            return null;
        }

        private T GetValue<T>(ref T value)
        {
            if (!_initialized)
            {
                var error = Parse();
                if (error is not null)
                    throw new FormatException(error);
            }

            return value;
        }

        private static ResourceType ChooseResourceType(ReadOnlySpan<char> resourceTypeName, ResourceIdentifier parent, out SpecialType specialType)
        {
            if (resourceTypeName.Equals(ResourceGroupKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                //resourceGroups type is Microsoft.Resources/resourceGroups only when its parent is Subscription
                specialType = SpecialType.ResourceGroup;
                if (parent.ResourceType == ResourceType.Subscription)
                {
                    return ResourceType.ResourceGroup;
                }
            }
            else if (resourceTypeName.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) && parent.ResourceType == ResourceType.Tenant)
            {
                //subscriptions' type is Microsoft.Resources/subscriptions only when its parent is Tenant
                specialType = SpecialType.Subscription;
                return ResourceType.Subscription;
            }
            else
            {
                specialType = resourceTypeName.Equals(LocationsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) ? SpecialType.Location : SpecialType.None;
            }

            return parent.ResourceType.AppendChild(resourceTypeName.ToString());
        }

        private static string? GetNextParts(ResourceIdentifier parent, ref ReadOnlySpan<char> remaining, ref ReadOnlySpan<char> nextWord, out ResourceIdentifierParts? parts)
        {
            parts = null;
            ReadOnlySpan<char> firstWord = nextWord;
            ReadOnlySpan<char> secondWord = PopNextWord(ref remaining);

            if (secondWord.IsEmpty)
            {
                //subscriptions and resourceGroups aren't valid ids without their name
                if (firstWord.Equals(SubscriptionsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) || firstWord.Equals(ResourceGroupKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                    return $"The ResourceIdentifier is missing the key for {firstWord.ToString()}.";

                //resourceGroup must contain either child or provider resource type
                if (parent.ResourceType == ResourceType.ResourceGroup)
                    return $"Expected {ProvidersKey} path segment after {ResourceGroupKey}.";

                nextWord = secondWord;
                SpecialType specialType = firstWord.Equals(LocationsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) ? SpecialType.Location : SpecialType.None;
                var resourceType = parent.ResourceType.AppendChild(firstWord.ToString());
                parts = new ResourceIdentifierParts(parent, new ResourceType(resourceType), string.Empty, false, specialType);
                return null;
            }

            ReadOnlySpan<char> thirdWord = PopNextWord(ref remaining);
            if (firstWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                if (thirdWord.IsEmpty || thirdWord.Equals(ProvidersKey.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    //provider resource can only be on a tenant or a subscription parent
                    if (parent.ResourceType == ResourceType.Subscription || parent.ResourceType == ResourceType.Tenant)
                    {
                        nextWord = thirdWord;
                        parts = new ResourceIdentifierParts(parent, ResourceType.Provider, secondWord.ToString(), true, SpecialType.Provider);
                        return null;
                    }

                    return $"Provider resource can only come after the root or {SubscriptionsKey}.";
                }

                ReadOnlySpan<char> fourthWord = PopNextWord(ref remaining);
                if (!fourthWord.IsEmpty)
                {
                    nextWord = PopNextWord(ref remaining);
                    SpecialType specialType = thirdWord.Equals(LocationsKey.AsSpan(), StringComparison.OrdinalIgnoreCase) ? SpecialType.Location : SpecialType.None;
                    parts = new ResourceIdentifierParts(parent, new ResourceType(secondWord.ToString(), thirdWord.ToString()), fourthWord.ToString(), true, specialType);
                    return null;
                }
            }
            else
            {
                nextWord = thirdWord;
                parts = new ResourceIdentifierParts(parent, ChooseResourceType(firstWord, parent, out SpecialType specialType), secondWord.ToString(), false, specialType);
                return null;
            }

            return "Invalid resource id.";
        }

        private static ReadOnlySpan<char> PopNextWord(scoped ref ReadOnlySpan<char> remaining)
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
        public ResourceType ResourceType => GetValue(ref _resourceType);

        /// <summary>
        /// The name of the resource.
        /// </summary>
        public string Name => GetValue(ref _name);

        /// <summary>
        /// The immediate parent containing this resource.
        /// </summary>
        public ResourceIdentifier? Parent => GetValue(ref _parent);

        /// <summary>
        /// Determines whether this resource is in the same namespace as its parent.
        /// </summary>
        internal bool IsProviderResource => GetValue(ref _isProviderResource);

        /// <summary>
        /// Gets the subscription id if it exists otherwise null.
        /// </summary>
        public string? SubscriptionId => GetValue(ref _subscriptionId);

        /// <summary>
        /// Gets the provider namespace if it exists otherwise null.
        /// </summary>
        public string? Provider => GetValue(ref _provider);

        /// <summary>
        /// Gets the location if it exists otherwise null.
        /// </summary>
        public AzureLocation? Location => GetValue(ref _location);

        /// <summary>
        /// The name of the resource group if it exists otherwise null.
        /// </summary>
        public string? ResourceGroupName => GetValue(ref _resourceGroupName);

        private string ToResourceString()
        {
            if (Parent is null)
                return string.Empty;

            string initial = Parent == Root ? string.Empty : Parent.StringValue;

            StringBuilder builder = new StringBuilder(initial);
            if (!IsProviderResource)
            {
                builder.Append('/').Append(ResourceType.GetLastType());
                if (!string.IsNullOrWhiteSpace(Name))
                    builder.Append('/').Append(Name);
            }
            else
            {
                builder.Append(ProviderStart).Append(ResourceType).Append('/').Append(Name);
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
        /// <returns> 0 if the resource identifiers are equivalent, less than 0 if this resource identifier
        /// should be ordered before the given resource identifier, greater than 0 if this resource identifier
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
        /// Converts the string representation of a ResourceIdentifier to the equivalent <see cref="ResourceIdentifier"/> structure.
        /// </summary>
        /// <param name="input"> The id string to convert. </param>
        /// <returns> A class that contains the value that was parsed. </returns>
        /// <exception cref="FormatException"> when resourceId is not a valid <see cref="ResourceIdentifier"/> format. </exception>
        /// <exception cref="ArgumentNullException"> when resourceId is null. </exception>
        /// <exception cref="ArgumentException"> when resourceId is empty. </exception>
        public static ResourceIdentifier Parse(string input)
        {
            var result = new ResourceIdentifier(input);
            var error = result.Parse();
            if (error is not null)
                throw new FormatException(error);
            return result;
        }

        /// <summary>
        /// Converts the string representation of a ResourceIdentifier to the equivalent <see cref="ResourceIdentifier"/> structure.
        /// </summary>
        /// <param name="input"> The id string to convert. </param>
        /// <param name="result">
        /// The structure that will contain the parsed value.
        /// If the method returns true result contains a valid ResourceIdentifier.
        /// If the method returns false, result will be null.
        /// </param>
        /// <returns> True if the parse operation was successful; otherwise, false. </returns>
        public static bool TryParse(string? input, out ResourceIdentifier? result)
        {
            result = null;
            if (string.IsNullOrEmpty(input))
                return false;

            result = new ResourceIdentifier(input!);
            var error = result.Parse();
            if (error is null)
                return true;

            result = null;
            return false;
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
            SpecialType specialType = resourceType.Equals(LocationsKey, StringComparison.OrdinalIgnoreCase) ? SpecialType.Location : SpecialType.None;
            return new ResourceIdentifier(this, new ResourceType(providerNamespace, resourceType), resourceName, true, specialType);
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
            return new ResourceIdentifier(this, ChooseResourceType(childResourceType.AsSpan(), this, out SpecialType specialType), childResourceName, false, specialType);
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
