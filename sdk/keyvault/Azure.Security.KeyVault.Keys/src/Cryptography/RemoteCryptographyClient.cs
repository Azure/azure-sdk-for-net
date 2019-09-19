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
    internal class RemoteCryptographyClient : ICryptographyProvider
    {
        private readonly Uri _keyId;

        internal RemoteCryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(credential, nameof(credential));

            _keyId = keyId;
            options ??= new CryptographyClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            Pipeline = new KeyVaultPipeline(keyId, apiVersion, pipeline);
        }

        internal KeyVaultPipeline Pipeline { get; }

        public async Task<Response<EncryptResult>> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm,
                Value = plaintext,
                Iv = iv,
                AuthenticationData = authenticationData
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new EncryptResult { Algorithm = algorithm }, cancellationToken, "/encrypt").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<EncryptResult> Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv = default, byte[] authenticationData = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm,
                Value = plaintext,
                Iv = iv,
                AuthenticationData = authenticationData
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Encrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new EncryptResult { Algorithm = algorithm }, cancellationToken, "/encrypt");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<DecryptResult>> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm,
                Value = ciphertext,
                Iv = iv,
                AuthenticationData = authenticationData,
                AuthenticationTag = authenticationTag
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new DecryptResult { Algorithm = algorithm }, cancellationToken, "/decrypt").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<DecryptResult> Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv = default, byte[] authenticationData = default, byte[] authenticationTag = default, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm,
                Value = ciphertext,
                Iv = iv,
                AuthenticationData = authenticationData,
                AuthenticationTag = authenticationTag
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Decrypt");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new DecryptResult { Algorithm = algorithm }, cancellationToken, "/decrypt");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<WrapResult>> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm,
                Key = key
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new WrapResult { Algorithm = algorithm }, cancellationToken, "/wrapKey").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<WrapResult> WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm,
                Key = key
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.WrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new WrapResult { Algorithm = algorithm }, cancellationToken, "/wrapKey");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<UnwrapResult>> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm,
                Key = encryptedKey
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new UnwrapResult { Algorithm = algorithm }, cancellationToken, "/unwrapKey").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<UnwrapResult> UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm,
                Key = encryptedKey
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.UnwrapKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new UnwrapResult { Algorithm = algorithm }, cancellationToken, "/unwrapKey");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<SignResult>> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm,
                Digest = digest
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new SignResult { Algorithm = algorithm }, cancellationToken, "/sign").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<SignResult> Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm,
                Digest = digest
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Sign");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new SignResult { Algorithm = algorithm }, cancellationToken, "/sign");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async Task<Response<VerifyResult>> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm,
                Digest = digest,
                Signature = signature
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new VerifyResult { Algorithm = algorithm, KeyId = _keyId.ToString() }, cancellationToken, "/verify").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public Response<VerifyResult> Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm,
                Digest = digest,
                Signature = signature
            };

            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.Verify");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new VerifyResult { Algorithm = algorithm, KeyId = _keyId.ToString() }, cancellationToken, "/verify");
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
