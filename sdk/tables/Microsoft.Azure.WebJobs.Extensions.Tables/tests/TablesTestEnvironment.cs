// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    public class TablesTestEnvironment: TestEnvironment
    {
        // Storage Tables
        public const string DefaultStorageSuffix = "core.windows.net";
        public string PrimaryStorageAccountKey => GetRecordedVariable("TABLES_PRIMARY_STORAGE_ACCOUNT_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string StorageAccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string StorageUri => $"https://{StorageAccountName}.table.{StorageEndpointSuffix ?? DefaultStorageSuffix}";
        public string StorageConnectionString => $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={PrimaryStorageAccountKey};EndpointSuffix={StorageEndpointSuffix ?? DefaultStorageSuffix}";
    }
}