// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    [ClientTestFixture(
        CertificateClientOptions.ServiceVersion.V7_0,
        CertificateClientOptions.ServiceVersion.V7_1_Preview)]
    [NonParallelizable]
    public class CertificatesTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        protected readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(5);
        private readonly CertificateClientOptions.ServiceVersion _serviceVersion;

        public CertificateClient Client { get; set; }

        public Uri VaultUri { get; set; }

        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _certificatesToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _certificatesToPurge = new ConcurrentStack<string>();

        public CertificatesTestBase(bool isAsync, CertificateClientOptions.ServiceVersion serviceVersion) : base(isAsync)
        {
            _serviceVersion = serviceVersion;
        }

        internal CertificateClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            CertificateClientOptions options = new CertificateClientOptions(_serviceVersion)
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = Debugger.IsAttached,
                }
            };

            return InstrumentClient
                (new CertificateClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(options)));
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            Client = GetClient();
            VaultUri = new Uri(Recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable));
        }

        [TearDown]
        public async Task Cleanup()
        {
            // Start deleting resources as soon as possible.
            while (_certificatesToDelete.TryDequeue(out string name))
            {
                await DeleteCertificate(name);

                _certificatesToPurge.Push(name);
            }
        }

        [OneTimeTearDown]
        public async Task CleanupAll()
        {
            // Make sure the delete queue is empty.
            await Cleanup();

            while (_certificatesToPurge.TryPop(out string name))
            {
                await PurgeCertificate(name).ConfigureAwait(false);
            }
        }

        protected async Task DeleteCertificate(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.StartDeleteCertificateAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected async Task PurgeCertificate(string name)
        {
            try
            {
                await WaitForDeletedCertificate(name).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.PurgeDeletedCertificateAsync(name).ConfigureAwait(false);
                }
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
                    await operation.WaitForCompletionAsync(pollingInterval, cts.Token);
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedCertificateAsync(name), delay: PollingInterval);
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
                }, delay: PollingInterval);
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetCertificateAsync(name), delay: PollingInterval);
            }
        }

        protected void RegisterForCleanup(string certificateName)
        {
            _certificatesToDelete.Enqueue(certificateName);
        }

        protected IAsyncDisposable EnsureDeleted(CertificateOperation operation) => new CertificateOperationDeleter(operation);

        private class CertificateOperationDeleter : IAsyncDisposable
        {
            private readonly CertificateOperation _operation;

            public CertificateOperationDeleter(CertificateOperation operation)
            {
                _operation = operation;
            }

            public async ValueTask DisposeAsync()
            {
                if (!_operation.HasCompleted)
                {
                    await _operation.DeleteAsync();
                }
            }
        }
    }
}
