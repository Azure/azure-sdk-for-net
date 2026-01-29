// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
     public partial class SynonymMap
    {
        [CodeGenMember("ETag")]
        private string _etag;

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="reader">
        /// A <see cref="TextReader"/> from which formatted synonyms are read.
        /// Because only the "solr" synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="reader"/> is null.</exception>
        public SynonymMap(string name, TextReader reader)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(reader, nameof(reader));

            Name = name;
            Synonyms = reader.ReadToEnd();
        }

        /// <summary>
        /// The <see cref="global::Azure.ETag"/> of the <see cref="SynonymMap"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary> The format of the synonym map. Only the "solr" format is currently supported. </summary>
        internal string Format { get; } = "solr";
    }
}
