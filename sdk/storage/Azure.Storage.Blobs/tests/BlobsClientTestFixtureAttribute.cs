// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobsClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public BlobsClientTestFixtureAttribute()
            : base(
                BlobClientOptions.ServiceVersion.V2019_02_02,
                BlobClientOptions.ServiceVersion.V2019_07_07,
                BlobClientOptions.ServiceVersion.V2019_12_12,
                BlobClientOptions.ServiceVersion.V2020_02_10,
                BlobClientOptions.ServiceVersion.V2020_04_08,
                BlobClientOptions.ServiceVersion.V2020_06_12,
                BlobClientOptions.ServiceVersion.V2020_08_04,
                BlobClientOptions.ServiceVersion.V2020_10_02,
                BlobClientOptions.ServiceVersion.V2020_12_06,
                BlobClientOptions.ServiceVersion.V2021_02_12,
                BlobClientOptions.ServiceVersion.V2021_04_10,
                StorageVersionExtensions.LatestVersion,
                StorageVersionExtensions.MaxVersion)
        {
            RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion };
        }
    }
}
