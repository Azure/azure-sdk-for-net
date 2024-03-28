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

namespace Azure.AI.Translation.Text
{
    /// <summary> The Translator service client. </summary>
    // Methods are replaced by the version where clientTraceId parameter is of type System.Guid
    [CodeGenSuppress("TranslateAsync", typeof(IEnumerable<string>), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(string), typeof(TextType?), typeof(string), typeof(ProfanityAction?), typeof(ProfanityMarker?), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("Translate", typeof(IEnumerable<string>), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(string), typeof(TextType?), typeof(string), typeof(ProfanityAction?), typeof(ProfanityMarker?), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("TranslateAsync", typeof(IEnumerable<string>), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("Translate", typeof(IEnumerable<string>), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("TransliterateAsync", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Transliterate", typeof(string), typeof(string), typeof(string), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("TransliterateAsync", typeof(string), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("Transliterate", typeof(string), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("FindSentenceBoundariesAsync", typeof(IEnumerable<InputTextItem>), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("FindSentenceBoundaries", typeof(IEnumerable<InputTextItem>), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("FindSentenceBoundariesAsync", typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("FindSentenceBoundaries", typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LookupDictionaryEntriesAsync", typeof(string), typeof(string), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("LookupDictionaryEntries", typeof(string), typeof(string), typeof(IEnumerable<InputTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("LookupDictionaryEntriesAsync", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LookupDictionaryEntries", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LookupDictionaryExamplesAsync", typeof(string), typeof(string), typeof(IEnumerable<DictionaryExampleTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("LookupDictionaryExamples", typeof(string), typeof(string), typeof(IEnumerable<DictionaryExampleTextItem>), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("LookupDictionaryExamplesAsync", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("LookupDictionaryExamples", typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(RequestContext))]
    public partial class TextTranslationClient
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string TOKEN_SCOPE = "https://cognitiveservices.azure.com/.default";
        private const string PLATFORM_PATH = "/translator/text/v3.0";
        private const string DEFAULT_REGION = "global";

        private static readonly Uri DEFAULT_ENDPOINT = new Uri("https://api.cognitive.microsofttranslator.com");

        /// <summary> Initializes a new instance of TextTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported Text Translation endpoints (protocol and hostname, for example:
        ///     https://api.cognitive.microsofttranslator.com).
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        protected TextTranslationClient(Uri endpoint) : this(endpoint, new TextTranslationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of TextTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported Text Translation endpoints (protocol and hostname, for example:
        ///     https://api.cognitive.microsofttranslator.com).
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        protected TextTranslationClient(Uri endpoint, TextTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new TextTranslationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Azure Key Credential</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(AzureKeyCredential credential, string region = DEFAULT_REGION, TextTranslationClientOptions options = default) : this(credential, DEFAULT_ENDPOINT, region, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Azure Key Credential</param>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(AzureKeyCredential credential, Uri endpoint, string region = DEFAULT_REGION, TextTranslationClientOptions options = default) : this(endpoint, options)
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
        public TextTranslationClient(TokenCredential credential, TextTranslationClientOptions options = default) : this(credential, DEFAULT_ENDPOINT, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, Uri endpoint, TextTranslationClientOptions options = default) : this(endpoint, options)
        {
            var policy = new BearerTokenAuthenticationPolicy(credential, TOKEN_SCOPE);
            options = options ?? new TextTranslationClientOptions();

            this._pipeline = HttpPipelineBuilder.Build(options, new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());

            if (endpoint.IsPlatformHost())
            {
                this._endpoint = new Uri(endpoint, PLATFORM_PATH);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="resourceId">The value is the Resource ID for your Translator resource instance.</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, string resourceId, string region = DEFAULT_REGION, TextTranslationClientOptions options = default) : this(DEFAULT_ENDPOINT, options)
        {
            var policy = new TextTranslationAADAuthenticationPolicy(credential, TOKEN_SCOPE, region, resourceId);
            options = options ?? new TextTranslationClientOptions();

            this._pipeline = HttpPipelineBuilder.Build(options, new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
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
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(IEnumerable<string> targetLanguages, IEnumerable<string> content, Guid clientTraceId = default, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguages, nameof(targetLanguages));
            Argument.AssertNotNull(content, nameof(content));

            return this.TranslateAsync(targetLanguages, content.Select(input => new InputTextItem(input)), clientTraceId, sourceLanguage, textType?.ToString(), category, profanityAction?.ToString(), profanityMarker?.ToString(), includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="options">The client translation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(TextTranslationTranslateOptions options, CancellationToken cancellationToken = default)
       {
            Argument.AssertNotNull(options, nameof(options));

            return this.TranslateAsync(options.TargetLanguages, options.Content.Select(input => new InputTextItem(input)), options.ClientTraceId, options.SourceLanguage, options.TextType?.ToString(), options.Category, options.ProfanityAction?.ToString(), options.ProfanityMarker?.ToString(), options.IncludeAlignment, options.IncludeSentenceLength, options.SuggestedFrom, options.FromScript, options.ToScript, options.AllowFallback, cancellationToken);
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

            return this.TranslateAsync(new[] { targetLanguage }, content.Select(input => new InputTextItem(input)), from: sourceLanguage, cancellationToken: cancellationToken);
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

            return this.TranslateAsync(new[] { targetLanguage }, new[] { new InputTextItem(text) }, from: sourceLanguage, cancellationToken: cancellationToken);
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
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(IEnumerable<string> targetLanguages, IEnumerable<string> content, Guid clientTraceId = default, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguages, nameof(targetLanguages));
            Argument.AssertNotNull(content, nameof(content));

            return this.Translate(targetLanguages, content.Select(input => new InputTextItem(input)), clientTraceId, sourceLanguage, textType?.ToString(), category, profanityAction?.ToString(), profanityMarker?.ToString(), includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="options">The client translation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null. </exception>
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(TextTranslationTranslateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return this.Translate(options.TargetLanguages, options.Content.Select(input => new InputTextItem(input)), options.ClientTraceId, options.SourceLanguage, options.TextType?.ToString(), options.Category, options.ProfanityAction?.ToString(), options.ProfanityMarker?.ToString(), options.IncludeAlignment, options.IncludeSentenceLength, options.SuggestedFrom, options.FromScript, options.ToScript, options.AllowFallback, cancellationToken);
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

            return this.Translate(new[] { targetLanguage }, content.Select(input => new InputTextItem(input)), from: sourceLanguage, cancellationToken: cancellationToken);
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

            return this.Translate(new[] { targetLanguage }, new[] { new InputTextItem(text) }, from: sourceLanguage, cancellationToken: cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, IEnumerable<string> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            return this.TransliterateAsync(language, fromScript, toScript, content.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
        }

        /// <summary>Transliterate Text. </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(TextTranslationTransliterateOptions options, CancellationToken cancellationToken = default)
       {
            Argument.AssertNotNull(options, nameof(options));

            return this.TransliterateAsync(options.Language, options.FromScript, options.ToScript, options.Content.Select(input => new InputTextItem(input)), options.ClientTraceId, cancellationToken);
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

            return this.TransliterateAsync(language, fromScript, toScript, new[] { new InputTextItem(text) }, cancellationToken: cancellationToken);
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
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, IEnumerable<string> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            return this.Transliterate(language, fromScript, toScript, content.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
        }

        /// <summary> Transliterate Text. </summary>
        /// <param name="options">The configuration options for the transliterate call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(TextTranslationTransliterateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return this.Transliterate(options.Language, options.FromScript, options.ToScript, options.Content.Select(input => new InputTextItem(input)), options.ClientTraceId, cancellationToken);
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

            return this.Transliterate(language, fromScript, toScript, new[] { new InputTextItem(text) }, cancellationToken: cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(IEnumerable<string> content, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.FindSentenceBoundariesAsync(content.Select(input => new InputTextItem(input)), clientTraceId, language, script, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(string text, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(text, nameof(text));

            return this.FindSentenceBoundariesAsync(new[] { new InputTextItem(text) }, clientTraceId, language, script, cancellationToken);
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
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(IEnumerable<string> content, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.FindSentenceBoundaries(content.Select(input => new InputTextItem(input)), clientTraceId, language, script, cancellationToken);
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
        public virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(string text, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(text, nameof(text));

            return this.FindSentenceBoundaries(new[] { new InputTextItem(text) }, clientTraceId, language, script, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, IEnumerable<string> words, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(words, nameof(words));

            return this.LookupDictionaryEntriesAsync(from, to, words.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, string word, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(word, nameof(word));

            return this.LookupDictionaryEntriesAsync(from, to, new[] { new InputTextItem(word) }, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, IEnumerable<string> words, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(words, nameof(words));

            return this.LookupDictionaryEntries(from, to, words.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, string word, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(word, nameof(word));

            return this.LookupDictionaryEntries(from, to, new[] { new InputTextItem(word) }, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, IEnumerable<InputTextWithTranslation> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamplesAsync(from, to, content.Select(input => new DictionaryExampleTextItem(input.Text, input.Translation)), clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, InputTextWithTranslation content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamplesAsync(from, to, new[] { new DictionaryExampleTextItem(content.Text, content.Translation) }, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, IEnumerable<InputTextWithTranslation> content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamples(from, to, content.Select(input => new DictionaryExampleTextItem(input.Text, input.Translation)), clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, InputTextWithTranslation content, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.LookupDictionaryExamples(from, to, new[] { new DictionaryExampleTextItem(content.Text, content.Translation) }, clientTraceId, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="from">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn't specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html. Allowed values: "Plain" | "Html"
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted. Allowed values: "NoAction" | "Marked" | "Deleted"
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag. . Allowed values: "Asterisk" | "Tag"
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
        /// Specifies a fallback language if the language of the input text can't be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the suggestedFrom language will be assumed.
        /// </param>
        /// <param name="fromScript"> Specifies the script of the input text. </param>
        /// <param name="toScript"> Specifies the script of the translated text. </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        ///
        /// allowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. allowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(IEnumerable<string> to, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, string @from = null, string textType = null, string category = null, string profanityAction = null, string profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await TranslateAsync(to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, @from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, context).ConfigureAwait(false);
            IReadOnlyList<TranslatedTextItem> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<TranslatedTextItem> array = new List<TranslatedTextItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(TranslatedTextItem.DeserializeTranslatedTextItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It's possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="from">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn't specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html. Allowed values: "Plain" | "Html"
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted. Allowed values: "NoAction" | "Marked" | "Deleted"
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag. . Allowed values: "Asterisk" | "Tag"
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
        /// Specifies a fallback language if the language of the input text can't be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the suggestedFrom language will be assumed.
        /// </param>
        /// <param name="fromScript"> Specifies the script of the input text. </param>
        /// <param name="toScript"> Specifies the script of the translated text. </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        ///
        /// allowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. allowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(IEnumerable<string> to, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, string @from = null, string textType = null, string category = null, string profanityAction = null, string profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Translate(to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, @from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, context);
            IReadOnlyList<TranslatedTextItem> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<TranslatedTextItem> array = new List<TranslatedTextItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(TranslatedTextItem.DeserializeTranslatedTextItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="from">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html. Allowed values: &quot;plain&quot; | &quot;html&quot;
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted. Allowed values: &quot;NoAction&quot; | &quot;Marked&quot; | &quot;Deleted&quot;
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag. . Allowed values: &quot;Asterisk&quot; | &quot;Tag&quot;
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> TranslateAsync(IEnumerable<string> to, RequestContent content, Guid clientTraceId = default, string @from = null, string textType = null, string category = null, string profanityAction = null, string profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.Translate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTranslateRequest(to, content, GetClientTraceId(clientTraceId), @from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="from">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html. Allowed values: &quot;plain&quot; | &quot;html&quot;
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted. Allowed values: &quot;NoAction&quot; | &quot;Marked&quot; | &quot;Deleted&quot;
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag. . Allowed values: &quot;Asterisk&quot; | &quot;Tag&quot;
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
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response Translate(IEnumerable<string> to, RequestContent content, Guid clientTraceId = default, string @from = null, string textType = null, string category = null, string profanityAction = null, string profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.Translate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTranslateRequest(to, content, GetClientTraceId(clientTraceId), @from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await TransliterateAsync(language, fromScript, toScript, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context).ConfigureAwait(false);
            IReadOnlyList<TransliteratedText> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<TransliteratedText> array = new List<TransliteratedText>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(TransliteratedText.DeserializeTransliteratedText(item));
            }
            value = array;
            return Response.FromValue(value, response);
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
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Transliterate(language, fromScript, toScript, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context);
            IReadOnlyList<TransliteratedText> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<TransliteratedText> array = new List<TransliteratedText>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(TransliteratedText.DeserializeTransliteratedText(item));
            }
            value = array;
            return Response.FromValue(value, response);
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
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> TransliterateAsync(string language, string fromScript, string toScript, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.Transliterate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTransliterateRequest(language, fromScript, toScript, content, GetClientTraceId(clientTraceId), context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response Transliterate(string language, string fromScript, string toScript, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.Transliterate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateTransliterateRequest(language, fromScript, toScript, content, GetClientTraceId(clientTraceId), context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Find Sentence Boundaries. </summary>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn't specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn't specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestBody"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<BreakSentenceItem>>> FindSentenceBoundariesAsync(IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await FindSentenceBoundariesAsync(RequestContentHelper.FromEnumerable(requestBody), clientTraceId, language, script, context).ConfigureAwait(false);
            IReadOnlyList<BreakSentenceItem> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<BreakSentenceItem> array = new List<BreakSentenceItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(BreakSentenceItem.DeserializeBreakSentenceItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Find Sentence Boundaries. </summary>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn't specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn't specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requestBody"/> is null. </exception>
        internal virtual Response<IReadOnlyList<BreakSentenceItem>> FindSentenceBoundaries(IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = FindSentenceBoundaries(RequestContentHelper.FromEnumerable(requestBody), clientTraceId, language, script, context);
            IReadOnlyList<BreakSentenceItem> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<BreakSentenceItem> array = new List<BreakSentenceItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(BreakSentenceItem.DeserializeBreakSentenceItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Find Sentence Boundaries. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> FindSentenceBoundariesAsync(RequestContent content, Guid clientTraceId = default, string language = null, string script = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.FindSentenceBoundaries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFindSentenceBoundariesRequest(content, GetClientTraceId(clientTraceId), language, script, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Find Sentence Boundaries. </summary>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="language">
        /// Language tag identifying the language of the input text.
        /// If a code isn&apos;t specified, automatic language detection will be applied.
        /// </param>
        /// <param name="script">
        /// Script tag identifying the script used by the input text.
        /// If a script isn&apos;t specified, the default script of the language will be assumed.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response FindSentenceBoundaries(RequestContent content, Guid clientTraceId = default, string language = null, string script = null, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.FindSentenceBoundaries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateFindSentenceBoundariesRequest(content, GetClientTraceId(clientTraceId), language, script, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lookup Dictionary Entries. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<DictionaryLookupItem>>> LookupDictionaryEntriesAsync(string @from, string to, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await LookupDictionaryEntriesAsync(@from, to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context).ConfigureAwait(false);
            IReadOnlyList<DictionaryLookupItem> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<DictionaryLookupItem> array = new List<DictionaryLookupItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(DictionaryLookupItem.DeserializeDictionaryLookupItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Lookup Dictionary Entries. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual Response<IReadOnlyList<DictionaryLookupItem>> LookupDictionaryEntries(string @from, string to, IEnumerable<InputTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = LookupDictionaryEntries(@from, to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context);
            IReadOnlyList<DictionaryLookupItem> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<DictionaryLookupItem> array = new List<DictionaryLookupItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(DictionaryLookupItem.DeserializeDictionaryLookupItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Lookup Dictionary Entries. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> LookupDictionaryEntriesAsync(string @from, string to, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.LookupDictionaryEntries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLookupDictionaryEntriesRequest(@from, to, content, GetClientTraceId(clientTraceId), context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lookup Dictionary Entries. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response LookupDictionaryEntries(string @from, string to, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.LookupDictionaryEntries");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLookupDictionaryEntriesRequest(@from, to, content, GetClientTraceId(clientTraceId), context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lookup Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<DictionaryExampleItem>>> LookupDictionaryExamplesAsync(string @from, string to, IEnumerable<DictionaryExampleTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await LookupDictionaryExamplesAsync(@from, to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context).ConfigureAwait(false);
            IReadOnlyList<DictionaryExampleItem> value = default;
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            List<DictionaryExampleItem> array = new List<DictionaryExampleItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(DictionaryExampleItem.DeserializeDictionaryExampleItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Lookup Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="requestBody"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="requestBody"/> is null. </exception>
        internal virtual Response<IReadOnlyList<DictionaryExampleItem>> LookupDictionaryExamples(string @from, string to, IEnumerable<DictionaryExampleTextItem> requestBody, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = LookupDictionaryExamples(@from, to, RequestContentHelper.FromEnumerable(requestBody), clientTraceId, context);
            IReadOnlyList<DictionaryExampleItem> value = default;
            using var document = JsonDocument.Parse(response.ContentStream);
            List<DictionaryExampleItem> array = new List<DictionaryExampleItem>();
            foreach (var item in document.RootElement.EnumerateArray())
            {
                array.Add(DictionaryExampleItem.DeserializeDictionaryExampleItem(item));
            }
            value = array;
            return Response.FromValue(value, response);
        }

        /// <summary> Lookup Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual async Task<Response> LookupDictionaryExamplesAsync(string @from, string to, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.LookupDictionaryExamples");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLookupDictionaryExamplesRequest(@from, to, content, GetClientTraceId(clientTraceId), context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lookup Dictionary Examples. </summary>
        /// <param name="from">
        /// Specifies the language of the input text.
        /// The source language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="to">
        /// Specifies the language of the output text.
        /// The target language must be one of the supported languages included in the dictionary scope.
        /// </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        internal virtual Response LookupDictionaryExamples(string @from, string to, RequestContent content, Guid clientTraceId = default, RequestContext context = null)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("TextTranslationClient.LookupDictionaryExamples");
            scope.Start();
            try
            {
                using HttpMessage message = CreateLookupDictionaryExamplesRequest(@from, to, content, GetClientTraceId(clientTraceId), context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the value of Client Trace Id.
        /// </summary>
        /// <param name="clientTraceId">Client Trace Id</param>
        /// <returns>Value of Client Trace Id.</returns>
        private static string GetClientTraceId(Guid clientTraceId)
        {
            return clientTraceId == default ? null : clientTraceId.ToString();
        }
    }
}
