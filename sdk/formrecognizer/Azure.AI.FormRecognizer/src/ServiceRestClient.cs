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
        internal static string GetContentTypeString(FormContentType contentType)
        {
            return contentType switch
            {
                FormContentType.Pdf => "application/pdf",
                FormContentType.Png => "image/png",
                FormContentType.Jpeg => "image/jpeg",
                FormContentType.Tiff => "image/tiff",
                _ => throw new NotSupportedException($"The content type {contentType} is not supported."),
            };
        }

        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, Stream stream, FormContentType contentType)
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

        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, Stream stream, FormContentType contentType)
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
        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(Stream stream, FormContentType contentType)
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

        //// Workaround for autorest bug
        /// <summary> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, bool? includeTextDetails, SourcePath_internal fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, fileStream);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeWithCustomModelHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, SourcePath_internal fileStream)
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
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(fileStream);
            request.Content = content;
            return message;
        }

        /// <summary> Extract text and layout information from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<AnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(SourcePath_internal fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeLayoutAsyncRequest(fileStream);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeLayoutAsyncHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Extract text and layout information from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(SourcePath_internal fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeLayoutAsyncRequest(fileStream);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeLayoutAsyncHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(SourcePath_internal fileStream)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyze", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(fileStream);
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, SourcePath_internal fileStream)
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
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(fileStream);
            request.Content = content;
            return message;
        }
        /// <summary> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<AnalyzeReceiptAsyncHeaders>> AnalyzeReceiptAsyncAsync(bool? includeTextDetails, SourcePath_internal fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeReceiptAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, fileStream);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeReceiptAsyncHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Extract field text and semantic values from a given receipt document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(bool? includeTextDetails, SourcePath_internal fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeReceiptAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, fileStream);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeReceiptAsyncHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
