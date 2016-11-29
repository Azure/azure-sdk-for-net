﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all tokenizers supported by Azure Search.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<TokenizerName>))]
    public sealed class TokenizerName : ExtensibleEnum<TokenizerName>
    {
        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search

        /// <summary>
        /// Grammar-based tokenizer that is suitable for processing most
        /// European-language documents.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/ClassicTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Classic = new TokenizerName("classic");

        /// <summary>
        /// Tokenizes the input from an edge into n-grams of the given size(s).
        /// <see href="https://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/EdgeNGramTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName EdgeNGram = new TokenizerName("edgeNGram");

        /// <summary>
        /// Emits the entire input as a single token.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Keyword = new TokenizerName("keyword_v2");

        /// <summary>
        /// Divides text at non-letters.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/LetterTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Letter = new TokenizerName("letter");

        /// <summary>
        /// Divides text at non-letters and converts them to lower case.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/LowerCaseTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Lowercase = new TokenizerName("lowercase");

        /// <summary>
        /// Divides text using language-specific rules.
        /// </summary>
        public static readonly TokenizerName MicrosoftLanguageTokenizer = new TokenizerName("microsoft_language_tokenizer");

        /// <summary>
        /// Divides text using language-specific rules and reduces words to their base forms.
        /// </summary>
        public static readonly TokenizerName MicrosoftLanguageStemmingTokenizer = new TokenizerName("microsoft_language_stemming_tokenizer");

        /// <summary>
        /// Tokenizes the input into n-grams of the given size(s).
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/NGramTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName NGram = new TokenizerName("nGram");

        /// <summary>
        /// Tokenizer for path-like hierarchies.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/path/PathHierarchyTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName PathHierarchy = new TokenizerName("path_hierarchy_v2");

        /// <summary>
        /// Tokenizer that uses regex pattern matching to construct distinct tokens.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/pattern/PatternTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Pattern = new TokenizerName("pattern");

        /// <summary>
        /// Standard Lucene analyzer; Composed of the standard tokenizer,
        /// lowercase filter and stop filter.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/StandardTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Standard = new TokenizerName("standard_v2");

        /// <summary>
        /// Tokenizes urls and emails as one token.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/UAX29URLEmailTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName UaxUrlEmail = new TokenizerName("uax_url_email");

        /// <summary>
        /// Divides text at whitespace.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceTokenizer.html" />
        /// </summary>
        public static readonly TokenizerName Whitespace = new TokenizerName("whitespace");

        private TokenizerName(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new TokenizerName instance, or returns an existing instance if the given name matches that of a
        /// known tokenizer.
        /// </summary>
        /// <param name="name">Name of the tokenizer.</param>
        /// <returns>A TokenizerName instance with the given name.</returns>
        public static TokenizerName Create(string name) => Lookup(name) ?? new TokenizerName(name);

        /// <summary>
        /// Defines implicit conversion from string to TokenizerName.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a TokenizerName.</returns>
        public static implicit operator TokenizerName(string name) => Create(name);
    }
}
