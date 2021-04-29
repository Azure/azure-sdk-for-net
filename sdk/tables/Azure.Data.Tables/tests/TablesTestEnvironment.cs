// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.Tables.Tests
{
    public class TablesTestEnvironment : TestEnvironment
    {
        // Storage Tables
        public const string DefaultStorageSuffix = "core.windows.net";
        public string PrimaryStorageAccountKey => GetRecordedVariable("TABLES_PRIMARY_STORAGE_ACCOUNT_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string StorageAccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string StorageUri => $"https://{StorageAccountName}.table.{StorageEndpointSuffix ?? DefaultStorageSuffix}";

        // Cosmos Tables
        public string CosmosEndpointSuffix => GetRecordedOptionalVariable("COSMOS_TABLES_ENDPOINT_SUFFIX") ?? "cosmos.azure.com";
        public string PrimaryCosmosAccountKey => GetRecordedVariable("TABLES_PRIMARY_COSMOS_ACCOUNT_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string CosmosAccountName => GetRecordedVariable("TABLES_COSMOS_ACCOUNT_NAME");
        public string CosmosUri => $"https://{CosmosAccountName}.table.{CosmosEndpointSuffix}";
    }
}
