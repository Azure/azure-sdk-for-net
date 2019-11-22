// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public abstract class KeysTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        public KeyClient Client { get; set; }

        public Uri VaultUri { get; set; }

        private readonly ConcurrentQueue<string> _keysToCleanup = new ConcurrentQueue<string>();

        protected KeysTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal KeyClient GetClient(TestRecording recording = null)
        {
            recording = recording ?? Recording;

            return InstrumentClient
                (new KeyClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(new KeyClientOptions())));
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            Client = GetClient();
            VaultUri = new Uri(Recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable));
        }

        [OneTimeTearDown]
        public async Task Cleanup()
        {
            List<Task> cleanupTasks = new List<Task>();

            foreach (string name in _keysToCleanup)
            {
                cleanupTasks.Add(CleanupKey(name));
            }

            await Task.WhenAll(cleanupTasks);
        }

        protected async Task CleanupKey(string name)
        {
            try
            {
                await Client.StartDeleteKeyAsync(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try
            {
                await WaitForDeletedKey(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try
            {
                await Client.PurgeDeletedKeyAsync(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterForCleanup(string name)
        {
            _keysToCleanup.Enqueue(name);
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedKeyAsync(name));
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
                });
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetKeyAsync(name));
            }
        }
    }
}
