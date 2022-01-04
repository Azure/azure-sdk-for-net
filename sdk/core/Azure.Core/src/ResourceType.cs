// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Azure.Core
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    public readonly struct ResourceType : IEquatable<ResourceType>
    {
        /// <summary>
        /// The resource type for the root of the resource hierarchy.
        /// </summary>
        public static ResourceType Root { get; } = new ResourceType(string.Empty, string.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        /// <param name="resourceType"> The resource type string to convert. </param>
        public ResourceType(string resourceType)
        {
            if (string.IsNullOrWhiteSpace(resourceType))
                throw new ArgumentException($"{nameof(resourceType)} cannot be null or whitespace", nameof(resourceType));

            // split the path into segments
            var parts = resourceType.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            // There must be at least a namespace and type name
            if (parts.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(resourceType));

            Namespace = parts[0];
            Type = string.Join("/", parts.Skip(1).Take(parts.Length - 1));
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
        }

        internal ResourceType AppendChild(string childType)
        {
            return new ResourceType(Namespace, $"{Type}/{childType}");
        }

        /// <summary>
        /// Gets the last resource type name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetLastType()
        {
            var types = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return types[types.Length - 1];
        }

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
            return other.ToString();
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
            return string.Equals(ToString(), other.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Namespace}/{Type}";
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
            return StringComparer.OrdinalIgnoreCase.GetHashCode(ToString());
        }
    }
}
