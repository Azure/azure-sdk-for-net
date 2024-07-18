// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("DEID_SERVICE_ENDPOINT");

        public static string FakeNextLink => "https://deidservicetest.api.deid.azure.com/jobs?api-version=2000-01-01-preview&continuationToken=1234";
        public static string FakeStorageLocation => "https://fakeblobstorage.blob.core.windows.net/container";
        public static string FakeJobName => "net-sdk-job-1234";

        public string GetStorageAccountLocation()
        {
            return $"https://{GetRecordedVariable("STORAGE_ACCOUNT_NAME")}.blob.core.windows.net/{GetRecordedVariable("STORAGE_CONTAINER_NAME")}";
        }
    }
}
