// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Core
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    /// <remarks> See https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/resource-providers-and-types for more info. </remarks>
    public readonly struct ResourceType : IEquatable<ResourceType>
    {
        private readonly string _stringValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        /// <param name="resourceType"> The resource type string to convert. </param>
        public ResourceType(string resourceType)
        {
            Argument.AssertNotNullOrWhiteSpace(resourceType, nameof(resourceType));

            int index = resourceType.IndexOf(ResourceIdentifier.Separator);
            if (index == -1 || resourceType.Length <3)
                throw new ArgumentOutOfRangeException(nameof(resourceType));

            _stringValue = resourceType;
            Namespace = resourceType.Substring(0, index);
            Type = resourceType.Substring(index + 1);
        }

        /// <summary>
        /// Create a resource type given the namespace and typename components.
        /// </summary>
        /// <param name="providerNamespace"></param>
        /// <param name="name"></param>
        internal ResourceType(string providerNamespace, string name)
        {
            Namespace = providerNamespace;
            Type = name;
            _stringValue = $"{Namespace}{ResourceIdentifier.Separator}{Type}";
        }

        internal ResourceType AppendChild(string childType)
        {
            return new ResourceType($"{_stringValue}{ResourceIdentifier.Separator}{childType}");
        }

        /// <summary>
        /// Gets the last resource type name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetLastType() => Type.Substring(Type.LastIndexOf(ResourceIdentifier.Separator) + 1);

        /// <summary>
        /// Gets the resource type Namespace.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// Gets the resource Type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Implicit operator for initializing a <see cref="ResourceType"/> instance from a string.
        /// </summary>
        /// <param name="other"> String to be converted into a <see cref="ResourceType"/> object. </param>
        public static implicit operator ResourceType(string other)
        {
            return new ResourceType(other);
        }

        /// <summary>
        /// Implicit operator for initializing a string from a <see cref="ResourceType"/>.
        /// </summary>
        /// <param name="other"> <see cref="ResourceType"/> to be converted into a string. </param>
        public static implicit operator string(ResourceType other)
        {
            return other._stringValue;
        }

        /// <summary>
        /// Compares two <see cref="ResourceType"/> objects.
        /// </summary>
        /// <param name="left"> First <see cref="ResourceType"/> object. </param>
        /// <param name="right"> Second <see cref="ResourceType"/> object. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool operator ==(ResourceType left, ResourceType right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="ResourceType"/> objects.
        /// </summary>
        /// <param name="left"> First <see cref="ResourceType"/> object. </param>
        /// <param name="right"> Second <see cref="ResourceType"/> object. </param>
        /// <returns> False if they are equal, otherwise True. </returns>
        public static bool operator !=(ResourceType left, ResourceType right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Compares this <see cref="ResourceType"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="ResourceType"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(ResourceType other)
        {
            return _stringValue.Equals(other._stringValue, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _stringValue;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? other)
        {
            if (other is null)
                return false;

            if (other is ResourceType resourceObj)
                return Equals(resourceObj);

            var stringObj = other as string;

            if (stringObj is not null)
                return Equals(stringObj);

            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(_stringValue);
        }
    }
}
