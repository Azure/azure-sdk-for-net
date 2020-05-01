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

        public static ConfigurationTestEnvironment Instance { get; } = new ConfigurationTestEnvironment();
        public string KeyVaultUrl => GetVariable("AZURE_KEYVAULT_URL");
    }
}