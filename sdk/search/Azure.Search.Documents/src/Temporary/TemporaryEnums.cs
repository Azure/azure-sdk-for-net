// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> Scripts that can be ignored by CjkBigramTokenFilter. </summary>
    [CodeGenType("CjkBigramTokenFilterScripts")]
    public enum CjkBigramTokenFilterScripts
    {
        /// <summary> Ignore Han script when forming bigrams of CJK terms. </summary>
        Han,
        /// <summary> Ignore Hiragana script when forming bigrams of CJK terms. </summary>
        Hiragana,
        /// <summary> Ignore Katakana script when forming bigrams of CJK terms. </summary>
        Katakana,
        /// <summary> Ignore Hangul script when forming bigrams of CJK terms. </summary>
        Hangul
    }

    // Suppress the generated EdgeNGramTokenFilterSide struct
    /// <summary> Specifies which side of the input an n-gram should be generated from. </summary>
    [CodeGenType("EdgeNGramTokenFilterSide")]
    public enum EdgeNGramTokenFilterSide
    {
        /// <summary> Specifies that the n-gram should be generated from the front of the input. </summary>
        Front,
        /// <summary> Specifies that the n-gram should be generated from the back of the input. </summary>
        Back
    }

    // Suppress the generated IndexerExecutionStatus struct
    /// <summary> Represents the status of an individual indexer execution. </summary>
    [CodeGenType("IndexerExecutionStatus")]
    public enum IndexerExecutionStatus
    {
        /// <summary> An indexer invocation has failed, but the failure may be transient. Indexer invocations will continue per schedule. </summary>
        TransientFailure,
        /// <summary> Indexer execution completed successfully. </summary>
        Success,
        /// <summary> Indexer execution is in progress. </summary>
        InProgress,
        /// <summary> Indexer has been reset. </summary>
        Reset
    }

    // Suppress the generated IndexerStatus struct
    /// <summary> Represents the overall indexer status. </summary>
    [CodeGenType("IndexerStatus")]
    public enum IndexerStatus
    {
        /// <summary> Indicates that the indexer is in an unknown state. </summary>
        Unknown,
        /// <summary> Indicates that the indexer experienced an error that cannot be corrected without human intervention. </summary>
        Error,
        /// <summary> Indicates that the indexer is running normally. </summary>
        Running
    }

    // Suppress the generated MicrosoftStemmingTokenizerLanguage struct
    /// <summary> Lists the languages supported by the Microsoft language stemming tokenizer. </summary>
    [CodeGenType("MicrosoftStemmingTokenizerLanguage")]
    public enum MicrosoftStemmingTokenizerLanguage
    {
        /// <summary> Selects the Microsoft stemming tokenizer for Arabic. </summary>
        Arabic,
        /// <summary> Selects the Microsoft stemming tokenizer for Bangla. </summary>
        Bangla,
        /// <summary> Selects the Microsoft stemming tokenizer for Bulgarian. </summary>
        Bulgarian,
        /// <summary> Selects the Microsoft stemming tokenizer for Catalan. </summary>
        Catalan,
        /// <summary> Selects the Microsoft stemming tokenizer for Croatian. </summary>
        Croatian,
        /// <summary> Selects the Microsoft stemming tokenizer for Czech. </summary>
        Czech,
        /// <summary> Selects the Microsoft stemming tokenizer for Danish. </summary>
        Danish,
        /// <summary> Selects the Microsoft stemming tokenizer for Dutch. </summary>
        Dutch,
        /// <summary> Selects the Microsoft stemming tokenizer for English. </summary>
        English,
        /// <summary> Selects the Microsoft stemming tokenizer for Estonian. </summary>
        Estonian,
        /// <summary> Selects the Microsoft stemming tokenizer for Finnish. </summary>
        Finnish,
        /// <summary> Selects the Microsoft stemming tokenizer for French. </summary>
        French,
        /// <summary> Selects the Microsoft stemming tokenizer for German. </summary>
        German,
        /// <summary> Selects the Microsoft stemming tokenizer for Greek. </summary>
        Greek,
        /// <summary> Selects the Microsoft stemming tokenizer for Gujarati. </summary>
        Gujarati,
        /// <summary> Selects the Microsoft stemming tokenizer for Hebrew. </summary>
        Hebrew,
        /// <summary> Selects the Microsoft stemming tokenizer for Hindi. </summary>
        Hindi,
        /// <summary> Selects the Microsoft stemming tokenizer for Hungarian. </summary>
        Hungarian,
        /// <summary> Selects the Microsoft stemming tokenizer for Icelandic. </summary>
        Icelandic,
        /// <summary> Selects the Microsoft stemming tokenizer for Indonesian. </summary>
        Indonesian,
        /// <summary> Selects the Microsoft stemming tokenizer for Italian. </summary>
        Italian,
        /// <summary> Selects the Microsoft stemming tokenizer for Kannada. </summary>
        Kannada,
        /// <summary> Selects the Microsoft stemming tokenizer for Latvian. </summary>
        Latvian,
        /// <summary> Selects the Microsoft stemming tokenizer for Lithuanian. </summary>
        Lithuanian,
        /// <summary> Selects the Microsoft stemming tokenizer for Malay. </summary>
        Malay,
        /// <summary> Selects the Microsoft stemming tokenizer for Malayalam. </summary>
        Malayalam,
        /// <summary> Selects the Microsoft stemming tokenizer for Marathi. </summary>
        Marathi,
        /// <summary> Selects the Microsoft stemming tokenizer for Norwegian (Bokmål). </summary>
        NorwegianBokmaal,
        /// <summary> Selects the Microsoft stemming tokenizer for Polish. </summary>
        Polish,
        /// <summary> Selects the Microsoft stemming tokenizer for Portuguese. </summary>
        Portuguese,
        /// <summary> Selects the Microsoft stemming tokenizer for Portuguese (Brazil). </summary>
        PortugueseBrazilian,
        /// <summary> Selects the Microsoft stemming tokenizer for Punjabi. </summary>
        Punjabi,
        /// <summary> Selects the Microsoft stemming tokenizer for Romanian. </summary>
        Romanian,
        /// <summary> Selects the Microsoft stemming tokenizer for Russian. </summary>
        Russian,
        /// <summary> Selects the Microsoft stemming tokenizer for Serbian (Cyrillic). </summary>
        SerbianCyrillic,
        /// <summary> Selects the Microsoft stemming tokenizer for Serbian (Latin). </summary>
        SerbianLatin,
        /// <summary> Selects the Microsoft stemming tokenizer for Slovak. </summary>
        Slovak,
        /// <summary> Selects the Microsoft stemming tokenizer for Slovenian. </summary>
        Slovenian,
        /// <summary> Selects the Microsoft stemming tokenizer for Spanish. </summary>
        Spanish,
        /// <summary> Selects the Microsoft stemming tokenizer for Swedish. </summary>
        Swedish,
        /// <summary> Selects the Microsoft stemming tokenizer for Tamil. </summary>
        Tamil,
        /// <summary> Selects the Microsoft stemming tokenizer for Telugu. </summary>
        Telugu,
        /// <summary> Selects the Microsoft stemming tokenizer for Turkish. </summary>
        Turkish,
        /// <summary> Selects the Microsoft stemming tokenizer for Ukrainian. </summary>
        Ukrainian,
        /// <summary> Selects the Microsoft stemming tokenizer for Urdu. </summary>
        Urdu
    }

    // Suppress the generated MicrosoftTokenizerLanguage struct
    /// <summary> Lists the languages supported by the Microsoft language tokenizer. </summary>
    [CodeGenType("MicrosoftTokenizerLanguage")]
    public enum MicrosoftTokenizerLanguage
    {
        /// <summary> Selects the Microsoft tokenizer for Bangla. </summary>
        Bangla,
        /// <summary> Selects the Microsoft tokenizer for Bulgarian. </summary>
        Bulgarian,
        /// <summary> Selects the Microsoft tokenizer for Catalan. </summary>
        Catalan,
        /// <summary> Selects the Microsoft tokenizer for Chinese (Simplified). </summary>
        ChineseSimplified,
        /// <summary> Selects the Microsoft tokenizer for Chinese (Traditional). </summary>
        ChineseTraditional,
        /// <summary> Selects the Microsoft tokenizer for Croatian. </summary>
        Croatian,
        /// <summary> Selects the Microsoft tokenizer for Czech. </summary>
        Czech,
        /// <summary> Selects the Microsoft tokenizer for Danish. </summary>
        Danish,
        /// <summary> Selects the Microsoft tokenizer for Dutch. </summary>
        Dutch,
        /// <summary> Selects the Microsoft tokenizer for English. </summary>
        English,
        /// <summary> Selects the Microsoft tokenizer for French. </summary>
        French,
        /// <summary> Selects the Microsoft tokenizer for German. </summary>
        German,
        /// <summary> Selects the Microsoft tokenizer for Greek. </summary>
        Greek,
        /// <summary> Selects the Microsoft tokenizer for Gujarati. </summary>
        Gujarati,
        /// <summary> Selects the Microsoft tokenizer for Hindi. </summary>
        Hindi,
        /// <summary> Selects the Microsoft tokenizer for Icelandic. </summary>
        Icelandic,
        /// <summary> Selects the Microsoft tokenizer for Indonesian. </summary>
        Indonesian,
        /// <summary> Selects the Microsoft tokenizer for Italian. </summary>
        Italian,
        /// <summary> Selects the Microsoft tokenizer for Japanese. </summary>
        Japanese,
        /// <summary> Selects the Microsoft tokenizer for Kannada. </summary>
        Kannada,
        /// <summary> Selects the Microsoft tokenizer for Korean. </summary>
        Korean,
        /// <summary> Selects the Microsoft tokenizer for Malay. </summary>
        Malay,
        /// <summary> Selects the Microsoft tokenizer for Malayalam. </summary>
        Malayalam,
        /// <summary> Selects the Microsoft tokenizer for Marathi. </summary>
        Marathi,
        /// <summary> Selects the Microsoft tokenizer for Norwegian (Bokmål). </summary>
        NorwegianBokmaal,
        /// <summary> Selects the Microsoft tokenizer for Polish. </summary>
        Polish,
        /// <summary> Selects the Microsoft tokenizer for Portuguese. </summary>
        Portuguese,
        /// <summary> Selects the Microsoft tokenizer for Portuguese (Brazil). </summary>
        PortugueseBrazilian,
        /// <summary> Selects the Microsoft tokenizer for Punjabi. </summary>
        Punjabi,
        /// <summary> Selects the Microsoft tokenizer for Romanian. </summary>
        Romanian,
        /// <summary> Selects the Microsoft tokenizer for Russian. </summary>
        Russian,
        /// <summary> Selects the Microsoft tokenizer for Serbian (Cyrillic). </summary>
        SerbianCyrillic,
        /// <summary> Selects the Microsoft tokenizer for Serbian (Latin). </summary>
        SerbianLatin,
        /// <summary> Selects the Microsoft tokenizer for Slovenian. </summary>
        Slovenian,
        /// <summary> Selects the Microsoft tokenizer for Spanish. </summary>
        Spanish,
        /// <summary> Selects the Microsoft tokenizer for Swedish. </summary>
        Swedish,
        /// <summary> Selects the Microsoft tokenizer for Tamil. </summary>
        Tamil,
        /// <summary> Selects the Microsoft tokenizer for Telugu. </summary>
        Telugu,
        /// <summary> Selects the Microsoft tokenizer for Thai. </summary>
        Thai,
        /// <summary> Selects the Microsoft tokenizer for Ukrainian. </summary>
        Ukrainian,
        /// <summary> Selects the Microsoft tokenizer for Urdu. </summary>
        Urdu,
        /// <summary> Selects the Microsoft tokenizer for Vietnamese. </summary>
        Vietnamese
    }

    // Suppress the generated PhoneticEncoder struct
    /// <summary> Identifies the type of phonetic encoder to use with a PhoneticTokenFilter. </summary>
    [CodeGenType("PhoneticEncoder")]
    public enum PhoneticEncoder
    {
        /// <summary> Encodes a token into a Metaphone value. </summary>
        Metaphone,
        /// <summary> Encodes a token into a double metaphone value. </summary>
        DoubleMetaphone,
        /// <summary> Encodes a token into a Soundex value. </summary>
        Soundex,
        /// <summary> Encodes a token into a Refined Soundex value. </summary>
        RefinedSoundex,
        /// <summary> Encodes a token into a Caverphone 1.0 value. </summary>
        Caverphone1,
        /// <summary> Encodes a token into a Caverphone 2.0 value. </summary>
        Caverphone2,
        /// <summary> Encodes a token into a Cologne Phonetic value. </summary>
        Cologne,
        /// <summary> Encodes a token into a NYSIIS value. </summary>
        Nysiis,
        /// <summary> Encodes a token using the Kölner Phonetik algorithm. </summary>
        KoelnerPhonetik,
        /// <summary> Encodes a token using the Haase refinement of the Kölner Phonetik algorithm. </summary>
        HaasePhonetik,
        /// <summary> Encodes a token into a Beider-Morse value. </summary>
        BeiderMorse
    }

    // Suppress the generated ScoringFunctionAggregation struct
    /// <summary> Defines the aggregation function used to combine the results of all the scoring functions in a scoring profile. </summary>
    [CodeGenType("ScoringFunctionAggregation")]
    public enum ScoringFunctionAggregation
    {
        /// <summary> Boost scores by the sum of all scoring function results. </summary>
        Sum,
        /// <summary> Boost scores by the average of all scoring function results. </summary>
        Average,
        /// <summary> Boost scores by the minimum of all scoring function results. </summary>
        Minimum,
        /// <summary> Boost scores by the maximum of all scoring function results. </summary>
        Maximum,
        /// <summary> Boost scores using the first applicable scoring function in the scoring profile. </summary>
        FirstMatching,
        /// <summary> Boost scores by the product of all scoring function results. </summary>
        Product
    }

    // Suppress the generated ScoringFunctionInterpolation struct
    /// <summary> Defines the function used to interpolate score boosting across a range of documents. </summary>
    [CodeGenType("ScoringFunctionInterpolation")]
    public enum ScoringFunctionInterpolation
    {
        /// <summary> Boosts scores by a linearly decreasing amount. This is the default interpolation for scoring functions. </summary>
        Linear,
        /// <summary> Boosts scores by a constant factor. </summary>
        Constant,
        /// <summary> Boosts scores by an amount that decreases quadratically. Boosts decrease slowly for higher scores, and more quickly as the scores decrease. This interpolation option is not allowed in tag scoring functions. </summary>
        Quadratic,
        /// <summary> Boosts scores by an amount that decreases logarithmically. Boosts decrease quickly for higher scores, and more slowly as the scores decrease. This interpolation option is not allowed in tag scoring functions. </summary>
        Logarithmic
    }

    // Suppress the generated SnowballTokenFilterLanguage struct
    /// <summary> The language to use for a Snowball token filter. </summary>
    [CodeGenType("SnowballTokenFilterLanguage")]
    public enum SnowballTokenFilterLanguage
    {
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Armenian. </summary>
        Armenian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Basque. </summary>
        Basque,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Catalan. </summary>
        Catalan,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Danish. </summary>
        Danish,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Dutch. </summary>
        Dutch,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for English. </summary>
        English,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Finnish. </summary>
        Finnish,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for French. </summary>
        French,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for German. </summary>
        German,
        /// <summary> Selects the Lucene Snowball stemming tokenizer that uses the German variant algorithm. </summary>
        German2,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Hungarian. </summary>
        Hungarian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Italian. </summary>
        Italian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Dutch that uses the Kraaij-Pohlmann stemming algorithm. </summary>
        Kp,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for English that uses the Lovins stemming algorithm. </summary>
        Lovins,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Norwegian. </summary>
        Norwegian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for English that uses the Porter stemming algorithm. </summary>
        Porter,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Portuguese. </summary>
        Portuguese,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Romanian. </summary>
        Romanian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Russian. </summary>
        Russian,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Spanish. </summary>
        Spanish,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Swedish. </summary>
        Swedish,
        /// <summary> Selects the Lucene Snowball stemming tokenizer for Turkish. </summary>
        Turkish
    }

    // Suppress the generated StemmerTokenFilterLanguage struct
    /// <summary> The language to use for a stemmer token filter. </summary>
    [CodeGenType("StemmerTokenFilterLanguage")]
    public enum StemmerTokenFilterLanguage
    {
        /// <summary> Selects the Lucene stemming tokenizer for Arabic. </summary>
        Arabic,
        /// <summary> Selects the Lucene stemming tokenizer for Armenian. </summary>
        Armenian,
        /// <summary> Selects the Lucene stemming tokenizer for Basque. </summary>
        Basque,
        /// <summary> Selects the Lucene stemming tokenizer for Portuguese (Brazil). </summary>
        Brazilian,
        /// <summary> Selects the Lucene stemming tokenizer for Bulgarian. </summary>
        Bulgarian,
        /// <summary> Selects the Lucene stemming tokenizer for Catalan. </summary>
        Catalan,
        /// <summary> Selects the Lucene stemming tokenizer for Czech. </summary>
        Czech,
        /// <summary> Selects the Lucene stemming tokenizer for Danish. </summary>
        Danish,
        /// <summary> Selects the Lucene stemming tokenizer for Dutch. </summary>
        Dutch,
        /// <summary> Selects the Lucene stemming tokenizer for Dutch that uses the Kraaij-Pohlmann stemming algorithm. </summary>
        DutchKp,
        /// <summary> Selects the Lucene stemming tokenizer for English. </summary>
        English,
        /// <summary> Selects the Lucene stemming tokenizer for English that does light stemming. </summary>
        LightEnglish,
        /// <summary> Selects the Lucene stemming tokenizer for English that does minimal stemming. </summary>
        MinimalEnglish,
        /// <summary> Selects the Lucene stemming tokenizer for English that removes trailing possessives from words. </summary>
        PossessiveEnglish,
        /// <summary> Selects the Lucene stemming tokenizer for English that uses the Porter2 stemming algorithm. </summary>
        Porter2,
        /// <summary> Selects the Lucene stemming tokenizer for English that uses the Lovins stemming algorithm. </summary>
        Lovins,
        /// <summary> Selects the Lucene stemming tokenizer for Finnish. </summary>
        Finnish,
        /// <summary> Selects the Lucene stemming tokenizer for Finnish that does light stemming. </summary>
        LightFinnish,
        /// <summary> Selects the Lucene stemming tokenizer for French. </summary>
        French,
        /// <summary> Selects the Lucene stemming tokenizer for French that does light stemming. </summary>
        LightFrench,
        /// <summary> Selects the Lucene stemming tokenizer for French that does minimal stemming. </summary>
        MinimalFrench,
        /// <summary> Selects the Lucene stemming tokenizer for Galician. </summary>
        Galician,
        /// <summary> Selects the Lucene stemming tokenizer for Galician that does minimal stemming. </summary>
        MinimalGalician,
        /// <summary> Selects the Lucene stemming tokenizer for German. </summary>
        German,
        /// <summary> Selects the Lucene stemming tokenizer that uses the German variant algorithm. </summary>
        German2,
        /// <summary> Selects the Lucene stemming tokenizer for German that does light stemming. </summary>
        LightGerman,
        /// <summary> Selects the Lucene stemming tokenizer for German that does minimal stemming. </summary>
        MinimalGerman,
        /// <summary> Selects the Lucene stemming tokenizer for Greek. </summary>
        Greek,
        /// <summary> Selects the Lucene stemming tokenizer for Hindi. </summary>
        Hindi,
        /// <summary> Selects the Lucene stemming tokenizer for Hungarian. </summary>
        Hungarian,
        /// <summary> Selects the Lucene stemming tokenizer for Hungarian that does light stemming. </summary>
        LightHungarian,
        /// <summary> Selects the Lucene stemming tokenizer for Indonesian. </summary>
        Indonesian,
        /// <summary> Selects the Lucene stemming tokenizer for Irish. </summary>
        Irish,
        /// <summary> Selects the Lucene stemming tokenizer for Italian. </summary>
        Italian,
        /// <summary> Selects the Lucene stemming tokenizer for Italian that does light stemming. </summary>
        LightItalian,
        /// <summary> Selects the Lucene stemming tokenizer for Sorani. </summary>
        Sorani,
        /// <summary> Selects the Lucene stemming tokenizer for Latvian. </summary>
        Latvian,
        /// <summary> Selects the Lucene stemming tokenizer for Norwegian (Bokmål). </summary>
        Norwegian,
        /// <summary> Selects the Lucene stemming tokenizer for Norwegian (Bokmål) that does light stemming. </summary>
        LightNorwegian,
        /// <summary> Selects the Lucene stemming tokenizer for Norwegian (Bokmål) that does minimal stemming. </summary>
        MinimalNorwegian,
        /// <summary> Selects the Lucene stemming tokenizer for Norwegian (Nynorsk) that does light stemming. </summary>
        LightNynorsk,
        /// <summary> Selects the Lucene stemming tokenizer for Norwegian (Nynorsk) that does minimal stemming. </summary>
        MinimalNynorsk,
        /// <summary> Selects the Lucene stemming tokenizer for Portuguese. </summary>
        Portuguese,
        /// <summary> Selects the Lucene stemming tokenizer for Portuguese that does light stemming. </summary>
        LightPortuguese,
        /// <summary> Selects the Lucene stemming tokenizer for Portuguese that does minimal stemming. </summary>
        MinimalPortuguese,
        /// <summary> Selects the Lucene stemming tokenizer for Portuguese that uses the RSLP stemming algorithm. </summary>
        PortugueseRslp,
        /// <summary> Selects the Lucene stemming tokenizer for Romanian. </summary>
        Romanian,
        /// <summary> Selects the Lucene stemming tokenizer for Russian. </summary>
        Russian,
        /// <summary> Selects the Lucene stemming tokenizer for Russian that does light stemming. </summary>
        LightRussian,
        /// <summary> Selects the Lucene stemming tokenizer for Spanish. </summary>
        Spanish,
        /// <summary> Selects the Lucene stemming tokenizer for Spanish that does light stemming. </summary>
        LightSpanish,
        /// <summary> Selects the Lucene stemming tokenizer for Swedish. </summary>
        Swedish,
        /// <summary> Selects the Lucene stemming tokenizer for Swedish that does light stemming. </summary>
        LightSwedish,
        /// <summary> Selects the Lucene stemming tokenizer for Turkish. </summary>
        Turkish
    }

    // Suppress the generated StopwordsList struct
    /// <summary> Identifies a predefined list of language-specific stopwords. </summary>
    [CodeGenType("StopwordsList")]
    public enum StopwordsList
    {
        /// <summary> Selects the stopword list for Arabic. </summary>
        Arabic,
        /// <summary> Selects the stopword list for Armenian. </summary>
        Armenian,
        /// <summary> Selects the stopword list for Basque. </summary>
        Basque,
        /// <summary> Selects the stopword list for Portuguese (Brazil). </summary>
        Brazilian,
        /// <summary> Selects the stopword list for Bulgarian. </summary>
        Bulgarian,
        /// <summary> Selects the stopword list for Catalan. </summary>
        Catalan,
        /// <summary> Selects the stopword list for Czech. </summary>
        Czech,
        /// <summary> Selects the stopword list for Danish. </summary>
        Danish,
        /// <summary> Selects the stopword list for Dutch. </summary>
        Dutch,
        /// <summary> Selects the stopword list for English. </summary>
        English,
        /// <summary> Selects the stopword list for Finnish. </summary>
        Finnish,
        /// <summary> Selects the stopword list for French. </summary>
        French,
        /// <summary> Selects the stopword list for Galician. </summary>
        Galician,
        /// <summary> Selects the stopword list for German. </summary>
        German,
        /// <summary> Selects the stopword list for Greek. </summary>
        Greek,
        /// <summary> Selects the stopword list for Hindi. </summary>
        Hindi,
        /// <summary> Selects the stopword list for Hungarian. </summary>
        Hungarian,
        /// <summary> Selects the stopword list for Indonesian. </summary>
        Indonesian,
        /// <summary> Selects the stopword list for Irish. </summary>
        Irish,
        /// <summary> Selects the stopword list for Italian. </summary>
        Italian,
        /// <summary> Selects the stopword list for Latvian. </summary>
        Latvian,
        /// <summary> Selects the stopword list for Norwegian. </summary>
        Norwegian,
        /// <summary> Selects the stopword list for Persian. </summary>
        Persian,
        /// <summary> Selects the stopword list for Portuguese. </summary>
        Portuguese,
        /// <summary> Selects the stopword list for Romanian. </summary>
        Romanian,
        /// <summary> Selects the stopword list for Russian. </summary>
        Russian,
        /// <summary> Selects the stopword list for Sorani. </summary>
        Sorani,
        /// <summary> Selects the stopword list for Spanish. </summary>
        Spanish,
        /// <summary> Selects the stopword list for Swedish. </summary>
        Swedish,
        /// <summary> Selects the stopword list for Thai. </summary>
        Thai,
        /// <summary> Selects the stopword list for Turkish. </summary>
        Turkish
    }

    // Suppress the generated TokenCharacterKind struct
    /// <summary> Represents classes of characters on which a token filter can operate. </summary>
    [CodeGenType("TokenCharacterKind")]
    public enum TokenCharacterKind
    {
        /// <summary> Keeps letters in tokens. </summary>
        Letter,
        /// <summary> Keeps digits in tokens. </summary>
        Digit,
        /// <summary> Keeps whitespace in tokens. </summary>
        Whitespace,
        /// <summary> Keeps punctuation in tokens. </summary>
        Punctuation,
        /// <summary> Keeps symbols in tokens. </summary>
        Symbol
    }
}

