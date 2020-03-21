// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Represents a field in an index definition, which describes the name, data type, and search behavior of a field.
    /// <para>
    /// When creating an index, instead use the <see cref="SimpleField"/> and <see cref="ComplexField"/> classes to help you more easily create a <see cref="SearchIndex"/>.
    /// </para>
    /// </summary>
    [CodeGenModel("Field")]
    public partial class SearchField
    {
        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchField"/> class.
        /// </summary>
        /// <param name="name">The name of the field, which must be unique within the index or parent field.</param>
        /// <param name="type">The data type of the field.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SearchField(string name, DataType type)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
            Type = type;
        }

        private SearchField()
        {
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        [CodeGenMember("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Ge the data type of the field.
        /// </summary>
        [CodeGenMember("type")]
        public DataType Type { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field can be returned in a search result.
        /// You can disable this option if you want to use a field (for example, margin) as a filter, sorting, or scoring mechanism but do not want the field to be visible to the end user.
        /// This property must be false for key fields, and it must be null for complex fields.
        /// This property can be changed on existing fields.
        /// Enabling this property does not cause any increase in index storage requirements.
        /// Default is false for simple fields and null for complex fields.
        /// </summary>
        [CodeGenMember("retrievable")]
        public bool? IsHidden { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"{Name} : {Type}";
    }
}
