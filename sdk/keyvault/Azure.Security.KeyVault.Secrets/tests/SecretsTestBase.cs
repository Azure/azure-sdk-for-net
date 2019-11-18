// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public abstract class SecretsTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        public SecretClient Client { get; set; }

        public Uri VaultUri { get; set; }

        private readonly Queue<(string Name, bool Delete)> _secretsToCleanup = new Queue<(string, bool)>();

        protected SecretsTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal SecretClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new SecretClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new DefaultAzureCredential()),
                    recording.InstrumentClientOptions(new SecretClientOptions())));
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

            foreach ((string name, bool delete) in _secretsToCleanup)
            {
                if (delete)
                {
                    cleanupTasks.Add(CleanupSecret(name));
                }

                await Task.WhenAll(cleanupTasks);
            }
        }

        protected async Task CleanupSecret(string name)
        {
            try
            {
                await Client.StartDeleteSecretAsync(name);

                await WaitForDeletedSecret(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try
            {
                await Client.PurgeDeletedSecretAsync(name);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterForCleanup(string name, bool delete = true)
        {
            _secretsToCleanup.Enqueue((name, delete));
        }

        protected void AssertSecretsEqual(KeyVaultSecret exp, KeyVaultSecret act)
        {
            Assert.AreEqual(exp.Value, act.Value);
            AssertSecretPropertiesEqual(exp.Properties, act.Properties);
        }

        protected void AssertSecretPropertiesEqual(SecretProperties exp, SecretProperties act, bool compareId = true)
        {
            if (compareId)
            {
                Assert.AreEqual(exp.Id, act.Id);
            }

            Assert.AreEqual(exp.ContentType, act.ContentType);
            Assert.AreEqual(exp.KeyId, act.KeyId);
            Assert.AreEqual(exp.Managed, act.Managed);

            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.ExpiresOn, act.ExpiresOn);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
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

        protected Task WaitForDeletedSecret(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedSecretAsync(name));
            }
        }

        protected Task WaitForPurgedSecret(string name)
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
                        await Client.GetDeletedSecretAsync(name);
                        throw new InvalidOperationException("Secret still exists");
                    }
                    catch
                    {
                        return (Response)null;
                    }
                });
            }
        }

        protected Task PollForSecret(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetSecretAsync(name));
            }
        }
    }
}
