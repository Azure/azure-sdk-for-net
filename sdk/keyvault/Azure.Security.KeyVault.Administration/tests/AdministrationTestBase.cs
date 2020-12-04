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
    public abstract class AdministrationTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _keysToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _keysToPurge = new ConcurrentStack<string>();

        protected AdministrationTestBase(bool isAsync, RecordedTestMode? mode)
            : base(isAsync, mode ?? RecordedTestUtilities.GetModeFromEnvironment())
        {
        }

        /// <summary>
        /// Gets a <see cref="KeyClient"/> after tests have started.
        /// </summary>
        protected KeyClient KeyClient { get; private set; }

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
        /// Gets a polling interval based on whether we're playing back recorded tests (0s) or not (2s).
        /// </summary>
        protected TimeSpan PollingInterval => Recording.Mode == RecordedTestMode.Playback
            ? TimeSpan.Zero
            : TimeSpan.FromSeconds(2);

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
                await Task.Delay(delay ?? TimeSpan.FromSeconds(1));
            }
            else if (playbackDelay != null)
            {
                await Task.Delay(playbackDelay.Value);
            }
        }

        /// <inheritdoc/>
        public sealed override void StartTestRecording()
        {
            base.StartTestRecording();

            // Clear the challenge cache to force a challenge response.
            // This results in consistent results when recording or playing back recorded tests.
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }

            KeyClient = InstrumentClient(
                new KeyClient(
                    Uri,
                    TestEnvironment.Credential,
                    InstrumentClientOptions(new KeyClientOptions())));

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
                return TestRetryHelper.RetryAsync(async () => await KeyClient.GetDeletedKeyAsync(name), delay: PollingInterval);
            }
        }
    }
}
