// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class SecretClientDisposalTests : ClientDisposalTestsBase<SecretClient, SecretClientOptions>
    {
        protected override SecretClient CreateClient(TokenCredential credential, SecretClientOptions options = null) =>
            options == null ? new SecretClient(VaultUri, credential) : new SecretClient(VaultUri, credential, options);

        protected override SecretClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(SecretClient client) =>
            ReadField<KeyVaultSecretsClient>(client, "_generated").Pipeline;

        [Test]
        public void SettingsConstructorDoesNotRequireDisposal([Values] bool explicitOptions)
        {
#pragma warning disable SCME0002
            var settings = new SecretClientSettings
            {
                VaultUri = VaultUri,
                Options = explicitOptions ? CreateOptions() : null,
                Credential = new System.ClientModel.Primitives.CredentialSettings(null) { TokenProvider = new MockCredential() }
            };
            using var client = new SecretClient(settings);
#pragma warning restore SCME0002
            var lifetime = new DefaultTransportLifetime(GetPipeline(client));
            DisposeRepeatedly(client, concurrent: true);
            lifetime.AssertAlive();
        }

        [Test]
        public void DisposePreservesDerivedFinalizationSuppression([Values] bool dispose)
        {
            var state = new FinalizationState();
            CreateFinalizableClient(state, dispose);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assert.That(state.Count, Is.EqualTo(dispose ? 0 : 1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CreateFinalizableClient(FinalizationState state, bool dispose)
        {
            var client = new FinalizableSecretClient(state);
            if (dispose)
            {
                client.Dispose();
            }
        }

        private sealed class FinalizationState
        {
            internal int Count;
        }

        private sealed class FinalizableSecretClient : SecretClient
        {
            private readonly FinalizationState _state;

            internal FinalizableSecretClient(FinalizationState state) => _state = state;

            ~FinalizableSecretClient() => Interlocked.Increment(ref _state.Count);
        }
    }
}
