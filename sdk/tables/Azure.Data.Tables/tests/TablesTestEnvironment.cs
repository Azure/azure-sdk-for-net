// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Data.Tables.Tests
{
    public class TablesTestEnvironment : TestEnvironment
    {
        public TablesTestEnvironment() : base("tables")
        {
        }

        private const string StorageUriFormat = "https://{0}.table.core.windows.net";
        public string PrimaryStorageAccountKey => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_KEY");
        public string AccountName => GetRecordedVariable("TABLES_STORAGE_ACCOUNT_NAME");
        public string StorageUri => string.Format(StorageUriFormat, AccountName);
    }
}
