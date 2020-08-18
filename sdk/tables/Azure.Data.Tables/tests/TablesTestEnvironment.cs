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
        public string PrimaryStorageAccountKey => GetRecordedVariable(PrimaryStorageKeyEnvironmentVariableName);
        public string StorageAccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string TablesStorageEndpointSuffix => GetOptionalVariable("TABLES_STORAGE_ENDPOINT_SUFFIX") ?? "table.core.windows.net";
        public string StorageUri => $"https://{StorageAccountName}.{TablesStorageEndpointSuffix}";

        // Cosmos Tables
        public const string PrimaryCosmosKeyEnvironmentVariableName = "TABLES_PRIMARY_COSMOS_ACCOUNT_KEY";
        public string PrimaryCosmosAccountKey => GetRecordedVariable(PrimaryCosmosKeyEnvironmentVariableName);
        public string CosmosAccountName => GetRecordedVariable("TABLES_COSMOS_ACCOUNT_NAME");
        public string TablesCosmosEndpointSuffix => GetOptionalVariable("TABLES_COSMOS_ENDPOINT_SUFFIX") ?? "table.cosmos.azure.com";
        public string CosmosUri => $"https://{CosmosAccountName}.{TablesCosmosEndpointSuffix}";
    }
}
