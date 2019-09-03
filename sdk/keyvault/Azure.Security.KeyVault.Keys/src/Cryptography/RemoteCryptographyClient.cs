// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    internal class RemoteCryptographyClient : ICryptographyProvider
    {
        private const string EncryptOperation = "/encrypt";
        private const string DecryptOperation = "/decrypt";
        private const string SignOperation = "/sign";
        private const string VerifyOperation = "/verify";
        private const string WrapOperation = "/wrapKey";
        private const string UnwrapOperation = "/unwrapKey";

        /// <summary>
        /// 
        /// </summary>
        protected RemoteCryptographyClient()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        public RemoteCryptographyClient(Uri keyId, TokenCredential credential)
            : this(keyId, credential, null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public RemoteCryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            KeyId = keyId ?? throw new ArgumentNullException(nameof(keyId));
            if (credential is null) throw new ArgumentNullException(nameof(credential));

            options ??= new CryptographyClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            Pipeline = new KeyVaultPipeline(keyId, apiVersion, pipeline);
        }

        internal KeyVaultPipeline Pipeline { get; }

        /// <summary>
        /// 
        /// </summary>
        public Uri KeyId { get; }

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

            return await SendRequestAsync(VerifyOperation, parameters, () => new VerifyResult() { Algorithm = algorithm, KeyId = KeyId.ToString() }, cancellationToken).ConfigureAwait(false);
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

            return SendRequest(VerifyOperation, parameters, () => new VerifyResult() { Algorithm = algorithm, KeyId = KeyId.ToString() }, cancellationToken);
        }

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(string operation, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.{operation}");
            scope.AddAttribute("key", KeyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, content, resultFactory, cancellationToken, operation).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<TResult> SendRequest<TContent, TResult>(string operation, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken)
            where TContent : IJsonSerializable
            where TResult : IJsonDeserializable
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"Azure.Security.KeyVault.Keys.Cryptography.CryptographyClient.{operation}");
            scope.AddAttribute("key", KeyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, content, resultFactory, cancellationToken, operation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        async Task<EncryptResult> ICryptographyProvider.EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            return await EncryptAsync(algorithm, plaintext, iv, authenticationData, cancellationToken).ConfigureAwait(false);
        }

        EncryptResult ICryptographyProvider.Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] authenticationData, CancellationToken cancellationToken)
        {
            return Encrypt(algorithm, plaintext, iv, authenticationData, cancellationToken);
        }

        async Task<DecryptResult> ICryptographyProvider.DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            return await DecryptAsync(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken).ConfigureAwait(false);
        }

        DecryptResult ICryptographyProvider.Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationData, byte[] authenticationTag, CancellationToken cancellationToken)
        {
            return Decrypt(algorithm, ciphertext, iv, authenticationData, authenticationTag, cancellationToken);
        }

        async Task<WrapResult> ICryptographyProvider.WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return await WrapKeyAsync(algorithm, key, cancellationToken).ConfigureAwait(false);
        }

        WrapResult ICryptographyProvider.WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken)
        {
            return WrapKey(algorithm, key, cancellationToken);
        }

        async Task<UnwrapResult> ICryptographyProvider.UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            return await UnwrapKeyAsync(algorithm, encryptedKey, cancellationToken).ConfigureAwait(false);
        }

        UnwrapResult ICryptographyProvider.UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken)
        {
            return UnwrapKey(algorithm, encryptedKey, cancellationToken);
        }

        async Task<SignResult> ICryptographyProvider.SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            return await SignAsync(algorithm, digest, cancellationToken).ConfigureAwait(false);
        }

        SignResult ICryptographyProvider.Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken)
        {
            return Sign(algorithm, digest, cancellationToken);
        }

        async Task<VerifyResult> ICryptographyProvider.VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            return await VerifyAsync(algorithm, digest, signature, cancellationToken).ConfigureAwait(false);
        }

        VerifyResult ICryptographyProvider.Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken)
        {
            return Verify(algorithm, digest, signature, cancellationToken);
        }
    }
}
