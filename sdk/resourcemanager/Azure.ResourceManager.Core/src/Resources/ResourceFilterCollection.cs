// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// A class representing a collection of arm filters.
    /// </summary>
    public sealed class ResourceFilterCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFilterCollection"/> class.
        /// </summary>
        public ResourceFilterCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFilterCollection"/> class.
        /// </summary>
        /// <param name="type"> The resource type to filter by. </param>
        public ResourceFilterCollection(ResourceType type)
        {
            ResourceTypeFilter = new ResourceTypeFilter(type);
        }

        /// <summary>
        /// Gets or sets the substring filter to use in the collection.
        /// </summary>
        public ResourceNameFilter SubstringFilter { get; set; }

        /// <summary>
        /// Gets the resource type filter to use in the collection.
        /// </summary>
        public ResourceTypeFilter ResourceTypeFilter { get; }

        /// <summary>
        /// Gets or sets the tag filter to use in the collection.
        /// </summary>
        public ResourceTagFilter TagFilter { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var builder = new List<string>();

            var substring = ResourceTypeFilter?.GetFilterString();
            if (!string.IsNullOrWhiteSpace(substring))
            {
                builder.Add(substring);
            }

            substring = SubstringFilter?.GetFilterString();
            if (!string.IsNullOrWhiteSpace(substring))
            {
                builder.Add(substring);
            }

            substring = TagFilter?.GetFilterString();
            if (!string.IsNullOrWhiteSpace(substring))
            {
                builder.Add(substring);
            }

            return $"{string.Join(" and ", builder)}";
        }
    }
}
