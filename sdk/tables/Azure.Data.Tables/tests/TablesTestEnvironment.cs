// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.Tables.Tests
{
    public class TablesTestEnvironment : TestEnvironment
    {
        public TablesTestEnvironment() : base("tables")
        {
        }

        // Storage Tables
        public const string PrimaryStorageKeyEnvironmentVariableName = "TABLES_PRIMARY_STORAGE_ACCOUNT_KEY";
        private const string StorageUriFormat = "https://{0}.table.core.windows.net";
        public string PrimaryStorageAccountKey => GetRecordedVariable(PrimaryStorageKeyEnvironmentVariableName);
        public string StorageAccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string StorageUri => string.Format(StorageUriFormat, StorageAccountName);

        // Cosmos Tables
        public const string PrimaryCosmosKeyEnvironmentVariableName = "TABLES_PRIMARY_COSMOS_ACCOUNT_KEY";
        private const string CosmosUriFormat = "https://{0}.table.cosmos.azure.com";
        public string PrimaryCosmosAccountKey => GetRecordedVariable(PrimaryCosmosKeyEnvironmentVariableName);
        public string CosmosAccountName => GetRecordedVariable("TABLES_COSMOS_ACCOUNT_NAME");
        public string CosmosUri => string.Format(CosmosUriFormat, CosmosAccountName);
    }
}
