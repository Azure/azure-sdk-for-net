// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentTranslationClient
    {
        internal HttpMessage CreateDocumentTranslateRequest(string targetLanguage, RequestContent content, string sourceLanguage, string category, bool? allowFallback, RequestContext context)
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
            request.Content = content;
            (content as MultipartFormDataContent).ApplyToRequest(request);
            return message;
        }
    }
}
