// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all character filters supported by Azure Search.
    /// <see href="https://msdn.microsoft.com/library/azure/mt605304.aspx"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<CharFilterName>))]
    public sealed class CharFilterName : ExtensibleEnum<CharFilterName>
    {
        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://msdn.microsoft.com/library/azure/mt605304.aspx

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
        public static CharFilterName Create(string name)
        {
            // Character filter names are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new CharFilterName(name);
        }
    }
}
