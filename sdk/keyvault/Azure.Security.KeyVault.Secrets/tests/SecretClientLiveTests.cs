// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework.Constraints;
using Azure.Core.Tests;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class SecretClientLiveTests : SecretsTestBase
    {
        private const int PagedSecretCount = 50;

        public SecretClientLiveTests(bool isAsync, SecretClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.ClearCache();
            }
        }

        [RecordedTest]
        public async Task SetSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret version1 = await Client.SetSecretAsync(secretName, "value1");
            RegisterForCleanup(version1.Name);
            KeyVaultSecret version2 = await Client.SetSecretAsync(secretName, "value2");
            await Client.SetSecretAsync(secretName, "value3");

            KeyVaultSecret secret = await Client.GetSecretAsync(secretName, version2.Properties.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [RecordedTest]
        public async Task SetSecretWithExtendedProps()
        {
            string secretName = Recording.GenerateId();

            // TODO: Update this value whenever you re-record tests. Both the sync and async JSON recordings need to use the same value.
            IResolveConstraint createdUpdatedConstraint = Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1648054293));

            KeyVaultSecret setResult = null;

            try
            {
                var exp = new DateTimeOffset(new DateTime(637027248120000000, DateTimeKind.Utc));
                DateTimeOffset nbf = exp.AddDays(-30);

                var secret = new KeyVaultSecret(secretName, "CrudWithExtendedPropsValue1")
                {
                    Properties =
                    {
                        ContentType = "password",
                        NotBefore = nbf,
                        ExpiresOn = exp,
                        Tags =
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                    },
                };

                setResult = await Client.SetSecretAsync(secret);
                if (Mode != RecordedTestMode.Playback)
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    createdUpdatedConstraint = Is.InRange(now.AddMinutes(-5), now.AddMinutes(5));
                }

                RegisterForCleanup(secret.Name);

                Assert.IsNotEmpty(setResult.Properties.Version);
                Assert.AreEqual("password", setResult.Properties.ContentType);
                Assert.AreEqual(nbf, setResult.Properties.NotBefore);
                Assert.AreEqual(exp, setResult.Properties.ExpiresOn);
                Assert.AreEqual(2, setResult.Properties.Tags.Count);
                Assert.AreEqual("value1", setResult.Properties.Tags["tag1"]);
                Assert.AreEqual("value2", setResult.Properties.Tags["tag2"]);
                Assert.AreEqual(secretName, setResult.Name);
                Assert.AreEqual("CrudWithExtendedPropsValue1", setResult.Value);
                Assert.AreEqual(VaultUri, setResult.Properties.VaultUri);
                Assert.IsNotNull(setResult.Properties.RecoveryLevel); // Value changes based on how the Key Vault is configured.
                Assert.That(setResult.Properties.CreatedOn, Is.Not.Null);
                Assert.That(setResult.Properties.UpdatedOn, Is.Not.Null);

                KeyVaultSecret getResult = await Client.GetSecretAsync(secretName);

                AssertSecretsEqual(setResult, getResult);
            }
            finally
            {
                DeleteSecretOperation deleteOperation = await Client.StartDeleteSecretAsync(secretName);
                DeletedSecret deleteResult = deleteOperation.Value;

                AssertSecretPropertiesEqual(setResult.Properties, deleteResult.Properties);
            }
        }

        [RecordedTest]
        public async Task UpdateEnabled()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret.Name);

            secret.Properties.Enabled = false;

            SecretProperties updateResult = await Client.UpdateSecretPropertiesAsync(secret.Properties);

            AssertSecretPropertiesEqual(secret.Properties, updateResult);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetSecretAsync(secretName));

            secret.Properties.Enabled = true;

            await Client.UpdateSecretPropertiesAsync(secret.Properties);
        }

        [RecordedTest]
        public async Task UpdateSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret.Name);

            secret.Properties.ExpiresOn = secret.Properties.CreatedOn;

            SecretProperties updateResult = await Client.UpdateSecretPropertiesAsync(secret.Properties);

            AssertSecretPropertiesEqual(secret.Properties, updateResult);
        }

        [RecordedTest]
        public async Task UpdateTags()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = new KeyVaultSecret(secretName, "test")
            {
                Properties =
                {
                    Tags =
                    {
                        ["A"] = "1",
                        ["B"] = "2",
                    },
                },
            };

            secret = await Client.SetSecretAsync(secret);
            RegisterForCleanup(secret.Name);

            IDictionary<string, string> expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "2",
            };

            AssertAreEqual(expectedTags, secret.Properties.Tags);

            secret.Properties.Tags["B"] = "3";
            secret.Properties.Tags["C"] = "4";

            SecretProperties updateResult = await Client.UpdateSecretPropertiesAsync(secret.Properties);

            expectedTags = new Dictionary<string, string>
            {
                ["A"] = "1",
                ["B"] = "3",
                ["C"] = "4",
            };

            AssertAreEqual(expectedTags, updateResult.Tags);

            updateResult.Tags.Clear();
            updateResult.Tags["D"] = "5";

            updateResult = await Client.UpdateSecretPropertiesAsync(updateResult);

            expectedTags = new Dictionary<string, string>
            {
                ["D"] = "5",
            };

            AssertAreEqual(expectedTags, updateResult.Tags);
        }

        [RecordedTest]
        public async Task GetSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret setSecret = await Client.SetSecretAsync(secretName, "value");
            RegisterForCleanup(setSecret.Name);

            KeyVaultSecret secret = await Client.GetSecretAsync(secretName);

            AssertSecretsEqual(setSecret, secret);
        }

        [RecordedTest]
        public async Task GetSecretWithVersion()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret version1 = await Client.SetSecretAsync(secretName, "value1");
            RegisterForCleanup(version1.Name);
            KeyVaultSecret version2 = await Client.SetSecretAsync(secretName, "value2");
            await Client.SetSecretAsync(secretName, "value3");

            KeyVaultSecret secret = await Client.GetSecretAsync(secretName, version2.Properties.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [RecordedTest]
        public async Task GetSecretVersionsNonExisting()
        {
            List<SecretProperties> allSecrets = await Client.GetPropertiesOfSecretVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();

            Assert.AreEqual(0, allSecrets.Count);
        }

        [RecordedTest]
        public async Task BackupSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "BackupRestore");

            RegisterForCleanup(secret.Name);

            byte[] backup = await Client.BackupSecretAsync(secretName);

            Assert.NotNull(backup);
        }

        [RecordedTest]
        public void BackupSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.BackupSecretAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public async Task RestoreSecretBackup()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "BackupRestore");

            RegisterForCleanup(secret.Name);

            byte[] backup = await Client.BackupSecretAsync(secretName);

            await Client.StartDeleteSecretAsync(secretName);
            await WaitForDeletedSecret(secretName);

            await Client.PurgeDeletedSecretAsync(secretName);
            await WaitForPurgedSecret(secretName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetSecretAsync(secretName));
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedSecretAsync(secretName));

            SecretProperties restoreResult = await Client.RestoreSecretBackupAsync(backup);

            AssertSecretPropertiesEqual(secret.Properties, restoreResult);
        }

        [RecordedTest]
        public void RestoreMalformedBackup()
        {
            byte[] backupMalformed = Encoding.ASCII.GetBytes("non-existing");
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RestoreSecretBackupAsync(backupMalformed));
        }

        [RecordedTest]
        public async Task StartDeleteSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "value");

            RegisterForCleanup(secret.Name);

            DeleteSecretOperation deleteOperation = await Client.StartDeleteSecretAsync(secretName);
            DeletedSecret deletedSecret = deleteOperation.Value;

            AssertSecretPropertiesEqual(secret.Properties, deletedSecret.Properties);
            Assert.NotNull(deletedSecret.DeletedOn);
            Assert.NotNull(deletedSecret.ScheduledPurgeDate);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetSecretAsync(secretName));
        }

        [RecordedTest]
        public void StartDeleteSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartDeleteSecretAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task GetDeletedSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "value");

            RegisterForCleanup(secret.Name);

            DeleteSecretOperation deleteOperation = await Client.StartDeleteSecretAsync(secretName);
            DeletedSecret deletedSecret = deleteOperation.Value;

            await WaitForDeletedSecret(secretName);

            DeletedSecret polledSecret = await Client.GetDeletedSecretAsync(secretName);

            Assert.NotNull(deletedSecret.DeletedOn);
            Assert.NotNull(deletedSecret.RecoveryId);
            Assert.NotNull(deletedSecret.ScheduledPurgeDate);

            AssertSecretPropertiesEqual(deletedSecret.Properties, polledSecret.Properties);
            AssertSecretPropertiesEqual(secret.Properties, polledSecret.Properties);
        }

        [RecordedTest]
        public void GetDeletedSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedSecretAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task StartRecoverDeletedSecret()
        {
            string secretName = Recording.GenerateId();

            KeyVaultSecret secret = await Client.SetSecretAsync(secretName, "value");

            RegisterForCleanup(secret.Name);

            DeleteSecretOperation deleteOperation = await Client.StartDeleteSecretAsync(secretName);
            DeletedSecret deletedSecret = deleteOperation.Value;

            await WaitForDeletedSecret(secretName);

            RecoverDeletedSecretOperation operation = await Client.StartRecoverDeletedSecretAsync(secretName);
            SecretProperties recoverSecretResult = operation.Value;

            await operation.WaitForCompletionAsync(); ;

            KeyVaultSecret recoveredSecret = await Client.GetSecretAsync(secretName);

            AssertSecretPropertiesEqual(secret.Properties, deletedSecret.Properties);
            AssertSecretPropertiesEqual(secret.Properties, recoverSecretResult);
            AssertSecretsEqual(secret, recoveredSecret);
        }

        [RecordedTest]
        public void StartRecoverDeletedSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.StartRecoverDeletedSecretAsync(Recording.GenerateId()));
        }

        [RecordedTest]
        public async Task GetPropertiesOfSecrets()
        {
            string secretName = Recording.GenerateId();

            List<KeyVaultSecret> createdSecrets = new List<KeyVaultSecret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                KeyVaultSecret secret = await Client.SetSecretAsync(secretName + i, i.ToString());
                createdSecrets.Add(secret);
                RegisterForCleanup(secret.Name);
            }

            List<SecretProperties> allSecrets = await Client.GetPropertiesOfSecretsAsync().ToEnumerableAsync();

            foreach (KeyVaultSecret createdSecret in createdSecrets)
            {
                SecretProperties returnedSecret = allSecrets.Single(s => s.Name == createdSecret.Name);
                AssertSecretPropertiesEqual(createdSecret.Properties, returnedSecret, compareId: false);
            }
        }

        [RecordedTest]
        public async Task GetPropertiesOfSecretVersions()
        {
            string secretName = Recording.GenerateId();

            List<KeyVaultSecret> createdSecrets = new List<KeyVaultSecret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                KeyVaultSecret secret = await Client.SetSecretAsync(secretName, i.ToString());
                createdSecrets.Add(secret);
            }

            RegisterForCleanup(createdSecrets.First().Name);

            List<SecretProperties> allSecrets = await Client.GetPropertiesOfSecretVersionsAsync(secretName).ToEnumerableAsync();

            foreach (KeyVaultSecret createdSecret in createdSecrets)
            {
                SecretProperties returnedSecret = allSecrets.Single(s => s.Id == createdSecret.Id);
                AssertSecretPropertiesEqual(createdSecret.Properties, returnedSecret);
            }
        }

        [RecordedTest]
        public async Task GetDeletedSecrets()
        {
            string secretName = Recording.GenerateId();

            List<KeyVaultSecret> deletedSecrets = new List<KeyVaultSecret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                KeyVaultSecret secret = await Client.SetSecretAsync(secretName + i, i.ToString());
                RegisterForCleanup(secret.Name);

                deletedSecrets.Add(secret);
                await TestRetryHelper.RetryAsync(async () =>
                {
                    // Try a few times since it sometimes fails when trying to delete right away.
                    return await Client.StartDeleteSecretAsync(secret.Name);
                }, maxIterations: 3);
            }

            List<Task> deletingSecrets = new List<Task>();
            foreach (KeyVaultSecret deletedSecret in deletedSecrets)
            {
                // WaitForDeletedSecret disables recording, so we can wait concurrently.
                deletingSecrets.Add(WaitForDeletedSecret(deletedSecret.Name));
            }

            await Task.WhenAll(deletingSecrets);

            List<DeletedSecret> allSecrets = await Client.GetDeletedSecretsAsync().ToEnumerableAsync();
            foreach (KeyVaultSecret deletedSecret in deletedSecrets)
            {
                KeyVaultSecret returnedSecret = allSecrets.Single(s => s.Name == deletedSecret.Name);
                AssertSecretPropertiesEqual(deletedSecret.Properties, returnedSecret.Properties, compareId: false);
            }
        }

        [RecordedTest]
        public async Task AuthenticateCrossTenant()
        {
            TokenCredential credential = GetCredential(Recording.Random.NewGuid().ToString());
            SecretClient client = GetClient(credential);

            string secretName = Recording.GenerateId();

            Response<KeyVaultSecret> response = await client.SetSecretAsync(secretName, "secret");
            RegisterForCleanup(secretName);

            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [RecordedTest]
        public async Task GetNonExistentSecretNoThrow()
        {
            ClientDiagnosticListener trace = new ClientDiagnosticListener(name => name.StartsWith("Azure."), IsAsync);
            try
            {
                NullableResponse<KeyVaultSecret> response = await Client.GetSecretIfExistsAsync("ShouldNotExist");

                Assert.AreEqual(404, response.GetRawResponse().Status);
                Assert.IsFalse(response.HasValue);
                Assert.Throws<InvalidOperationException>(() => { var _ = response.Value; });
            }
            finally
            {
                // Unregister listener before enumerating scopes.
                trace.Dispose();

                var scope = trace.AssertScope($"{nameof(SecretClient)}.{nameof(SecretClient.GetSecretIfExists)}");
                Assert.IsFalse(scope.IsFailed);
            }
        }
    }
}
