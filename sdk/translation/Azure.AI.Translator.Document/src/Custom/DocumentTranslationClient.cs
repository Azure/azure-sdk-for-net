// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translator.Document
{
    [CodeGenSuppress("CreateDocumentTranslateRequest", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("DocumentTranslate", typeof(string), typeof(DocumentTranslateContent), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("DocumentTranslateAsync", typeof(string), typeof(DocumentTranslateContent), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("DocumentTranslate", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("DocumentTranslateAsync", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    public partial class DocumentTranslationClient
    {
        /// <summary> API to translate a document. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document to Translate. </param>
        /// <param name="sourceGlossaries"> Glossaries / translation memory will be used during translation. </param>
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
        public virtual async Task<Response<BinaryData>> DocumentTranslateAsync(string targetLanguage, MultipartFormFileData sourceDocument, IEnumerable<MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await DocumentTranslateAsync(targetLanguage, sourceDocument, sourceGlossaries, sourceLanguage, category, allowFallback, context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> API to translate a document. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document to Translate. </param>
        /// <param name="sourceGlossaries"> Glossaries / translation memory will be used during translation. </param>
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
        public virtual Response<BinaryData> DocumentTranslate(string targetLanguage, MultipartFormFileData sourceDocument, IEnumerable<MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = DocumentTranslate(targetLanguage, sourceDocument, sourceGlossaries, sourceLanguage, category, allowFallback, context);
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
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document to Translate. </param>
        /// <param name="sourceGlossaries"> Glossaries / translation memory will be used during translation. </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="sourceDocument"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> DocumentTranslateAsync(string targetLanguage, MultipartFormFileData sourceDocument, IEnumerable<MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.DocumentTranslate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDocumentTranslateRequest(targetLanguage, sourceDocument, sourceGlossaries, sourceLanguage, category, allowFallback, context);
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
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output document.
        /// The target language must be one of the supported languages included in the translation scope.
        /// For example if you want to translate the document in German language, then use targetLanguage=de
        /// </param>
        /// <param name="sourceDocument"> Document to Translate. </param>
        /// <param name="sourceGlossaries"> Glossaries / translation memory will be used during translation. </param>
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
        /// <exception cref="ArgumentNullException"> <paramref name="targetLanguage"/> or <paramref name="sourceDocument"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response DocumentTranslate(string targetLanguage, MultipartFormFileData sourceDocument, IEnumerable<MultipartFormFileData> sourceGlossaries = null, string sourceLanguage = null, string category = null, bool? allowFallback = null, RequestContext context = null)
        {
            Argument.AssertNotNull(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNull(sourceDocument, nameof(sourceDocument));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("DocumentTranslationClient.DocumentTranslate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDocumentTranslateRequest(targetLanguage, sourceDocument, sourceGlossaries, sourceLanguage, category, allowFallback, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDocumentTranslateRequest(string targetLanguage, MultipartFormFileData sourceDocument, IEnumerable<MultipartFormFileData> sourceGlossaries, string sourceLanguage, string category, bool? allowFallback, RequestContext context)
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

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(sourceDocument.Content, "document", sourceDocument.Name, new Dictionary<string, string>(sourceDocument.Headers)
            {
                {"Content-Type", sourceDocument.ContentType }
            });

            if (sourceGlossaries != null)
            {
                foreach (MultipartFormFileData glossary in sourceGlossaries)
                {
                    requestContent.Add(glossary.Content, "glossary", glossary.Name, new Dictionary<string, string>(glossary.Headers)
                {
                    {"Content-Type", glossary.ContentType }
                });
                }
            }

            requestContent.ApplyToRequest(request);
            return message;
        }
    }
}
