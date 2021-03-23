// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Keys.Perf.Infrastructure
{
    internal sealed class PerfTestEnvironment : KeyVaultTestEnvironment
    {
        private Uri _vaultUri;

        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        /// Gets the Key Vault <see cref="Uri"/> from <see cref="KeyVaultUrl"/>.
        /// </summary>
        public Uri VaultUri => LazyInitializer.EnsureInitialized(ref _vaultUri, () => new Uri(KeyVaultUrl));
    }
}
