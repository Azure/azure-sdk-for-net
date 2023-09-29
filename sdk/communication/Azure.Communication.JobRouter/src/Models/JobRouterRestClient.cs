// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("CreateGetJobsNextPageRequest", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(int), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetWorkersNextPageRequest", typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(int), typeof(RequestContext))]
    internal partial class JobRouterRestClient
    {
        /// <summary> Initializes a new instance of JobRouterAdministrationRestClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterRestClient(Uri endpoint, JobRouterClientOptions options, HttpPipeline pipeline)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetJobsNextPageRequest(string nextLink, string status, string queueId, string channelId, string classificationPolicyId, DateTimeOffset scheduledBefore, DateTimeOffset scheduledAfter, int maxPageSize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetWorkersNextPageRequest(string nextLink, string state, string channelId, string queueId, bool hasCapacity, int maxpagesize, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
