// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("Index")]
    public partial class SearchIndex
    {
        private List<SearchField> _fields;

        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndex"/> class.
        /// </summary>
        /// <param name="name">The name of the index.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SearchIndex(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;

            _fields = new List<SearchField>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndex"/> class.
        /// </summary>
        /// <param name="name">The name of the index.</param>
        /// <param name="fields">Fields to add to the index.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="fields"/> is null.</exception>
        public SearchIndex(string name, IEnumerable<SearchField> fields) : this(name)
        {
            Argument.AssertNotNull(fields, nameof(fields));

            // We define the field as List<SearchField> to take advantage of its faster AddRange.
            _fields.AddRange(fields);
        }

        // TODO: Remove when https://github.com/Azure/autorest.csharp/issues/582 is fixed.
        private SearchIndex()
        {
        }

        /// <summary>
        /// Gets the name of the index.
        /// </summary>
        [CodeGenMember("name")]
        public string Name { get; }

        // TODO: Remove read-only collection properties when https://github.com/Azure/autorest.csharp/issues/521 is fixed.

        /// <summary>
        /// Gets the fields in the index.
        /// Use <see cref="SimpleField"/>, <see cref="SearchableField"/>, and <see cref="ComplexField"/> for help defining valid indexes.
        /// Index fields have many constraints that are not validated with <see cref="SearchField"/> until the index is created on the server.
        /// </summary>
        [CodeGenMember("fields")]
        public IList<SearchField> Fields
        {
            get => _fields;

            // Make a shallow copy of the fields.
            internal set => _fields = new List<SearchField>(value ?? throw new ArgumentNullException(nameof(value)));
        }
    }
}
