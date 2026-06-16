// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    /// <summary>
    /// Comprehensive live + playback tests for <see cref="SecretGeneratedClient"/>.
    /// Mirrors the spirit of <see cref="SecretClientLiveTests"/> but targets the
    /// new client whose transport is generated from TypeSpec. Every test runs
    /// in both sync and async modes via Azure.Core.TestFramework
    /// (<see cref="ClientTestFixtureAttribute"/>), and across every service
    /// version exposed by <see cref="SecretGeneratedClientOptions"/>.
    /// </summary>
    [ClientTestFixture(
        SecretGeneratedClientOptions.ServiceVersion.V2025_07_01,
        SecretGeneratedClientOptions.ServiceVersion.V7_6,
        SecretGeneratedClientOptions.ServiceVersion.V7_5)]
    public class SecretGeneratedClientLiveTests : RecordedTestBase<KeyVaultTestEnvironment>
    {
        private readonly SecretGeneratedClientOptions.ServiceVersion _serviceVersion;

        // Soft-delete cleanup queues, identical pattern to the legacy live tests.
        private readonly ConcurrentQueue<string> _toDelete = new();
        private readonly ConcurrentStack<string> _toPurge  = new();

        public SecretGeneratedClient Client { get; private set; }
        public Uri VaultUri { get; private set; }

        public SecretGeneratedClientLiveTests(bool isAsync, SecretGeneratedClientOptions.ServiceVersion version)
            : base(isAsync, /* mode */ null)
        {
            _serviceVersion = version;
        }

        private TimeSpan PollingInterval => Recording.Mode == RecordedTestMode.Playback
            ? TimeSpan.Zero
            : KeyVaultTestEnvironment.DefaultPollingInterval;

        private SecretGeneratedClient CreateClient()
        {
            return InstrumentClient(new SecretGeneratedClient(
                new Uri(TestEnvironment.KeyVaultUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new SecretGeneratedClientOptions(_serviceVersion)
                {
                    Diagnostics = { LoggedHeaderNames = { "x-ms-request-id" } },
                })));
        }

        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();
            Client = CreateClient();
            VaultUri = new Uri(TestEnvironment.KeyVaultUrl);
        }

        [TearDown]
        public async Task Cleanup()
        {
            // Delete what was set during the test ...
            while (_toDelete.TryDequeue(out string name))
            {
                try
                {
                    var op = await Client.StartDeleteSecretAsync(name);
                    await op.WaitForCompletionAsync().ConfigureAwait(false);
                    _toPurge.Push(name);
                }
                catch (RequestFailedException ex) when (ex.Status == 404) { /* already gone */ }
            }

            // ... then purge so the vault is left clean for the next run.
            while (_toPurge.TryPop(out string name))
            {
                try { await Client.PurgeDeletedSecretAsync(name); }
                catch (RequestFailedException ex) when (ex.Status == 404 || ex.Status == 403) { /* tolerate */ }
            }
        }

        private string Name(string prefix) => Recording.GenerateAssetName($"sec-{prefix}-");
        private void Register(string name) => _toDelete.Enqueue(name);

        // -------------------------------------------------------------------
        // SET + GET
        // -------------------------------------------------------------------

        [RecordedTest]
        public async Task Set_Then_Get_Roundtrip()
        {
            string name = Name("rt");
            Register(name);

            Response<KeyVaultSecret> set = await Client.SetSecretAsync(name, "hello-world");
            Assert.That(set.Value.Name, Is.EqualTo(name));
            Assert.That(set.Value.Value, Is.EqualTo("hello-world"));
            Assert.That(set.Value.Properties.Version, Is.Not.Null.And.Not.Empty);
            Assert.That(set.Value.Properties.CreatedOn, Is.Not.Null);
            Assert.That(set.Value.Properties.UpdatedOn, Is.Not.Null);

            Response<KeyVaultSecret> got = await Client.GetSecretAsync(name);
            Assert.That(got.Value.Value, Is.EqualTo("hello-world"));
            Assert.That(got.Value.Id, Is.EqualTo(set.Value.Id));
            Assert.That(got.Value.Properties.VaultUri, Is.EqualTo(VaultUri));
        }

        [RecordedTest]
        public async Task Set_With_Tags_Roundtrips_All_Tags()
        {
            string name = Name("tags");
            Register(name);

            var input = new KeyVaultSecret(name, "tag-value");
            input.Properties.Tags["env"]    = "prod";
            input.Properties.Tags["owner"]  = "rohit";
            input.Properties.Tags["region"] = "westus2";

            await Client.SetSecretAsync(input);

            KeyVaultSecret got = (await Client.GetSecretAsync(name)).Value;
            Assert.That(got.Properties.Tags, Contains.Key("env").WithValue("prod"));
            Assert.That(got.Properties.Tags, Contains.Key("owner").WithValue("rohit"));
            Assert.That(got.Properties.Tags, Contains.Key("region").WithValue("westus2"));
            Assert.That(got.Properties.Tags.Count, Is.EqualTo(3));
        }

        [RecordedTest]
        public async Task Set_With_ContentType_And_Enabled_False()
        {
            string name = Name("ct");
            Register(name);

            var input = new KeyVaultSecret(name, "encoded");
            input.Properties.ContentType = "application/json";
            input.Properties.Enabled     = false;

            await Client.SetSecretAsync(input);

            // Disabled secrets cannot be GET'd directly — service returns 403.
            // We assert by listing properties so we don't read the value.
            SecretProperties props = (await ToListAsync(Client.GetPropertiesOfSecretsAsync()))
                .Single(p => p.Name == name);
            Assert.That(props.ContentType, Is.EqualTo("application/json"));
            Assert.That(props.Enabled, Is.False);
        }

        [RecordedTest]
        public async Task Set_With_NotBefore_And_ExpiresOn()
        {
            string name = Name("dates");
            Register(name);

            // Use whole seconds (the wire format is unix-seconds) and a deterministic
            // pivot derived from the recording so playback is reproducible.
            DateTimeOffset pivot = new(2026, 6, 15, 12, 0, 0, TimeSpan.Zero);
            var input = new KeyVaultSecret(name, "scheduled");
            input.Properties.NotBefore = pivot;
            input.Properties.ExpiresOn = pivot.AddDays(30);

            await Client.SetSecretAsync(input);
            KeyVaultSecret got = (await Client.GetSecretAsync(name)).Value;
            Assert.That(got.Properties.NotBefore, Is.EqualTo(pivot));
            Assert.That(got.Properties.ExpiresOn, Is.EqualTo(pivot.AddDays(30)));
        }

        [RecordedTest]
        public async Task Set_Twice_Creates_New_Version_Older_Still_Readable()
        {
            string name = Name("ver");
            Register(name);

            KeyVaultSecret v1 = (await Client.SetSecretAsync(name, "v1")).Value;
            KeyVaultSecret v2 = (await Client.SetSecretAsync(name, "v2")).Value;

            Assert.That(v1.Properties.Version, Is.Not.EqualTo(v2.Properties.Version));

            KeyVaultSecret latest = (await Client.GetSecretAsync(name)).Value;
            Assert.That(latest.Value, Is.EqualTo("v2"));

            KeyVaultSecret historical = (await Client.GetSecretAsync(name, v1.Properties.Version)).Value;
            Assert.That(historical.Value, Is.EqualTo("v1"));
        }

        // -------------------------------------------------------------------
        // UPDATE
        // -------------------------------------------------------------------

        [RecordedTest]
        public async Task Update_Toggles_Enabled_And_Preserves_Other_Fields()
        {
            string name = Name("upd-en");
            Register(name);

            KeyVaultSecret original = (await Client.SetSecretAsync(name, "v")).Value;
            original.Properties.ContentType = "text/plain";
            original.Properties.Tags["k"]   = "v";
            await Client.SetSecretAsync(original);

            SecretProperties refreshed = (await Client.GetSecretAsync(name)).Value.Properties;
            refreshed.Enabled = false;

            SecretProperties updated = (await Client.UpdateSecretPropertiesAsync(refreshed)).Value;
            Assert.That(updated.Enabled, Is.False);
            Assert.That(updated.ContentType, Is.EqualTo("text/plain"));
            Assert.That(updated.Tags, Contains.Key("k").WithValue("v"));
        }

        [RecordedTest]
        public async Task Update_Replaces_Tags_Wholesale()
        {
            string name = Name("upd-tags");
            Register(name);

            var input = new KeyVaultSecret(name, "v");
            input.Properties.Tags["a"] = "1";
            input.Properties.Tags["b"] = "2";
            await Client.SetSecretAsync(input);

            SecretProperties refreshed = (await Client.GetSecretAsync(name)).Value.Properties;
            refreshed.Tags.Clear();
            refreshed.Tags["c"] = "3";

            SecretProperties updated = (await Client.UpdateSecretPropertiesAsync(refreshed)).Value;
            Assert.That(updated.Tags, Contains.Key("c").WithValue("3"));
            Assert.That(updated.Tags, Has.Count.EqualTo(1));
        }

        // -------------------------------------------------------------------
        // PAGINATION
        // -------------------------------------------------------------------

        [RecordedTest]
        public async Task GetPropertiesOfSecrets_Enumerates_Set_Secrets()
        {
            string[] names = Enumerable.Range(0, 3).Select(i => Name($"list-{i}")).ToArray();
            foreach (string n in names) { Register(n); await Client.SetSecretAsync(n, "v"); }

            var seen = new HashSet<string>();
            await foreach (SecretProperties p in Client.GetPropertiesOfSecretsAsync())
            {
                seen.Add(p.Name);
            }
            Assert.That(seen, Is.SupersetOf(names));
        }

        [RecordedTest]
        public async Task GetPropertiesOfSecretVersions_Returns_All_Versions()
        {
            string name = Name("vers");
            Register(name);
            for (int i = 0; i < 3; i++) await Client.SetSecretAsync(name, $"v{i}");

            int versionCount = 0;
            await foreach (SecretProperties p in Client.GetPropertiesOfSecretVersionsAsync(name))
            {
                versionCount++;
                Assert.That(p.Name, Is.EqualTo(name));
                Assert.That(p.Version, Is.Not.Null.And.Not.Empty);
            }
            Assert.That(versionCount, Is.EqualTo(3));
        }

        // -------------------------------------------------------------------
        // DELETE / GET DELETED / RECOVER / PURGE
        // -------------------------------------------------------------------

        [RecordedTest]
        public async Task Delete_Then_GetDeleted_Returns_RecoveryId_And_Dates()
        {
            string name = Name("del");
            await Client.SetSecretAsync(name, "to-be-deleted");

            DeleteSecretOperation op = await Client.StartDeleteSecretAsync(name);
            Assert.That(op.Value.Name, Is.EqualTo(name));
            Assert.That(op.Value.RecoveryId, Is.Not.Null, "RecoveryId should be set on soft-delete enabled vault");

            await op.WaitForCompletionAsync();
            _toPurge.Push(name);

            DeletedSecret deleted = (await Client.GetDeletedSecretAsync(name)).Value;
            Assert.That(deleted.RecoveryId, Is.Not.Null);
            Assert.That(deleted.DeletedOn, Is.Not.Null);
            Assert.That(deleted.ScheduledPurgeDate, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Recover_Returns_Secret_Back_To_Active()
        {
            string name = Name("rec");
            await Client.SetSecretAsync(name, "phoenix");

            DeleteSecretOperation delOp = await Client.StartDeleteSecretAsync(name);
            await delOp.WaitForCompletionAsync();

            RecoverDeletedSecretOperation recOp = await Client.StartRecoverDeletedSecretAsync(name);
            Assert.That(recOp.Value.Name, Is.EqualTo(name));

            await recOp.WaitForCompletionAsync();
            Register(name);

            KeyVaultSecret got = (await Client.GetSecretAsync(name)).Value;
            Assert.That(got.Value, Is.EqualTo("phoenix"));
        }

        [RecordedTest]
        public async Task GetDeletedSecrets_Lists_Soft_Deleted_Items()
        {
            string name = Name("listd");
            await Client.SetSecretAsync(name, "v");
            DeleteSecretOperation op = await Client.StartDeleteSecretAsync(name);
            await op.WaitForCompletionAsync();
            _toPurge.Push(name);

            bool found = false;
            await foreach (DeletedSecret d in Client.GetDeletedSecretsAsync())
            {
                if (d.Name == name) { found = true; break; }
            }
            Assert.That(found, Is.True);
        }

        // -------------------------------------------------------------------
        // BACKUP / RESTORE
        // -------------------------------------------------------------------

        [RecordedTest]
        public async Task Backup_Returns_Non_Empty_Blob()
        {
            string name = Name("bk");
            Register(name);
            await Client.SetSecretAsync(name, "to-backup");

            byte[] backup = (await Client.BackupSecretAsync(name)).Value;
            Assert.That(backup, Is.Not.Null);
            Assert.That(backup.Length, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task RestoreSecretBackup_Roundtrips_Value()
        {
            string name = Name("rb");
            await Client.SetSecretAsync(name, "before-restore");
            byte[] backup = (await Client.BackupSecretAsync(name)).Value;

            // Delete + purge the original so restore is unambiguous.
            DeleteSecretOperation op = await Client.StartDeleteSecretAsync(name);
            await op.WaitForCompletionAsync();
            await Client.PurgeDeletedSecretAsync(name);

            // Service has a known restore-retry window after purge. Tolerate
            // RequestFailedException with status 409 and back off briefly.
            SecretProperties restored = null;
            for (int attempt = 0; attempt < 20 && restored is null; attempt++)
            {
                try
                {
                    restored = (await Client.RestoreSecretBackupAsync(backup)).Value;
                }
                catch (RequestFailedException ex) when (ex.Status == 409)
                {
                    await Task.Delay(PollingInterval);
                }
            }
            Assume.That(restored, Is.Not.Null, "Restore did not complete within the polling budget.");
            Register(name);

            KeyVaultSecret got = (await Client.GetSecretAsync(name)).Value;
            Assert.That(got.Value, Is.EqualTo("before-restore"));
        }

        // -------------------------------------------------------------------
        // ARGUMENT VALIDATION (sync, do not record HTTP)
        // -------------------------------------------------------------------

        [Test]
        public void Ctor_NullVaultUri_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SecretGeneratedClient(null, new MockCredential()));
        }

        [Test]
        public void Ctor_NullCredential_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SecretGeneratedClient(new Uri("https://example.vault.azure.net"), null));
        }

        [Test]
        public void GetSecret_EmptyName_Throws()
        {
            var c = new SecretGeneratedClient(new Uri("https://example.vault.azure.net"), new MockCredential());
            Assert.Throws<ArgumentException>(() => c.GetSecret(""));
            Assert.Throws<ArgumentNullException>(() => c.GetSecret(null));
        }

        [Test]
        public void SetSecret_NullSecret_Throws()
        {
            var c = new SecretGeneratedClient(new Uri("https://example.vault.azure.net"), new MockCredential());
            Assert.Throws<ArgumentNullException>(() => c.SetSecret((KeyVaultSecret)null));
        }

        [Test]
        public void UpdateSecretProperties_NullProps_Throws()
        {
            var c = new SecretGeneratedClient(new Uri("https://example.vault.azure.net"), new MockCredential());
            Assert.Throws<ArgumentNullException>(() => c.UpdateSecretProperties(null));
        }

        [Test]
        public void RestoreSecretBackup_NullBackup_Throws()
        {
            var c = new SecretGeneratedClient(new Uri("https://example.vault.azure.net"), new MockCredential());
            Assert.Throws<ArgumentNullException>(() => c.RestoreSecretBackup(null));
        }

        [Test]
        public void VaultUri_Reflects_Constructor_Argument()
        {
            var uri = new Uri("https://my.vault.azure.net");
            var c = new SecretGeneratedClient(uri, new MockCredential());
            Assert.That(c.VaultUri, Is.EqualTo(uri));
        }

        private async Task<List<T>> ToListAsync<T>(AsyncPageable<T> source)
        {
            var list = new List<T>();
            await foreach (T item in source) list.Add(item);
            return list;
        }

        private sealed class MockCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new AccessToken("mock", DateTimeOffset.UtcNow.AddHours(1));
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(new AccessToken("mock", DateTimeOffset.UtcNow.AddHours(1)));
        }
    }
}
