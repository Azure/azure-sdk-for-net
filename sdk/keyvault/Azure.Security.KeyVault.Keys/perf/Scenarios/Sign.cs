// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Keys.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Perf.Scenarios
{
    public sealed class Sign : CryptographyScenarioBase<PerfOptions>
    {
        private static readonly SignatureAlgorithm s_algorithm = SignatureAlgorithm.RS256;

        private readonly SHA256 _hasher;
        private byte[] _digest;

        public Sign(PerfOptions options) : base(options)
        {
            _hasher = SHA256.Create();
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Generate new plaintext and digest with each iteration to avoid potential caching of results.
            Regenerate();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            SignResult result = CryptographyClient.Sign(s_algorithm, _digest);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            SignResult result = await CryptographyClient.SignAsync(s_algorithm, _digest);
        }

        public override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hasher.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Regenerate()
        {
            var plaintext = new byte[2048];
            Random.NextBytes(plaintext);

            _digest = _hasher.ComputeHash(plaintext);
        }
    }
}
