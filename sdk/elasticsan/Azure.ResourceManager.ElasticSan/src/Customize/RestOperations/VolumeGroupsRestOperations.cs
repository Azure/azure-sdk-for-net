// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ElasticSan
{
    internal partial class VolumeGroups
    {
        // Customized to propagate the x-ms-access-soft-deleted-resources header on continuation-page requests,
        // so that soft-deleted listings do not revert to the default active-resource view after the first page.
        internal HttpMessage CreateNextGetByElasticSanRequest(Uri nextPage, string subscriptionId, string resourceGroupName, string elasticSanName, string accessSoftDeletedResources, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            if (nextPage.IsAbsoluteUri)
            {
                uri.Reset(nextPage);
            }
            else
            {
                uri.Reset(new Uri(_endpoint, nextPage));
            }
            if (_apiVersion != null)
            {
                uri.UpdateQuery("api-version", _apiVersion);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            _userAgent.Apply(message);
            if (accessSoftDeletedResources != null)
            {
                request.Headers.SetValue("x-ms-access-soft-deleted-resources", accessSoftDeletedResources);
            }
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}