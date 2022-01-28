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
        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public async Task GetKeyRotationPolicyReturnsDefault()
        {
            string name = Recording.GenerateId();

            await Client.CreateRsaKeyAsync(new CreateRsaKeyOptions(name));
            RegisterForCleanup(name);

            KeyRotationPolicy policy = await Client.GetKeyRotationPolicyAsync(name);
            Assert.That(policy.LifetimeActions, Has.One.Matches<KeyRotationLifetimeAction>(action => action.Action == KeyRotationPolicyAction.Notify));
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public void GetKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.GetKeyRotationPolicyAsync("missing"));

            IgnoreIfNotSupported(ex);

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

            // Notify policy is always present and can only be updated.
            Assert.That(updatedPolicy.LifetimeActions, Has.One.Matches<KeyRotationLifetimeAction>(action => action.Action == KeyRotationPolicyAction.Notify));

            KeyRotationLifetimeAction rotateAction = updatedPolicy.LifetimeActions.Single(p => p.Action == KeyRotationPolicyAction.Rotate);
            Assert.AreEqual(policy.LifetimeActions[0].Action, rotateAction.Action);
            Assert.AreEqual(policy.LifetimeActions[0].TimeAfterCreate, rotateAction.TimeAfterCreate);
            Assert.AreEqual(policy.LifetimeActions[0].TimeBeforeExpiry, rotateAction.TimeBeforeExpiry);
        }

        [Test]
        [KeyVaultOnly]
        [ServiceVersion(Min = KeyClientOptions.ServiceVersion.V7_3_Preview)]
        public void UpdateKeyRotationPolicyThrowsForMissingKey()
        {
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await Client.UpdateKeyRotationPolicyAsync("missing", new()));

            IgnoreIfNotSupported(ex);

            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual("KeyNotFound", ex.ErrorCode);
        }
    }
}
