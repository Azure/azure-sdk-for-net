// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        protected RemoteCryptographyClient()
        {
        }

        internal RemoteCryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(credential, nameof(credential));

            _keyId = keyId;
            options ??= new CryptographyClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential));

            Pipeline = new KeyVaultPipeline(keyId, apiVersion, pipeline, new ClientDiagnostics(options));
        }

        internal RemoteCryptographyClient(KeyVaultPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        internal KeyVaultPipeline Pipeline { get; }

        public bool SupportsOperation(KeyOperation operation) => true;

        public virtual async Task<Response<EncryptResult>> EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.ToString(),
                Value = plaintext,
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

        public virtual Response<EncryptResult> Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.ToString(),
                Value = plaintext,
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

        public virtual async Task<Response<DecryptResult>> DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.ToString(),
                Value = ciphertext,
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

        public virtual Response<DecryptResult> Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyEncryptParameters()
            {
                Algorithm = algorithm.ToString(),
                Value = ciphertext,
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

        public virtual async Task<Response<WrapResult>> WrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.ToString(),
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

        public virtual Response<WrapResult> WrapKey(KeyWrapAlgorithm algorithm, byte[] key, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.ToString(),
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

        public virtual async Task<Response<UnwrapResult>> UnwrapKeyAsync(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.ToString(),
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

        public virtual Response<UnwrapResult> UnwrapKey(KeyWrapAlgorithm algorithm, byte[] encryptedKey, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyWrapParameters()
            {
                Algorithm = algorithm.ToString(),
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

        public virtual async Task<Response<SignResult>> SignAsync(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm.ToString(),
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

        public virtual Response<SignResult> Sign(SignatureAlgorithm algorithm, byte[] digest, CancellationToken cancellationToken = default)
        {
            var parameters = new KeySignParameters
            {
                Algorithm = algorithm.ToString(),
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

        public virtual async Task<Response<VerifyResult>> VerifyAsync(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm.ToString(),
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

        public virtual Response<VerifyResult> Verify(SignatureAlgorithm algorithm, byte[] digest, byte[] signature, CancellationToken cancellationToken = default)
        {
            var parameters = new KeyVerifyParameters
            {
                Algorithm = algorithm.ToString(),
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

        internal virtual async Task<Response<KeyVaultKey>> GetKeyAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.GetKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultKey(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<KeyVaultKey> GetKey(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope("Azure.Security.KeyVault.Keys.Cryptography.RemoteCryptographyClient.GetKey");
            scope.AddAttribute("key", _keyId);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultKey(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        bool ICryptographyProvider.ShouldRemote => false;

        async Task<EncryptResult> ICryptographyProvider.EncryptAsync(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken)
        {
            return await EncryptAsync(algorithm, plaintext, cancellationToken).ConfigureAwait(false);
        }

        EncryptResult ICryptographyProvider.Encrypt(EncryptionAlgorithm algorithm, byte[] plaintext, CancellationToken cancellationToken)
        {
            return Encrypt(algorithm, plaintext, cancellationToken);
        }

        async Task<DecryptResult> ICryptographyProvider.DecryptAsync(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken)
        {
            return await DecryptAsync(algorithm, ciphertext, cancellationToken).ConfigureAwait(false);
        }

        DecryptResult ICryptographyProvider.Decrypt(EncryptionAlgorithm algorithm, byte[] ciphertext, CancellationToken cancellationToken)
        {
            return Decrypt(algorithm, ciphertext, cancellationToken);
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
