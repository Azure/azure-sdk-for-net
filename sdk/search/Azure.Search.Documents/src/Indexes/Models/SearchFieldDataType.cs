// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public readonly partial struct SearchFieldDataType
    {
        private const string CollectionPrefix = "Collection(";

        /// <summary>
        /// Gets a <see cref="SearchFieldDataType"/> representing a collection of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of collection.</param>
        /// <returns>A <see cref="SearchFieldDataType"/> representing a collection of <paramref name="type"/>.</returns>
        public static SearchFieldDataType Collection(SearchFieldDataType type) => type.IsCollection ? type : new SearchFieldDataType(string.Concat(CollectionPrefix, type._value, ")"));

        /// <summary>
        /// Gets a value indicating whether the <see cref="SearchFieldDataType"/> represents a collection.
        /// </summary>
        public bool IsCollection => _value.StartsWith(CollectionPrefix, StringComparison.InvariantCultureIgnoreCase);
    }
}
