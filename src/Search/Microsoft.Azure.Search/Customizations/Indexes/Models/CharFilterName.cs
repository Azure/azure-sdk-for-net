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
        /// </summary>
        public static readonly CharFilterName HtmlStrip = new CharFilterName("html_strip");

        /// <summary>
        /// A character filter that applies mappings defined with the mappings
        /// option. Matching is greedy (longest pattern matching at a given point
        /// wins). Replacement is allowed to be the empty string.
        /// </summary>
        public static readonly CharFilterName Mapping = new CharFilterName("mapping");

        /// <summary>
        /// A character filter that replaces characters in the input string. It
        /// uses a regular expression to identify character sequences to preserve
        /// and a replacement pattern to identify characters to replace. For
        /// example, given the input text "aa bb aa bb", pattern
        /// "(aa)\s+(bb)", and replacement "$1#$2", the result would be
        /// "aa#bb aa#bb".
        /// </summary>
        public static readonly CharFilterName PatternReplace = new CharFilterName("pattern_replace");

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
