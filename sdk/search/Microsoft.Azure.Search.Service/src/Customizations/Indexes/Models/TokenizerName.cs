// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all tokenizers supported by Azure Cognitive Search.
    /// For more information, see <see href="https://docs.microsoft.com/azure/search/index-add-custom-analyzers">Add custom analyzers to string fields in an Azure Cognitive Search index</see>.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<TokenizerName>))]
    public struct TokenizerName : IEquatable<TokenizerName>
    {
        private readonly string _value;

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

        private TokenizerName(string name)
        {
            Throw.IfArgumentNull(name, nameof(name));
            _value = name;
        }

        /// <summary>
        /// Defines implicit conversion from string to TokenizerName.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a TokenizerName.</returns>
        public static implicit operator TokenizerName(string name) => new TokenizerName(name);

        /// <summary>
        /// Defines explicit conversion from TokenizerName to string.
        /// </summary>
        /// <param name="name">TokenizerName to convert.</param>
        /// <returns>The TokenizerName as a string.</returns>
        public static explicit operator string(TokenizerName name) => name.ToString();

        /// <summary>
        /// Compares two TokenizerName values for equality.
        /// </summary>
        /// <param name="lhs">The first TokenizerName to compare.</param>
        /// <param name="rhs">The second TokenizerName to compare.</param>
        /// <returns>true if the TokenizerName objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(TokenizerName lhs, TokenizerName rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two TokenizerName values for inequality.
        /// </summary>
        /// <param name="lhs">The first TokenizerName to compare.</param>
        /// <param name="rhs">The second TokenizerName to compare.</param>
        /// <returns>true if the TokenizerName objects are not equal; false otherwise.</returns>
        public static bool operator !=(TokenizerName lhs, TokenizerName rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the TokenizerName for equality with another TokenizerName.
        /// </summary>
        /// <param name="other">The TokenizerName with which to compare.</param>
        /// <returns><c>true</c> if the TokenizerName objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(TokenizerName other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is TokenizerName ? Equals((TokenizerName)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the TokenizerName.
        /// </summary>
        /// <returns>The TokenizerName as a string.</returns>
        public override string ToString() => _value;
    }
}
