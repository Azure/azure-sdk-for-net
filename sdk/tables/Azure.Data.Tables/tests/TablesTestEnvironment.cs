// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        
        public string PrimaryStorageAccountKey => GetRecordedVariable(PrimaryKeyEnvironmentVariableName);
        public string AccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string TablesEndpointSuffix => GetOptionalVariable("TABLES_STORAGE_ENDPOINT_SUFFIX");
        public string StorageUri => !string.IsNullOrEmpty(TablesEndpointSuffix) ? $"https://{AccountName}.{TablesEndpointSuffix}" : string.Format(StorageUriFormat, AccountName);
        // Cosmos Tables
        public const string PrimaryCosmosKeyEnvironmentVariableName = "TABLES_PRIMARY_COSMOS_ACCOUNT_KEY";
        private const string CosmosUriFormat = "https://{0}.table.cosmos.azure.com";
        public string PrimaryCosmosAccountKey => GetRecordedVariable(PrimaryCosmosKeyEnvironmentVariableName);
        public string CosmosAccountName => GetRecordedVariable("TABLES_COSMOS_ACCOUNT_NAME");
        public string CosmosUri => string.Format(CosmosUriFormat, CosmosAccountName);
    }
}
