// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public partial class KeyClientLiveTests
    {
        [RecordedTest]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public async Task GetKeyRotationPolicyReturnsDefault()
        {
            string name = Recording.GenerateId();

            await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyRotationPolicy policy = await Client.GetKeyRotationPolicyAsync(name);
            Assert.That(policy.LifetimeActions, Has.One.Matches<KeyRotationLifetimeAction>(action => action.Action == KeyRotationPolicyAction.Notify));
        }

        [RecordedTest]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public void GetKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetKeyRotationPolicyAsync("missing"));

            IgnoreIfNotSupported(ex);

            Assert.That(ex.Status, Is.EqualTo(404));
            Assert.That(ex.ErrorCode, Is.EqualTo("KeyNotFound"));
        }

        [RecordedTest]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public async Task RotateKeyCreatesNewVersion()
        {
            string name = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyVaultKey rotatedKey = await Client.RotateKeyAsync(name);

            Assert.That(rotatedKey.Id, Is.Not.EqualTo(key.Id));
            Assert.That(rotatedKey.Properties.Version, Is.Not.EqualTo(key.Properties.Version));
            Assert.That(rotatedKey.Key.N, Is.Not.EqualTo(key.Key.N));
        }

        [RecordedTest]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public async Task UpdateKeyRotationPolicy()
        {
            string name = Recording.GenerateId();

            await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyRotationPolicy policy = new()
            {
                ExpiresIn = "P90D",
                LifetimeActions =
                {
                    new KeyRotationLifetimeAction(KeyRotationPolicyAction.Rotate)
                    {
                        TimeBeforeExpiry = "P10D",
                    }
                }
            };

            KeyRotationPolicy updatedPolicy = await Client.UpdateKeyRotationPolicyAsync(name, policy);

            Assert.That(updatedPolicy.ExpiresIn, Is.EqualTo(policy.ExpiresIn));

            KeyRotationLifetimeAction rotateAction = updatedPolicy.LifetimeActions.Single(p => p.Action == KeyRotationPolicyAction.Rotate);
            Assert.That(rotateAction.Action, Is.EqualTo(policy.LifetimeActions[0].Action));
            Assert.That(rotateAction.TimeAfterCreate, Is.EqualTo(policy.LifetimeActions[0].TimeAfterCreate));
            Assert.That(rotateAction.TimeBeforeExpiry, Is.EqualTo(policy.LifetimeActions[0].TimeBeforeExpiry));
        }

        [RecordedTest]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3)]
        public void UpdateKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyRotationPolicyAsync("missing", new()));

            IgnoreIfNotSupported(ex);

            Assert.That(ex.Status, Is.EqualTo(404));
            Assert.That(ex.ErrorCode, Is.EqualTo("KeyNotFound"));
        }
    }
}
