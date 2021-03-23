// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Security.KeyVault.Keys.Perf.Infrastructure
{
    public abstract class KeysScenarioBase<T> : PerfTest<T> where T : PerfOptions
    {
        private readonly Random _rand;

        protected KeysScenarioBase(T options) : base(options)
        {
            _rand = new Random();

            KeyName = $"k-{GetRandomName()}";

            Client = new KeyClient(
                PerfTestEnvironment.Instance.VaultUri,
                PerfTestEnvironment.Instance.Credential,
                new()
                {
                    Transport = PerfTransport.Create(Options),
                });
        }

        protected KeyClient Client { get; }

        protected Uri KeyId { get; private set; }

        protected string KeyName { get; }

        protected Random Random => _rand;

        protected string GetRandomName() => _rand.Next().ToString();

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            KeyVaultKey key = await Client.CreateRsaKeyAsync(
                new CreateRsaKeyOptions(KeyName)
                {
                    KeySize = 2048,
                });

            KeyId = key.Id;
        }

        public override async Task GlobalCleanupAsync()
        {
            await DeleteKeysAsync(KeyName);

            await base.GlobalCleanupAsync();
        }

        protected async Task DeleteKeysAsync(params string[] names)
        {
            List<Task> tasks = new(names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                Task t = Task.Run(async () =>
                {
                    DeleteKeyOperation operation = null;
                    try
                    {
                        operation = await Client.StartDeleteKeyAsync(name);
                        await operation.WaitForCompletionAsync();
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                    }

                    // Purge deleted Certificates if soft delete is enabled.
                    if (operation.Value.RecoveryId != null)
                    {
                        try
                        {
                            await Client.PurgeDeletedKeyAsync(name);
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
