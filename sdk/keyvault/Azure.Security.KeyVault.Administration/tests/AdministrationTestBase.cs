// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    /// <summary>
    /// Base class for recorded Administration tests.
    /// </summary>
    [ClientTestFixture(
        KeyVaultAdministrationClientOptions.ServiceVersion.V2025_07_01,
        KeyVaultAdministrationClientOptions.ServiceVersion.V7_6,
        KeyVaultAdministrationClientOptions.ServiceVersion.V7_5,
        KeyVaultAdministrationClientOptions.ServiceVersion.V7_4,
        KeyVaultAdministrationClientOptions.ServiceVersion.V7_3,
        KeyVaultAdministrationClientOptions.ServiceVersion.V7_2)]
    public abstract class AdministrationTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _keysToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _keysToPurge = new ConcurrentStack<string>();

        protected AdministrationTestBase(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        /// Gets a <see cref="KeyClient"/> after tests have started.
        /// </summary>
        protected KeyClient KeyClient { get; private set; }

        protected KeyVaultAdministrationClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Gets the endpoint to connect. By default it is <see cref="KeyVaultTestEnvironment.ManagedHsmUrl"/>.
        /// </summary>
        public Uri Uri =>
            Uri.TryCreate(TestEnvironment.ManagedHsmUrl, UriKind.Absolute, out Uri uri)
                ? uri
                // If the AZURE_MANAGEDHSM_URL variable is not defined, we didn't provision one
                // due to limitations: https://github.com/Azure/azure-sdk-for-net/issues/16531
                : throw new IgnoreException($"Required variable 'AZURE_MANAGEDHSM_URL' is not defined");

        /// <summary>
        /// Gets a polling interval based on whether we're playing back recorded tests (0s) or not (<see cref="KeyVaultTestEnvironment.DefaultPollingInterval"/>).
        /// </summary>
        protected TimeSpan PollingInterval => Recording.Mode == RecordedTestMode.Playback
            ? TimeSpan.Zero
            : KeyVaultTestEnvironment.DefaultPollingInterval;

        [TearDown]
        public virtual async Task Cleanup()
        {
            // Start deleting resources as soon as possible.
            while (_keysToDelete.TryDequeue(out string name))
            {
                await DeleteKey(name);

                _keysToPurge.Push(name);
            }
        }

        [OneTimeTearDown]
        public async Task CleanupAll()
        {
            // Make sure the delete queue is empty.
            await Cleanup();

            while (_keysToPurge.TryPop(out string name))
            {
                await PurgeKey(name).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Delays a test unless currently playing back a test recording.
        /// </summary>
        /// <param name="delay">Delay to wait unless playing back test recordings. The default is 1s.</param>
        /// <param name="playbackDelay">Optional time to wait when playing back test recordings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to cancel the request.</param>
        /// <returns>A <see cref="Task"/> to await.</returns>
        public async Task DelayAsync(TimeSpan? delay = null, TimeSpan? playbackDelay = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(delay ?? PollingInterval);
            }
            else if (playbackDelay != null)
            {
                await Task.Delay(playbackDelay.Value);
            }
        }

        /// <inheritdoc/>
        public sealed override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            // Clear the challenge cache to force a challenge response.
            // This results in consistent results when recording or playing back recorded tests.
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ChallengeBasedAuthenticationPolicy.ClearCache();
            }

            KeyClient = InstrumentClient(
                new KeyClient(
                    Uri,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new KeyClientOptions(KeyClientOptions.ServiceVersion.V7_3)
                    {
                        Diagnostics =
                        {
                            LoggedHeaderNames =
                            {
                                "x-ms-request-id",
                            },
                        },
                    })));

            Start();
        }

        protected virtual void Start()
        {
        }

        protected async Task DeleteKey(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await KeyClient.StartDeleteKeyAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected async Task PurgeKey(string name)
        {
            try
            {
                await WaitForDeletedKey(name).ConfigureAwait(false);
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
                    await KeyClient.PurgeDeletedKeyAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterKeyForCleanup(string keyName)
        {
            _keysToDelete.Enqueue(keyName);
        }

        protected Task WaitForDeletedKey(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => {
                    try
                    {
                        return await KeyClient.GetDeletedKeyAsync(name).ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                        throw new InconclusiveException($"Timed out while waiting for key '{name}' to be deleted");
                    }
                }, delay: PollingInterval);
            }
        }
    }
}
