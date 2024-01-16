// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentTranslationClient
    {
        /// <summary> API to translate a document. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document Translate Request / Content. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        ///     from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        ///     project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        ///     Possible values are: true (default) or false.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="sourceDocument"/> is null. </exception>
        public virtual async Task<Response<BinaryData>> DocumentTranslateAsync(string targetLanguage, DocumentContent sourceDocument, string sourceLanguage = null, string category = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = sourceDocument.ToRequestContent();
            Response response = await DocumentTranslateAsync(targetLanguage, content, sourceLanguage, category, allowFallback, context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> API to translate a document. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document Translate Request / Content. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        ///     from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        ///     project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        ///     Possible values are: true (default) or false.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="sourceDocument"/> is null. </exception>
        public virtual Response<BinaryData> DocumentTranslate(string targetLanguage, DocumentContent sourceDocument, string sourceLanguage = null, string category = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = sourceDocument.ToRequestContent();
            Response response = DocumentTranslate(targetLanguage, content, sourceLanguage, category, allowFallback, context);
            return Response.FromValue(response.Content, response);
        }

        /// <summary>
        /// [Protocol Method] API to translate a document.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DocumentTranslateAsync(string,DocumentContent,string,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="requestContent"> The content to send as the body of the request. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        ///     from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        ///     project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        ///     Possible values are: true (default) or false.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="requestContent"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> DocumentTranslateAsync(string targetLanguage, RequestContent requestContent, string sourceLanguage = null, string category = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(requestContent, nameof(requestContent));

            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.DocumentTranslate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDocumentTranslateRequest(targetLanguage, requestContent, sourceLanguage, category, allowFallback, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] API to translate a document.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DocumentTranslate(string,DocumentContent,string,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="requestContent"> The content to send as the body of the request. </param>
        /// <param name="sourceLanguage">
        /// Specifies source language of the input document.
        /// If this parameter isn't specified, automatic language detection is applied to determine the source language.
        /// For example if the source document is written in English, then use sourceLanguage=en
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        ///     from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        ///     project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn't exist.
        ///     Possible values are: true (default) or false.
        /// </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="requestContent"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response DocumentTranslate(string targetLanguage, RequestContent requestContent, string sourceLanguage = null, string category = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(requestContent, nameof(requestContent));

            using var scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.DocumentTranslate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDocumentTranslateRequest(targetLanguage, requestContent, sourceLanguage, category, allowFallback, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDocumentTranslateRequest(string targetLanguage, RequestContent requestContent, string sourceLanguage, string category, bool? allowFallback, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/document:translate", false);
            uri.AppendQuery("targetLanguage", targetLanguage, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (sourceLanguage != null)
            {
                uri.AppendQuery("sourceLanguage", sourceLanguage, true);
            }
            if (category != null)
            {
                uri.AppendQuery("category", category, true);
            }
            if (allowFallback != null)
            {
                uri.AppendQuery("allowFallback", allowFallback.Value, true);
            }
            request.Uri = uri;
            request.Content = requestContent;
            (requestContent as MultipartFormDataContent).ApplyToRequest(request);
            return message;
        }
    }
}
