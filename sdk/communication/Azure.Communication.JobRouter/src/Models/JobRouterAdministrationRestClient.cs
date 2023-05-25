// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.JobRouter.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("CreateListExceptionPoliciesNextPageRequest", typeof(string), typeof(int?))]
    [CodeGenSuppress("CreateListClassificationPoliciesNextPageRequest", typeof(string), typeof(int?))]
    [CodeGenSuppress("CreateListQueuesNextPageRequest", typeof(string), typeof(int?))]
    [CodeGenSuppress("CreateListDistributionPoliciesNextPageRequest", typeof(string), typeof(int?))]
    internal partial class JobRouterAdministrationRestClient
    {
#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateListExceptionPoliciesNextPageRequest(string nextLink, int? maxpagesize)
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
        internal HttpMessage CreateListClassificationPoliciesNextPageRequest(string nextLink, int? maxpagesize)
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
        internal HttpMessage CreateListQueuesNextPageRequest(string nextLink, int? maxpagesize)
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
        internal HttpMessage CreateListDistributionPoliciesNextPageRequest(string nextLink, int? maxpagesize)
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
        internal HttpMessage CreateUpsertClassificationPolicyRequest(string id, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/classificationPolicies/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="id"> Id of the classification policy. </param>
        /// <param name="patchContent"> Model of classification policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<ClassificationPolicy>> UpsertClassificationPolicyAsync(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertClassificationPolicyRequest(id, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ClassificationPolicy value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ClassificationPolicy.DeserializeClassificationPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="id"> Id of the classification policy. </param>
        /// <param name="patchContent"> Model of classification policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<ClassificationPolicy> UpsertClassificationPolicy(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertClassificationPolicyRequest(id, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ClassificationPolicy value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ClassificationPolicy.DeserializeClassificationPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        // GH Issue: https://github.com/Azure/azure-sdk/issues/3520
        // Workaround before: https://github.com/Azure/azure-sdk-for-net/issues/27402
        internal HttpMessage CreateUpsertDistributionPolicyRequest(string id, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/distributionPolicies/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        /// <summary> Creates or updates a distribution policy. </summary>
        /// <param name="id"> Id of the distribution policy. </param>
        /// <param name="patchContent"> Model of distribution policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<DistributionPolicy>> UpsertDistributionPolicyAsync(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertDistributionPolicyRequest(id, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DistributionPolicy value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DistributionPolicy.DeserializeDistributionPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a distribution policy. </summary>
        /// <param name="id"> Id of the distribution policy. </param>
        /// <param name="patchContent"> Model of distribution policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<DistributionPolicy> UpsertDistributionPolicy(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertDistributionPolicyRequest(id, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DistributionPolicy value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DistributionPolicy.DeserializeDistributionPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        // GH Issue: https://github.com/Azure/azure-sdk/issues/3520
        // Workaround before: https://github.com/Azure/azure-sdk-for-net/issues/27402
        internal HttpMessage CreateUpsertExceptionPolicyRequest(string id, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/exceptionPolicies/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="id"> Id of the exception policy. </param>
        /// <param name="patchContent"> Model of exception policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<ExceptionPolicy>> UpsertExceptionPolicyAsync(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertExceptionPolicyRequest(id, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ExceptionPolicy value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ExceptionPolicy.DeserializeExceptionPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="id"> Id of the exception policy. </param>
        /// <param name="patchContent"> Model of exception policy properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<ExceptionPolicy> UpsertExceptionPolicy(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertExceptionPolicyRequest(id, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ExceptionPolicy value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ExceptionPolicy.DeserializeExceptionPolicy(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        // GH Issue: https://github.com/Azure/azure-sdk/issues/3520
        // Workaround before: https://github.com/Azure/azure-sdk-for-net/issues/27402
        internal HttpMessage CreateUpsertQueueRequest(string id, RequestContent patchContent)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_endpoint, false);
            uri.AppendPath("/routing/queues/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = patchContent;
            return message;
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="id"> Id of the queue. </param>
        /// <param name="patchContent"> Model of queue properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public async Task<Response<JobQueue>> UpsertQueueAsync(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertQueueRequest(id, patchContent);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        JobQueue value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = JobQueue.DeserializeJobQueue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="id"> Id of the queue. </param>
        /// <param name="patchContent"> Model of queue properties to be patched. See also: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="patchContent"/> is null. </exception>
        public Response<JobQueue> UpsertQueue(string id, RequestContent patchContent, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchContent == null)
            {
                throw new ArgumentNullException(nameof(patchContent));
            }

            using var message = CreateUpsertQueueRequest(id, patchContent);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        JobQueue value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = JobQueue.DeserializeJobQueue(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
