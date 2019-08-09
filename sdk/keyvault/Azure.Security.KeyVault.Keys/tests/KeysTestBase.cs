// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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

        private readonly Queue<(KeyBase Key, bool Delete)> _keysToCleanup = new Queue<(KeyBase, bool)>();

        protected KeysTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal KeyClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

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
                foreach (var cleanupItem in _keysToCleanup)
                {
                    if (cleanupItem.Delete)
                    {
                        await Client.DeleteKeyAsync(cleanupItem.Key.Name);
                    }
                }

                foreach (var cleanupItem in _keysToCleanup)
                {
                    await WaitForDeletedKey(cleanupItem.Key.Name);
                }

                foreach (var cleanupItem in _keysToCleanup)
                {
                    await Client.PurgeDeletedKeyAsync(cleanupItem.Key.Name);
                }

                foreach (var cleanupItem in _keysToCleanup)
                {
                    await WaitForPurgedKey(cleanupItem.Key.Name);
                }
            }
            finally
            {
                _keysToCleanup.Clear();
            }
        }

        protected void RegisterForCleanup(KeyBase key, bool delete = true)
        {
            _keysToCleanup.Enqueue((key, delete));
        }

        protected void AssertKeysEqual(Key exp, Key act)
        {
            AssertKeyMaterialEqual(exp.KeyMaterial, act.KeyMaterial);
            AssertKeysEqual((KeyBase)exp, (KeyBase)act);
        }

        private void AssertKeyMaterialEqual(JsonWebKey exp, JsonWebKey act)
        {
            Assert.AreEqual(exp.KeyId, act.KeyId);
            Assert.AreEqual(exp.KeyType, act.KeyType);
            Assert.IsTrue(AreEqual(exp.KeyOps, act.KeyOps));
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

        protected void AssertKeysEqual(KeyBase exp, KeyBase act)
        {
            Assert.AreEqual(exp.Managed, act.Managed);
            Assert.AreEqual(exp.RecoveryLevel, act.RecoveryLevel);
            Assert.AreEqual(exp.Expires, act.Expires);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
            Assert.IsTrue(AreEqual(exp.Tags, act.Tags));
        }

        private static bool AreEqual(IList<KeyOperations> exp, IList<KeyOperations> act)
        {
            if (exp == null && act == null)
                return true;

            if (exp.Count != act.Count)
                return false;

            for (var i = 0; i < exp.Count; ++i)
                if (exp[i] != act[i])
                    return false;

            return true;
        }

        private static bool AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp == null && act == null)
                return true;

            if (exp?.Count != act?.Count)
                return false;

            foreach (var pair in exp)
            {
                if (!act.TryGetValue(pair.Key, out string value)) return false;
                if (!string.Equals(value, pair.Value)) return false;
            }
            return true;
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