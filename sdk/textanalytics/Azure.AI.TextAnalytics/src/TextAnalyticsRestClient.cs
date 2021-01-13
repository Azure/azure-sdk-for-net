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
        internal HttpMessage CreateHealthStatusNextPageRequest(string nextLink, bool? showStats)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendRaw("/text/analytics/v3.1-preview.3", false);
            uri.AppendRawNextLink(nextLink, false);
            if (showStats != null)
            {
                uri.AppendQuery("showStats", showStats.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json, text/json");
            return message;
        }

        /// <summary> Get details of the healthcare prediction job specified by the jobId. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain request and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<HealthcareJobState>> HealthStatusNextPageAsync(string nextLink, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateHealthStatusNextPageRequest(nextLink, showStats);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        HealthcareJobState value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = HealthcareJobState.DeserializeHealthcareJobState(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get details of the healthcare prediction job specified by the jobId. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="showStats"> (Optional) if set to true, response will contain request and document level statistics. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<HealthcareJobState> HealthStatusNextPage(string nextLink, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateHealthStatusNextPageRequest(nextLink, showStats);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        HealthcareJobState value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = HealthcareJobState.DeserializeHealthcareJobState(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
