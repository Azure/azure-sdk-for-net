// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// A complex field or collection of complex fields that contain child fields.
    /// Child fields may be <see cref="SimpleField"/> or <see cref="ComplexField"/>.
    /// </summary>
    public class ComplexField : SearchFieldTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="collection">Whether the field is a collection of strings.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public ComplexField(string name, bool collection = false) : base(name, collection ? SearchFieldDataType.Collection(SearchFieldDataType.Complex) : SearchFieldDataType.Complex)
        {
        }

        /// <summary>
        /// Gets a collection of <see cref="SimpleField"/> or <see cref="ComplexField"/> child fields.
        /// </summary>
        public IList<SearchFieldTemplate> Fields { get; } = new List<SearchFieldTemplate>();

        /// <inheritdoc/>
        private protected override void Save(SearchField field)
        {
            IList<SearchField> fields = field.Fields;
            foreach (SearchFieldTemplate child in Fields)
            {
                fields.Add(child);
            }
        }
    }
}
