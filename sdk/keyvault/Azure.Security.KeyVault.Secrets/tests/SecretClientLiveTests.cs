// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Security.KeyVault.Secrets;
using Azure.Core.Testing;
using System.Text;
using NUnit.Framework.Constraints;

namespace Azure.Security.KeyVault.Test
{
    public class SecretClientLiveTests : KeyVaultTestBase
    {
        private const int PagedSecretCount = 50;

        public SecretClientLiveTests(bool isAsync) : base(isAsync)
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

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [Test]
        public async Task SetSecret()
        {
            string secretName = Recording.GenerateId();

            Secret version1 = await Client.SetAsync(secretName, "value1");
            RegisterForCleanup(version1.Name);
            Secret version2 = await Client.SetAsync(secretName, "value2");
            await Client.SetAsync(secretName, "value3");

            Secret secret = await Client.GetAsync(secretName, version2.Properties.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [Test]
        public async Task SetSecretWithExtendedProps()
        {
            string secretName = Recording.GenerateId();
            IResolveConstraint createdUpdatedConstraint = Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1565114301));

            Secret setResult = null;

            try
            {
                var exp = new DateTimeOffset(new DateTime(637027248120000000, DateTimeKind.Utc));
                DateTimeOffset nbf = exp.AddDays(-30);

                var secret = new Secret(secretName, "CrudWithExtendedPropsValue1")
                {
                    Properties =
                    {
                        ContentType = "password",
                        NotBefore = nbf,
                        Expires = exp,
                        Tags =
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                    },
                };

                setResult = await Client.SetAsync(secret);
                if (Mode != RecordedTestMode.Playback)
                {
                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    createdUpdatedConstraint = Is.InRange(now.AddMinutes(-5), now.AddMinutes(5));
                }

                RegisterForCleanup(secret.Name, delete: false);

                Assert.IsNotEmpty(setResult.Properties.Version);
                Assert.AreEqual("password", setResult.Properties.ContentType);
                Assert.AreEqual(nbf, setResult.Properties.NotBefore);
                Assert.AreEqual(exp, setResult.Properties.Expires);
                Assert.AreEqual(2, setResult.Properties.Tags.Count);
                Assert.AreEqual("value1", setResult.Properties.Tags["tag1"]);
                Assert.AreEqual("value2", setResult.Properties.Tags["tag2"]);
                Assert.AreEqual(secretName, setResult.Name);
                Assert.AreEqual("CrudWithExtendedPropsValue1", setResult.Value);
                Assert.AreEqual(VaultUri, setResult.Properties.VaultUri);
                Assert.AreEqual("Recoverable+Purgeable", setResult.Properties.RecoveryLevel);
                Assert.That(setResult.Properties.Created, createdUpdatedConstraint);
                Assert.That(setResult.Properties.Updated, createdUpdatedConstraint);

                Secret getResult = await Client.GetAsync(secretName);

                AssertSecretsEqual(setResult, getResult);
            }
            finally
            {
                DeletedSecret deleteResult = await Client.DeleteAsync(secretName);

                AssertSecretPropertiesEqual(setResult.Properties, deleteResult.Properties);
            }
        }

        [Test]
        public async Task UpdateEnabled()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret.Name);

            secret.Properties.Enabled = false;

            SecretProperties updateResult = await Client.UpdatePropertiesAsync(secret.Properties);

