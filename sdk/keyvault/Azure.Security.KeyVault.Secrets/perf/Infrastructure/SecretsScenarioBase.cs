// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Security.KeyVault.Secrets.Perf.Infrastructure
{
    public abstract class SecretsScenarioBase<T> : PerfTest<T> where T : PerfOptions
    {
        private readonly Random _rand;

        protected SecretsScenarioBase(T options) : base(options)
        {
            _rand = new Random();

            Client = new SecretClient(
                PerfTestEnvironment.Instance.VaultUri,
                PerfTestEnvironment.Instance.Credential,
                ConfigureClientOptions(new SecretClientOptions()));
        }

        protected SecretClient Client { get; }

        protected static string GetRandomName(string prefix = null) => $"{prefix}{Guid.NewGuid():n}";

        protected async Task DeleteSecretsAsync(params string[] names)
        {
            List<Task> tasks = new(names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                Task t = Task.Run(async () =>
                {
                    DeleteSecretOperation operation = null;
                    try
                    {
                        operation = await Client.StartDeleteSecretAsync(name);
                        await operation.WaitForCompletionAsync();
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                    }

                    // Purge deleted Secrets if soft delete is enabled.
                    if (operation.Value.RecoveryId != null)
                    {
                        try
                        {
                            await Client.PurgeDeletedSecretAsync(name, default(CancellationToken));
                        }
                        catch (RequestFailedException ex) when (ex.Status == 404)
                        {
                        }
                    }
                });

                tasks.Add(t);
            }

            await Task.WhenAll(tasks);
        }
    }
}
