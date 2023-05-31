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
    }
}
