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
    /// <summary> A content package scoped to a sandbox group. </summary>
    public partial class ContentPackageResource
    {
        private readonly ContentPackagesClient _client;

        /// <summary> The identifier of the content package. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual ContentPackage? Data { get; }

        /// <summary> Initializes a new instance of ContentPackageResource for mocking. </summary>
        protected ContentPackageResource()
        {
        }

        internal ContentPackageResource(ContentPackagesClient client, string id, ContentPackage? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _client = client;
            Id = id;
            Data = data;
        }

        /// <summary> Gets the current content package in a new resource client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<ContentPackageResource> Get(CancellationToken cancellationToken = default)
        {
            Response<ContentPackage> response = _client.GetContentPackage(Id, cancellationToken);
            return Response.FromValue(new ContentPackageResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current content package in a new resource client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<ContentPackageResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<ContentPackage> response = await _client.GetContentPackageAsync(Id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContentPackageResource(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a content package by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteContentPackage(RequestContext context)
        {
            return _client.DeleteContentPackage(Id, context);
        }

        /// <summary> Deletes a content package by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteContentPackageAsync(RequestContext context)
        {
            return _client.DeleteContentPackageAsync(Id, context);
        }

        /// <summary> Deletes a content package by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteContentPackage(CancellationToken cancellationToken = default)
        {
            return _client.DeleteContentPackage(Id, cancellationToken);
        }

        /// <summary> Deletes a content package by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteContentPackageAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteContentPackageAsync(Id, cancellationToken);
        }

        /// <summary> Gets a specific content package by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetContentPackage(RequestContext context)
        {
            return _client.GetContentPackage(Id, context);
        }

        /// <summary> Gets a specific content package by ID. Uses this resource's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetContentPackageAsync(RequestContext context)
        {
            return _client.GetContentPackageAsync(Id, context);
        }

        /// <summary> Gets a specific content package by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<ContentPackage> GetContentPackage(CancellationToken cancellationToken = default)
        {
            return _client.GetContentPackage(Id, cancellationToken);
        }

        /// <summary> Gets a specific content package by ID. Uses this resource's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<ContentPackage>> GetContentPackageAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetContentPackageAsync(Id, cancellationToken);
        }
    }
}
