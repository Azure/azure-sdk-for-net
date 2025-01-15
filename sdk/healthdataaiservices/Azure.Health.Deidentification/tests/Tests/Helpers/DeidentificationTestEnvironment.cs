// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("DEID_SERVICE_ENDPOINT");
        public string SasUri => GetRecordedVariable("SAS_URI", options => options.IsSecret());

        public static string FakeNextLink => "https://localhost:5020/jobs/net-sdk-job-1234/documents?api-version=2024-11-15&maxpagesize=2&continuationToken=1234";
        public static string FakeStorageLocation => "https://fakeblobstorage.blob.core.windows.net/container";
        public static string FakeJobName => "net-sdk-job-1234";
        public static string FakeContinuationTokenSegment => "continuationToken=1234";

        public string GetStorageAccountLocation()
        {
            if (!string.IsNullOrEmpty(SasUri))
            {
                // In playback mode, the SAS URI is sanitized to avoid sharing secrets.
                if (string.Equals(SasUri, "Sanitized", System.StringComparison.OrdinalIgnoreCase))
                {
                    return FakeStorageLocation;
                }
                return SasUri;
            }
            return $"https://{GetRecordedVariable("STORAGE_ACCOUNT_NAME")}.blob.core.windows.net/{GetRecordedVariable("STORAGE_CONTAINER_NAME")}";
        }
    }
}
