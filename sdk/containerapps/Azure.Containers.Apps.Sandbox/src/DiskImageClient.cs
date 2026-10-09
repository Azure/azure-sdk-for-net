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
    /// <summary> A disk image scoped to a sandbox group. </summary>
    public partial class DiskImageClient
    {
        private readonly DiskImagesClient _client;

        /// <summary> The identifier of the disk image. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual DiskImage? Data { get; }

        /// <summary> Initializes a new instance of DiskImageClient for mocking. </summary>
        protected DiskImageClient()
        {
        }

        internal DiskImageClient(DiskImagesClient client, string id, DiskImage? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _client = client;
            Id = id;
            Data = data;
        }

        /// <summary> Gets the current disk image in a new client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<DiskImageClient> Get(CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = _client.GetDiskImage(Id, cancellationToken);
            return Response.FromValue(new DiskImageClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current disk image in a new client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<DiskImageClient>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<DiskImage> response = await _client.GetDiskImageAsync(Id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new DiskImageClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a disk image by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteDiskImage(RequestContext context)
        {
            return _client.DeleteDiskImage(Id, context);
        }

        /// <summary> Deletes a disk image by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteDiskImageAsync(RequestContext context)
        {
            return _client.DeleteDiskImageAsync(Id, context);
        }

        /// <summary> Deletes a disk image by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteDiskImage(CancellationToken cancellationToken = default)
        {
            return _client.DeleteDiskImage(Id, cancellationToken);
        }

        /// <summary> Deletes a disk image by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteDiskImageAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteDiskImageAsync(Id, cancellationToken);
        }

        /// <summary> Gets a specific disk image by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetDiskImage(RequestContext context)
        {
            return _client.GetDiskImage(Id, context);
        }

        /// <summary> Gets a specific disk image by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetDiskImageAsync(RequestContext context)
        {
            return _client.GetDiskImageAsync(Id, context);
        }

        /// <summary> Gets a specific disk image by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<DiskImage> GetDiskImage(CancellationToken cancellationToken = default)
        {
            return _client.GetDiskImage(Id, cancellationToken);
        }

        /// <summary> Gets a specific disk image by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<DiskImage>> GetDiskImageAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetDiskImageAsync(Id, cancellationToken);
        }
    }
}
