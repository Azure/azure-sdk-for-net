// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobsClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public BlobsClientTestFixtureAttribute(params object[] additionalParameters)
            : base(
                serviceVersions: new object[]
                {
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
                    BlobClientOptions.ServiceVersion.V2021_06_08,
                    BlobClientOptions.ServiceVersion.V2021_08_06,
                    BlobClientOptions.ServiceVersion.V2021_10_04,
                    BlobClientOptions.ServiceVersion.V2021_12_02,
                    BlobClientOptions.ServiceVersion.V2022_11_02,
                    BlobClientOptions.ServiceVersion.V2023_01_03,
                    BlobClientOptions.ServiceVersion.V2023_05_03,
                    BlobClientOptions.ServiceVersion.V2023_08_03,
                    BlobClientOptions.ServiceVersion.V2023_11_03,
                    BlobClientOptions.ServiceVersion.V2024_02_04,
                    BlobClientOptions.ServiceVersion.V2024_05_04,
                    BlobClientOptions.ServiceVersion.V2024_08_04,
                    BlobClientOptions.ServiceVersion.V2024_11_04,
                    BlobClientOptions.ServiceVersion.V2025_01_05,
                    BlobClientOptions.ServiceVersion.V2025_05_05,
                    BlobClientOptions.ServiceVersion.V2025_07_05,
                    BlobClientOptions.ServiceVersion.V2025_11_05,
                    BlobClientOptions.ServiceVersion.V2026_02_06,
                    BlobClientOptions.ServiceVersion.V2026_04_06,
                    StorageVersionExtensions.LatestVersion,
                    StorageVersionExtensions.MaxVersion
                },
                additionalParameters: additionalParameters
                )
        {
            RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.MaxVersion };
        }
    }
}
