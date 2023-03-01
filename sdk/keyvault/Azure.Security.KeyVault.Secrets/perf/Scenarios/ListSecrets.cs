// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets.Perf.Infrastructure;
using Azure.Test.Perf;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Perf.Scenarios
{
    public sealed class ListSecrets : SecretsScenarioBase<CountOptions>
    {
        private string[] _secretNames;

        public ListSecrets(CountOptions options) : base(options)
        {
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            // Validate that vault contains 0 secrets (including soft-deleted secrets), since additional secrets
            // (including soft-deleted) impact performance.
            if (await Client.GetPropertiesOfSecretsAsync().AnyAsync() || await Client.GetDeletedSecretsAsync(default(CancellationToken)).AnyAsync())
            {
                throw new InvalidOperationException($"KeyVault {PerfTestEnvironment.Instance.VaultUri} must contain 0 " +
                    "secrets (including soft-deleted) before starting perf test");
            }

            List<Task> tasks = new(Options.Count);
            _secretNames = new string[Options.Count];

            for (int i = 0; i < Options.Count; i++)
            {
                string name = GetRandomName($"s{i}-");

                tasks.Add(Client.SetSecretAsync(name, "value"));
                _secretNames[i] = name;
            }

            await Task.WhenAll(tasks);
        }

        public override async Task GlobalCleanupAsync()
        {
            await DeleteSecretsAsync(_secretNames);

            await base.GlobalCleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            Pageable<SecretProperties> secretProperties = Client.GetPropertiesOfSecrets();

            // Actually enumerate properties to exercising any paging code.
            int count = 0;
            foreach (SecretProperties secretProperty in secretProperties)
            {
                count++;
            }

#if DEBUG
            Assert.AreEqual(Options.Count, count);
#endif
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            AsyncPageable<SecretProperties> secretProperties = Client.GetPropertiesOfSecretsAsync();

            // Actually enumerate properties to exercising any paging code.
            int count = 0;
            await foreach (SecretProperties secretProperty in secretProperties)
            {
                count++;
            }

#if DEBUG
            Assert.AreEqual(Options.Count, count);
#endif
        }
    }
}