            AssertSecretPropertiesEqual(secret.Properties, updateResult);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetAsync(secretName));

            secret.Properties.Enabled = true;

            await Client.UpdatePropertiesAsync(secret.Properties);
        }

        [Test]
        public async Task UpdateSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret.Name);

            secret.Properties.Expires = secret.Properties.Created;

            SecretProperties updateResult = await Client.UpdatePropertiesAsync(secret.Properties);

            AssertSecretPropertiesEqual(secret.Properties, updateResult);
        }

        [Test]
        public async Task GetSecret()
        {
            string secretName = Recording.GenerateId();

            Secret setSecret = await Client.SetAsync(secretName, "value");
            RegisterForCleanup(setSecret.Name);

            Secret secret = await Client.GetAsync(secretName);

            AssertSecretsEqual(setSecret, secret);
        }

        [Test]
        public async Task GetSecretWithVersion()
        {
            string secretName = Recording.GenerateId();

            Secret version1 = await Client.SetAsync(secretName, "value1");
            RegisterForCleanup(version1.Name);
            Secret version2 = await Client.SetAsync(secretName, "value2");
            await Client.SetAsync(secretName, "value3");

            Secret secret = await Client.GetAsync(secretName, version2.Properties.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [Test]
        public async Task GetSecretVersionsNonExisting()
        {
            List<Response<SecretProperties>> allSecrets = await Client.GetSecretVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();

            Assert.AreEqual(0, allSecrets.Count);
        }

        [Test]
        public async Task BackupSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "BackupRestore");

            RegisterForCleanup(secret.Name);

            byte[] backup = await Client.BackupAsync(secretName);

            Assert.NotNull(backup);
        }

        [Test]
        public void BackupSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.BackupAsync(Recording.GenerateId()));
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/6514")]
        public async Task RestoreSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "BackupRestore");

            RegisterForCleanup(secret.Name);

            byte[] backup = await Client.BackupAsync(secretName);

            await Client.DeleteAsync(secretName);
            await WaitForDeletedSecret(secretName);

            await Client.PurgeDeletedAsync(secretName);
            await WaitForPurgedSecret(secretName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetAsync(secretName));
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedAsync(secretName));

            SecretProperties restoreResult = await Client.RestoreAsync(backup);

            AssertSecretPropertiesEqual(secret.Properties, restoreResult);
        }

        [Test]
        public void RestoreMalformedBackup()
        {
            byte[] backupMalformed = Encoding.ASCII.GetBytes("non-existing");
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RestoreAsync(backupMalformed));
        }

        [Test]
        public async Task DeleteSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "value");

            RegisterForCleanup(secret.Name, delete: false);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            AssertSecretPropertiesEqual(secret.Properties, deletedSecret.Properties);
            Assert.NotNull(deletedSecret.DeletedDate);
            Assert.NotNull(deletedSecret.ScheduledPurgeDate);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetAsync(secretName));
        }

        [Test]
        public void DeleteSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.DeleteAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task GetDeletedSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "value");

            RegisterForCleanup(secret.Name, delete: false);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            await WaitForDeletedSecret(secretName);

            DeletedSecret polledSecret = await Client.GetDeletedAsync(secretName);

            Assert.NotNull(deletedSecret.DeletedDate);
            Assert.NotNull(deletedSecret.RecoveryId);
            Assert.NotNull(deletedSecret.ScheduledPurgeDate);

            AssertSecretPropertiesEqual(deletedSecret.Properties, polledSecret.Properties);
            AssertSecretPropertiesEqual(secret.Properties, polledSecret.Properties);
        }

        [Test]
        public void GetDeletedSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task RecoverSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "value");

            RegisterForCleanup(secret.Name);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            await WaitForDeletedSecret(secretName);

            SecretProperties recoverSecretResult = await Client.RecoverDeletedAsync(secretName);

            await PollForSecret(secretName);

            Secret recoveredSecret = await Client.GetAsync(secretName);

            AssertSecretPropertiesEqual(secret.Properties, deletedSecret.Properties);
            AssertSecretPropertiesEqual(secret.Properties, recoverSecretResult);
            AssertSecretsEqual(secret, recoveredSecret);
        }

        [Test]
        public void RecoverSecretNonExisting()
        {
            Assert.ThrowsAsync<RequestFailedException>(() => Client.RecoverDeletedAsync(Recording.GenerateId()));
        }

        [Test]
        public async Task GetSecrets()
        {
            string secretName = Recording.GenerateId();

            List<Secret> createdSecrets = new List<Secret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                Secret secret = await Client.SetAsync(secretName + i, i.ToString());
                createdSecrets.Add(secret);
                RegisterForCleanup(secret.Name);
            }

            List<Response<SecretProperties>> allSecrets = await Client.GetSecretsAsync().ToEnumerableAsync();

            foreach (Secret createdSecret in createdSecrets)
            {
                SecretProperties returnedSecret = allSecrets.Single(s => s.Value.Name == createdSecret.Name);
                AssertSecretPropertiesEqual(createdSecret.Properties, returnedSecret, compareId: false);
            }
        }

        [Test]
        public async Task GetSecretsVersions()
        {
            string secretName = Recording.GenerateId();

            List<Secret> createdSecrets = new List<Secret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                Secret secret = await Client.SetAsync(secretName, i.ToString());
                createdSecrets.Add(secret);
            }

            RegisterForCleanup(createdSecrets.First().Name);

            List<Response<SecretProperties>> allSecrets = await Client.GetSecretVersionsAsync(secretName).ToEnumerableAsync();

            foreach (Secret createdSecret in createdSecrets)
            {
                SecretProperties returnedSecret = allSecrets.Single(s => s.Value.Id == createdSecret.Id);
                AssertSecretPropertiesEqual(createdSecret.Properties, returnedSecret);
            }
        }


        [Test]
        public async Task GetDeletedSecrets()
        {
            string secretName = Recording.GenerateId();

            List<Secret> deletedSecrets = new List<Secret>();
            for (int i = 0; i < PagedSecretCount; i++)
            {
                Secret secret = await Client.SetAsync(secretName + i, i.ToString());
                deletedSecrets.Add(secret);
                await Client.DeleteAsync(secret.Name);

                RegisterForCleanup(secret.Name, delete: false);
            }

            foreach (Secret deletedSecret in deletedSecrets)
            {
                await WaitForDeletedSecret(deletedSecret.Name);
            }

            List<Response<DeletedSecret>> allSecrets = await Client.GetDeletedSecretsAsync().ToEnumerableAsync();

            foreach (Secret deletedSecret in deletedSecrets)
            {
                Secret returnedSecret = allSecrets.Single(s => s.Value.Name == deletedSecret.Name);
                AssertSecretPropertiesEqual(deletedSecret.Properties, returnedSecret.Properties, compareId: false);
            }
        }
    }
}
