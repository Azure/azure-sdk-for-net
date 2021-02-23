// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;

namespace Azure.Storage.Blobs.Batch
{
    internal partial class ContainerRestClient
    {
        internal HttpMessage CreateSubmitBatchRequest(string containerName, long contentLength, string multipartContentType, Stream body, int? timeout)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(containerName, true);
            uri.AppendQuery("restype", "container", true);
            uri.AppendQuery("comp", "batch", true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Length", contentLength);
            request.Headers.Add("Content-Type", multipartContentType);
            request.Content = RequestContent.Create(body);
            return message;
        }
    }
}
