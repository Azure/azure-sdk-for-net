// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class ContainerRegistryBlobRestClient
    {
        /// <summary>
        /// Replace the default implementation to call RedirectPolicy.SetAllowAutoRedirect(message, true).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="digest"></param>
        /// <returns></returns>
        internal HttpMessage CreateGetBlobRequest(string name, string digest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/v2/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/blobs/", false);
            uri.AppendPath(digest, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/octet-stream");
            // Follow redirects
            RedirectPolicy.SetAllowAutoRedirect(message, true);
            return message;
        }

        /// <summary>
        /// Replace the default implementation to call RedirectPolicy.SetAllowAutoRedirect(message, true).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="digest"></param>
        /// <returns></returns>
        internal HttpMessage CreateCheckBlobExistsRequest(string name, string digest)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/v2/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/blobs/", false);
            uri.AppendPath(digest, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            // Follow redirects
            RedirectPolicy.SetAllowAutoRedirect(message, true);
            return message;
        }

        internal HttpMessage CreateGetChunkRequest(string name, string digest, string range)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/v2/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/blobs/", false);
            uri.AppendPath(digest, true);
            request.Uri = uri;
            request.Headers.Add("Range", range);
            request.Headers.Add("Accept", "application/octet-stream");
            // Follow redirects
            RedirectPolicy.SetAllowAutoRedirect(message, true);
            return message;
        }
    }
}
