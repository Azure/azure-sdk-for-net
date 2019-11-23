// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificatesTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";
        private readonly HashSet<string> _toCleanup = new HashSet<string>();
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        public CertificateClient Client { get; set; }

        public Uri VaultUri { get; set; }

        public CertificatesTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal CertificateClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new CertificateClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(new CertificateClientOptions())));
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            Client = GetClient();
            VaultUri = new Uri(Recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable));
        }

        [OneTimeTearDown]
        public async Task CleanupCertificates()
        {
            List<Task> cleanupTasks = new List<Task>();

            _lock.EnterReadLock();
            try
            {
                foreach (string certName in _toCleanup)
                {
                    cleanupTasks.Add(CleanupCertificate(certName));
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }

            await Task.WhenAll(cleanupTasks);
        }

        protected async Task CleanupCertificate(string name)
        {
            try
            {
                await Client.StartDeleteCertificateAsync(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try
            {
                await WaitForDeletedCertificate(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try
            {
                await Client.PurgeDeletedCertificateAsync(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected async Task<KeyVaultCertificateWithPolicy> WaitForCompletion(CertificateOperation operation)
        {
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

            try
            {
                if (IsAsync)
                {
                    await operation.WaitForCompletionAsync(cts.Token);
                }
                else
                {
                    while (!operation.HasCompleted)
                    {
                        operation.UpdateStatus(cts.Token);

                        await Task.Delay(pollingInterval, cts.Token);
                    }
                }
            }
            catch (TaskCanceledException)
            {
                Assert.Inconclusive("Timed out while waiting for operation {0}", operation.Id);
            }

            return operation.Value;
        }

        protected Task WaitForDeletedCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedCertificateAsync(name));
            }
        }

        protected Task WaitForPurgedCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () =>
                {
                    try
                    {
                        await Client.GetDeletedCertificateAsync(name);
                        throw new InvalidOperationException("Key still exists");
                    }
                    catch
                    {
                        return (Response)null;
                    }
                });
            }
        }

        protected Task PollForCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetCertificateAsync(name));
            }
        }

        protected void RegisterForCleanup(string certificateName)
        {
            _lock.EnterWriteLock();
            try
            {
                _toCleanup.Add(certificateName);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
