// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    [ClientTestFixture(
        SecretClientOptions.ServiceVersion.V7_5,
        SecretClientOptions.ServiceVersion.V7_4,
        SecretClientOptions.ServiceVersion.V7_3,
        SecretClientOptions.ServiceVersion.V7_2,
        SecretClientOptions.ServiceVersion.V7_1,
        SecretClientOptions.ServiceVersion.V7_0,
        SecretClientOptions.ServiceVersion.V7_6)]
    public abstract class SecretsTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        protected TimeSpan PollingInterval => Recording.Mode == RecordedTestMode.Playback
            ? TimeSpan.Zero
            : KeyVaultTestEnvironment.DefaultPollingInterval;

        private readonly SecretClientOptions.ServiceVersion _serviceVersion;

        public SecretClient Client { get; set; }

        public Uri VaultUri { get; set; }

        // Queue deletes, but poll on the top of the purge stack to increase likelihood of others being purged by then.
        private readonly ConcurrentQueue<string> _secretsToDelete = new ConcurrentQueue<string>();
        private readonly ConcurrentStack<string> _secretsToPurge = new ConcurrentStack<string>();

        private KeyVaultTestEventListener _listener;

        protected SecretsTestBase(bool isAsync, SecretClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            _serviceVersion = serviceVersion;
        }

        internal SecretClient GetClient(TokenCredential credential = default)
        {
            return InstrumentClient
                (new SecretClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    credential ?? TestEnvironment.Credential,
                    InstrumentClientOptions(
                        new SecretClientOptions(_serviceVersion)
                        {
                            Diagnostics =
                            {
                                LoggedHeaderNames =
                                {
                                    "x-ms-request-id",
                                }
                            },
                        })));
        }

        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            _listener = new KeyVaultTestEventListener();

            Client = GetClient();
            VaultUri = new Uri(TestEnvironment.KeyVaultUrl);
        }

        public override async Task StopTestRecordingAsync()
        {
            _listener?.Dispose();

            await base.StopTestRecordingAsync();
        }

        [TearDown]
        public async Task Cleanup()
        {
            // Start deleting resources as soon as possible.
            while (_secretsToDelete.TryDequeue(out string name))
            {
                await DeleteSecret(name);

                _secretsToPurge.Push(name);
            }
        }

        [OneTimeTearDown]
        public async Task CleanupAll()
        {
            // Make sure the delete queue is empty.
            await Cleanup();

            while (_secretsToPurge.TryPop(out string name))
            {
                await PurgeSecret(name).ConfigureAwait(false);
            }
        }

        protected async Task DeleteSecret(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.StartDeleteSecretAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected async Task PurgeSecret(string name)
        {
            try
            {
                await WaitForDeletedSecret(name).ConfigureAwait(false);
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
                    await Client.PurgeDeletedSecretAsync(name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterForCleanup(string name)
        {
            _secretsToDelete.Enqueue(name);
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
                return TestRetryHelper.RetryAsync(async () => {
                    try
                    {
                        return await Client.GetDeletedSecretAsync(name).ConfigureAwait(false);
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                        throw new InconclusiveException($"Timed out while waiting for secret '{name}' to be deleted");
                    }
                }, delay: PollingInterval);
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
                        await Client.GetDeletedSecretAsync(name).ConfigureAwait(false);
                        throw new InvalidOperationException($"Secret {name} still exists");
                    }
                    catch (RequestFailedException ex) when (ex.Status == 404)
                    {
                        return (Response)null;
                    }
                }, delay: PollingInterval);
            }
        }

        protected Task WaitForSecret(string name)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Task.CompletedTask;
            }

            using (Recording.DisableRecording())
            {
                return TestRetryHelper.RetryAsync(async () => await Client.GetSecretAsync(name).ConfigureAwait(false), delay: PollingInterval);
            }
        }

        protected TokenCredential GetCredential(string tenantId)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new MockCredential();
            }

            return string.IsNullOrEmpty(TestEnvironment.ClientSecret)
                ? new AzurePowerShellCredential(
                    new AzurePowerShellCredentialOptions()
                    {
                        AuthorityHost = new Uri(TestEnvironment.AuthorityHostUrl),
                        AdditionallyAllowedTenants = { TestEnvironment.TenantId },
                    })
                : new ClientSecretCredential(
                    tenantId ?? TestEnvironment.TenantId,
                    TestEnvironment.ClientId,
                    TestEnvironment.ClientSecret,
                    new ClientSecretCredentialOptions()
                    {
                        AuthorityHost = new Uri(TestEnvironment.AuthorityHostUrl),
                        AdditionallyAllowedTenants = { TestEnvironment.TenantId },
                    });
        }
    }
}
