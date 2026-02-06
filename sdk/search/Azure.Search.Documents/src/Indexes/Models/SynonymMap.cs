// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// <param name="synonyms">
        /// The formatted synonyms string to define.
        /// Because only the "solr" synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="synonyms"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="synonyms"/> is null.</exception>
        public SynonymMap(string name, string synonyms)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(synonyms, nameof(synonyms));

            Name = name;
            Synonyms = synonyms;
        }

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
            SynonymsList = [.. reader.ReadToEnd().Split('\n')];
        }

        /// <summary> Initializes a new instance of <see cref="SynonymMap"/>. </summary>
        /// <param name="name"> The name of the synonym map. </param>
        /// <param name="format"> The format of the synonym map. Only the 'solr' format is currently supported. </param>
        /// <param name="synonyms"> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data. Once you have encrypted your data, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="etag"> The ETag of the synonym map. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SynonymMap(string name, string format, string synonyms, SearchResourceEncryptionKey encryptionKey, string etag, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Format = format;
            Synonyms = synonyms;
            EncryptionKey = encryptionKey;
            _etag = etag;
            _additionalBinaryDataProperties = serializedAdditionalRawData;
        }

        /// <summary>
        /// The <see cref="global::Azure.ETag"/> of the <see cref="SynonymMap"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </summary>
        [CodeGenMember("Synonyms")]
        public IList<string> SynonymsList { get; private set; }

        /// <summary> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </summary>
        public string Synonyms { get => string.Join("\n", SynonymsList); set => SynonymsList = [.. value.Split('\n')]; }

        /// <summary> The format of the synonym map. Only the "solr" format is currently supported. </summary>
        internal string Format { get; } = "solr";
    }
}
