// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Custom;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    [CodeGenClient("")]
    internal partial class ServiceClient
    {
        #region Custom

        internal ResponseWithHeaders<AnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, bool? includeTextDetails, Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                // TODO: Could refactor this so different AnalyzeWithCustomModels overload call the same implementation with different request messages.
                using var message = RestClient.CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, stream, contentType);
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

        internal async ValueTask<ResponseWithHeaders<AnalyzeWithCustomModelHeaders>> AnalyzeWithCustomModelAsync(Guid modelId, bool? includeTextDetails, Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                using var message = RestClient.CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, stream, contentType);
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
        public Pageable<CustomModelInfo> GetCustomModelsPageableModelInfo(GetModelOptions? op, CancellationToken cancellationToken = default)
        {
            Page<CustomModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                var response =  RestClient.GetCustomModels(op, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            Page<CustomModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = RestClient.GetCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<CustomModelInfo> GetCustomModelsPageableModelInfoAsync(GetModelOptions? op, CancellationToken cancellationToken = default)
        {

            async Task<Page<CustomModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsAsync(op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<CustomModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await RestClient.GetCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList.Select(info => new CustomModelInfo(info)), response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion Custom

        #region Receipt

        public ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(bool? includeTextDetails, Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeReceiptAsync");
            scope.Start();
            try
            {
                using var message = RestClient.CreateAnalyzeReceiptAsyncRequest(includeTextDetails, stream, contentType);
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
        // This is missing from the swagger -- following up with service team.
        public async ValueTask<ResponseWithHeaders<AnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = RestClient.CreateAnalyzeLayoutAsyncRequest(stream, contentType);
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

        public ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(Stream stream, ContentType contentType, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeLayoutAsync");
            scope.Start();
            try
            {
                using var message = RestClient.CreateAnalyzeLayoutAsyncRequest(stream, contentType);
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
