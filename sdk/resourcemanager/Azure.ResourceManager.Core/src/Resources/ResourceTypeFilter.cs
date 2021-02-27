// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core.Resources
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
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Equals(ResourceTypeFilter other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override string GetFilterString()
        {
            return $"resourceType EQ '{ResourceType}'";
        }
    }
}
