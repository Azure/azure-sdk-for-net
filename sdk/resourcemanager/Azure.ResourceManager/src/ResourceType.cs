// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    public sealed class ResourceType : IEquatable<ResourceType>, IComparable<ResourceType>
    {
        /// <summary>
        /// The resource type for the root of the resource hierarchy.
        /// </summary>
        public static ResourceType Root => new ResourceType(string.Empty, string.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        /// <param name="resourceIdOrType"> Option to provide the Resource Type directly, or a Resource ID from which the type is going to be obtained. </param>
        public ResourceType(string resourceIdOrType)
        {
            if (string.IsNullOrWhiteSpace(resourceIdOrType))
                throw new ArgumentException($"{nameof(resourceIdOrType)} cannot be null or whitespace", nameof(resourceIdOrType));

            Parse(resourceIdOrType);
            Types = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
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
            Types = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Create child resource type using parent resource type
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childType"></param>
        internal ResourceType(ResourceType parent, string childType)
            : this(parent.Namespace, $"{parent.Type}/{childType}")
        {
        }

        internal string LastType => Types[Types.Count - 1];

        /// <summary>
        /// Gets the resource type Namespace.
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// Gets the resource Type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the resource Types.
        /// </summary>
        public IReadOnlyList<string> Types { get; } = new List<string>();

        /// <summary>
        /// Determines if this resource type is the parent of the given resource.
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool IsParentOf(ResourceType child)
        {
            if (!string.Equals(Namespace, child.Namespace, StringComparison.InvariantCultureIgnoreCase))
                return false;
            var types = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var childTypes = child.Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (types.Length >= childTypes.Length)
                return false;
            for (int i = 0; i < types.Length; ++i)
            {
                if (!string.Equals(types[i], childTypes[i], StringComparison.InvariantCultureIgnoreCase))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Implicit operator for initializing a <see cref="ResourceType"/> instance from a string.
        /// </summary>
        /// <param name="other"> String to be converted into a <see cref="ResourceType"/> object. </param>
        public static implicit operator ResourceType(string other)
        {
            if (other is null)
                return null;

            return new ResourceType(other);
        }

        /// <summary>
        /// Implicit operator for initializing a string from a <see cref="ResourceType"/>.
        /// </summary>
        /// <param name="other"> <see cref="ResourceType"/> to be converted into a string. </param>
        public static implicit operator string(ResourceType other)
        {
            if (other is null)
                return null;

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
            if (left is null)
                return right is null;

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
            return !(left == right);
        }

        /// <summary>
        /// Compares this <see cref="ResourceType"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="ResourceType"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(ResourceType other)
        {
            if (other is null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            int compareResult = string.Compare(Namespace, other.Namespace, StringComparison.InvariantCultureIgnoreCase);
            if (compareResult == 0)
            {
                compareResult = string.Compare(Type, other.Type, StringComparison.InvariantCultureIgnoreCase);
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="ResourceType"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="ResourceType"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(ResourceType other)
        {
            if (other is null)
                return false;

            return string.Equals(ToString(), other.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Namespace}/{Type}";
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other is null)
                return false;

            var resourceObj = other as ResourceType;

            if (resourceObj is not null)
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
            return ToString().ToLower(CultureInfo.InvariantCulture).GetHashCode();
        }

        /// <summary>
        /// Helper method to determine if the given string is a Resource ID or a Type,
        /// and then assign the proper values to the <see cref="ResourceType"/> class properties.
        /// </summary>
        /// <param name="resourceIdOrType"> String to be parsed. </param>
        private void Parse(string resourceIdOrType)
        {
            // split the path into segments
            var parts = resourceIdOrType.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // There must be at least a namespace and type name
            if (parts.Count < 1)
                throw new ArgumentOutOfRangeException(nameof(resourceIdOrType));

            // if the type is just subscriptions, it is a built-in type in the Microsoft.Resources namespace
            if (parts.Count == 1)
            {
                // Simple resource type
                Type = parts[0];
                Namespace = "Microsoft.Resources";
            }

            // Handle resource types (Microsoft.Compute/virtualMachines, Microsoft.Network/virtualNetworks/subnets)
            // Type
            else if (parts[0].Contains('.'))
            {
                // it is a full type name
                Namespace = parts[0];
                Type = string.Join("/", parts.Skip(1).Take(parts.Count - 1));
            }

            // Check if ResourceIdentifier
            else
            {
                ResourceIdentifier id = new ResourceIdentifier(resourceIdOrType);
                Type = id.ResourceType.Type;
                Namespace = id.ResourceType.Namespace;
            }
        }

        /// <summary>
        /// Compares one <see cref="ResourceType"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than the right. </returns>
        public static bool operator <(ResourceType left, ResourceType right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceType"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is less than or equal to the right. </returns>
        public static bool operator <=(ResourceType left, ResourceType right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceType"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than the right. </returns>
        public static bool operator >(ResourceType left, ResourceType right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Compares one <see cref="ResourceType"/> with another instance.
        /// </summary>
        /// <param name="left"> The object on the left side of the operator. </param>
        /// <param name="right"> The object on the right side of the operator. </param>
        /// <returns> True if the left object is greater than or equal to the right. </returns>
        public static bool operator >=(ResourceType left, ResourceType right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
