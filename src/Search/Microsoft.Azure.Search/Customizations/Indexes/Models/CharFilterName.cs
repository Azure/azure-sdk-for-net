// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all character filters supported by Azure Search.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<CharFilterName>))]
    public sealed class CharFilterName : ExtensibleEnum<CharFilterName>
    {
        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search

        /// <summary>
        /// A character filter that attempts to strip out HTML constructs.
        /// <see href="https://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/charfilter/HTMLStripCharFilter.html" />
        /// </summary>
        public static readonly CharFilterName HtmlStrip = new CharFilterName("html_strip");

        private CharFilterName(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new CharFilterName instance, or returns an existing instance if the given name matches that of a
        /// known character filter.
        /// </summary>
        /// <param name="name">Name of the character filter.</param>
        /// <returns>A CharFilterName instance with the given name.</returns>
        public static CharFilterName Create(string name) => Lookup(name) ?? new CharFilterName(name);

        /// <summary>
        /// Defines implicit conversion from string to CharFilterName.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a CharFilterName.</returns>
        public static implicit operator CharFilterName(string name) => Create(name);
    }
}
