// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all token filters supported by Azure Search.
    /// <see href="https://msdn.microsoft.com/library/azure/mt605304.aspx"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<TokenFilterName>))]
    public sealed class TokenFilterName : ExtensibleEnum<TokenFilterName>
    {
        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // https://msdn.microsoft.com/library/azure/mt605304.aspx

        /// <summary>
        /// A token filter that applies the Arabic normalizer to normalize the
        /// orthography.
        /// </summary>
        public static readonly TokenFilterName ArabicNormalization = new TokenFilterName("arabic_normalization");

        /// <summary>
        /// Strips all characters after an apostrophe.
        /// </summary>
        public static readonly TokenFilterName Apostrophe = new TokenFilterName("apostrophe");

        /// <summary>
        /// Converts alphabetic, numeric, and symbolic Unicode characters which
        /// are not in the first 127 ASCII characters (the "Basic Latin" Unicode
        /// block) into their ASCII equivalents, if such equivalents exist.
        /// </summary>
        public static readonly TokenFilterName AsciiFolding = new TokenFilterName("asciifolding");

        /// <summary>
        /// Forms bigrams of CJK terms that are generated from StandardTokenizer.
        /// </summary>
        public static readonly TokenFilterName CjkBigram = new TokenFilterName("cjk_bigram");

        /// <summary>
        /// Normalizes CJK width differences. Folds fullwidth ASCII variants into
        /// the equivalent basic Latin, and half-width Katakana variants into the
        /// equivalent Kana.
        /// </summary>
        public static readonly TokenFilterName CjkWidth = new TokenFilterName("cjk_width");

        /// <summary>
        /// Removes English possessives, and dots from acronyms.
        /// </summary>
        public static readonly TokenFilterName Classic = new TokenFilterName("classic");

        /// <summary>
        /// Construct bigrams for frequently occurring terms while indexing.
        /// Single terms are still indexed too, with bigrams overlaid.
        /// </summary>
        public static readonly TokenFilterName CommonGram = new TokenFilterName("common_grams");

        /// <summary>
        /// Decomposes compound words found in many Germanic languages.
        /// </summary>
        public static readonly TokenFilterName DictionaryDecompounder = new TokenFilterName("dictionary_decompounder");

        /// <summary>
        /// Generates n-grams of the given size(s) starting from the front or the
        /// back of an input token.
        /// </summary>
        public static readonly TokenFilterName EdgeNGram = new TokenFilterName("edgeNGram");

        /// <summary>
        /// Removes elisions. For example, "l'avion" (the plane) will be converted
        /// to "avion" (plane).
        /// </summary>
        public static readonly TokenFilterName Elision = new TokenFilterName("elision");

        /// <summary>
        /// Normalizes German characters according to the heuristics of the
        /// German2 snowball algorithm.
        /// </summary>
        public static readonly TokenFilterName GermanNormalization = new TokenFilterName("german_normalization");

        /// <summary>
        /// Normalizes text in Hindi to remove some differences in spelling
        /// variations.
        /// </summary>
        public static readonly TokenFilterName HindiNormalization = new TokenFilterName("hindi_normalization");

        /// <summary>
        /// Normalizes the Unicode representation of text in Indian languages.
        /// </summary>
        public static readonly TokenFilterName IndicNormalization = new TokenFilterName("indic_normalization");

        /// <summary>
        /// A token filter that only keeps tokens with text contained in a
        /// specified list of words.
        /// </summary>
        public static readonly TokenFilterName Keep = new TokenFilterName("keep");

        /// <summary>
        /// Marks terms as keywords.
        /// </summary>
        public static readonly TokenFilterName KeywordMarker = new TokenFilterName("keyword_marker");

        /// <summary>
        /// Emits each incoming token twice, once as keyword and once as
        /// non-keyword.
        /// </summary>
        public static readonly TokenFilterName KeywordRepeat = new TokenFilterName("keyword_repeat");

        /// <summary>
        /// A high-performance kstem filter for English.
        /// </summary>
        public static readonly TokenFilterName KStem = new TokenFilterName("kstem");

        /// <summary>
        /// Removes words that are too long or too short.
        /// </summary>
        public static readonly TokenFilterName Length = new TokenFilterName("length");

        /// <summary>
        /// Limits the number of tokens while indexing.
        /// </summary>
        public static readonly TokenFilterName Limit = new TokenFilterName("limit");

        /// <summary>
        /// Normalizes token text to lower case.
        /// </summary>
        public static readonly TokenFilterName Lowercase = new TokenFilterName("lowercase");

        /// <summary>
        /// Generates n-grams of the given size(s).
        /// </summary>
        public static readonly TokenFilterName NGram = new TokenFilterName("nGram");

        /// <summary>
        /// Uses Java regexes to emit multiple tokens - one for each capture group
        /// in one or more patterns.
        /// </summary>
        public static readonly TokenFilterName PatternCapture = new TokenFilterName("pattern_capture");

        /// <summary>
        /// A character filter that replaces characters in the input string. It
        /// uses a regular expression to identify character sequences to preserve
        /// and a replacement pattern to identify characters to replace. For
        /// example, given the input text "aa bb aa bb", pattern
        /// "(aa)\s+(bb)", and replacement "$1#$2", the result would be
        /// "aa#bb aa#bb".
        /// </summary>
        public static readonly TokenFilterName PatternReplace = new TokenFilterName("pattern_replace");

        /// <summary>
        /// Applies normalization for Persian.
        /// </summary>
        public static readonly TokenFilterName PersianNormalization = new TokenFilterName("persian_normalization");

        /// <summary>
        /// Create tokens for phonetic matches.
        /// </summary>
        public static readonly TokenFilterName Phonetic = new TokenFilterName("phonetic");

        /// <summary>
        /// Transforms the token stream as per the Porter stemming algorithm.
        /// </summary>
        public static readonly TokenFilterName PorterStem = new TokenFilterName("porter_stem");

        /// <summary>
        /// Reverses the token string.
        /// </summary>
        public static readonly TokenFilterName Reverse = new TokenFilterName("reverse");

        /// <summary>
        /// Normalizes use of the interchangeable Scandinavian characters.
        /// </summary>
        public static readonly TokenFilterName ScandinavianNormalization = new TokenFilterName("scandinavian_normalization");

        /// <summary>
        /// Folds Scandinavian characters åÅäæÄÆ-&gt;a and öÖøØ-&gt;o. It also
        /// discriminates against use of double vowels aa, ae, ao, oe and oo,
        /// leaving just the first one.
        /// </summary>
        public static readonly TokenFilterName ScandinavianFoldingNormalization = new TokenFilterName("scandinavian_folding");

        /// <summary>
        /// Creates combinations of tokens as a single token.
        /// </summary>
        public static readonly TokenFilterName Shingle = new TokenFilterName("shingle");

        /// <summary>
        /// A filter that stems words using a Snowball-generated stemmer.
        /// </summary>
        public static readonly TokenFilterName Snowball = new TokenFilterName("snowball");

        /// <summary>
        /// Normalizes the Unicode representation of Sorani text.
        /// </summary>
        public static readonly TokenFilterName SoraniNormalization = new TokenFilterName("sorani_normalization");

        /// <summary>
        /// Language specific stemming filter.
        /// </summary>
        public static readonly TokenFilterName Stemmer = new TokenFilterName("stemmer");

        /// <summary>
        /// Provides the ability to override other stemming filters with custom
        /// dictionary-based stemming. Any dictionary-stemmed terms will be
        /// marked as keywords so that they will not be stemmed with stemmers
        /// down the chain. Must be placed before any stemming filters.
        /// </summary>
        public static readonly TokenFilterName StemmerOverride = new TokenFilterName("stemmer_override");

        /// <summary>
        /// Removes stop words from a token stream.
        /// </summary>
        public static readonly TokenFilterName Stopwords = new TokenFilterName("stopwords");

        /// <summary>
        /// Matches single or multi-word synonyms in a token stream.
        /// </summary>
        public static readonly TokenFilterName Synonym = new TokenFilterName("synonym");

        /// <summary>
        /// Trims leading and trailing whitespace from tokens.
        /// </summary>
        public static readonly TokenFilterName Trim = new TokenFilterName("trim");

        /// <summary>
        /// Truncates the terms to a specific length.
        /// </summary>
        public static readonly TokenFilterName Truncate = new TokenFilterName("truncate");

        /// <summary>
        /// Filters out tokens with same text as the previous token.
        /// </summary>
        public static readonly TokenFilterName Unique = new TokenFilterName("unique");

        /// <summary>
        /// Normalizes token text to upper case.
        /// </summary>
        public static readonly TokenFilterName Uppercase = new TokenFilterName("uppercase");

        /// <summary>
        /// Splits words into subwords and performs optional transformations on
        /// subword groups.
        /// </summary>
        public static readonly TokenFilterName WordDelimiter = new TokenFilterName("word_delimiter");

        private TokenFilterName(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new TokenFilterName instance, or returns an existing instance if the given name matches that of a
        /// known token filter.
        /// </summary>
        /// <param name="name">Name of the token filter.</param>
        /// <returns>A TokenFilterName instance with the given name.</returns>
        public static TokenFilterName Create(string name)
        {
            // Token filter names are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new TokenFilterName(name);
        }
    }
}
