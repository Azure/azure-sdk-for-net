// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        private readonly Queue<(string Name, bool Delete)> _keysToCleanup = new Queue<(string, bool)>();

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

        [TearDown]
        public async Task Cleanup()
        {
            try
            {
                foreach ((string Name, bool Delete) cleanupItem in _keysToCleanup)
                {
                    if (cleanupItem.Delete)
                    {
                        await Client.StartDeleteKeyAsync(cleanupItem.Name);
                    }
                }

                foreach ((string Name, bool Delete) cleanupItem in _keysToCleanup)
                {
                    await WaitForDeletedKey(cleanupItem.Name);
                }

                foreach ((string Name, bool Delete) cleanupItem in _keysToCleanup)
                {
                    await Client.PurgeDeletedKeyAsync(cleanupItem.Name);
                }

                foreach ((string Name, bool Delete) cleanupItem in _keysToCleanup)
                {
                    await WaitForPurgedKey(cleanupItem.Name);
                }
            }
            finally
            {
                _keysToCleanup.Clear();
            }
        }

        protected void RegisterForCleanup(string name, bool delete = true)
        {
            _keysToCleanup.Enqueue((name, delete));
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
                        await Client.GetDeletedKeyAsync(name);
                        throw new InvalidOperationException("Key still exists");
                    }
                    catch
                    {
                        return (Response)null;
                    }
                });
            }
        }

        protected Task PollForKey(string name)
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
