// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.AI.Translation.Text
{
    /// <summary> The Translator service client. </summary>
    public partial class TextTranslationClient
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string TOKEN_SCOPE = "https://cognitiveservices.azure.com/.default";
        private const string PLATFORM_PATH = "/translator/text/v3.0";
        private const string DEFAULT_REGION = "global";

        private static readonly Uri DEFAULT_ENDPOINT = new Uri("https://api.cognitive.microsofttranslator.com");

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Azure Key Credential</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(AzureKeyCredential credential, string region = DEFAULT_REGION, TextTranslationClientOptions options = null) : this(DEFAULT_ENDPOINT, credential, region, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="credential">Azure Key Credential</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(Uri endpoint, AzureKeyCredential credential, string region = DEFAULT_REGION, TextTranslationClientOptions options = null) : this(endpoint, options)
        {
            options = options ?? new TextTranslationClientOptions();

            List<HttpPipelinePolicy> authenticationPolicies = new List<HttpPipelinePolicy>()
            {
                new AzureKeyCredentialPolicy(credential, KEY_HEADER_NAME)
            };

            if (!string.IsNullOrWhiteSpace(region) && !string.Equals(DEFAULT_REGION, region, StringComparison.InvariantCultureIgnoreCase))
            {
                authenticationPolicies.Add(new TranslatorRegionalEndpointAuthenticationPolicy(region));
            }

            this._pipeline = HttpPipelineBuilder.Build(options, authenticationPolicies.ToArray(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());

            if (endpoint.IsPlatformHost())
            {
                this._endpoint = new Uri(endpoint, PLATFORM_PATH);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, TextTranslationClientOptions options = null) : this(DEFAULT_ENDPOINT, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(Uri endpoint, TokenCredential credential, TextTranslationClientOptions options = null) : this(endpoint, options)
        {
            var policy = new BearerTokenAuthenticationPolicy(credential, TOKEN_SCOPE);
            options = options ?? new TextTranslationClientOptions();

            this._pipeline = HttpPipelineBuilder.Build(options, new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());

            if (endpoint.IsPlatformHost())
            {
                this._endpoint = new Uri(endpoint, PLATFORM_PATH);
            }
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
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(IEnumerable<string> targetLanguages, IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguages, nameof(targetLanguages));
            Argument.AssertNotNull(content, nameof(content));

            return this.TranslateAsync(targetLanguages, content as object, clientTraceId, sourceLanguage, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="content"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(string targetLanguage, IEnumerable<string> content, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(content, nameof(content));

            return this.TranslateAsync(new[] { targetLanguage }, content as object, from: sourceLanguage, cancellationToken: cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="text"> Text to be translated. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="text"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(string targetLanguage, string text, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(text, nameof(text));

            return this.TranslateAsync(new[] { targetLanguage }, new[] { text } as object, from: sourceLanguage, cancellationToken: cancellationToken);
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
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(IEnumerable<string> targetLanguages, IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguages, nameof(targetLanguages));
            Argument.AssertNotNull(content, nameof(content));

            return this.Translate(targetLanguages, content as object, clientTraceId, sourceLanguage, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(string targetLanguage, IEnumerable<string> content, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(content, nameof(content));

            return this.Translate(new[] { targetLanguage }, content as object, from: sourceLanguage, cancellationToken: cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="text"> Text to be translated. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="text"/> is null. </exception>
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(string targetLanguage, string text, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(text, nameof(text));

            return this.Translate(new[] { targetLanguage }, new[] { text } as object, from: sourceLanguage, cancellationToken: cancellationToken);
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="content"> Array of the text to be transliterated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="content"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, IEnumerable<string> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            return this.TransliterateAsync(language, fromScript, toScript, content as object, clientTraceId, cancellationToken);
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="text"> Text to be transliterated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="text"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, string text, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(text, nameof(text));

            return this.TransliterateAsync(language, fromScript, toScript, new[] { text } as object, cancellationToken: cancellationToken);
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="content"> Array of the text to be transliterated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, IEnumerable<string> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            return this.Transliterate(language, fromScript, toScript, content as object, clientTraceId, cancellationToken);
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="text"> Text to be transliterated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="text"/> is null. </exception>
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, string text, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(text, nameof(text));

            return this.Transliterate(language, fromScript, toScript, new[] { text } as object, cancellationToken: cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(IEnumerable<string> content, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.FindSentenceBoundariesAsync(content as object, clientTraceId, language, script, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(string text, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(text, nameof(text));

            return this.FindSentenceBoundariesAsync(new[] { text } as object, clientTraceId, language, script, cancellationToken);
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
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(IEnumerable<string> content, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.FindSentenceBoundaries(content as object, clientTraceId, language, script, cancellationToken);
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
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(string text, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(text, nameof(text));

            return this.FindSentenceBoundaries(new[] { text } as object, clientTraceId, language, script, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, IEnumerable<string> words, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(words, nameof(words));

            return this.LookupDictionaryEntriesAsync(from, to, words as object, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, string word, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(word, nameof(word));

            return this.LookupDictionaryEntriesAsync(from, to, new[] { word } as object, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, IEnumerable<string> words, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(words, nameof(words));

            return this.LookupDictionaryEntries(from, to, words as object, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, string word, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(word, nameof(word));

            return this.LookupDictionaryEntries(from, to, new[] { word } as object, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, IEnumerable<InputTextWithTranslation> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamplesAsync(from, to, content as object, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, InputTextWithTranslation content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamplesAsync(from, to, new[] { content } as object, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, IEnumerable<InputTextWithTranslation> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamples(from, to, content as object, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, InputTextWithTranslation content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamples(from, to, new[] { content } as object, clientTraceId, cancellationToken);
        }
    }
}
