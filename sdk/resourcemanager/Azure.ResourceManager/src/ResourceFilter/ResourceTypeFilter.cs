// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager
{
    /// <summary>
    /// A class representing a resource type filter used in Azure API calls.
    /// </summary>
    public class ResourceTypeFilter : GenericResourceFilter, IEquatable<ResourceTypeFilter>, IEquatable<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceTypeFilter"/> class.
        /// </summary>
        /// <param name="resourceType"> The resource type to filter by. </param>
        /// <exception cref="ArgumentNullException"> If <see cref="ResourceType"/> is null. </exception>
        public ResourceTypeFilter(ResourceType resourceType)
        {
            ResourceType = resourceType;
        }

        /// <summary>
        /// Gets the resource type to filter by.
        /// </summary>
        public ResourceType ResourceType { get; }

        /// <inheritdoc/>
        public bool Equals(string other)
        {
            return ResourceType.Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(ResourceTypeFilter other)
        {
            return ResourceType.Equals(other);
        }

        /// <inheritdoc/>
        public override string GetFilterString()
        {
            return $"resourceType EQ '{ResourceType}'";
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            if (obj is string other)
                return Equals(other);

            return Equals(obj as ResourceTypeFilter);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return ResourceType.GetHashCode();
        }
    }
}
