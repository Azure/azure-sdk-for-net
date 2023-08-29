// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Keys.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Perf.Scenarios
{
    public sealed class GetKey : KeysScenarioBase<PerfOptions>
    {
        public GetKey(PerfOptions options) : base(options)
        {
        }

        public override void Run(CancellationToken cancellationToken)
        {
            KeyVaultKey key = Client.GetKey(KeyName);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            KeyVaultKey key = await Client.GetKeyAsync(KeyName);
        }
    }
}
