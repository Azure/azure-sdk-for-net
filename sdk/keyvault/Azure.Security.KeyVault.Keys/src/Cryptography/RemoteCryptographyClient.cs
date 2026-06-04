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
        private const string OTelKeyIdKey = "az.keyvault.key.id";
        private readonly Uri _keyId;
        private readonly string _keyIdStr;

        protected RemoteCryptographyClient()
        {
        }

        internal RemoteCryptographyClient(Uri keyId, TokenCredential credential, CryptographyClientOptions options)
        {
            Argument.AssertNotNull(keyId, nameof(keyId));
            Argument.AssertNotNull(credential, nameof(credential));

            _keyId = keyId;
            _keyIdStr = _keyId.OriginalString;
            options ??= new CryptographyClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification));

            Pipeline = new KeyVaultPipeline(keyId, apiVersion, pipeline, new ClientDiagnostics(options));
        }

        internal RemoteCryptographyClient(KeyVaultPipeline pipeline)
        {
            Pipeline = pipeline;
        }

        internal KeyVaultPipeline Pipeline { get; }

        public bool SupportsOperation(KeyOperation operation) => true;

        public virtual async Task<Response<EncryptResult>> EncryptAsync(EncryptParameters parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                // Make sure the IV is initialized.
                // TODO: Remove this call once the service will initialized it: https://github.com/Azure/azure-sdk-for-net/issues/16175
                parameters.Initialize();

                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new EncryptResult { Algorithm = parameters.Algorithm }, cancellationToken, "/encrypt").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<EncryptResult> Encrypt(EncryptParameters parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Encrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                // Make sure the IV is initialized.
                // TODO: Remove this call once the service will initialized it: https://github.com/Azure/azure-sdk-for-net/issues/16175
                parameters.Initialize();

                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new EncryptResult { Algorithm = parameters.Algorithm }, cancellationToken, "/encrypt");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<DecryptResult>> DecryptAsync(DecryptParameters parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new DecryptResult { Algorithm = parameters.Algorithm }, cancellationToken, "/decrypt").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<DecryptResult> Decrypt(DecryptParameters parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Decrypt)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new DecryptResult { Algorithm = parameters.Algorithm }, cancellationToken, "/decrypt");
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(WrapKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(WrapKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(UnwrapKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(UnwrapKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Sign)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Sign)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Verify)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                return await Pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new VerifyResult { Algorithm = algorithm, KeyId = _keyId.AbsoluteUri }, cancellationToken, "/verify").ConfigureAwait(false);
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

            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(Verify)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
            scope.Start();

            try
            {
                return Pipeline.SendRequest(RequestMethod.Post, parameters, () => new VerifyResult { Algorithm = algorithm, KeyId = _keyId.AbsoluteUri }, cancellationToken, "/verify");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<Response<KeyVaultKey>> GetKeyAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(GetKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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
            using DiagnosticScope scope = Pipeline.CreateScope($"{nameof(RemoteCryptographyClient)}.{nameof(GetKey)}");
            scope.AddAttribute(OTelKeyIdKey, _keyIdStr);
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

        bool ICryptographyProvider.CanRemote => false;

        async Task<EncryptResult> ICryptographyProvider.EncryptAsync(EncryptParameters parameters, CancellationToken cancellationToken)
        {
            return await EncryptAsync(parameters, cancellationToken).ConfigureAwait(false);
        }

        EncryptResult ICryptographyProvider.Encrypt(EncryptParameters parameters, CancellationToken cancellationToken)
        {
            return Encrypt(parameters, cancellationToken);
        }

        async Task<DecryptResult> ICryptographyProvider.DecryptAsync(DecryptParameters parameters, CancellationToken cancellationToken)
        {
            return await DecryptAsync(parameters, cancellationToken).ConfigureAwait(false);
        }

        DecryptResult ICryptographyProvider.Decrypt(DecryptParameters parameters, CancellationToken cancellationToken)
        {
            return Decrypt(parameters, cancellationToken);
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
