using Azure.Core;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    internal class DirectCryptographyClient : ICryptographyProvider
    {
        private Uri _keyId;
        private HttpPipeline _pipeline;
        private readonly string ApiVersion;

        private const string EncryptOperation = "encrypt";
        private const string DecryptOperation = "decrypt";
        private const string SignOperation = "sign";
        private const string VerifyOperation = "verify";
        private const string WrapOperation = "wrap";
        private const string UnwrapOperation = "unwrap";

        /// <summary>
        /// 
        /// </summary>
        protected DirectCryptographyClient()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        public DirectCryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public DirectCryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            _keyId = keyId ?? throw new ArgumentNullException(nameof(keyId));

            options ??= new CryptographyClientOptions();

            this.ApiVersion = options.GetVersionString();

            _pipeline = HttpPipelineBuilder.Build(options,
                    bufferResponse: true,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default"));
        }

        /// <summary>
        /// 
        /// </summary>
        public Uri KeyId => _keyId;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<EncryptResult>> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.GetName(),
                Value = plaintext,
                Iv = iv,
                AuthenticationData = authenticationData
            };

            return await SendRequestAsync(EncryptOperation, parameters, () => new EncryptResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="plaintext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<EncryptResult> Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.GetName(),
                Value = plaintext,
                Iv = iv,
                AuthenticationData = authenticationData
            };

            return SendRequest(EncryptOperation, parameters, () => new EncryptResult() { Algorithm = algorithm }, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DecryptResult>> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.GetName(),
                Value = ciphertext,
                Iv = iv,
                AuthenticationData = authenticationData,
                AuthenticationTag = authenticationTag
            };

            return await SendRequestAsync(DecryptOperation, parameters, () => new DecryptResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="ciphertext"></param>
        /// <param name="iv"></param>
        /// <param name="authenticationData"></param>
        /// <param name="authenticationTag"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DecryptResult> Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.GetName(),
                Value = ciphertext,
                Iv = iv,
                AuthenticationData = authenticationData,
                AuthenticationTag = authenticationTag
            };

            return SendRequest(DecryptOperation, parameters, () => new DecryptResult() { Algorithm = algorithm }, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<WrapResult>> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.GetName(),
                Key = key
            };

            return await SendRequestAsync(WrapOperation, parameters, () => new WrapResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<WrapResult> WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.GetName(),
                Key = key
            };

            return SendRequest(WrapOperation, parameters, () => new WrapResult() { Algorithm = algorithm }, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="encryptedKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<UnwrapResult>> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.GetName(),
                Key = encryptedKey
            };

            return await SendRequestAsync(UnwrapOperation, parameters, () => new UnwrapResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="encryptedKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<UnwrapResult> UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.GetName(),
                Key = encryptedKey
            };

            return SendRequest(UnwrapOperation, parameters, () => new UnwrapResult() { Algorithm = algorithm }, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="digest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<SignResult>> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm.GetName(),
                Digest = digest
            };

            return await SendRequestAsync(SignOperation, parameters, () => new SignResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="digest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<SignResult> Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm.GetName(),
                Digest = digest
            };

            return SendRequest(SignOperation, parameters, () => new SignResult() { Algorithm = algorithm }, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="digest"></param>
        /// <param name="signature"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<VerifyResult>> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm.GetName(),
                Digest = digest,
                Signature = signature
            };

            return await SendRequestAsync(VerifyOperation, parameters, () => new VerifyResult() { Algorithm = algorithm }, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="digest"></param>
        /// <param name="signature"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<VerifyResult> Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm.GetName(),
                Digest = digest,
                Signature = signature
            };

            return SendRequest(VerifyOperation, parameters, () => new VerifyResult() { Algorithm = algorithm }, cancellationToken);
        }

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(string operation, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope($"Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.{operation}");
            scope.AddAttribute("key", _keyId.ToString());
            scope.Start();

            try
            {
                using (Request request = CreateRequest(operation))
                {
                    request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                    Response response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                    return this.CreateResponse(response, resultFactory());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
            }
        }

        private Response<TResult> SendRequest<TContent, TResult>(string operation, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope($"Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.{operation}");
            scope.AddAttribute("key", _keyId.ToString());
            scope.Start();

            try
            {
                using (Request request = CreateRequest(operation))
                {
                    request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                    Response response = SendRequest(request, cancellationToken);

                    return CreateResponse(response, resultFactory());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var response = _pipeline.SendRequest(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                case 204:
                    return response;
                default:
                    throw response.CreateRequestFailedException();
            }
        }

        private Request CreateRequest(string operation)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = RequestMethod.Post;
            request.UriBuilder.Uri = _keyId;
            request.UriBuilder.AppendPath(operation);

            request.UriBuilder.AppendQuery("api-version", ApiVersion);

            return request;
        }

        private Request CreateRequest(RequestMethod method, Uri uri)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Common.JsonAccept);
            request.Method = method;
            request.UriBuilder.Uri = uri;

            return request;
        }

        private Response<T> CreateResponse<T>(Response response, T result)
            where T : IJsonDeserializable
        {
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }

        async Task<EncryptResult> ICryptographyProvider.EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken).ConfigureAwait(false);
        }

        EncryptResult ICryptographyProvider.Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
        }

        async Task<DecryptResult> ICryptographyProvider.DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken).ConfigureAwait(false);
        }

        DecryptResult ICryptographyProvider.Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
        }

        async Task<WrapResult> ICryptographyProvider.WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
        }

        WrapResult ICryptographyProvider.WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).WrapKey(algorithm, key, cancellationToken);
        }

        async Task<UnwrapResult> ICryptographyProvider.UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
        }

        UnwrapResult ICryptographyProvider.UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).UnwrapKey(algorithm, encryptedKey, cancellationToken);
        }

        async Task<SignResult> ICryptographyProvider.SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
        }

        SignResult ICryptographyProvider.Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).Sign(algorithm, digest, cancellationToken);
        }

        async Task<VerifyResult> ICryptographyProvider.VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            return await ((DirectCryptographyClient)this).VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
        }

        VerifyResult ICryptographyProvider.Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            return ((DirectCryptographyClient)this).Verify(algorithm, digest, signature, cancellationToken);
        }
    }
}
