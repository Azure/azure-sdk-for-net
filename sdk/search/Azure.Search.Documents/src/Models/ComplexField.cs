// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// A complex field or collection of complex fields that contain child fields.
    /// Child fields may be <see cref="SimpleField"/> or <see cref="ComplexField"/>.
    /// </summary>
    public class ComplexField : FieldBase, IEnumerable<FieldBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="collection">Whether the field is a collection of strings.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public ComplexField(string name, bool collection = false) : base(name, collection ? DataType.Collection(DataType.Complex) : DataType.Complex)
        {
        }

        /// <summary>
        /// Gets a collection of <see cref="SimpleField"/> or <see cref="ComplexField"/> child fields.
        /// </summary>
        public IList<FieldBase> Fields { get; } = new List<FieldBase>();

        /// <summary>
        /// Adds a child <see cref="SimpleField"/> or <see cref="ComplexField"/>.
        /// </summary>
        /// <param name="field">The <see cref="SimpleField"/> or <see cref="ComplexField"/> to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="field"/> is null.</exception>
        public void Add(FieldBase field)
        {
            Argument.AssertNotNull(field, nameof(field));

            Fields.Add(field);
        }

        /// <inheritdoc/>
        protected override void Save(SearchField field)
        {
            foreach (FieldBase child in Fields)
            {
                field.Fields.Add(child);
            }
        }

        IEnumerator<FieldBase> IEnumerable<FieldBase>.GetEnumerator() => Fields.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Fields.GetEnumerator();
    }
}
