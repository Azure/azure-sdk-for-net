// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        public void Add(string secretName)
        {
            _tasks.Add(GetSecret(secretName));
        }

        private async Task<Response<KeyVaultSecret>> GetSecret(string secretName)
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

        public Task<Response<KeyVaultSecret>[]> WaitForAll()
        {
            return Task.WhenAll(_tasks);
        }

        public void Dispose()
        {
            _semaphore?.Dispose();
        }
    }
}