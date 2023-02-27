// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.TextTranslator.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.AI.TextTranslator
{
    /// <summary> The Translator service client. </summary>
    public partial class TranslatorClient
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string TOKEN_SCOPE = "https://cognitiveservices.azure.com/.default";

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="key">Security key</param>
        /// <param name="region">Region</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, AzureKeyCredential key, string region) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new GlobalEndpointAuthenticationPolicy(key, region);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="key">Security key</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, AzureKeyCredential key) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new AzureKeyCredentialPolicy(key, KEY_HEADER_NAME);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            this._endpoint = new Uri(endpoint, "/translator/text/v3.0");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorClient"/> class.
        /// </summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="token">Cognitive Services Token</param>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public TranslatorClient(Uri endpoint, TokenCredential token) : this(endpoint)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            var policy = new BearerTokenAuthenticationPolicy(token, TOKEN_SCOPE);

            this._pipeline = HttpPipelineBuilder.Build(new TranslatorClientOptions(), new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<TranslatedTextElement>>> TranslateAsync(IEnumerable<string> to, IEnumerable<InputText> content, string clientTraceId = null, string @from = null, TextTypes? textType = null, string category = null, ProfanityActions? profanityAction = null, ProfanityMarkers? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.TranslateAsync(to, content as object, clientTraceId, from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="to">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IReadOnlyList<TranslatedTextElement>> Translate(IEnumerable<string> to, IEnumerable<InputText> content, string clientTraceId = null, string @from = null, TextTypes? textType = null, string category = null, ProfanityActions? profanityAction = null, ProfanityMarkers? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.Translate(to, content as object, clientTraceId, from, textType, category, profanityAction, profanityMarker, includeAlignment, includeSentenceLength, suggestedFrom, fromScript, toScript, allowFallback, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, IEnumerable<InputText> content, string clientTraceId = null, CancellationToken cancellationToken = default)
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
        /// <param name="content"> Array of the text to be transliterated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, IEnumerable<InputText> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(content, nameof(content));

            return this.Transliterate(language, fromScript, toScript, content as object, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<BreakSentenceElement>>> BreakSentenceAsync(IEnumerable<InputText> content, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.BreakSentenceAsync(content as object, clientTraceId, language, script, cancellationToken);
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
        public virtual Response<IReadOnlyList<BreakSentenceElement>> BreakSentence(IEnumerable<InputText> content, string clientTraceId = null, string language = null, string script = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return this.BreakSentence(content as object, clientTraceId, language, script, cancellationToken);
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
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        public virtual Task<Response<IReadOnlyList<DictionaryLookupElement>>> DictionaryLookupAsync(string @from, string to, IEnumerable<InputText> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.DictionaryLookupAsync(from, to, content as object, clientTraceId, cancellationToken);
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
        /// <param name="content"> Array of the text to be sent to dictionary. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="from"/>, <paramref name="to"/> or <paramref name="content"/> is null. </exception>
        public virtual Response<IReadOnlyList<DictionaryLookupElement>> DictionaryLookup(string @from, string to, IEnumerable<InputText> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.DictionaryLookup(from, to, content as object, clientTraceId, cancellationToken);
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
        public virtual Task<Response<IReadOnlyList<DictionaryExampleElement>>> DictionaryExamplesAsync(string @from, string to, IEnumerable<InputTextWithTranslation> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.DictionaryExamplesAsync(from, to, content as object, clientTraceId, cancellationToken);
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
        public virtual Response<IReadOnlyList<DictionaryExampleElement>> DictionaryExamples(string @from, string to, IEnumerable<InputTextWithTranslation> content, string clientTraceId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(@from, nameof(@from));
            Argument.AssertNotNull(to, nameof(to));
            Argument.AssertNotNull(content, nameof(content));

            return this.DictionaryExamples(from, to, content as object, clientTraceId, cancellationToken);
        }
    }
}
