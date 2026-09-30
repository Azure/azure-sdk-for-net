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
    /// <summary> A snapshot scoped to a sandbox group. </summary>
    public partial class SnapshotResource
    {
        private readonly SnapshotsClient _client;

        /// <summary> The identifier of the snapshot. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxSnapshot? Data { get; }

        /// <summary> Initializes a new instance of SnapshotResource for mocking. </summary>
        protected SnapshotResource()
        {
        }

        internal SnapshotResource(SnapshotsClient client, string id, SandboxSnapshot? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _client = client;
            Id = id;
            Data = data;
        }

        /// <summary> Gets the current snapshot in a new resource client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SnapshotResource> Get(CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = _client.GetSnapshot(Id, cancellationToken);
            return Response.FromValue(new SnapshotResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current snapshot in a new resource client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<SnapshotResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<SandboxSnapshot> response = await _client.GetSnapshotAsync(Id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new SnapshotResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteSnapshot(RequestContext context)
        {
            return _client.DeleteSnapshot(Id, context);
        }

        /// <summary> Deletes a snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteSnapshotAsync(RequestContext context)
        {
            return _client.DeleteSnapshotAsync(Id, context);
        }

        /// <summary> Deletes a snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteSnapshot(CancellationToken cancellationToken = default)
        {
            return _client.DeleteSnapshot(Id, cancellationToken);
        }

        /// <summary> Deletes a snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteSnapshotAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteSnapshotAsync(Id, cancellationToken);
        }

        /// <summary> Gets a specific snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetSnapshot(RequestContext context)
        {
            return _client.GetSnapshot(Id, context);
        }

        /// <summary> Gets a specific snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetSnapshotAsync(RequestContext context)
        {
            return _client.GetSnapshotAsync(Id, context);
        }

        /// <summary> Gets a specific snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxSnapshot> GetSnapshot(CancellationToken cancellationToken = default)
        {
            return _client.GetSnapshot(Id, cancellationToken);
        }

        /// <summary> Gets a specific snapshot by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxSnapshot>> GetSnapshotAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetSnapshotAsync(Id, cancellationToken);
        }
    }
}
