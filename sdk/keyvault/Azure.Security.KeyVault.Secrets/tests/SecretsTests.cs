using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;
using Azure.Identity;

namespace Azure.Security.KeyVault.Test
{
    public class SecretTests : KeyVaultTestBase
    {
        static void Main(string[] args)
        {

        }
        public SecretTests()
        {
        }

        [Test]
        public async Task CredentialProvider()
        {
            var client = new Secrets.SecretClient(VaultUri, AzureCredential.Default);

            Secret setResult = await client.SetAsync("CrudBasic", "CrudBasicValue1");

            Secret getResult = await client.GetAsync("CrudBasic");

            AssertSecretsEqual(setResult, getResult);

            DeletedSecret deleteResult = await client.DeleteAsync("CrudBasic");

            AssertSecretsEqual(setResult, deleteResult);
        }

        [Test]
        public async Task CrudBasic()
        {
            var client = new SecretClient(VaultUri, AzureCredential.Default);

            Secret setResult = await client.SetAsync("CrudBasic", "CrudBasicValue1");

            Secret getResult = await client.GetAsync("CrudBasic");

            Assert.AreEqual("CrudBasic", setResult.Name);
            Assert.AreEqual(VaultUri, setResult.Vault);

            AssertSecretsEqual(setResult, getResult);

            getResult.Enabled = false;
            SecretBase updateResult = await client.UpdateAsync(getResult);

            AssertSecretsEqual(getResult, updateResult);

            DeletedSecret deleteResult = await client.DeleteAsync("CrudBasic");

            AssertSecretsEqual(updateResult, deleteResult);
        }

        [Test]
        public async Task CrudWithExtendedProps()
        {
            var client = new SecretClient(VaultUri, AzureCredential.Default);

            var secret = new Secret("CrudWithExtendedProps", "CrudWithExtendedPropsValue1")
            {
                ContentType = "password",
                NotBefore = UtcNowMs() + TimeSpan.FromDays(1),
                Expires = UtcNowMs() + TimeSpan.FromDays(90)
            };

            Secret setResult = await client.SetAsync(secret);

            Assert.AreEqual("password", setResult.ContentType);

            Secret getResult = await client.GetAsync("CrudWithExtendedProps");

            AssertSecretsEqual(setResult, getResult);

            DeletedSecret deleteResult = await client.DeleteAsync("CrudWithExtendedProps");

            // remove the value which is not set on the deleted response
            typeof(Secret).GetProperty(nameof(setResult.Value)).SetValue(setResult, null);

            AssertSecretsEqual(setResult, deleteResult);
        }

        [Test]
        public async Task BackupRestore()
        {
            var backupPath = Path.GetTempFileName();

            try
            {
                var client = new SecretClient(VaultUri, AzureCredential.Default);

                Secret setResult = await client.SetAsync("BackupRestore", "BackupRestore");

                byte[] backup = await client.BackupAsync("BackupRestore");

                await client.DeleteAsync("BackupRestore");

                Secret restoreResult = await client.RestoreAsync(backup);

                // remove the vaule which is not set in the restore response
                typeof(Secret).GetProperty(nameof(setResult.Value)).SetValue(setResult, null);

                AssertSecretsEqual(setResult, restoreResult);
            }
            finally
            {
                File.Delete(backupPath);
            }
        }

        private DateTime UtcNowMs()
        {
            return DateTime.MinValue.ToUniversalTime() + TimeSpan.FromMilliseconds(new TimeSpan(DateTime.UtcNow.Ticks).TotalMilliseconds);
        }

    }

    public class SecretListTests : KeyVaultTestBase, IDisposable
    {
        private const int VersionCount = 50;
        private readonly string SecretName = Guid.NewGuid().ToString("N");

        private readonly Dictionary<string, Secret> _versions = new Dictionary<string, Secret>(VersionCount);
        private readonly SecretClient _client;

        public SecretListTests()
        {
            _client = new SecretClient(VaultUri, AzureCredential.Default);

            for (int i = 0; i < VersionCount; i++)
            {
                Secret secret = _client.SetAsync(SecretName, Guid.NewGuid().ToString("N")).GetAwaiter().GetResult();

                typeof(Secret).GetProperty(nameof(secret.Value)).SetValue(secret, null);

                _versions[secret.Id.ToString()] = secret;
            }
        }

        public void Dispose()
        {
            var deleteResult = _client.DeleteAsync(SecretName);
        }

        [Test]
        public async Task GetAllVersionsAsyncForEach()
        {
            int actVersionCount = 0;

            await foreach (var secret in _client.GetAllVersionsAsync(SecretName))
            {
                Assert.True(_versions.TryGetValue(secret.Id.ToString(), out Secret exp));

                AssertSecretsEqual(exp, secret);

                actVersionCount++;
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }

        [Test]
        public async Task ListVersionEnumeratorMoveNext()
        {
            int actVersionCount = 0;

            var enumerator = _client.GetAllVersionsAsync(SecretName);

            while (await enumerator.MoveNextAsync())
            {
                Assert.True(_versions.TryGetValue(enumerator.Current.Id.ToString(), out Secret exp));

                AssertSecretsEqual(exp, enumerator.Current);

                actVersionCount++;
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }


        [Test]
        public async Task GetAllVersionsByPageAsyncForEach()
        {
            int actVersionCount = 0;

            await foreach (Page<SecretBase> currentPage in _client.GetAllVersionsAsync(SecretName).ByPage())
            {
                for (int i = 0; i < currentPage.Items.Length; i++)
                {
                    Assert.True(_versions.TryGetValue(currentPage.Items[i].Id.ToString(), out Secret exp));

                    AssertSecretsEqual(exp, currentPage.Items[i]);

                    actVersionCount++;
                }
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }

        [Test]
        public async Task ListVersionByPageEnumeratorMoveNext()
        {
            int actVersionCount = 0;

            var enumerator = _client.GetAllVersionsAsync(SecretName).ByPage();

            while (await enumerator.MoveNextAsync())
            {
                Page<SecretBase> currentPage = enumerator.Current;

                for (int i = 0; i < currentPage.Items.Length; i++)
                {
                    Assert.True(_versions.TryGetValue(currentPage.Items[i].Id.ToString(), out Secret exp));

                    AssertSecretsEqual(exp, currentPage.Items[i]);

                    actVersionCount++;
                }
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }
    }

    public class KeyVaultTestBase
    {
        private static Lazy<Uri> s_vaultUri = new Lazy<Uri>(() => { return new Uri(Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL")); });

        protected Uri VaultUri { get => s_vaultUri.Value; }

        protected void AssertSecretsEqual(Secret exp, Secret act)
        {
            Assert.AreEqual(exp.Value, act.Value);

        }

        protected void AssertSecretsEqual(SecretBase exp, SecretBase act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.ContentType, act.ContentType);
            Assert.AreEqual(exp.KeyId, act.KeyId);
            Assert.AreEqual(exp.Managed, act.Managed);

            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.Expires, act.Expires);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
        }
    }
}