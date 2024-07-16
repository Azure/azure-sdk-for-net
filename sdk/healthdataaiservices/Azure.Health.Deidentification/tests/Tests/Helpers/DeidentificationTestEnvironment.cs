// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public const string FakeSASUri = "https://localhost/fakecontainer";
        public string Endpoint => "https://localhost:5020"; // FIXME: GetRecordedVariable("HEALTHDATAAISERVICES_DEID_SERVICE_ENDPOINT");
        public string FakeNextLink => $"{Endpoint}/jobs?api-version=2024-01-16-preview&continuationToken=1234";
        public string FakeStorageLocation => "https://fakeblobstorage.blob.core.windows.net/container";
        public string FakeJobName => "net-sdk-job-1234";

        public string GetStorageAccountLocation()
        {
            return GetRecordedVariable("STORAGE_ACCOUNT_SAS_URI", options => options.IsSecret(FakeSASUri));
            // return $"https://{GetRecordedVariable("HEALTHDATAAISERVICES_STORAGE_ACCOUNT_NAME")}.blob.core.windows.net/{GetRecordedVariable("HEALTHDATAAISERVICES_STORAGE_CONTAINER_NAME")}";
        }
    }
}
