// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedOptionalVariable("DEID_SERVICE_ENDPOINT") ?? "https://localhost:5020";
        public string StorageAccountName => GetRecordedOptionalVariable("STORAGE_ACCOUNT_NAME") ?? "storageAccount";
        public string StorageContainerName => GetRecordedOptionalVariable("STORAGE_CONTAINER_NAME") ?? "container";
        public static string FakeNextLink => "https://localhost:5020/jobs/net-sdk-job-1234/documents?api-version=2024-11-15&maxpagesize=2&continuationToken=1234";
        public static string FakeStorageLocation => "https://fakeblobstorage.blob.core.windows.net/container";
        public static string FakeJobName => "net-sdk-job-1234";
        public static string FakeContinuationTokenSegment => "continuationToken=1234";

        public string GetStorageAccountLocation()
        {
            return $"https://{StorageAccountName}.blob.core.windows.net/{StorageContainerName}";
        }
    }
}
