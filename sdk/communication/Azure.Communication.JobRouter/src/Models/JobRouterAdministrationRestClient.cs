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
    [CodeGenSuppress("CreateGetExceptionPoliciesNextPageRequest", typeof(string), typeof(int), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetClassificationPoliciesNextPageRequest", typeof(string), typeof(int), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetQueuesNextPageRequest", typeof(string), typeof(int), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetDistributionPoliciesNextPageRequest", typeof(string), typeof(int), typeof(RequestContext))]
    internal partial class JobRouterAdministrationRestClient
    {
#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetExceptionPoliciesNextPageRequest(string nextLink, int maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetClassificationPoliciesNextPageRequest(string nextLink, int maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetQueuesNextPageRequest(string nextLink, int maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetDistributionPoliciesNextPageRequest(string nextLink, int maxpagesize, RequestContext context)
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
