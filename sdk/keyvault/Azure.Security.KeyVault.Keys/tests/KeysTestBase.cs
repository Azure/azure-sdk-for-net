// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [ClientTestFixture(
        KeyClientOptions.ServiceVersion.V7_0,
        KeyClientOptions.ServiceVersion.V7_1_Preview)]
    [NonParallelizable]
    public abstract class KeysTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        protected readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(5);

        public KeyClient Client { get; set; }

        public Uri VaultUri { get; set; }

        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _keysToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _keysToPurge = new ConcurrentStack<string>();
        private readonly KeyClientOptions.ServiceVersion _serviceVersion;

        private KeyVaultTestEventListener _listener;

        protected KeysTestBase(bool isAsync, KeyClientOptions.ServiceVersion serviceVersion) : base(isAsync)
        {
            _serviceVersion = serviceVersion;
        }

        internal KeyClient GetClient(TestRecording recording = null)
        {
            recording = recording ?? Recording;

            // Until https://github.com/Azure/azure-sdk-for-net/issues/8575 is fixed,
            // we need to delay creation of keys due to aggressive service limits on key creation:
            // https://docs.microsoft.com/azure/key-vault/key-vault-service-limits
            IInterceptor[] interceptors = new[] { new DelayCreateKeyInterceptor(Mode) };

            return InstrumentClient(
                new KeyClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    TestEnvironment.Credential,
                    recording.InstrumentClientOptions(new KeyClientOptions(_serviceVersion))),
                interceptors);
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
                    await Client.StartDeleteKeyAsync(name).ConfigureAwait(false);
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
                    await Client.PurgeDeletedKeyAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterForCleanup(string name)
        {
            _keysToDelete.Enqueue(name);
        }

        protected void AssertKeyVaultKeysEqual(KeyVaultKey exp, KeyVaultKey act)
        {
            AssertKeysEqual(exp.Key, act.Key);
            AssertKeyPropertiesEqual(exp.Properties, act.Properties);
        }

        private void AssertKeysEqual(JsonWebKey exp, JsonWebKey act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.KeyType, act.KeyType);
            AssertAreEqual(exp.KeyOps, act.KeyOps);
            Assert.AreEqual(exp.CurveName, act.CurveName);
            Assert.AreEqual(exp.K, act.K);
            Assert.AreEqual(exp.N, act.N);
            Assert.AreEqual(exp.E, act.E);
            Assert.AreEqual(exp.X, act.X);
            Assert.AreEqual(exp.Y, act.Y);
            Assert.AreEqual(exp.D, act.D);
            Assert.AreEqual(exp.DP, act.DP);
            Assert.AreEqual(exp.DQ, act.DQ);
            Assert.AreEqual(exp.QI, act.QI);
            Assert.AreEqual(exp.P, act.P);
            Assert.AreEqual(exp.Q, act.Q);
            Assert.AreEqual(exp.T, act.T);
        }

        protected void AssertKeyPropertiesEqual(KeyProperties exp, KeyProperties act)
        {
            Assert.AreEqual(exp.Managed, act.Managed);
            Assert.AreEqual(exp.RecoveryLevel, act.RecoveryLevel);
            Assert.AreEqual(exp.ExpiresOn, act.ExpiresOn);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
            AssertAreEqual(exp.Tags, act.Tags);
        }

        protected static void AssertAreEqual<T>(IReadOnlyCollection<T> exp, IReadOnlyCollection<T> act)
        {
            if (exp is null && act is null)
                return;

            CollectionAssert.AreEqual(exp, act);
        }

        protected static void AssertAreEqual<TKey, TValue>(IDictionary<TKey, TValue> exp, IDictionary<TKey, TValue> act)
        {
            if (exp == null && act == null)
                return;

            if (exp?.Count != act?.Count)
                Assert.Fail("Actual count {0} does not match expected count {1}", act?.Count, exp?.Count);

            foreach (KeyValuePair<TKey, TValue> pair in exp)
            {
                if (!act.TryGetValue(pair.Key, out TValue value))
                    Assert.Fail("Actual dictionary does not contain expected key '{0}'", pair.Key);

                Assert.AreEqual(pair.Value, value);
            }
        }

        protected Task WaitForDeletedKey(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedKeyAsync(name), delay: PollingInterval);
            }
        }

        protected Task WaitForPurgedKey(string name)
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
                        await Client.GetDeletedKeyAsync(name).ConfigureAwait(false);
                        throw new InvalidOperationException($"Key {name} still exists");
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                        return (Response)null;
                    }
                }, delay: PollingInterval);
            }
        }

        protected Task WaitForKey(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetKeyAsync(name), delay: PollingInterval);
            }
        }
    }
}
