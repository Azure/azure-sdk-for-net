// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Structure representing a resource type
    /// </summary>
    public sealed class ResourceType : IEquatable<ResourceType>, IEquatable<string>, IComparable<ResourceType>,
        IComparable<string>
    {
        /// <summary>
        /// The "none" resource type
        /// </summary>
        public static readonly ResourceType None = new ResourceType { Namespace = string.Empty, Type = string.Empty };

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        /// <param name="resourceIdOrType"> Option to provide the Resource Type directly, or a Resource ID from which the type is going to be obtained. </param>
        public ResourceType(string resourceIdOrType)
        {
            if (string.IsNullOrWhiteSpace(resourceIdOrType))
                throw new ArgumentException($"{nameof(resourceIdOrType)} cannot be null or whitespace", nameof(resourceIdOrType));

            Parse(resourceIdOrType);
        }

        private ResourceType()
        {
        }

        /// <summary>
        /// Gets the resource type Namespace.
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// Gets the resource Type.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the resource type Parent.
        /// </summary>
        public ResourceType Parent
        {
            get
            {
                var parts = Type.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 2)
                    return None;

                var list = new List<string>(parts);
                list.RemoveAt(list.Count - 1);

                return new ResourceType($"{Namespace}/{string.Join("/", list.ToArray())}");
            }
        }

        /// <summary>
        /// Implicit operator for initializing a <see cref="ResourceType"/> instance from a string.
        /// </summary>
        /// <param name="other"> String to be conferted into a <see cref="ResourceType"/> object. </param>
        public static implicit operator ResourceType(string other)
        {
            if (other is null)
                return null;

            return new ResourceType(other);
        }

        /// <summary>
        /// Compares a <see cref="ResourceType"/> object with a <see cref="string"/>.
        /// </summary>
        /// <param name="source"> <see cref="ResourceType"/> object. </param>
        /// <param name="target"> String. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool operator ==(ResourceType source, string target)
        {
            if (source is null)
                return target is null;

            return source.Equals(target);
        }

        /// <summary>
        /// Compares a <see cref="string"/> with a <see cref="ResourceType"/> object.
        /// </summary>
        /// <param name="source"> String representation of a ResourceType. </param>
        /// <param name="target"> <see cref="ResourceType"/> object. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool operator ==(string source, ResourceType target)
        {
            if (target is null)
                return source is null;

            return target.Equals(source);
        }

        /// <summary>
        /// Compares two <see cref="ResourceType"/> objects.
        /// </summary>
        /// <param name="source"> First <see cref="ResourceType"/> object. </param>
        /// <param name="target"> Second <see cref="ResourceType"/> object. </param>
        /// <returns> True if they are equal, otherwise False. </returns>
        public static bool operator ==(ResourceType source, ResourceType target)
        {
            if (source is null)
                return target is null;

            return source.Equals(target);
        }

        /// <summary>
        /// Compares a <see cref="ResourceType"/> object with a <see cref="string"/>.
        /// </summary>
        /// <param name="source"> <see cref="ResourceType"/> object. </param>
        /// <param name="target"> String representation of a ResourceType. </param>
        /// <returns> False if they are equal, otherwise True. </returns>
        public static bool operator !=(ResourceType source, string target)
        {
            if (source is null)
                return !(target is null);

            return !source.Equals(target);
        }

        /// <summary>
        /// Compares a <see cref="string"/> with a <see cref="ResourceType"/> object.
        /// </summary>
        /// <param name="source"> String. </param>
        /// <param name="target"> <see cref="ResourceType"/> object. </param>
        /// <returns> False if they are equal, otherwise True. </returns>
        public static bool operator !=(string source, ResourceType target)
        {
            if (target is null)
                return !(source is null);

            return !target.Equals(source);
        }

        /// <summary>
        /// Compares two <see cref="ResourceType"/> objects.
        /// </summary>
        /// <param name="source"> First <see cref="ResourceType"/> object. </param>
        /// <param name="target"> Second <see cref="ResourceType"/> object. </param>
        /// <returns> False if they are equal, otherwise True. </returns>
        public static bool operator !=(ResourceType source, ResourceType target)
        {
            if (source is null)
                return !(target is null);

            return !source.Equals(target);
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

            int compareResult = 0;
            if ((compareResult = string.Compare(Namespace, other.Namespace, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Type, other.Type, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (other.Parent != null))
            {
                return Parent.CompareTo(other.Parent);
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="ResourceType"/> with a resource type representation as a string.
        /// </summary>
        /// <param name="other"> String to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(string other)
        {
            if (other is null)
                return 1;

            return CompareTo(new ResourceType(other));
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

        /// <summary>
        /// Compares this <see cref="ResourceType"/> instance with a string and determines if they are equals.
        /// </summary>
        /// <param name="other"> String to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(string other)
        {
            if (other is null)
                return false;

            return string.Equals(ToString(), other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Namespace}/{Type}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            var resourceObj = obj as ResourceType;

            if (resourceObj != null)
                return Equals(resourceObj);

            var stringObj = obj as string;

            if (stringObj != null)
                return Equals(stringObj);

            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Helper method to determine if the given string is a Resource ID or a Type,
        /// and then assign the proper values to the <see cref="ResourceType"/> class properties.
        /// </summary>
        /// <param name="resourceIdOrType"> String to be parsed. </param>
        private void Parse(string resourceIdOrType)
        {
            // Note that this code will either parse a resource id to find the type, or a resource type
            resourceIdOrType = resourceIdOrType.Trim('/');

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

            // Handle resource identifiers from RPs (they have the /providers path segment)
            if (parts.Contains(KnownKeys.ProviderNamespace))
            {
                // it is a resource id from a provider
                var index = parts.LastIndexOf(KnownKeys.ProviderNamespace);
                for (var i = index; i >= 0; --i)
                {
                    parts.RemoveAt(i);
                }

                if (parts.Count < 3)
                    throw new ArgumentOutOfRangeException(nameof(resourceIdOrType), "Invalid resource id.");

                var type = new List<string>();
                for (var i = 1; i < parts.Count; i += 2)
                {
                    type.Add(parts[i]);
                }

                Namespace = parts[0];
                Type = string.Join("/", type);
            }

            // Handle resource types (Micsrsoft.Compute/virtualMachines, Microsoft.Network/virtualNetworks/subnets)
            else if (parts[0].Contains('.'))
            {
                // it is a full type name
                Namespace = parts[0];
                Type = string.Join("/", parts.Skip(Math.Max(0, 1)).Take(parts.Count - 1));
            }

            // Handle built-in resource ids (e.g. /subscriptions/{sub}, /subscriptions/{sub}/resourceGroups/{rg})
            else if (parts.Count % 2 == 0)
            {
                // primitive resource manager resource id
                Namespace = "Microsoft.Resources";
                Type = parts[parts.Count - 2];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(resourceIdOrType));
            }
        }
    }
}
