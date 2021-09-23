// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    internal static class AmsDirectRequestHelpers
    {
        internal static HttpMessage GetHttpMessage(CallingServerClient client, Uri requestEndpoint, RequestMethod requestMethod, HttpRange? rangeHeader = null)
        {
            HttpMessage message = client._pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = requestMethod;
            var uri = new RequestUriBuilder();
            uri.Reset(requestEndpoint);

            request.Uri = uri;

            if (rangeHeader != null)
            {
                request.Headers.Add(Constants.HeaderNames.Range, rangeHeader.ToString());
            }

            // Even if using an external location, we must use the acs resource's information to sign our request.
            string path = uri.Path;
            if (path.StartsWith("/", StringComparison.InvariantCulture))
            {
                path = path.Substring(1);
            }

            request.Headers.Add(Constants.HeaderNames.XMsHost, new Uri(client._resourceEndpoint).Authority);
            message.SetProperty("uriToSignRequestWith", new Uri(client._resourceEndpoint + path));

            message.BufferResponse = false;
            return message;
        }
    }
}
