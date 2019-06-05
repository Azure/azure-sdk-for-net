// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Security.KeyVault.Secrets;

namespace Azure.Security.KeyVault.Test
{
    public class SecretTests : KeyVaultTestBase
    {
        public SecretTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CredentialProvider()
        {
            var client = GetClient();

            Secret setResult = await client.SetAsync("CrudBasic", "CrudBasicValue1");

            Secret getResult = await client.GetAsync("CrudBasic");

            AssertSecretsEqual(setResult, getResult);

            DeletedSecret deleteResult = await client.DeleteAsync("CrudBasic");

            AssertSecretsEqual(setResult, deleteResult);
        }

        [Test]
        public async Task CrudBasic()
        {
            var client = GetClient();

            Secret setResult = await client.SetAsync("CrudBasic", "CrudBasicValue1");

            Secret getResult = await client.GetAsync("CrudBasic");

            Assert.AreEqual("CrudBasic", setResult.Name);
            Assert.AreEqual("CrudBasicValue1", setResult.Value);
            //Assert.AreEqual(VaultUri, setResult.Vault);

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
            var exp = new DateTimeOffset(new DateTime(637027248124480000, DateTimeKind.Utc));
            var nbf = exp.AddDays(-30);

            var client = GetClient();

            var secret = new Secret("CrudWithExtendedProps", "CrudWithExtendedPropsValue1")
            {
                ContentType = "password",
                NotBefore = nbf,
                Expires = exp
            };

            Secret setResult = await client.SetAsync(secret);

            Assert.AreEqual("password", setResult.ContentType);
            Assert.AreEqual(nbf, setResult.NotBefore);
            Assert.AreEqual(exp, setResult.Expires);

            Secret getResult = await client.GetAsync("CrudWithExtendedProps");

            AssertSecretsEqual(setResult, getResult);

            DeletedSecret deleteResult = await client.DeleteAsync("CrudWithExtendedProps");

            AssertSecretsEqual(setResult, deleteResult);
        }

        [Test]
        public async Task BackupRestore()
        {
            var client = GetClient();

            Secret setResult = await client.SetAsync("BackupRestore", "BackupRestore");

            byte[] backup = await client.BackupAsync("BackupRestore");

            await client.DeleteAsync("BackupRestore");

            SecretBase restoreResult = await client.RestoreAsync(backup);

            AssertSecretsEqual(setResult, restoreResult);
        }

        private DateTime UtcNowMs()
        {
            return DateTime.MinValue.ToUniversalTime() + TimeSpan.FromMilliseconds(new TimeSpan(DateTime.UtcNow.Ticks).TotalMilliseconds);
        }
    }
}