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
    /// <summary> A credential scoped to a sandbox group. </summary>
    public partial class CredentialResource
    {
        private readonly CredentialsClient _client;

        /// <summary> The name of the credential. </summary>
        public virtual string Name { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxGroupCredential? Data { get; }

        /// <summary> Initializes a new instance of CredentialResource for mocking. </summary>
        protected CredentialResource()
        {
        }

        internal CredentialResource(CredentialsClient client, string credentialName, SandboxGroupCredential? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(credentialName, nameof(credentialName));

            _client = client;
            Name = credentialName;
            Data = data;
        }

        /// <summary> Gets the current credential in a new resource client. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<CredentialResource> Get(CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = _client.GetCredential(Name, cancellationToken);
            return Response.FromValue(new CredentialResource(_client, Name, response.Value), response.GetRawResponse());
        }

        /// <summary> Gets the current credential in a new resource client asynchronously. This instance's <see cref="Data"/> remains unchanged. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual async Task<Response<CredentialResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<SandboxGroupCredential> response = await _client.GetCredentialAsync(Name, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new CredentialResource(_client, Name, response.Value), response.GetRawResponse());
        }

        /// <summary> Deletes a credential in a sandbox group. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteCredential(RequestContext context)
        {
            return _client.DeleteCredential(Name, context);
        }

        /// <summary> Deletes a credential in a sandbox group. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteCredentialAsync(RequestContext context)
        {
            return _client.DeleteCredentialAsync(Name, context);
        }

        /// <summary> Deletes a credential in a sandbox group. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteCredential(CancellationToken cancellationToken = default)
        {
            return _client.DeleteCredential(Name, cancellationToken);
        }

        /// <summary> Deletes a credential in a sandbox group. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteCredentialAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteCredentialAsync(Name, cancellationToken);
        }

        /// <summary> Gets a specific credential by name in a sandbox group. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetCredential(RequestContext context)
        {
            return _client.GetCredential(Name, context);
        }

        /// <summary> Gets a specific credential by name in a sandbox group. Uses this resource's name. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetCredentialAsync(RequestContext context)
        {
            return _client.GetCredentialAsync(Name, context);
        }

        /// <summary> Gets a specific credential by name in a sandbox group. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxGroupCredential> GetCredential(CancellationToken cancellationToken = default)
        {
            return _client.GetCredential(Name, cancellationToken);
        }

        /// <summary> Gets a specific credential by name in a sandbox group. Uses this resource's name. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxGroupCredential>> GetCredentialAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetCredentialAsync(Name, cancellationToken);
        }

        /// <summary> Creates or updates a credential in a sandbox group. If the credential already exists, it will be updated; otherwise, a new credential will be created. Uses this resource's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetCredential(RequestContent content, RequestContext context = null)
        {
            return _client.SetCredential(Name, content, context);
        }

        /// <summary> Creates or updates a credential in a sandbox group. If the credential already exists, it will be updated; otherwise, a new credential will be created. Uses this resource's name. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetCredentialAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetCredentialAsync(Name, content, context);
        }

        /// <summary> Creates or updates a credential in a sandbox group. If the credential already exists, it will be updated; otherwise, a new credential will be created. Uses this resource's name. </summary>
        /// <param name="body"> The credential configuration to store. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxGroupCredential> SetCredential(CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetCredential(Name, body, cancellationToken);
        }

        /// <summary> Creates or updates a credential in a sandbox group. If the credential already exists, it will be updated; otherwise, a new credential will be created. Uses this resource's name. </summary>
        /// <param name="body"> The credential configuration to store. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxGroupCredential>> SetCredentialAsync(CreateSandboxGroupCredentialContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetCredentialAsync(Name, body, cancellationToken);
        }
    }
}
