// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the format of a Azure Search synonymmap.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<SynonymMapFormat>))]
    public sealed class SynonymMapFormat : ExtensibleEnum<SynonymMapFormat>
    {
        /// <summary>
        /// Indicates Solr synonyms format
        /// </summary>
        public static readonly SynonymMapFormat Solr = new SynonymMapFormat("solr");

        private SynonymMapFormat(string formatName) : base(formatName)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new SynonymMapFormat instance, or returns an existing instance if the given name matches that of a
        /// known synonym format.
        /// </summary>
        /// <param name="name">Name of the synonym map format.</param>
        /// <returns>A SynonymMapFormat instance with the given name.</returns>
        public static SynonymMapFormat Create(string name) => Lookup(name) ?? new SynonymMapFormat(name);

        /// <summary>
        /// Defines implicit conversion from string to SynonymMapFormat.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a SynonymMapFormat.</returns>
        public static implicit operator SynonymMapFormat(string name) => Create(name);
    }
}
