// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    internal static class AmsDirectRequestHelpers
    {
        internal static HttpMessage GetHttpMessage(CallRecording client, Uri requestEndpoint, RequestMethod requestMethod, HttpRange? rangeHeader = null)
        {
            Argument.CheckNotNull(client, nameof(client));
            Argument.CheckNotNull(requestEndpoint, nameof(requestEndpoint));
            Argument.CheckNotNullOrEmpty(requestMethod.Method, nameof(requestMethod));

            HttpMessage message = client._pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = requestMethod;
            RequestUriBuilder uri = new RequestUriBuilder();
            uri.Reset(requestEndpoint);

            request.Uri = uri;

            if (rangeHeader != null)
            {
                request.Headers.Add(Constants.HeaderNames.Range, rangeHeader.ToString());
            }

            // When generating security information, we need to use the ACS resource's information,
            // even if we are not connecting directly to our resource (such as the case of downloading a recording)
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
