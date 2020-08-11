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
    /// Defines the names of all token filters supported by Azure Cognitive Search.
    /// For more information, see <see href="https://docs.microsoft.com/azure/search/index-add-custom-analyzers">Add custom analyzers to string fields in an Azure Cognitive Search index</see>.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<TokenFilterName>))]
    public struct TokenFilterName : IEquatable<TokenFilterName>
    {
        private readonly string _value;

        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search

        /// <summary>
        /// A token filter that applies the Arabic normalizer to normalize the orthography.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ar/ArabicNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName ArabicNormalization = new TokenFilterName("arabic_normalization");

        /// <summary>
        /// Strips all characters after an apostrophe (including the apostrophe itself).
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/tr/ApostropheFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Apostrophe = new TokenFilterName("apostrophe");

        /// <summary>
        /// Converts alphabetic, numeric, and symbolic Unicode characters which
        /// are not in the first 127 ASCII characters (the "Basic Latin" Unicode
        /// block) into their ASCII equivalents, if such equivalents exist.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/ASCIIFoldingFilter.html" />
        /// </summary>
        public static readonly TokenFilterName AsciiFolding = new TokenFilterName("asciifolding");

        /// <summary>
        /// Forms bigrams of CJK terms that are generated from StandardTokenizer.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/cjk/CJKBigramFilter.html" />
        /// </summary>
        public static readonly TokenFilterName CjkBigram = new TokenFilterName("cjk_bigram");

        /// <summary>
        /// Normalizes CJK width differences. Folds fullwidth ASCII variants into
        /// the equivalent basic Latin, and half-width Katakana variants into the
        /// equivalent Kana.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/cjk/CJKWidthFilter.html" /> 
        /// </summary>
        public static readonly TokenFilterName CjkWidth = new TokenFilterName("cjk_width");

        /// <summary>
        /// Removes English possessives, and dots from acronyms.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/ClassicFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Classic = new TokenFilterName("classic");

        /// <summary>
        /// Construct bigrams for frequently occurring terms while indexing.
        /// Single terms are still indexed too, with bigrams overlaid.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/commongrams/CommonGramsFilter.html" />
        /// </summary>
        public static readonly TokenFilterName CommonGram = new TokenFilterName("common_grams");

        /// <summary>
        /// Generates n-grams of the given size(s) starting from the front or the
        /// back of an input token.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/EdgeNGramTokenFilter.html" />
        /// </summary>
        public static readonly TokenFilterName EdgeNGram = new TokenFilterName("edgeNGram_v2");

        /// <summary>
        /// Removes elisions. For example, "l'avion" (the plane) will be converted
        /// to "avion" (plane).
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/util/ElisionFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Elision = new TokenFilterName("elision");

        /// <summary>
        /// Normalizes German characters according to the heuristics of the
        /// German2 snowball algorithm.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/de/GermanNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName GermanNormalization = new TokenFilterName("german_normalization");

        /// <summary>
        /// Normalizes text in Hindi to remove some differences in spelling
        /// variations.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/hi/HindiNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName HindiNormalization = new TokenFilterName("hindi_normalization");

        /// <summary>
        /// Normalizes the Unicode representation of text in Indian languages.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/in/IndicNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName IndicNormalization = new TokenFilterName("indic_normalization");

        /// <summary>
        /// Emits each incoming token twice, once as keyword and once as
        /// non-keyword.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/KeywordRepeatFilter.html" />
        /// </summary>
        public static readonly TokenFilterName KeywordRepeat = new TokenFilterName("keyword_repeat");

        /// <summary>
        /// A high-performance kstem filter for English.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/en/KStemFilter.html" />
        /// </summary>
        public static readonly TokenFilterName KStem = new TokenFilterName("kstem");

        /// <summary>
        /// Removes words that are too long or too short.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/LengthFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Length = new TokenFilterName("length");

        /// <summary>
        /// Limits the number of tokens while indexing.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/LimitTokenCountFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Limit = new TokenFilterName("limit");

        /// <summary>
        /// Normalizes token text to lower case.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/LowerCaseFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Lowercase = new TokenFilterName("lowercase");

        /// <summary>
        /// Generates n-grams of the given size(s).
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/NGramTokenFilter.html" />
        /// </summary>
        public static readonly TokenFilterName NGram = new TokenFilterName("nGram_v2");

        /// <summary>
        /// Applies normalization for Persian.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/fa/PersianNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName PersianNormalization = new TokenFilterName("persian_normalization");

        /// <summary>
        /// Create tokens for phonetic matches.
        /// <see href="https://lucene.apache.org/core/4_10_3/analyzers-phonetic/org/apache/lucene/analysis/phonetic/package-tree.html" />
        /// </summary>
        public static readonly TokenFilterName Phonetic = new TokenFilterName("phonetic");

        /// <summary>
        /// Uses the Porter stemming algorithm to transform the token stream.
        /// <see href="http://tartarus.org/~martin/PorterStemmer/" />
        /// </summary>
        public static readonly TokenFilterName PorterStem = new TokenFilterName("porter_stem");

        /// <summary>
        /// Reverses the token string.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/reverse/ReverseStringFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Reverse = new TokenFilterName("reverse");

        /// <summary>
        /// Normalizes use of the interchangeable Scandinavian characters.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/ScandinavianNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName ScandinavianNormalization = new TokenFilterName("scandinavian_normalization");

        /// <summary>
        /// Folds Scandinavian characters åÅäæÄÆ-&gt;a and öÖøØ-&gt;o. It also
        /// discriminates against use of double vowels aa, ae, ao, oe and oo,
        /// leaving just the first one.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/ScandinavianFoldingFilter.html" />
        /// </summary>
        public static readonly TokenFilterName ScandinavianFoldingNormalization = new TokenFilterName("scandinavian_folding");

        /// <summary>
        /// Creates combinations of tokens as a single token.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/shingle/ShingleFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Shingle = new TokenFilterName("shingle");

        /// <summary>
        /// A filter that stems words using a Snowball-generated stemmer.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/snowball/SnowballFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Snowball = new TokenFilterName("snowball");

        /// <summary>
        /// Normalizes the Unicode representation of Sorani text.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ckb/SoraniNormalizationFilter.html" />
        /// </summary>
        public static readonly TokenFilterName SoraniNormalization = new TokenFilterName("sorani_normalization");

        /// <summary>
        /// Language specific stemming filter.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search#TokenFilters" />
        /// </summary>
        public static readonly TokenFilterName Stemmer = new TokenFilterName("stemmer");

        /// <summary>
        /// Removes stop words from a token stream.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/StopFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Stopwords = new TokenFilterName("stopwords");

        /// <summary>
        /// Trims leading and trailing whitespace from tokens.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/TrimFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Trim = new TokenFilterName("trim");

        /// <summary>
        /// Truncates the terms to a specific length.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/TruncateTokenFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Truncate = new TokenFilterName("truncate");

        /// <summary>
        /// Filters out tokens with same text as the previous token.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/RemoveDuplicatesTokenFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Unique = new TokenFilterName("unique");

        /// <summary>
        /// Normalizes token text to upper case.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/UpperCaseFilter.html" />
        /// </summary>
        public static readonly TokenFilterName Uppercase = new TokenFilterName("uppercase");

        /// <summary>
        /// Splits words into subwords and performs optional transformations on
        /// subword groups.
        /// </summary>
        public static readonly TokenFilterName WordDelimiter = new TokenFilterName("word_delimiter");

        private TokenFilterName(string name)
        {
            Throw.IfArgumentNull(name, nameof(name));
            _value = name;
        }

        /// <summary>
        /// Defines implicit conversion from string to TokenFilterName.
        /// </summary>
        /// <param name="name">string to convert.</param>
        /// <returns>The string as a TokenFilterName.</returns>
        public static implicit operator TokenFilterName(string name) => new TokenFilterName(name);

        /// <summary>
        /// Defines explicit conversion from TokenFilterName to string.
        /// </summary>
        /// <param name="name">TokenFilterName to convert.</param>
        /// <returns>The TokenFilterName as a string.</returns>
        public static explicit operator string(TokenFilterName name) => name.ToString();

        /// <summary>
        /// Compares two TokenFilterName values for equality.
        /// </summary>
        /// <param name="lhs">The first TokenFilterName to compare.</param>
        /// <param name="rhs">The second TokenFilterName to compare.</param>
        /// <returns>true if the TokenFilterName objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(TokenFilterName lhs, TokenFilterName rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two TokenFilterName values for inequality.
        /// </summary>
        /// <param name="lhs">The first TokenFilterName to compare.</param>
        /// <param name="rhs">The second TokenFilterName to compare.</param>
        /// <returns>true if the TokenFilterName objects are not equal; false otherwise.</returns>
        public static bool operator !=(TokenFilterName lhs, TokenFilterName rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the TokenFilterName for equality with another TokenFilterName.
        /// </summary>
        /// <param name="other">The TokenFilterName with which to compare.</param>
        /// <returns><c>true</c> if the TokenFilterName objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(TokenFilterName other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is TokenFilterName ? Equals((TokenFilterName)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the TokenFilterName.
        /// </summary>
        /// <returns>The TokenFilterName as a string.</returns>
        public override string ToString() => _value;
    }
}
