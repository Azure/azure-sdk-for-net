// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenSuppress(nameof(SynonymMap), typeof(string), typeof(string))]
    public partial class SynonymMap
    {
        private const string DefaultFormat = "solr";

        // TODO: Replace constructor and read-only properties when https://github.com/Azure/autorest.csharp/issues/554 is fixed.

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="synonyms">
        /// The formatted synonyms string to define.
        /// Because only the Solr synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="synonyms"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="synonyms"/> is null.</exception>
        public SynonymMap(string name, string synonyms)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(synonyms, nameof(synonyms));

            Name = name;
            Format = DefaultFormat;
            Synonyms = synonyms;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="reader">
        /// A <see cref="TextReader"/> from which formatted synonyms are read.
        /// Because only the Solr synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="reader"/> is null.</exception>
        public SynonymMap(string name, TextReader reader)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(reader, nameof(reader));

            Name = name;
            Format = DefaultFormat;
            Synonyms = reader.ReadToEnd();
        }

        /// <summary>
        /// Canonicalizes property names from how they appear on <see cref="SynonymMap"/> to those expected by the Search service.
        /// </summary>
        /// <param name="names">The given property names.</param>
        /// <returns>Canonicalized property names expected by the Search service, or null if <paramref name="names"/> is null.</returns>
        internal static IEnumerable<string> CanonicalizePropertyNames(IEnumerable<string> names) =>
            // TODO: Replace when https://github.com/Azure/azure-sdk-for-net/issues/11393 is resolved.
            names?.Select(name =>
            {
                if (string.Equals("name", name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "name";
                }

                if (string.Equals("format", name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "format";
                }

                if (string.Equals("synonyms", name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "synonyms";
                }

                if (string.Equals("encryptionKey", name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "encryptionKey";
                }

                if (string.Equals("etag", name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return "@odata.etag";
                }

                return name;
            });
    }
}
