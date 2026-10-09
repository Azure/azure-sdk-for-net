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
    /// <summary> A connection scoped to a sandbox group. </summary>
    public partial class ConnectionClient
    {
        private readonly ConnectionsClient _client;

        /// <summary> The identifier of the connection. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxConnection? Data { get; }

        /// <summary> Initializes a new instance of ConnectionClient for mocking. </summary>
        protected ConnectionClient()
        {
        }

        internal ConnectionClient(ConnectionsClient client, string id, SandboxConnection? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            _client = client;
            Id = id;
            Data = data;
        }

        /// <summary> Gets the current connection in a new client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<ConnectionClient> Get(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = _client.GetConnection(Id, includeSandboxIds, cancellationToken);
            return Response.FromValue(new ConnectionClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current connection in a new client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<ConnectionClient>> GetAsync(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            Response<SandboxConnection> response = await _client.GetConnectionAsync(Id, includeSandboxIds, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ConnectionClient(_client, Id, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a connection by ID. Uses this client's identifier. </summary>
        /// <param name="force"> Whether to force deletion of the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteConnection(bool? force, RequestContext context)
        {
            return _client.DeleteConnection(Id, force, context);
        }

        /// <summary> Deletes a connection by ID. Uses this client's identifier. </summary>
        /// <param name="force"> Whether to force deletion of the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteConnectionAsync(bool? force, RequestContext context)
        {
            return _client.DeleteConnectionAsync(Id, force, context);
        }

        /// <summary> Deletes a connection by ID. Uses this client's identifier. </summary>
        /// <param name="force"> Whether to force deletion of the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteConnection(bool? force = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteConnection(Id, force, cancellationToken);
        }

        /// <summary> Deletes a connection by ID. Uses this client's identifier. </summary>
        /// <param name="force"> Whether to force deletion of the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteConnectionAsync(bool? force = default, CancellationToken cancellationToken = default)
        {
            return _client.DeleteConnectionAsync(Id, force, cancellationToken);
        }

        /// <summary> Gets a specific connection by ID. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetConnection(bool? includeSandboxIds, RequestContext context)
        {
            return _client.GetConnection(Id, includeSandboxIds, context);
        }

        /// <summary> Gets a specific connection by ID. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetConnectionAsync(bool? includeSandboxIds, RequestContext context)
        {
            return _client.GetConnectionAsync(Id, includeSandboxIds, context);
        }

        /// <summary> Gets a specific connection by ID. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxConnection> GetConnection(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            return _client.GetConnection(Id, includeSandboxIds, cancellationToken);
        }

        /// <summary> Gets a specific connection by ID. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include sandbox identifiers using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxConnection>> GetConnectionAsync(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            return _client.GetConnectionAsync(Id, includeSandboxIds, cancellationToken);
        }

        /// <summary> Authorizes a connection with parameter values. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response AuthorizeConnection(RequestContent content, RequestContext context = null)
        {
            return _client.AuthorizeConnection(Id, content, context);
        }

        /// <summary> Authorizes a connection with parameter values. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> AuthorizeConnectionAsync(RequestContent content, RequestContext context = null)
        {
            return _client.AuthorizeConnectionAsync(Id, content, context);
        }

        /// <summary> Authorizes a connection with parameter values. Uses this client's identifier. </summary>
        /// <param name="body"> Provider-specific authorization parameters. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxConnection> AuthorizeConnection(AuthorizeConnectionContent body, CancellationToken cancellationToken = default)
        {
            return _client.AuthorizeConnection(Id, body, cancellationToken);
        }

        /// <summary> Authorizes a connection with parameter values. Uses this client's identifier. </summary>
        /// <param name="body"> Provider-specific authorization parameters. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxConnection>> AuthorizeConnectionAsync(AuthorizeConnectionContent body, CancellationToken cancellationToken = default)
        {
            return _client.AuthorizeConnectionAsync(Id, body, cancellationToken);
        }

        /// <summary> Generates a consent link for a connection. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GenerateConnectionConsentLink(RequestContent content, RequestContext context = null)
        {
            return _client.GenerateConnectionConsentLink(Id, content, context);
        }

        /// <summary> Generates a consent link for a connection. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GenerateConnectionConsentLinkAsync(RequestContent content, RequestContext context = null)
        {
            return _client.GenerateConnectionConsentLinkAsync(Id, content, context);
        }

        /// <summary> Generates a consent link for a connection. Uses this client's identifier. </summary>
        /// <param name="body"> Options for the generated consent link. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<GenerateConsentLinkResult> GenerateConnectionConsentLink(GenerateConsentLinkContent body = default, CancellationToken cancellationToken = default)
        {
            return _client.GenerateConnectionConsentLink(Id, body, cancellationToken);
        }

        /// <summary> Generates a consent link for a connection. Uses this client's identifier. </summary>
        /// <param name="body"> Options for the generated consent link. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<GenerateConsentLinkResult>> GenerateConnectionConsentLinkAsync(GenerateConsentLinkContent body = default, CancellationToken cancellationToken = default)
        {
            return _client.GenerateConnectionConsentLinkAsync(Id, body, cancellationToken);
        }

        /// <summary> Refreshes a connection's state from the upstream provider. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include identifiers of sandboxes using the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response RefreshConnection(bool? includeSandboxIds, RequestContext context)
        {
            return _client.RefreshConnection(Id, includeSandboxIds, context);
        }

        /// <summary> Refreshes a connection's state from the upstream provider. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include identifiers of sandboxes using the connection. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> RefreshConnectionAsync(bool? includeSandboxIds, RequestContext context)
        {
            return _client.RefreshConnectionAsync(Id, includeSandboxIds, context);
        }

        /// <summary> Refreshes a connection's state from the upstream provider. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include identifiers of sandboxes using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxConnection> RefreshConnection(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            return _client.RefreshConnection(Id, includeSandboxIds, cancellationToken);
        }

        /// <summary> Refreshes a connection's state from the upstream provider. Uses this client's identifier. </summary>
        /// <param name="includeSandboxIds"> Whether to include identifiers of sandboxes using the connection. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxConnection>> RefreshConnectionAsync(bool? includeSandboxIds = default, CancellationToken cancellationToken = default)
        {
            return _client.RefreshConnectionAsync(Id, includeSandboxIds, cancellationToken);
        }

        /// <summary> Updates the policy rules and tool settings on a connection. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response UpdateConnectionPolicyRules(RequestContent content, RequestContext context = null)
        {
            return _client.UpdateConnectionPolicyRules(Id, content, context);
        }

        /// <summary> Updates the policy rules and tool settings on a connection. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> UpdateConnectionPolicyRulesAsync(RequestContent content, RequestContext context = null)
        {
            return _client.UpdateConnectionPolicyRulesAsync(Id, content, context);
        }

        /// <summary> Updates the policy rules and tool settings on a connection. Uses this client's identifier. </summary>
        /// <param name="body"> The policy rules and enabled tool groups to apply. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxConnection> UpdateConnectionPolicyRules(UpdatePolicyRulesContent body, CancellationToken cancellationToken = default)
        {
            return _client.UpdateConnectionPolicyRules(Id, body, cancellationToken);
        }

        /// <summary> Updates the policy rules and tool settings on a connection. Uses this client's identifier. </summary>
        /// <param name="body"> The policy rules and enabled tool groups to apply. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxConnection>> UpdateConnectionPolicyRulesAsync(UpdatePolicyRulesContent body, CancellationToken cancellationToken = default)
        {
            return _client.UpdateConnectionPolicyRulesAsync(Id, body, cancellationToken);
        }
    }
}
