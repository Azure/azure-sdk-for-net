// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Security.KeyVault.Secrets;
using Azure.Core.Testing;
using System.Text;

namespace Azure.Security.KeyVault.Test
{
    public class SecretClientLiveTests : KeyVaultTestBase
    {
        private const int PagedSecretCount = 50;

        public SecretClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SetSecret()
        {
            string secretName = Recording.GenerateId();

            SecretBase version1 = await Client.SetAsync(secretName, "value1");
            RegisterForCleanup(version1);
            SecretBase version2 = await Client.SetAsync(secretName, "value2");
            await Client.SetAsync(secretName, "value3");

            Secret secret = await Client.GetAsync(secretName, version2.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [Test]
        public async Task SetSecretWithExtendedProps()
        {
            string secretName = Recording.GenerateId();

            Secret setResult = null;

            try
            {
                var exp = new DateTimeOffset(new DateTime(637027248124480000, DateTimeKind.Utc));
                var nbf = exp.AddDays(-30);

                var secret = new Secret(secretName, "CrudWithExtendedPropsValue1")
                {
                    ContentType = "password",
                    NotBefore = nbf,
                    Expires = exp,
                    Tags =
                    {
                        {"tag1", "value1"},
                        {"tag2", "value2"}
                    },
                };

                setResult = await Client.SetAsync(secret);

                RegisterForCleanup(secret, delete: false);

                Assert.IsNotEmpty(setResult.Version);
                Assert.AreEqual("password", setResult.ContentType);
                Assert.AreEqual(nbf, setResult.NotBefore);
                Assert.AreEqual(exp, setResult.Expires);
                Assert.AreEqual(2, setResult.Tags.Count);
                Assert.AreEqual("value1", setResult.Tags["tag1"]);
                Assert.AreEqual("value2", setResult.Tags["tag2"]);
                Assert.AreEqual(secretName, setResult.Name);
                Assert.AreEqual("CrudWithExtendedPropsValue1", setResult.Value);
                Assert.AreEqual(VaultUri, setResult.Vault);
                Assert.AreEqual("Recoverable+Purgeable", setResult.RecoveryLevel);
                Assert.NotNull(setResult.Created);
                Assert.NotNull(setResult.Updated);

                Secret getResult = await Client.GetAsync(secretName);

                AssertSecretsEqual(setResult, getResult);
            }
            finally
            {
                DeletedSecret deleteResult = await Client.DeleteAsync(secretName);

                AssertSecretsEqual(setResult, deleteResult);
            }
        }

        [Test]
        public async Task UpdateEnabled()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret);

            secret.Enabled = false;

            SecretBase updateResult = await Client.UpdateAsync(secret);

            AssertSecretsEqual(secret, updateResult);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetAsync(secretName));

            secret.Enabled = true;

            await Client.UpdateAsync(secret);
        }

        [Test]
        public async Task UpdateSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "CrudBasicValue1");

            RegisterForCleanup(secret);

            secret.Expires = secret.Created;

            SecretBase updateResult = await Client.UpdateAsync(secret);

            AssertSecretsEqual(secret, updateResult);
        }

        [Test]
        public async Task GetSecret()
        {
            string secretName = Recording.GenerateId();

            SecretBase setSecret = await Client.SetAsync(secretName, "value");
            RegisterForCleanup(setSecret);

            Secret secret = await Client.GetAsync(secretName);

            AssertSecretsEqual(setSecret, secret);
        }

        [Test]
        public async Task GetSecretWithVersion()
        {
            string secretName = Recording.GenerateId();

            SecretBase version1 = await Client.SetAsync(secretName, "value1");
            RegisterForCleanup(version1);
            SecretBase version2 = await Client.SetAsync(secretName, "value2");
            await Client.SetAsync(secretName, "value3");

            Secret secret = await Client.GetAsync(secretName, version2.Version);

            Assert.AreEqual("value2", secret.Value);
        }

        [Test]
        public async Task GetSecretVersionsNonExisting()
        {
            List<Response<SecretBase>> allSecrets = await Client.GetSecretVersionsAsync(Recording.GenerateId()).ToEnumerableAsync();

            Assert.AreEqual(0, allSecrets.Count);
        }

        [Test]
        public async Task BackupSecret()
        {
            string secretName = Recording.GenerateId();

            Secret secret = await Client.SetAsync(secretName, "BackupRestore");

            RegisterForCleanup(secret);

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

            RegisterForCleanup(secret);

            byte[] backup = await Client.BackupAsync(secretName);

            await Client.DeleteAsync(secretName);
            await WaitForDeletedSecret(secretName);

            await Client.PurgeDeletedAsync(secretName);
            await WaitForPurgedSecret(secretName);

            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetAsync(secretName));
            Assert.ThrowsAsync<RequestFailedException>(() => Client.GetDeletedAsync(secretName));

            SecretBase restoreResult = await Client.RestoreAsync(backup);

            AssertSecretsEqual(secret, restoreResult);
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

            RegisterForCleanup(secret, delete: false);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            AssertSecretsEqual(secret, deletedSecret);
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

            RegisterForCleanup(secret, delete: false);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            await WaitForDeletedSecret(secretName);

            DeletedSecret polledSecret = await Client.GetDeletedAsync(secretName);

            Assert.NotNull(deletedSecret.DeletedDate);
            Assert.NotNull(deletedSecret.RecoveryId);
            Assert.NotNull(deletedSecret.ScheduledPurgeDate);

            AssertSecretsEqual(deletedSecret, polledSecret);
            AssertSecretsEqual(secret, polledSecret);
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

            RegisterForCleanup(secret);

            DeletedSecret deletedSecret = await Client.DeleteAsync(secretName);

            await WaitForDeletedSecret(secretName);

            SecretBase recoverSecretResult = await Client.RecoverDeletedAsync(secretName);

            await PollForSecret(secretName);

            Secret recoveredSecret = await Client.GetAsync(secretName);

            AssertSecretsEqual(secret, deletedSecret);
            AssertSecretsEqual(secret, recoverSecretResult);
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
                RegisterForCleanup(secret);
            }

            List<Response<SecretBase>> allSecrets = await Client.GetSecretsAsync().ToEnumerableAsync();

            foreach (Secret createdSecret in createdSecrets)
            {
                SecretBase returnedSecret = allSecrets.Single(s => s.Value.Name == createdSecret.Name);
                AssertSecretsEqual(createdSecret, returnedSecret, compareId: false);
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

            RegisterForCleanup(createdSecrets.First());

            List<Response<SecretBase>> allSecrets = await Client.GetSecretVersionsAsync(secretName).ToEnumerableAsync();

            foreach (Secret createdSecret in createdSecrets)
            {
                SecretBase returnedSecret = allSecrets.Single(s => s.Value.Id == createdSecret.Id);
                AssertSecretsEqual(createdSecret, returnedSecret);
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

                RegisterForCleanup(secret, delete: false);
            }

            foreach (Secret deletedSecret in deletedSecrets)
            {
                await WaitForDeletedSecret(deletedSecret.Name);
            }

            List<Response<DeletedSecret>> allSecrets = await Client.GetDeletedSecretsAsync().ToEnumerableAsync();

            foreach (Secret deletedSecret in deletedSecrets)
            {
                SecretBase returnedSecret = allSecrets.Single(s => s.Value.Name == deletedSecret.Name);
                AssertSecretsEqual(deletedSecret, returnedSecret, compareId: false);
            }
        }
    }
}