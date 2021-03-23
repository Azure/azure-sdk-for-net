// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Security.KeyVault.Certificates.Perf.Infrastructure
{
    public abstract class CertificatesScenarioBase<T> : PerfTest<T> where T : PerfOptions
    {
        private readonly Random _rand;

        protected CertificatesScenarioBase(T options) : base(options)
        {
            _rand = new Random();

            CertificateClientOptions clientOptions = new()
            {
                Transport = PerfTransport.Create(Options),
            };

            Client = new CertificateClient(
                PerfTestEnvironment.Instance.VaultUri,
                PerfTestEnvironment.Instance.Credential,
                clientOptions);
        }

        protected CertificateClient Client { get; }

        protected string GetRandomName() => _rand.Next().ToString();

        protected async Task DeleteCertificatesAsync(params string[] names)
        {
            List<Task> tasks = new(names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                Task t = Task.Run(async () =>
                {
                    DeleteCertificateOperation operation = null;
                    try
                    {
                        operation = await Client.StartDeleteCertificateAsync(name);
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
                            await Client.PurgeDeletedCertificateAsync(name);
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
