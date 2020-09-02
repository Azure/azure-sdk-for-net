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

        private const string StorageUriFormat = "https://{0}.blob.core.windows.net";
        public string KeyVaultUrl => GetRecordedVariable("AZURE_KEYVAULT_URL");
        public string ClientObjectId => GetRecordedVariable("CLIENT_OBJECTID");
        public const string PrimaryKeyEnvironmentVariableName = "BLOB_PRIMARY_STORAGE_ACCOUNT_KEY";
        public string PrimaryStorageAccountKey => GetRecordedVariable(PrimaryKeyEnvironmentVariableName, options => options.IsSecret());
        public string AccountName => GetRecordedVariable("BLOB_STORAGE_ACCOUNT_NAME");
        public string StorageUri => string.Format(StorageUriFormat, AccountName);
        public string BlobContainerName => GetRecordedVariable("BLOB_CONTAINER_NAME");

        /// <summary>
        /// Gets the value of the "KEYVAULT_SKU" variable, or "premium" if not defined.
        /// </summary>
        /// <remarks>
        /// Test preparation was previously successfully creating premium SKUs (not available in every cloud), so assume premium.
        /// </remarks>
        public string Sku => GetOptionalVariable("SKU") ?? "premium";
    }
}
