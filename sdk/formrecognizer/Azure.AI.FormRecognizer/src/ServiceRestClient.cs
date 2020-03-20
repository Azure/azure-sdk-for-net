// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    internal partial class ServiceRestClient
    {
        internal static string GetContentTypeString(ContentType contentType)
        {
            return contentType switch
            {
                ContentType.Pdf => "application/pdf",
                ContentType.Png => "image/png",
                ContentType.Jpeg => "image/jpeg",
                ContentType.Tiff => "image/tiff",
                _ => throw new NotSupportedException($"The content type {contentType} is not supported."),
            };
        }

        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, Stream stream, ContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", GetContentTypeString(contentType));
            request.Content = RequestContent.Create(stream);
            //using var content = new Utf8JsonRequestContent();
            //content.JsonWriter.WriteObjectValue(fileStream);
            //request.Content = content;
            return message;
        }

        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, Stream stream, ContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/prebuilt/receipt/analyze", false);
            if (includeTextDetails != null)
            {
                uri.AppendQuery("includeTextDetails", includeTextDetails.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", GetContentTypeString(contentType));
            request.Content = RequestContent.Create(stream);
            //request.Headers.Add("Content-Type", "application/json");
            //using var content = new Utf8JsonRequestContent();
            //content.JsonWriter.WriteObjectValue(fileStream);
            //request.Content = content;
            return message;
        }

        // TODO: Is it ok that includeTextDetails is missing here?  Or is it an issue with the Swagger?
        // This is missing from the swagger -- following up with service team.
        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(Stream stream, ContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", GetContentTypeString(contentType));
            request.Content = RequestContent.Create(stream);
            //request.Headers.Add("Content-Type", "application/json");
            //using var content = new Utf8JsonRequestContent();
            //content.JsonWriter.WriteObjectValue(fileStream);
            //request.Content = content;
            return message;
        }
    }
}
