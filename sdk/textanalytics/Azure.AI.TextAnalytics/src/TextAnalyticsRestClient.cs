// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    internal partial class TextAnalyticsRestClient
    {
        internal HttpMessage CreateAnalyzeStatusNextPageRequest(string apiversion, string nextLink, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/", false);
            uri.AppendRaw(apiversion, false);
            uri.AppendPath("/analyze/jobs/", false);
            uri.AppendRawNextLink(nextLink, false);
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Get the status of an analysis job.  A job may consist of one or more tasks.  Once all tasks are completed, the job will transition to the completed state and results will be available for each task. </summary>
        /// <param name="apiVersion"> The specific api version to use. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain request and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<AnalyzeJobState>> AnalyzeStatusNextPageAsync(string apiVersion, string nextLink, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateAnalyzeStatusNextPageRequest(apiVersion, nextLink, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeJobState value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AnalyzeJobState.DeserializeAnalyzeJobState(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get the status of an analysis job.  A job may consist of one or more tasks.  Once all tasks are completed, the job will transition to the completed state and results will be available for each task. </summary>
        /// <param name="apiVersion"> The specific api version to use. </param>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain request and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<AnalyzeJobState> AnalyzeStatusNextPage(string apiVersion, string nextLink, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateAnalyzeStatusNextPageRequest(apiVersion, nextLink, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AnalyzeJobState value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AnalyzeJobState.DeserializeAnalyzeJobState(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
