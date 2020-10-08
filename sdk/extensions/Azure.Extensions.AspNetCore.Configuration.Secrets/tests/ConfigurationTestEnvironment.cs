// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Extensions.AspNetCore.Configuration.Secrets.Tests
{
    public class ConfigurationTestEnvironment: TestEnvironment
    {
        public ConfigurationTestEnvironment() : base("extensions")
        {
        }

        public string KeyVaultUrl => GetVariable("AZURE_KEYVAULT_URL");
    }
}