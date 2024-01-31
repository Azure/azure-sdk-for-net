// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.KeyVault.Models;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    internal class VaultSecretTests : VaultOperationsTestsBase
    {
        public VaultSecretTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await Initialize().ConfigureAwait(false);
            }
        }

        [RecordedTest]
        public async Task SecretCreateOrUpdateExistGetGetAll()
        {
            IgnoreTestInLiveMode();
            VaultProperties.EnableSoftDelete = null;

            KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(Location, VaultProperties);
            parameters.Tags.InitializeFrom(Tags);
            ArmOperation<KeyVaultResource> rawVault = await VaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, VaultName, parameters).ConfigureAwait(false);

            var secretCollection = rawVault.Value.GetKeyVaultSecrets();
            // CreateOrUpdate
            string secretName = Recording.GenerateAssetName("secret");
            SecretProperties secretProperties = new SecretProperties()
            {
                Value = "secret-value",
            };
            var data = new KeyVaultSecretCreateOrUpdateContent(secretProperties);
            var secret = await secretCollection.CreateOrUpdateAsync(WaitUntil.Completed, secretName, data);
            ValidateSecret(secret.Value.Data, secretName);

            // Exist
            bool flag = await secretCollection.ExistsAsync( secretName);
            Assert.IsTrue(flag);

            // Get
            var getsecret = await secretCollection.GetAsync(secretName);
            ValidateSecret(getsecret.Value.Data, secretName);

            // GetAll
            var list = await secretCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateSecret(list.FirstOrDefault().Data, secretName);
        }

        private void ValidateSecret(KeyVaultSecretData secret, string secretName)
        {
            Assert.IsNotNull(secret);
            Assert.AreEqual(secretName, secret.Name);
            Assert.AreEqual(Location, secret.Location);
        }
    }
}
