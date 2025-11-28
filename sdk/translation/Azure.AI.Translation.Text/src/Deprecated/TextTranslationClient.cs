// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Text.Json;
using System.Security.Principal;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> The Translator service client. </summary>
    // Deprecated methods of TextTranslationClient
    public partial class TextTranslationClient
    {
        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguages">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted.
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <param name="includeAlignment">
        /// Specifies whether to include alignment projection from source text to translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="includeSentenceLength">
        /// Specifies whether to include sentence boundaries for the input text and the translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="suggestedFrom">
        /// Specifies a fallback language if the language of the input text can&apos;t be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the suggestedFrom language will be assumed.
        /// </param>
        /// <param name="fromScript"> Specifies the script of the input text. </param>
        /// <param name="toScript"> Specifies the script of the translated text. </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// Possible values are: true (default) or false.
        ///
        /// allowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. allowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguages"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(IEnumerable<string> targetLanguages, IEnumerable<string> content, Guid clientTraceId = default, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Translate Text. </summary>
        /// <param name="options">The client translation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(TextTranslationTranslateOptions options, CancellationToken cancellationToken = default)
       {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguages">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted.
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <param name="includeAlignment">
        /// Specifies whether to include alignment projection from source text to translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="includeSentenceLength">
        /// Specifies whether to include sentence boundaries for the input text and the translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="suggestedFrom">
        /// Specifies a fallback language if the language of the input text can&apos;t be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the suggestedFrom language will be assumed.
        /// </param>
        /// <param name="fromScript"> Specifies the script of the input text. </param>
        /// <param name="toScript"> Specifies the script of the translated text. </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// Possible values are: true (default) or false.
        ///
        /// allowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. allowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguages"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(IEnumerable<string> targetLanguages, IEnumerable<string> content, Guid clientTraceId = default, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Translate Text. </summary>
        /// <param name="options">The client translation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(TextTranslationTranslateOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary>Transliterate Text. </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(TextTranslationTransliterateOptions options, CancellationToken cancellationToken = default)
       {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="options">The configuration options for the transliterate call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(TextTranslationTransliterateOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Break Sentence. </summary>
        /// <param name="content"> Array of the text for which values the sentence boundaries will be calculated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(IEnumerable<string> content, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Break Sentence. </summary>
        /// <param name="text"> Array of the text for which values the sentence boundaries will be calculated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(string text, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Break Sentence. </summary>
        /// <param name="content"> Array of the text for which values the sentence boundaries will be calculated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(IEnumerable<string> content, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Break Sentence. </summary>
        /// <param name="text"> Array of the text for which values the sentence boundaries will be calculated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(string text, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Lookup. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="words"> Array of the words to lookup in the dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="words"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, IEnumerable<string> words, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Lookup. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="word"> A word to lookup in the dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="word"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, string word, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Lookup. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="words"> Array of the words to lookup in the dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="words"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, IEnumerable<string> words, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Lookup. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="word"> A word to lookup in the dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="word"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, string word, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, IEnumerable<InputTextWithTranslation> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, InputTextWithTranslation content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, IEnumerable<InputTextWithTranslation> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }

        /// <summary> Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, InputTextWithTranslation content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported.");
        }
    }
}
