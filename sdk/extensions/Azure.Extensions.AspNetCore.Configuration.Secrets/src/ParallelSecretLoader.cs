// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets
{
    internal class ParallelSecretLoader: IDisposable
    {
        private const int ParallelismLevel = 32;
        private readonly SecretClient _client;
        private readonly SemaphoreSlim _semaphore;
        private readonly List<Task<Response<KeyVaultSecret>>> _tasks;

        public ParallelSecretLoader(SecretClient client)
        {
            _client = client;
            _semaphore = new SemaphoreSlim(ParallelismLevel, ParallelismLevel);
            _tasks = new List<Task<Response<KeyVaultSecret>>>();
        }

        public void AddSecretToLoad(string secretName)
        {
            _tasks.Add(Task.Run(() => GetSecretAsync(secretName)));
        }

        private async Task<Response<KeyVaultSecret>> GetSecretAsync(string secretName)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                return await _client.GetSecretAsync(secretName).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public Response<KeyVaultSecret>[] WaitForAll()
        {
            Task.WaitAll(_tasks.Select(t => (Task)t).ToArray());
            return _tasks.Select(t => t.Result).ToArray();
        }

        public Task<Response<KeyVaultSecret>[]> WaitForAllAsync() => Task.WhenAll(_tasks);

        public void Dispose()
        {
            _semaphore?.Dispose();
        }
    }
}