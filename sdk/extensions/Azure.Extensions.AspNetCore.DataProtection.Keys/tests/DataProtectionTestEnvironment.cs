// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Extensions.AspNetCore.DataProtection.Keys.Tests
{
    public class DataProtectionTestEnvironment: TestEnvironment
    {
        public string KeyVaultUrl => GetVariable("AZURE_KEYVAULT_URL");
    }
}