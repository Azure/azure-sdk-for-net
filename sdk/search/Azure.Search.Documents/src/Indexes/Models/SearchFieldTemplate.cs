// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// Base field type for helper classes to more easily create a <see cref="SearchIndex"/>.
    /// </summary>
    public abstract class SearchFieldTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFieldTemplate"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="type">The data type of the field.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        private protected SearchFieldTemplate(string name, SearchFieldDataType type)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
            Type = type;
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the data type of the field.
        /// </summary>
        public SearchFieldDataType Type { get; }

        /// <summary>
        /// Persists class-specific properties into the given <see cref="SearchField"/>.
        /// </summary>
        /// <param name="field">The <see cref="SearchField"/> into which properties are persisted.</param>
        private protected abstract void Save(SearchField field);

        /// <summary>
        /// Casts a <see cref="SearchFieldTemplate"/> or derivative to a <see cref="SearchField"/>.
        /// </summary>
        /// <param name="value">The <see cref="SearchFieldTemplate"/> or derivative to cast.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public static implicit operator SearchField(SearchFieldTemplate value)
        {
            Argument.AssertNotNull(value, nameof(value));

            SearchField field = new SearchField(value.Name, value.Type);
            value.Save(field);

            return field;
        }
    }
}
