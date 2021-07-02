// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Test.Perf;

namespace Azure.Security.KeyVault.Keys.Perf.Infrastructure
{
    public abstract class CryptographyScenarioBase<T> : KeysScenarioBase<T> where T : PerfOptions
    {
        protected CryptographyScenarioBase(T options) : base(options)
        {
        }
        protected CryptographyClient CryptographyClient { get; private set; }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            CryptographyClient = new(
                KeyId,
                PerfTestEnvironment.Instance.Credential,
                new()
                {
                    Transport = PerfTransport.Create(Options),
                });
        }
    }
}
