// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public abstract class KeyVaultTestBase : RecordedTestBase
    {
        public const string AzureKeyVaultUrlEnvironmentVariable = "AZURE_KEYVAULT_URL";

        public SecretClient Client { get; set; }

        public Uri VaultUri { get; set; }

        private readonly Queue<(string Name, bool Delete)> _secretsToCleanup = new Queue<(string, bool)>();

        protected KeyVaultTestBase(bool isAsync) : base(isAsync)
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

        [TearDown]
        public async Task Cleanup()
        {
            try
            {
                foreach ((string Name, bool Delete) cleanupItem in _secretsToCleanup)
                {
                    if (cleanupItem.Delete)
                    {
                        await Client.DeleteSecretAsync(cleanupItem.Name);
                    }
                }

                foreach ((string Name, bool Delete) cleanupItem in _secretsToCleanup)
                {
                    await WaitForDeletedSecret(cleanupItem.Name);
                }

                foreach ((string Name, bool Delete) cleanupItem in _secretsToCleanup)
                {
                    await Client.PurgeDeletedSecretAsync(cleanupItem.Name);
                }

                foreach ((string Name, bool Delete) cleanupItem in _secretsToCleanup)
                {
                    await WaitForPurgedSecret(cleanupItem.Name);
                }
            }
            finally
            {
                _secretsToCleanup.Clear();
            }
        }

        protected void RegisterForCleanup(string name, bool delete = true)
        {
            _secretsToCleanup.Enqueue((name, delete));
        }

        protected void AssertSecretsEqual(Secret exp, Secret act)
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
            Assert.AreEqual(exp.Expires, act.Expires);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
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
