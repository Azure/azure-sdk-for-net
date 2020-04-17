// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.AspNetCore.DataProtection.Blobs.Tests
{
    public class BlobExtensionsTestEnvironment: TestEnvironment
    {
        public BlobExtensionsTestEnvironment() : base("extensions")
        {
        }

        public static BlobExtensionsTestEnvironment Instance { get; } = new BlobExtensionsTestEnvironment();
        public string KeyVaultUrl => GetVariable("AZURE_KEYVAULT_URL");
    }
}