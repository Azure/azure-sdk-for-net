// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Keys.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Perf.Scenarios
{
    public sealed class Decrypt : CryptographyScenarioBase<PerfOptions>
    {
        private static readonly EncryptionAlgorithm s_algorithm = EncryptionAlgorithm.RsaOaep256;

        private byte[] _plaintext;
        private byte[] _ciphertext;

        public Decrypt(PerfOptions options) : base(options)
        {
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Generate new plaintext with each iteration to avoid potential caching of results.
            _plaintext = new byte[32];
            Random.NextBytes(_plaintext);

            // CryptographyClient caches the public key so encrypting now removes the initial request from metrics.
            EncryptResult result = await CryptographyClient.EncryptAsync(s_algorithm, _plaintext);
            _ciphertext = result.Ciphertext;
        }

        public override void Run(CancellationToken cancellationToken)
        {
            DecryptResult result = CryptographyClient.Decrypt(s_algorithm, _ciphertext);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            DecryptResult result = await CryptographyClient.DecryptAsync(s_algorithm, _ciphertext);
        }
    }
}
