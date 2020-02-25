// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Template.Mocdels;
using Azure.Template.Models;

namespace Azure.AI.FormRecognizer
{
    internal partial class AllOperations
    {
        private string endpoint;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of AllOperations. </summary>
        public AllOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            this.endpoint = endpoint;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateTrainCustomModelAsyncRequest(TrainRequest trainRequest)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(trainRequest);
            request.Content = content;
            return message;
        }
        /// <summary> Create and train a custom model. The request must include a source parameter that is either an externally accessible Azure storage blob container Uri (preferably a Shared Access Signature Uri) or valid path to a data folder in a locally mounted drive. When local paths are specified, they must follow the Linux/Unix path format and be an absolute path rooted to the input mount configuration setting value e.g., if &apos;{Mounts:Input}&apos; configuration setting value is &apos;/input&apos; then a valid source path would be &apos;/input/contosodataset&apos;. All data to be trained is expected to be under the source folder or sub folders under it. Models are trained using documents that are of the following content type - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos;, &apos;image/tiff&apos;. Other type of content is ignored. </summary>
        /// <param name="trainRequest"> Training request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TrainCustomModelAsyncHeaders>> TrainCustomModelAsyncAsync(TrainRequest trainRequest, CancellationToken cancellationToken = default)
        {
            if (trainRequest == null)
            {
                throw new ArgumentNullException(nameof(trainRequest));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.TrainCustomModelAsync");
            scope.Start();
            try
            {
                using var message = CreateTrainCustomModelAsyncRequest(trainRequest);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        var headers = new TrainCustomModelAsyncHeaders(message.Response);
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
        /// <summary> Create and train a custom model. The request must include a source parameter that is either an externally accessible Azure storage blob container Uri (preferably a Shared Access Signature Uri) or valid path to a data folder in a locally mounted drive. When local paths are specified, they must follow the Linux/Unix path format and be an absolute path rooted to the input mount configuration setting value e.g., if &apos;{Mounts:Input}&apos; configuration setting value is &apos;/input&apos; then a valid source path would be &apos;/input/contosodataset&apos;. All data to be trained is expected to be under the source folder or sub folders under it. Models are trained using documents that are of the following content type - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos;, &apos;image/tiff&apos;. Other type of content is ignored. </summary>
        /// <param name="trainRequest"> Training request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TrainCustomModelAsyncHeaders> TrainCustomModelAsync(TrainRequest trainRequest, CancellationToken cancellationToken = default)
        {
            if (trainRequest == null)
            {
                throw new ArgumentNullException(nameof(trainRequest));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.TrainCustomModelAsync");
            scope.Start();
            try
            {
                using var message = CreateTrainCustomModelAsyncRequest(trainRequest);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        var headers = new TrainCustomModelAsyncHeaders(message.Response);
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
        internal HttpMessage CreateGetCustomModelsRequest(SomeEnum? op)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models", false);
            if (op != null)
            {
                uri.AppendQuery("op", op.Value.ToString(), true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CustomModelCollection>> GetCustomModelsAsync(SomeEnum? op, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModels");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelsRequest(op);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = CustomModelCollection.DeserializeCustomModelCollection(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        public Response<CustomModelCollection> GetCustomModels(SomeEnum? op, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModels");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelsRequest(op);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = CustomModelCollection.DeserializeCustomModelCollection(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateGetCustomModelRequest(Guid modelId, bool? includeKeys)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            if (includeKeys != null)
            {
                uri.AppendQuery("includeKeys", includeKeys.Value, true);
            }
            request.Uri = uri;
            return message;
        }
        /// <summary> Get detailed information about a custom model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeKeys"> Include list of extracted keys in model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Model>> GetCustomModelAsync(Guid modelId, bool? includeKeys, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModel");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelRequest(modelId, includeKeys);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Model.DeserializeModel(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Get detailed information about a custom model. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeKeys"> Include list of extracted keys in model information. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Model> GetCustomModel(Guid modelId, bool? includeKeys, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModel");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelRequest(modelId, includeKeys);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Model.DeserializeModel(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateDeleteCustomModelRequest(Guid modelId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Mark model for deletion. Model artifacts will be permanently removed within a predetermined period. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteCustomModelAsync(Guid modelId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteCustomModel");
            scope.Start();
            try
            {
                using var message = CreateDeleteCustomModelRequest(modelId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
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
        /// <summary> Mark model for deletion. Model artifacts will be permanently removed within a predetermined period. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response DeleteCustomModel(Guid modelId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.DeleteCustomModel");
            scope.Start();
            try
            {
                using var message = CreateDeleteCustomModelRequest(modelId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
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
        internal HttpMessage CreateAnalyzeWithCustomModelRequest(Guid modelId, bool? includeTextDetails, SourcePath fileStream)
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
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(fileStream);
            request.Content = content;
            return message;
        }
        /// <summary> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<AnalyzeWithCustomModelHeaders>> AnalyzeWithCustomModelAsync(Guid modelId, bool? includeTextDetails, SourcePath fileStream, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.AnalyzeWithCustomModel");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeWithCustomModelRequest(modelId, includeTextDetails, fileStream);
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
        /// <summary> Extract key-value pairs, tables, and semantic values from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="includeTextDetails"> Include text lines and element references in the result. </param>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<AnalyzeWithCustomModelHeaders> AnalyzeWithCustomModel(Guid modelId, bool? includeTextDetails, SourcePath fileStream, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateGetAnalyzeFormResultRequest(Guid modelId, Guid resultId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/custom/models/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Obtain current status and the result of the analyze form operation. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AnalyzeOperationResult>> GetAnalyzeFormResultAsync(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeFormResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeFormResultRequest(modelId, resultId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Obtain current status and the result of the analyze form operation. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AnalyzeOperationResult> GetAnalyzeFormResult(Guid modelId, Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeFormResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeFormResultRequest(modelId, resultId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateAnalyzeReceiptAsyncRequest(bool? includeTextDetails, SourcePath fileStream)
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
        public async ValueTask<ResponseWithHeaders<AnalyzeReceiptAsyncHeaders>> AnalyzeReceiptAsyncAsync(bool? includeTextDetails, SourcePath fileStream, CancellationToken cancellationToken = default)
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
        public ResponseWithHeaders<AnalyzeReceiptAsyncHeaders> AnalyzeReceiptAsync(bool? includeTextDetails, SourcePath fileStream, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateGetAnalyzeReceiptResultRequest(Guid resultId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/prebuilt/receipt/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Track the progress and obtain the result of the analyze receipt operation. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AnalyzeOperationResult>> GetAnalyzeReceiptResultAsync(Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeReceiptResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeReceiptResultRequest(resultId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Track the progress and obtain the result of the analyze receipt operation. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AnalyzeOperationResult> GetAnalyzeReceiptResult(Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeReceiptResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeReceiptResultRequest(resultId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateAnalyzeLayoutAsyncRequest(SourcePath fileStream)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
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
        /// <summary> Extract text and layout information from a given document. The input document must be of one of the supported content types - &apos;application/pdf&apos;, &apos;image/jpeg&apos;, &apos;image/png&apos; or &apos;image/tiff&apos;. Alternatively, use &apos;application/json&apos; type to specify the location (Uri or local path) of the document to be analyzed. </summary>
        /// <param name="fileStream"> .json, .pdf, .jpg, .png or .tiff type file stream. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<AnalyzeLayoutAsyncHeaders>> AnalyzeLayoutAsyncAsync(SourcePath fileStream, CancellationToken cancellationToken = default)
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
        public ResponseWithHeaders<AnalyzeLayoutAsyncHeaders> AnalyzeLayoutAsync(SourcePath fileStream, CancellationToken cancellationToken = default)
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
        internal HttpMessage CreateGetAnalyzeLayoutResultRequest(Guid resultId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/formrecognizer/v2.0-preview", false);
            uri.AppendPath("/layout/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Track the progress and obtain the result of the analyze layout operation. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AnalyzeOperationResult>> GetAnalyzeLayoutResultAsync(Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeLayoutResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeLayoutResultRequest(resultId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Track the progress and obtain the result of the analyze layout operation. </summary>
        /// <param name="resultId"> Analyze operation result identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AnalyzeOperationResult> GetAnalyzeLayoutResult(Guid resultId, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetAnalyzeLayoutResult");
            scope.Start();
            try
            {
                using var message = CreateGetAnalyzeLayoutResultRequest(resultId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = AnalyzeOperationResult.DeserializeAnalyzeOperationResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        internal HttpMessage CreateGetCustomModelsNextPageRequest(string nextLink)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(nextLink, false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get information about all custom models. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<CustomModelCollection>> GetCustomModelsNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModels");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelsNextPageRequest(nextLink);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = CustomModelCollection.DeserializeCustomModelCollection(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<CustomModelCollection> GetCustomModelsNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var scope = clientDiagnostics.CreateScope("AllOperations.GetCustomModels");
            scope.Start();
            try
            {
                using var message = CreateGetCustomModelsNextPageRequest(nextLink);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = CustomModelCollection.DeserializeCustomModelCollection(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
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
        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public AsyncPageable<ModelInfo> GetCustomModelsPageableAsync(SomeEnum? op, CancellationToken cancellationToken = default)
        {

            async Task<Page<ModelInfo>> FirstPageFunc(int? pageSizeHint)
            {
                var response = await GetCustomModelsAsync(op, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
            }
            async Task<Page<ModelInfo>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = await GetCustomModelsNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }
        /// <summary> Get information about all custom models. </summary>
        /// <param name="op"> Specify whether to return summary or full list of models. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Pageable<ModelInfo> GetCustomModelsPageable(SomeEnum? op, CancellationToken cancellationToken = default)
        {

            Page<ModelInfo> FirstPageFunc(int? pageSizeHint)
            {
                var response = GetCustomModels(op, cancellationToken);
                return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
            }
            Page<ModelInfo> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var response = GetCustomModelsNextPage(nextLink, cancellationToken);
                return Page.FromValues(response.Value.ModelList, response.Value.NextLink, response.GetRawResponse());
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