namespace Azure.Search.Documents.Models
{
    // Suppress the generated AutocompleteMode struct
    /// <summary> Specifies the mode for Autocomplete. The default is 'oneTerm'. Use 'twoTerms' to get shingles and 'oneTermWithContext' to use the current context in producing autocomplete terms. </summary>
    [CodeGenType("AutocompleteMode")]
    public enum AutocompleteMode
    {
        /// <summary> Only one term is suggested. If the query has two terms, only the last term is completed. For example, if the input is 'washington medic', the suggested terms could include 'medicaid', 'medicare', and 'medicine'. </summary>
        OneTerm,
        /// <summary> Matching two-term phrases in the index will be suggested. For example, if the input is 'medic', the suggested terms could include 'medicare coverage' and 'medical assistant'. </summary>
        TwoTerms,
        /// <summary> Completes the last term in a query with two or more terms, where the last two terms are a phrase that exists in the index. For example, if the input is 'washington medic', the suggested terms could include 'washington medicaid' and 'washington medical'. </summary>
        OneTermWithContext
    }

    // Suppress the generated IndexActionType struct
    /// <summary> The operation to perform on a document in an indexing batch. </summary>
    [CodeGenType("IndexActionType")]
    public enum IndexActionType
    {
        /// <summary> Inserts the document into the index if it is new and updates it if it exists. All fields are replaced in the update case. </summary>
        Upload,
        /// <summary> Merges the specified field values with an existing document. If the document does not exist, the merge will fail. Any field you specify in a merge will replace the existing field in the document. This also applies to collections of primitive and complex types. </summary>
        Merge,
        /// <summary> Behaves like merge if a document with the given key already exists in the index. If the document does not exist, it behaves like upload with a new document. </summary>
        MergeOrUpload,
        /// <summary> Removes the specified document from the index. Any field you specify in a delete operation other than the key field will be ignored. If you want to remove an individual field from a document, use merge instead and set the field explicitly to null. </summary>
        Delete
    }

    // Suppress the generated ScoringStatistics struct
    /// <summary> A value that specifies whether we want to calculate scoring statistics (such as document frequency) globally for more consistent scoring, or locally, for lower latency. The default is 'local'. Use 'global' to aggregate scoring statistics globally before scoring. Using global scoring statistics can increase latency of search queries. </summary>
    [CodeGenType("ScoringStatistics")]
    public enum ScoringStatistics
    {
        /// <summary> The scoring statistics will be calculated locally for lower latency. </summary>
        Local,
        /// <summary> The scoring statistics will be calculated globally for more consistent scoring. </summary>
        Global
    }
}
