﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    [ClientTestFixture(
        CertificateClientOptions.ServiceVersion.V7_0,
        CertificateClientOptions.ServiceVersion.V7_1,
        CertificateClientOptions.ServiceVersion.V7_2)]
    [NonParallelizable]
    public abstract class CertificatesTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        protected readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(5);
        private readonly CertificateClientOptions.ServiceVersion _serviceVersion;

        public CertificateClient Client { get; set; }

        public Uri VaultUri { get; set; }

        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _certificatesToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _certificatesToPurge = new ConcurrentStack<string>();
        private readonly ConcurrentQueue<string> _issuerToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentQueue<IEnumerable<CertificateContact>> _contactsToDelete = new ConcurrentQueue<IEnumerable<CertificateContact>>();

        private KeyVaultTestEventListener _listener;

        public CertificatesTestBase(bool isAsync, CertificateClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode ?? RecordedTestUtilities.GetModeFromEnvironment())
        {
            _serviceVersion = serviceVersion;
        }

        internal CertificateClient GetClient()
        {
            CertificateClientOptions options = new CertificateClientOptions(_serviceVersion)
            {
                Diagnostics =
                {
                    IsLoggingContentEnabled = Debugger.IsAttached || Mode == RecordedTestMode.Live,
                    LoggedHeaderNames =
                    {
                        "x-ms-request-id",
                    },
                }
            };

            return InstrumentClient
                (new CertificateClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    TestEnvironment.Credential,
                    InstrumentClientOptions(options)));
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            _listener = new KeyVaultTestEventListener();

            Client = GetClient();
            VaultUri = new Uri(TestEnvironment.KeyVaultUrl);
        }

        public override void StopTestRecording()
        {
            _listener?.Dispose();

            base.StopTestRecording();
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

            while (_issuerToDelete.TryDequeue(out string name))
            {
                await DeleteIssuer(name);
            }

            while (_contactsToDelete.TryDequeue(out IEnumerable<CertificateContact> contacts))
            {
                await DeleteContacts();
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

            while (_issuerToDelete.TryDequeue(out string name))
            {
                await DeleteIssuer(name);
            }
        }

        protected async Task DeleteContacts()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.DeleteContactsAsync().ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected async Task DeleteIssuer(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.DeleteIssuerAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
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

        protected void RegisterForCleanupIssuer(string issuerName)
        {
            _issuerToDelete.Enqueue(issuerName);
        }

        protected void RegisterForCleanUpContacts(IEnumerable<CertificateContact> contacts)
        {
            _contactsToDelete.Enqueue(contacts);
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
