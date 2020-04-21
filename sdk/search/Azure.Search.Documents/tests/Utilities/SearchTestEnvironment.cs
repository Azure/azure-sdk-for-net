// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Search.Documents.Tests
{
    public class SearchTestEnvironment: TestEnvironment
    {
        public SearchTestEnvironment() : base("search")
        {
        }

        public string SearchStorageName => GetRecordedVariable("AZURE_SEARCH_STORAGE_NAME");
        public string SearchStorageKey => GetRecordedVariable(StorageAccountKeyVariableName);

        public static string StorageAccountKeyVariableName = "AZURE_SEARCH_STORAGE_KEY";
    }
}