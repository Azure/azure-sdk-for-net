// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    // Data plane generated client.
    /// <summary> The SingleDocumentTranslation service client. </summary>
    public partial class SingleDocumentTranslationClient
    {
        /// <summary> Initializes a new instance of SingleDocumentTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported document Translation endpoint, protocol and hostname, for example:
        /// https://{TranslatorResourceName}-doctranslation.cognitiveservices.azure.com
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SingleDocumentTranslationClient(Uri endpoint) : this(endpoint, new DocumentTranslationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of SingleDocumentTranslationClient. </summary>
        /// <param name="endpoint">
        /// Supported document Translation endpoint, protocol and hostname, for example:
        /// https://{TranslatorResourceName}-doctranslation.cognitiveservices.azure.com
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SingleDocumentTranslationClient(Uri endpoint, DocumentTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new DocumentTranslationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Submit a single document translation request to the Document Translation service. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="documentTranslateContent"> Document Translate Request Content. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="documentTranslateContent"/> is null. </exception>
        /// <remarks> Use this API to submit a single translation request to the Document Translation Service. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002
        public virtual async Task<Response<BinaryData>> TranslateAsync(string targetLanguage, DocumentTranslateContent documentTranslateContent, string sourceLanguage, string category, bool? allowFallback, CancellationToken cancellationToken)
#pragma warning restore AZC0002
            => await TranslateAsync(targetLanguage, documentTranslateContent, sourceLanguage, category, allowFallback, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Submit a single document translation request to the Document Translation service. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="documentTranslateContent"> Document Translate Request Content. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="documentTranslateContent"/> is null. </exception>
        /// <remarks> Use this API to submit a single translation request to the Document Translation Service. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002
        public virtual Response<BinaryData> Translate(string targetLanguage, DocumentTranslateContent documentTranslateContent, string sourceLanguage, string category, bool? allowFallback, CancellationToken cancellationToken)
#pragma warning restore AZC0002
            => Translate(targetLanguage, documentTranslateContent, sourceLanguage, category, allowFallback, null, cancellationToken);

        /// <summary>
        /// [Protocol Method] Submit a single document translation request to the Document Translation service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="TranslateAsync(string,DocumentTranslateContent,string,string,bool?,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Content Type as multipart/form-data. Allowed values: "multipart/form-data". </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> TranslateAsync(string targetLanguage, RequestContent content, string contentType, string sourceLanguage, string category, bool? allowFallback, RequestContext context)
            => await TranslateAsync(targetLanguage, content, contentType, sourceLanguage, category, allowFallback, null, context).ConfigureAwait(false);

        /// <summary>
        /// [Protocol Method] Submit a single document translation request to the Document Translation service
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Translate(string,DocumentTranslateContent,string,string,bool?,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Content Type as multipart/form-data. Allowed values: "multipart/form-data". </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        /// Possible values are: true (default) or false.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Translate(string targetLanguage, RequestContent content, string contentType, string sourceLanguage, string category, bool? allowFallback, RequestContext context)
            => Translate(targetLanguage, content, contentType, sourceLanguage, category, allowFallback, null, context);
    }
}
