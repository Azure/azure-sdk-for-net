// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Perf.Scenarios
{
    public sealed class GetSecret : SecretsScenarioBase<PerfOptions>
    {
        private const string SecretValue = "value";
        private static string _secretName = GetRandomName("s-");

        public GetSecret(PerfOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            await Client.SetSecretAsync(_secretName, SecretValue);
        }

        public override async Task GlobalCleanupAsync()
        {
            await DeleteSecretsAsync(_secretName);

            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            KeyVaultSecret secret = Client.GetSecret(_secretName);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            KeyVaultSecret secret = await Client.GetSecretAsync(_secretName);
        }
    }
}
