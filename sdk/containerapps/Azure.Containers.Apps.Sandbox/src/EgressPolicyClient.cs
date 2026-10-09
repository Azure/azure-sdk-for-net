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
    /// <summary> An egress policy scoped to a sandbox group. </summary>
    public partial class EgressPolicyClient
    {
        private readonly EgressPoliciesClient _client;

        /// <summary> The identifier of the egress policy. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual NamedEgressPolicy? Data { get; }

        /// <summary> Initializes a new instance of EgressPolicyClient for mocking. </summary>
        protected EgressPolicyClient()
        {
        }

        internal EgressPolicyClient(EgressPoliciesClient client, string policyId, NamedEgressPolicy? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(policyId, nameof(policyId));

            _client = client;
            Id = policyId;
            Data = data;
        }

        /// <summary> Gets the current egress policy in a new client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<EgressPolicyClient> Get(CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = _client.GetEgressPolicy(Id, cancellationToken);
            return Response.FromValue(new EgressPolicyClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current egress policy in a new client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<EgressPolicyClient>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<NamedEgressPolicy> response = await _client.GetEgressPolicyAsync(Id, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new EgressPolicyClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteEgressPolicy(RequestContext context)
        {
            return _client.DeleteEgressPolicy(Id, context);
        }

        /// <summary> Deletes a named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteEgressPolicyAsync(RequestContext context)
        {
            return _client.DeleteEgressPolicyAsync(Id, context);
        }

        /// <summary> Deletes a named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteEgressPolicy(CancellationToken cancellationToken = default)
        {
            return _client.DeleteEgressPolicy(Id, cancellationToken);
        }

        /// <summary> Deletes a named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteEgressPolicyAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteEgressPolicyAsync(Id, cancellationToken);
        }

        /// <summary> Gets a specific named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetEgressPolicy(RequestContext context)
        {
            return _client.GetEgressPolicy(Id, context);
        }

        /// <summary> Gets a specific named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetEgressPolicyAsync(RequestContext context)
        {
            return _client.GetEgressPolicyAsync(Id, context);
        }

        /// <summary> Gets a specific named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<NamedEgressPolicy> GetEgressPolicy(CancellationToken cancellationToken = default)
        {
            return _client.GetEgressPolicy(Id, cancellationToken);
        }

        /// <summary> Gets a specific named egress policy by ID. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<NamedEgressPolicy>> GetEgressPolicyAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetEgressPolicyAsync(Id, cancellationToken);
        }

        /// <summary> Creates or updates a named egress policy. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetEgressPolicy(RequestContent content, RequestContext context = null)
        {
            return _client.SetEgressPolicy(Id, content, context);
        }

        /// <summary> Creates or updates a named egress policy. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetEgressPolicyAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetEgressPolicyAsync(Id, content, context);
        }

        /// <summary> Creates or updates a named egress policy. Uses this client's identifier. </summary>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<NamedEgressPolicy> SetEgressPolicy(NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            return _client.SetEgressPolicy(Id, resource, cancellationToken);
        }

        /// <summary> Creates or updates a named egress policy. Uses this client's identifier. </summary>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<NamedEgressPolicy>> SetEgressPolicyAsync(NamedEgressPolicy resource, CancellationToken cancellationToken = default)
        {
            return _client.SetEgressPolicyAsync(Id, resource, cancellationToken);
        }
    }
}
