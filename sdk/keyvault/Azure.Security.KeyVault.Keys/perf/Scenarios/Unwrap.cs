// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Keys.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Perf.Scenarios
{
    public sealed class Unwrap : CryptographyScenarioBase<PerfOptions>
    {
        private static readonly KeyWrapAlgorithm s_algorithm = KeyWrapAlgorithm.RsaOaep256;

        private readonly Aes _aes;
        private byte[] _encryptedKey;

        public Unwrap(PerfOptions options) : base(options)
        {
            _aes = Aes.Create();
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Generate new key with each iteration to avoid potential caching of results.
            _aes.GenerateKey();

            // CryptographyClient caches the public key so encrypting now removes the initial request from metrics.
            WrapResult result = await CryptographyClient.WrapKeyAsync(s_algorithm, _aes.Key);
            _encryptedKey = result.EncryptedKey;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            UnwrapResult result = CryptographyClient.UnwrapKey(KeyWrapAlgorithm.RsaOaep256, _encryptedKey);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            UnwrapResult result = await CryptographyClient.UnwrapKeyAsync(s_algorithm, _encryptedKey);
        }

        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _aes.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
