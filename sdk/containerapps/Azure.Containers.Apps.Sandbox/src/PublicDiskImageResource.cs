// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;

#nullable enable annotations

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> A public disk image accessed through a sandbox group. </summary>
    public partial class PublicDiskImageResource
    {
        private readonly PublicDiskImagesClient _client;

        /// <summary> The name of the public disk image. </summary>
        public virtual string Name { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual PublicDiskImage? Data { get; }

        /// <summary> Initializes a new instance of PublicDiskImageResource for mocking. </summary>
        protected PublicDiskImageResource()
        {
        }

        internal PublicDiskImageResource(PublicDiskImagesClient client, string name, PublicDiskImage? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            _client = client;
            Name = name;
            Data = data;
        }

        /// <summary> Gets the current public disk image in a new resource client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PublicDiskImageResource> Get(CancellationToken cancellationToken = default)
        {
            Response<PublicDiskImage> response = _client.GetPublicDiskImage(Name, cancellationToken);
            return Response.FromValue(new PublicDiskImageResource(_client, Name, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current public disk image in a new resource client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<PublicDiskImageResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<PublicDiskImage> response = await _client.GetPublicDiskImageAsync(Name, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new PublicDiskImageResource(_client, Name, response.Value), response.GetRawResponse());
        }

        /// <summary> Public images are global and shared across all sandbox groups. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetPublicDiskImage(RequestContext context)
        {
            return _client.GetPublicDiskImage(Name, context);
        }

        /// <summary> Public images are global and shared across all sandbox groups. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetPublicDiskImageAsync(RequestContext context)
        {
            return _client.GetPublicDiskImageAsync(Name, context);
        }

        /// <summary> Public images are global and shared across all sandbox groups. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<PublicDiskImage> GetPublicDiskImage(CancellationToken cancellationToken = default)
        {
            return _client.GetPublicDiskImage(Name, cancellationToken);
        }

        /// <summary> Public images are global and shared across all sandbox groups. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<PublicDiskImage>> GetPublicDiskImageAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetPublicDiskImageAsync(Name, cancellationToken);
        }
    }
}
