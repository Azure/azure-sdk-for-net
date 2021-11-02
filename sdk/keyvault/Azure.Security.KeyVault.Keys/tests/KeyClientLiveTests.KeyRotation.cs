// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public partial class KeyClientLiveTests
    {
        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task GetKeyRotationPolicyReturnsDefault()
        {
            string name = Recording.GenerateId();

            await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyRotationPolicy policy = await Client.GetKeyRotationPolicyAsync(name);
            Assert.NotNull(policy);
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public void GetKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetKeyRotationPolicyAsync("missing"));
            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual("KeyNotFound", ex.ErrorCode);
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task RotateKeyCreatesNewVersion()
        {
            string name = Recording.GenerateId();

            KeyVaultKey key = await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyVaultKey rotatedKey = await Client.RotateKeyAsync(name);

            Assert.AreNotEqual(key.Id, rotatedKey.Id);
            Assert.AreNotEqual(key.Properties.Version, rotatedKey.Properties.Version);
            Assert.AreNotEqual(key.Key.N, rotatedKey.Key.N);
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task UpdateKeyRotationPolicy()
        {
            string name = Recording.GenerateId();

            await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyRotationPolicy policy = new()
            {
                ExpiresIn = TimeSpan.FromDays(90),
                LifetimeActions =
                {
                    new KeyRotationLifetimeAction
                    {
                        Action = KeyRotationPolicyAction.Rotate,
                        TimeBeforeExpiry = TimeSpan.FromDays(10),
                    }
                }
            };

            KeyRotationPolicy updatedPolicy = await Client.UpdateKeyRotationPolicyAsync(name, policy);

            Assert.AreEqual(policy.ExpiresIn, updatedPolicy.ExpiresIn);
            Assert.AreEqual(policy.LifetimeActions.Count, updatedPolicy.LifetimeActions.Count);
            Assert.AreEqual(policy.LifetimeActions[0].Action, updatedPolicy.LifetimeActions[0].Action);
            Assert.AreEqual(policy.LifetimeActions[0].TimeAfterCreate, updatedPolicy.LifetimeActions[0].TimeAfterCreate);
            Assert.AreEqual(policy.LifetimeActions[0].TimeBeforeExpiry, updatedPolicy.LifetimeActions[0].TimeBeforeExpiry);
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public void UpdateKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyRotationPolicyAsync("missing", new()));
            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual("KeyNotFound", ex.ErrorCode);
        }
    }
}
