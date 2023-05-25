// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.JobRouter.Models;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("CreateListJobsNextPageRequest", typeof(string), typeof(JobStateSelector?), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?))]
    [CodeGenSuppress("CreateListWorkersNextPageRequest", typeof(string), typeof(WorkerStateSelector?), typeof(string), typeof(string), typeof(bool?), typeof(int?))]
    internal partial class JobRouterRestClient
    {
#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateListJobsNextPageRequest(string nextLink, JobStateSelector? status, string queueId, string channelId, string classificationPolicyId, DateTimeOffset? scheduledBefore, DateTimeOffset? scheduledAfter, int? maxPageSize)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateListWorkersNextPageRequest(string nextLink, WorkerStateSelector? status, string channelId, string queueId, bool? hasCapacity, int? maxpagesize)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        // GH Issue: https://github.com/Azure/azure-sdk/issues/3520
        // Workaround before: https://github.com/Azure/azure-sdk-for-net/issues/27402
        internal HttpMessage CreateUpsertJobRequest(string id, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/jobs/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        // GH Issue: https://github.com/Azure/azure-sdk/issues/3520
        // Workaround before: https://github.com/Azure/azure-sdk-for-net/issues/27402
        internal HttpMessage CreateUpsertWorkerRequest(string workerId, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/workers/", false);
            uri.AppendPath(workerId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        /// <summary> Creates or updates a router job. </summary>
        /// <param name="id"> Id of the job. </param>
        /// <param name="patchContent"> Model of job properties to be created or patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<RouterJob>> UpsertJobAsync(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertJobRequest(id, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RouterJob value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RouterJob.DeserializeRouterJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a router job. </summary>
        /// <param name="id"> Id of the job. </param>
        /// <param name="patchContent"> Model of job properties to be created or patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<RouterJob> UpsertJob(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertJobRequest(id, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RouterJob value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RouterJob.DeserializeRouterJob(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a worker. </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="patchContent"> Model of worker properties to be created or patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<RouterWorker>> UpsertWorkerAsync(string workerId, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (workerId == null)
            {
                throw new ArgumentNullException(nameof(workerId));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertWorkerRequest(workerId, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RouterWorker value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RouterWorker.DeserializeRouterWorker(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a worker. </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="patchContent"> Model of worker properties to be created or patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<RouterWorker> UpsertWorker(string workerId, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (workerId == null)
            {
                throw new ArgumentNullException(nameof(workerId));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertWorkerRequest(workerId, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RouterWorker value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RouterWorker.DeserializeRouterWorker(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
