// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Security.KeyVault.Tests
{
    public class KeyVaultTestEnvironment : TestEnvironment
    {
        public KeyVaultTestEnvironment() : base("keyvault")
        {
        }

        public string KeyVaultUrl => GetRecordedVariable("AZURE_KEYVAULT_URL");
    }
}