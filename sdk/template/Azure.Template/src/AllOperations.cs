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
    internal partial class AllOperations
    {
        #region Custom
        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, Stream stream, FormContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
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

        internal ResponseWithHeaders<AnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, bool? includeTextDetails, Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                // TODO: Could refactor this so different AnalyzeWithCustomModels overload call the same implementation with different request messages.
                using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, stream, contentType);
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

        internal async ValueTask<ResponseWithHeaders<AnalyzeWithCustomModelHeaders>> AnalyzeWithCustomModelAsync(Guid modelId, bool? includeTextDetails, Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, stream, contentType);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                        var headers = new AnalyzeWithCustomModelHeaders(message.Response);
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
        #endregion Custom

        #region Receipt


        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, Stream stream, FormContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
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

        public async ValueTask<ResponseWithHeaders<AnalyzeReceiptAsyncHeaders>> AnalyzeReceiptAsyncAsync(bool? includeTextDetails, Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeReceiptAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, stream, contentType);
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

        public ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(bool? includeTextDetails, Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeReceiptAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeReceiptAsyncRequest(includeTextDetails, stream, contentType);
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

        #endregion Receipt

        #region Layout
        #endregion Layout
    }
}
