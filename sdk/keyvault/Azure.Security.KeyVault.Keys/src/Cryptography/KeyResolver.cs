// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Azure Key Vault KeyResolver. This class resolves Key Vault Key Identifiers and
    /// Secret Identifiers to create <see cref="CryptographyClient"/> instances capable of performing
    /// cryptographic operations with the key. Secret Identifiers can only be resolved if the Secret is
    /// a byte array with a length matching one of the AES key lengths (128, 192, 256) and the
    /// content-type of the secret is application/octet-stream.
    /// </summary>
    public class KeyResolver : IKeyEncryptionKeyResolver
    {
        private const string OTelKeyIdKey = "az.keyvault.key.id";
        private readonly HttpPipeline  _pipeline;
        private readonly string _apiVersion;

        private ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyResolver"/> class for mocking.
        /// </summary>
        protected KeyResolver()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyResolver"/> class.
        /// </summary>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="credential"/> is null.</exception>
        public KeyResolver(TokenCredential credential)
            : this(credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyResolver"/> class.
        /// </summary>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options">Options to configure the management of the requests sent to Key Vault for both the <see cref="KeyResolver"/> instance as well as all created instances of <see cref="CryptographyClient"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="credential"/> is null.</exception>
        public KeyResolver(TokenCredential credential, CryptographyClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new CryptographyClientOptions();

            _apiVersion = options.GetVersionString();

            _pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification));

            _clientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary>
        /// Retrieves a <see cref="CryptographyClient"/> capable of performing cryptographic operations with the key represented by the specified <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier of the key used by the created <see cref="CryptographyClient"/>. You should validate that this URI references a valid Key Vault or Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A new <see cref="CryptographyClient"/> capable of performing cryptographic operations with the key represented by the specified <paramref name="keyId"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> is null.</exception>
        public virtual CryptographyClient Resolve(Uri keyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(KeyResolver)}.{nameof(Resolve)}");
            scope.AddAttribute(OTelKeyIdKey, keyId.OriginalString);
            scope.Start();

            try
            {
                Argument.AssertNotNull(keyId, nameof(keyId));

                KeyVaultKey key = GetKey(keyId, cancellationToken);

                KeyVaultPipeline pipeline = new KeyVaultPipeline(keyId, _apiVersion, _pipeline, _clientDiagnostics);

                // Since we already attempted to download the key, do not let the CryptographyClient needlessly try again.
                return (key != null) ? new CryptographyClient(key, pipeline) : new CryptographyClient(keyId, pipeline, forceRemote: true);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a <see cref="CryptographyClient"/> capable of performing cryptographic operations with the key represented by the specified <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier of the key used by the created <see cref="CryptographyClient"/>. You should validate that this URI references a valid Key Vault or Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A new <see cref="CryptographyClient"/> capable of performing cryptographic operations with the key represented by the specified <paramref name="keyId"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="keyId"/> is null.</exception>
        public virtual async Task<CryptographyClient> ResolveAsync(Uri keyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(KeyResolver)}.{nameof(Resolve)}");
            scope.AddAttribute(OTelKeyIdKey, keyId.OriginalString);
            scope.Start();

            try
            {
                Argument.AssertNotNull(keyId, nameof(keyId));

                KeyVaultKey key = await GetKeyAsync(keyId, cancellationToken).ConfigureAwait(false);

                KeyVaultPipeline pipeline = new KeyVaultPipeline(keyId, _apiVersion, _pipeline, _clientDiagnostics);

                // Since we already attempted to download the key, do not let the CryptographyClient needlessly try again.
                return (key != null) ? new CryptographyClient(key, pipeline) : new CryptographyClient(keyId, pipeline, forceRemote: true);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc/>
        IKeyEncryptionKey IKeyEncryptionKeyResolver.Resolve(string keyId, CancellationToken cancellationToken)
        {
            return ((KeyResolver)this).Resolve(new Uri(keyId), cancellationToken);
        }

        /// <inheritdoc/>
        async Task<IKeyEncryptionKey> IKeyEncryptionKeyResolver.ResolveAsync(string keyId, CancellationToken cancellationToken)
        {
            return await ((KeyResolver)this).ResolveAsync(new Uri(keyId), cancellationToken).ConfigureAwait(false);
        }

        private KeyVaultKey GetKey(Uri keyId, CancellationToken cancellationToken)
        {
            using Request request = CreateGetRequest(keyId);

            Response response = _pipeline.SendRequest(request, cancellationToken);

            return KeyVaultIdentifier.Parse(keyId).Collection == KeyVaultIdentifier.SecretsCollection ? (KeyVaultKey)ParseResponse(response, new SecretKey()) : ParseResponse(response, new KeyVaultKey());
        }

        private async Task<KeyVaultKey> GetKeyAsync(Uri keyId, CancellationToken cancellationToken)
        {
            using Request request = CreateGetRequest(keyId);

            Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return KeyVaultIdentifier.Parse(keyId).Collection == KeyVaultIdentifier.SecretsCollection ? (KeyVaultKey)ParseResponse(response, new SecretKey()) : ParseResponse(response, new KeyVaultKey());
        }

        private Response<T> ParseResponse<T>(Response response, T result)
            where T : IJsonDeserializable
        {
            switch (response.Status)
            {
                case 200:
                case 201:
                case 202:
                case 204:
                    result.Deserialize(response.ContentStream);
                    return Response.FromValue(result, response);
                case 403 when !(result is SecretKey):
                    // The "get" permission may not be granted on a key, while other key permissions may be granted.
                    // To use a key contained within a secret, the "get" permission is required to retrieve the key material.
                    return Response.FromValue<T>(default, response);
                default:
                    throw new RequestFailedException(response);
            }
        }

        private Request CreateGetRequest(Uri uri)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = RequestMethod.Get;
            request.Uri.Reset(uri);

            request.Uri.AppendQuery("api-version", _apiVersion);

            return request;
        }
    }
}
