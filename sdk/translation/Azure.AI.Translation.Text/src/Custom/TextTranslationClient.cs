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
    // Custom convenience methods that provide additional overloads for the generated methods
    public partial class TextTranslationClient
    {
        private const string KEY_HEADER_NAME = "Ocp-Apim-Subscription-Key";
        private const string DEFAULT_TOKEN_SCOPE = "https://cognitiveservices.azure.com/.default";
        private const string PLATFORM_PATH = "/translator/text";
        private const string DEFAULT_REGION = "global";

        private static readonly Uri DEFAULT_ENDPOINT = new Uri("https://api.cognitive.microsofttranslator.com");

        /// <summary> Initializes a new instance of TextTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported Text Translation endpoints (protocol and hostname, for example:
        ///     https://api.cognitive.microsofttranslator.com).
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public TextTranslationClient(Uri endpoint) : this(endpoint, new TextTranslationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of TextTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported Text Translation endpoints (protocol and hostname, for example:
        ///     https://api.cognitive.microsofttranslator.com).
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public TextTranslationClient(Uri endpoint, TextTranslationClientOptions options)
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
        public TextTranslationClient(TokenCredential credential, TextTranslationClientOptions options = default) : this(credential, DEFAULT_ENDPOINT, DEFAULT_TOKEN_SCOPE, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="tokenScope">Token Scopes</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, Uri endpoint, string tokenScope = DEFAULT_TOKEN_SCOPE, TextTranslationClientOptions options = default) : this(endpoint, options)
        {
            var policy = new BearerTokenAuthenticationPolicy(credential, tokenScope);
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
        /// <param name="tokenScope">Token Scopes</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, string resourceId, string region = DEFAULT_REGION, string tokenScope = DEFAULT_TOKEN_SCOPE, TextTranslationClientOptions options = default) : this(DEFAULT_ENDPOINT, options)
        {
            var policy = new TextTranslationAADAuthenticationPolicy(credential, tokenScope, region, resourceId);
            options = options ?? new TextTranslationClientOptions();

            this._pipeline = HttpPipelineBuilder.Build(options, new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextTranslationClient"/> class.
        /// </summary>
        /// <param name="credential">Cognitive Services Token</param>
        /// <param name="endpoint">Service Endpoint</param>
        /// <param name="resourceId">The value is the Resource ID for your Translator resource instance.</param>
        /// <param name="region">Azure Resource Region</param>
        /// <param name="tokenScope">Token Scopes</param>
        /// <param name="options">Translate Client Options</param>
        public TextTranslationClient(TokenCredential credential, Uri endpoint, string resourceId, string region = DEFAULT_REGION, string tokenScope = DEFAULT_TOKEN_SCOPE, TextTranslationClientOptions options = default) : this(endpoint, options)
        {
            var policy = new TextTranslationAADAuthenticationPolicy(credential, tokenScope, region, resourceId);
            options = options ?? new TextTranslationClientOptions();

            this._pipeline = HttpPipelineBuilder.Build(options, new[] { policy }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
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
        public virtual async Task<Response<TranslatedTextItem>> TranslateAsync(string targetLanguage, string text, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(text, nameof(text));

            Response<IReadOnlyList<TranslatedTextItem>> response = await TranslateAsync(targetLanguage, [text], sourceLanguage, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
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

            IEnumerable<TranslateInputItem> inputItems = content.Select(input => new TranslateInputItem(input, [new TranslationTarget(targetLanguage)]) { Language = sourceLanguage });
            return TranslateAsync(inputItems, cancellationToken: cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="input"> Defines the input of the translation request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual async Task<Response<TranslatedTextItem>> TranslateAsync(TranslateInputItem input, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            Response<IReadOnlyList<TranslatedTextItem>> response = await TranslateAsync([input], clientTraceId, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
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
        public virtual Response<TranslatedTextItem> Translate(string targetLanguage, string text, string sourceLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(text, nameof(text));

            Response<IReadOnlyList<TranslatedTextItem>> response = Translate(targetLanguage, [text], sourceLanguage, cancellationToken: cancellationToken);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
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

            IEnumerable<TranslateInputItem> inputItems = content.Select(input => new TranslateInputItem(input, [new TranslationTarget(targetLanguage)]) { Language = sourceLanguage });
            return Translate(inputItems, cancellationToken: cancellationToken);
        }

        /// <summary> Translate Text. </summary>
        /// <param name="input"> Defines the input of the translation request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
        public virtual Response<TranslatedTextItem> Translate(TranslateInputItem input, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            Response<IReadOnlyList<TranslatedTextItem>> response = Translate([input], clientTraceId, cancellationToken);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
        }

        /// <summary> Translate Text. </summary>
        /// <param name="inputs"> Defines the inputs of the translation request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
        public virtual async Task<Response<IReadOnlyList<TranslatedTextItem>>> TranslateAsync(IEnumerable<TranslateInputItem> inputs, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Response<TranslationResult> response = await TranslateAsync(new TranslateInputs(inputs), GetClientTraceId(clientTraceId), cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Value, response.GetRawResponse());
        }

        /// <summary> Translate Text. </summary>
        /// <param name="inputs"> Defines the inputs of the translation request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
        public virtual Response<IReadOnlyList<TranslatedTextItem>> Translate(IEnumerable<TranslateInputItem> inputs, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Response<TranslationResult> response = Translate(new TranslateInputs(inputs), GetClientTraceId(clientTraceId), cancellationToken);
            return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
        public async virtual Task<Response<TransliteratedText>> TransliterateAsync(string language, string fromScript, string toScript, string text, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(text, nameof(text));

            Response<IReadOnlyList<TransliteratedText>> response = await TransliterateAsync(language, fromScript, toScript, new[] { new InputTextItem(text) }, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
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

            return TransliterateAsync(language, fromScript, toScript, content.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
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
        public virtual Response<TransliteratedText> Transliterate(string language, string fromScript, string toScript, string text, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(text, nameof(text));

            Response<IReadOnlyList<TransliteratedText>> response = Transliterate(language, fromScript, toScript, new[] { new InputTextItem(text) }, cancellationToken: cancellationToken);
            return Response.FromValue(response.Value.FirstOrDefault(), response.GetRawResponse());
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

            return Transliterate(language, fromScript, toScript, content.Select(input => new InputTextItem(input)), clientTraceId, cancellationToken);
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
        /// <param name="inputs"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="inputs"/> is null. </exception>
        internal virtual async Task<Response<IReadOnlyList<TransliteratedText>>> TransliterateAsync(string language, string fromScript, string toScript, IEnumerable<InputTextItem> inputs, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(inputs, nameof(inputs));

            Response<TransliterateResult> response = await TransliterateAsync(language, fromScript, toScript, new TransliterateInputs(inputs), GetClientTraceId(clientTraceId), cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
        /// <param name="inputs"> Defines the content of the request. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/>, <paramref name="fromScript"/>, <paramref name="toScript"/> or <paramref name="inputs"/> is null. </exception>
        internal virtual Response<IReadOnlyList<TransliteratedText>> Transliterate(string language, string fromScript, string toScript, IEnumerable<InputTextItem> inputs, Guid clientTraceId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(fromScript, nameof(fromScript));
            Argument.AssertNotNull(toScript, nameof(toScript));
            Argument.AssertNotNull(inputs, nameof(inputs));

            Response<TransliterateResult> response = Transliterate(language, fromScript, toScript, new TransliterateInputs(inputs), GetClientTraceId(clientTraceId), cancellationToken);
            return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
