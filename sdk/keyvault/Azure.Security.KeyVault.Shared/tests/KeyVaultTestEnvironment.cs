// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Tests
{
    public class KeyVaultTestEnvironment : TestEnvironment
    {
        public KeyVaultTestEnvironment() : base("keyvault")
        {
        }

        public string KeyVaultUrl => GetRecordedVariable("AZURE_KEYVAULT_URL");

        public string ClientObjectId => GetRecordedVariable("CLIENT_OBJECTID");

        /// <summary>
        /// Gets the value of the "KEYVAULT_SKU" variable, or "premium" if not defined.
        /// </summary>
        /// <remarks>
        /// Test preparation was previously successfully creating premium SKUs (not available in every cloud), so assume premium.
        /// </remarks>
        public string Sku => GetOptionalVariable("SKU") ?? "premium";
    }
}
