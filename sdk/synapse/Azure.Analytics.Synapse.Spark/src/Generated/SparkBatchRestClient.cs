// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.Spark
{
    internal partial class SparkBatchRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _livyApiVersion;
        private readonly string _sparkPoolName;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of SparkBatchRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The workspace development endpoint, for example https://myworkspace.dev.azuresynapse.net. </param>
        /// <param name="livyApiVersion"> Valid api-version for the request. The default value is "2019-11-01-preview". </param>
        /// <param name="sparkPoolName"> Name of the spark pool. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/>, <paramref name="livyApiVersion"/> or <paramref name="sparkPoolName"/> is null. </exception>
        public SparkBatchRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string livyApiVersion, string sparkPoolName)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            _livyApiVersion = livyApiVersion ?? throw new ArgumentNullException(nameof(livyApiVersion));
            _sparkPoolName = sparkPoolName ?? throw new ArgumentNullException(nameof(sparkPoolName));
        }

        internal HttpMessage CreateGetSparkBatchJobsRequest(int? @from, int? size, bool? detailed)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/livyApi/versions/", false);
            uri.AppendPath(_livyApiVersion, false);
            uri.AppendPath("/sparkPools/", false);
            uri.AppendPath(_sparkPoolName, false);
            uri.AppendPath("/batches", false);
            if (@from != null)
            {
                uri.AppendQuery("from", @from.Value, true);
            }
            if (size != null)
            {
                uri.AppendQuery("size", size.Value, true);
            }
            if (detailed != null)
            {
                uri.AppendQuery("detailed", detailed.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> List all spark batch jobs which are running under a particular spark pool. </summary>
        /// <param name="from"> Optional param specifying which index the list should begin from. </param>
        /// <param name="size">
        /// Optional param specifying the size of the returned list.
        ///             By default it is 20 and that is the maximum.
        /// </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SparkBatchJobCollection>> GetSparkBatchJobsAsync(int? @from = null, int? size = null, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSparkBatchJobsRequest(@from, size, detailed);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJobCollection value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = SparkBatchJobCollection.DeserializeSparkBatchJobCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> List all spark batch jobs which are running under a particular spark pool. </summary>
        /// <param name="from"> Optional param specifying which index the list should begin from. </param>
        /// <param name="size">
        /// Optional param specifying the size of the returned list.
        ///             By default it is 20 and that is the maximum.
        /// </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SparkBatchJobCollection> GetSparkBatchJobs(int? @from = null, int? size = null, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSparkBatchJobsRequest(@from, size, detailed);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJobCollection value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = SparkBatchJobCollection.DeserializeSparkBatchJobCollection(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCreateSparkBatchJobRequest(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/livyApi/versions/", false);
            uri.AppendPath(_livyApiVersion, false);
            uri.AppendPath("/sparkPools/", false);
            uri.AppendPath(_sparkPoolName, false);
            uri.AppendPath("/batches", false);
            if (detailed != null)
            {
                uri.AppendQuery("detailed", detailed.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(sparkBatchJobOptions);
            request.Content = content;
            return message;
        }

        /// <summary> Create new spark batch job. </summary>
        /// <param name="sparkBatchJobOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sparkBatchJobOptions"/> is null. </exception>
        public async Task<Response<SparkBatchJob>> CreateSparkBatchJobAsync(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            if (sparkBatchJobOptions == null)
            {
                throw new ArgumentNullException(nameof(sparkBatchJobOptions));
            }

            using var message = CreateCreateSparkBatchJobRequest(sparkBatchJobOptions, detailed);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJob value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = SparkBatchJob.DeserializeSparkBatchJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Create new spark batch job. </summary>
        /// <param name="sparkBatchJobOptions"> Livy compatible batch job request payload. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sparkBatchJobOptions"/> is null. </exception>
        public Response<SparkBatchJob> CreateSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            if (sparkBatchJobOptions == null)
            {
                throw new ArgumentNullException(nameof(sparkBatchJobOptions));
            }

            using var message = CreateCreateSparkBatchJobRequest(sparkBatchJobOptions, detailed);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJob value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = SparkBatchJob.DeserializeSparkBatchJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSparkBatchJobRequest(int batchId, bool? detailed)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/livyApi/versions/", false);
            uri.AppendPath(_livyApiVersion, false);
            uri.AppendPath("/sparkPools/", false);
            uri.AppendPath(_sparkPoolName, false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(batchId, true);
            if (detailed != null)
            {
                uri.AppendQuery("detailed", detailed.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Gets a single spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<SparkBatchJob>> GetSparkBatchJobAsync(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSparkBatchJobRequest(batchId, detailed);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJob value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions, cancellationToken).ConfigureAwait(false);
                        value = SparkBatchJob.DeserializeSparkBatchJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a single spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="detailed"> Optional query param specifying whether detailed response is returned beyond plain livy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SparkBatchJob> GetSparkBatchJob(int batchId, bool? detailed = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSparkBatchJobRequest(batchId, detailed);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        SparkBatchJob value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, ModelSerializationExtensions.JsonDocumentOptions);
                        value = SparkBatchJob.DeserializeSparkBatchJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateCancelSparkBatchJobRequest(int batchId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/livyApi/versions/", false);
            uri.AppendPath(_livyApiVersion, false);
            uri.AppendPath("/sparkPools/", false);
            uri.AppendPath(_sparkPoolName, false);
            uri.AppendPath("/batches/", false);
            uri.AppendPath(batchId, true);
            request.Uri = uri;
            return message;
        }

        /// <summary> Cancels a running spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response> CancelSparkBatchJobAsync(int batchId, CancellationToken cancellationToken = default)
        {
            using var message = CreateCancelSparkBatchJobRequest(batchId);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Cancels a running spark batch job. </summary>
        /// <param name="batchId"> Identifier for the batch job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response CancelSparkBatchJob(int batchId, CancellationToken cancellationToken = default)
        {
            using var message = CreateCancelSparkBatchJobRequest(batchId);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
