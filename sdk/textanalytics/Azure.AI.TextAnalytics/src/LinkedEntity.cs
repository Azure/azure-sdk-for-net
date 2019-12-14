// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified from the input text as important, as well
    /// as a link to an entry in a data source that can be used to disambiguate
    /// the word or phrase.  The entity name may be different from the exact
    /// text match in the input document.  <see cref="LinkedEntity"/> has a
    /// collection of matches identifying the specific substring corresponding
    /// to the inferred entity.
    /// </summary>
    public readonly struct LinkedEntity
    {
        internal LinkedEntity(string name, string id, string language, string dataSource, Uri uri, IEnumerable<LinkedEntityMatch> matches)
        {
            Name = name;
            Id = id;
            Language = language;
            DataSource = dataSource;
            Uri = uri;
            Matches = matches;
        }

        /// <summary>
        /// Gets the formal name of the entity.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the unique identifier of the entity in the data source.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the language used in the data source.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets the name of the data source used to extract the entity linking.
        /// </summary>
        public string DataSource { get; }

        /// <summary>
        /// Gets the URI that identifies the linked entity's entry in the data source.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// Collection identifying the substrings of the document that correspond
        /// to this linked entity.
        /// </summary>
        public IEnumerable<LinkedEntityMatch> Matches { get; }
    }
}
