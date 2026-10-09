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
    /// <summary> A secret scoped to a sandbox group. </summary>
    public partial class SandboxSecretClient
    {
        private readonly SecretsClient _client;

        /// <summary> The identifier of the secret. </summary>
        public virtual string Id { get; }

        /// <summary> The model returned by the service, or null when this client was created from an identifier alone. </summary>
        public virtual SandboxSecret? Data { get; }

        /// <summary> Initializes a new instance of SandboxSecretClient for mocking. </summary>
        protected SandboxSecretClient()
        {
        }

        internal SandboxSecretClient(SecretsClient client, string secretId, SandboxSecret? data = null)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(secretId, nameof(secretId));

            _client = client;
            Id = secretId;
            Data = data;
        }

        /// <summary> Deletes an entire secret. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response DeleteSecret(RequestContext context)
        {
            return _client.DeleteSecret(Id, context);
        }

        /// <summary> Deletes an entire secret. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> DeleteSecretAsync(RequestContext context)
        {
            return _client.DeleteSecretAsync(Id, context);
        }

        /// <summary> Deletes an entire secret. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response DeleteSecret(CancellationToken cancellationToken = default)
        {
            return _client.DeleteSecret(Id, cancellationToken);
        }

        /// <summary> Deletes an entire secret. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response> DeleteSecretAsync(CancellationToken cancellationToken = default)
        {
            return _client.DeleteSecretAsync(Id, cancellationToken);
        }

        /// <summary> Lists key names of a secret (values are not returned). Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response GetSecretKeys(RequestContext context)
        {
            return _client.GetSecretKeys(Id, context);
        }

        /// <summary> Lists key names of a secret (values are not returned). Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> GetSecretKeysAsync(RequestContext context)
        {
            return _client.GetSecretKeysAsync(Id, context);
        }

        /// <summary> Lists key names of a secret (values are not returned). Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SecretKeysResult> GetSecretKeys(CancellationToken cancellationToken = default)
        {
            return _client.GetSecretKeys(Id, cancellationToken);
        }

        /// <summary> Lists key names of a secret (values are not returned). Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SecretKeysResult>> GetSecretKeysAsync(CancellationToken cancellationToken = default)
        {
            return _client.GetSecretKeysAsync(Id, cancellationToken);
        }

        /// <summary> Peeks (retrieves) all secret values. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response PeekSecret(RequestContext context)
        {
            return _client.PeekSecret(Id, context);
        }

        /// <summary> Peeks (retrieves) all secret values. Uses this client's identifier. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> PeekSecretAsync(RequestContext context)
        {
            return _client.PeekSecretAsync(Id, context);
        }

        /// <summary> Peeks (retrieves) all secret values. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SecretPeekResult> PeekSecret(CancellationToken cancellationToken = default)
        {
            return _client.PeekSecret(Id, cancellationToken);
        }

        /// <summary> Peeks (retrieves) all secret values. Uses this client's identifier. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SecretPeekResult>> PeekSecretAsync(CancellationToken cancellationToken = default)
        {
            return _client.PeekSecretAsync(Id, cancellationToken);
        }

        /// <summary> Upserts key-value pairs in a secret. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Response SetSecret(RequestContent content, RequestContext context = null)
        {
            return _client.SetSecret(Id, content, context);
        }

        /// <summary> Upserts key-value pairs in a secret. Uses this client's identifier. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public virtual Task<Response> SetSecretAsync(RequestContent content, RequestContext context = null)
        {
            return _client.SetSecretAsync(Id, content, context);
        }

        /// <summary> Upserts key-value pairs in a secret. Uses this client's identifier. </summary>
        /// <param name="body"> The secret key-value pairs to store. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Response<SandboxSecret> SetSecret(SetSecretContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetSecret(Id, body, cancellationToken);
        }

        /// <summary> Upserts key-value pairs in a secret. Uses this client's identifier. </summary>
        /// <param name="body"> The secret key-value pairs to store. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        public virtual Task<Response<SandboxSecret>> SetSecretAsync(SetSecretContent body, CancellationToken cancellationToken = default)
        {
            return _client.SetSecretAsync(Id, body, cancellationToken);
        }
    }
}
