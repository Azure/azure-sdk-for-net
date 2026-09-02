// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ServiceGroups
{
    internal partial class ServiceGroupsOperationGroup
    {
        internal HttpMessage CreateGetAncestorsRequest(string serviceGroupName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/serviceGroups/", false);
            uri.AppendPath(serviceGroupName, true);
            uri.AppendPath("/listAncestors", false);
            uri.AppendQuery("api-version", "2024-02-01-preview", true);

            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            _userAgent.Apply(message);
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
