// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core.Resources
{
    /// <summary>
    /// A class representing a substring filter used in Azure API calls.
    /// </summary>
    public class ResourceNameFilter : GenericResourceFilter, IEquatable<ResourceNameFilter>, IEquatable<string>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Converts a string into an <see cref="ResourceNameFilter"/>.
        /// </summary>
        /// <param name="nameString"> The string that can be match in any part of the resource name. </param>
        public static implicit operator ResourceNameFilter(string nameString)
        {
            if (nameString is null)
                return null;

            return new ResourceNameFilter { Name = nameString };
        }

        /// <inheritdoc/>
        public bool Equals(string other)
        {
            if (other is null)
                return false;

            return string.Equals(other, Name);
        }

        /// <inheritdoc/>
        public bool Equals(ResourceNameFilter other)
        {
            if (other is null)
                return false;

            return string.Equals(other.Name, Name);
        }

        /// <inheritdoc/>
        public override string GetFilterString()
        {
            var builder = new List<string>();
            if (!string.IsNullOrWhiteSpace(Name))
            {
                builder.Add($"substringof('{Name}', name)");
            }

            if (!string.IsNullOrWhiteSpace(ResourceGroup))
            {
                builder.Add($"substringof('{ResourceGroup}', name)");
            }

            return string.Join(" and ", builder);
        }
    }
}
