// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Custom;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using System.Linq;

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

        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<ModelInfo> GetCustomModelsPageableModelInfo(GetModelOptions? op, CancellationToken cancellationToken = default)
        {
            Page<ModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetCustomModels(op, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new ModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<ModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new ModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<ModelInfo> GetCustomModelsPageableModelInfoAsync(GetModelOptions? op, CancellationToken cancellationToken = default)
        {

            async Task<Page<ModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetCustomModelsAsync(op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new ModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<ModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new ModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
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

        // TODO: Is it ok that includeTextDetails is missing here?  Or is it an issue with the Swagger?
        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(Stream stream, FormContentType contentType)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
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

        // TODO: Is it ok that includeTextDetails is missing here?  Or is it an issue with the Swagger?
        public async ValueTask<ResponseWithHeaders<AnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeLayoutAsyncRequest(stream, contentType);
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

        public ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(Stream stream, FormContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeLayoutAsyncRequest(stream, contentType);
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
        #endregion Layout
    }
}
