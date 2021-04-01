// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    public sealed class ResourceType : IEquatable<ResourceType>, IComparable<ResourceType>
    {
        /// <summary>
        /// The resource type for the root of the resource hierarchy.
        /// </summary>
        public static ResourceType RootResourceType => new ResourceType(string.Empty, string.Empty);

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

        internal IList<string> Types { get; } = new List<string>();

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
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            var resourceObj = obj as ResourceType;

            if (!(resourceObj is null))
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
            if (parts.Contains(KnownKeys.ProviderNamespace) && !KnownKeys.ProviderNamespace.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase))
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
            else if (KnownKeys.ProviderNamespace.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase))
            {
                if (parts.Count < 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(resourceIdOrType));
                }
                if (!parts[1].Contains('.'))
                {
                    throw new ArgumentOutOfRangeException(nameof(resourceIdOrType));
                }
                Namespace = parts[1];

                Type = string.Join("/", parts.Skip(2).Take(parts.Count - 3));
            }
            // Handle resource types (Micsrsoft.Compute/virtualMachines, Microsoft.Network/virtualNetworks/subnets)
            else if (parts[0].Contains('.'))
            {
                // it is a full type name
                Namespace = parts[0];
                Type = string.Join("/", parts.Skip(1).Take(parts.Count - 1));
            }

            // Handle built-in resource ids (e.g. /subscriptions/{sub}, /subscriptions/{sub}/resourceGroups/{rg})
            else if (parts.Count % 2 == 0)
            {
                // primitive resource manager resource id
                Namespace = "Microsoft.Resources";
                Type = parts[parts.Count - 2];
            }
            else if (KnownKeys.Tenant.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase))
            {
                Namespace = "providers";
                Type = parts[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(resourceIdOrType));
            }
        }
    }
}
