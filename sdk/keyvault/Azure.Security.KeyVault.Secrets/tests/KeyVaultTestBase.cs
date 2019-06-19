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

        private readonly Queue<(SecretBase Secret, bool Delete)> _secretsToCleanup = new Queue<(SecretBase, bool)>();

        protected KeyVaultTestBase(bool isAsync) : base(isAsync)
        {
        }

        internal SecretClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new SecretClient(
                    new Uri(recording.GetVariableFromEnvironment(AzureKeyVaultUrlEnvironmentVariable)),
                    recording.GetCredential(new SystemCredential()),
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
                foreach (var cleanupItem in _secretsToCleanup)
                {
                    if (cleanupItem.Delete)
                    {
                        await Client.DeleteAsync(cleanupItem.Secret.Name);
                    }
                }

                foreach (var cleanupItem in _secretsToCleanup)
                {
                    await WaitForDeletedSecret(cleanupItem.Secret.Name);
                }

                foreach (var cleanupItem in _secretsToCleanup)
                {
                    await Client.PurgeDeletedAsync(cleanupItem.Secret.Name);
                }

                foreach (var cleanupItem in _secretsToCleanup)
                {
                    await WaitForPurgedSecret(cleanupItem.Secret.Name);
                }
            }
            finally
            {
                _secretsToCleanup.Clear();
            }
        }

        protected void RegisterForCleanup(SecretBase secret, bool delete = true)
        {
            _secretsToCleanup.Enqueue((secret, delete));
        }

        protected void AssertSecretsEqual(Secret exp, Secret act)
        {
            Assert.AreEqual(exp.Value, act.Value);
            AssertSecretsEqual((SecretBase)exp, (SecretBase)act);
        }

        protected void AssertSecretsEqual(SecretBase exp, SecretBase act, bool compareId = true)
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetDeletedAsync(name));
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
                        await Client.GetDeletedAsync(name);
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
                return TestRetryHelper.RetryAsync(async () => await Client.GetAsync(name));
            }
        }
    }
}