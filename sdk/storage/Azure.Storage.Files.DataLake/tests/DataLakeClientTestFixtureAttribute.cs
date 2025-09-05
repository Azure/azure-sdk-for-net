// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public DataLakeClientTestFixtureAttribute()
            : base(
                DataLakeClientOptions.ServiceVersion.V2019_02_02,
                DataLakeClientOptions.ServiceVersion.V2019_07_07,
                DataLakeClientOptions.ServiceVersion.V2019_12_12,
                DataLakeClientOptions.ServiceVersion.V2020_02_10,
                DataLakeClientOptions.ServiceVersion.V2020_04_08,
                DataLakeClientOptions.ServiceVersion.V2020_06_12,
                DataLakeClientOptions.ServiceVersion.V2020_08_04,
                DataLakeClientOptions.ServiceVersion.V2020_10_02,
                DataLakeClientOptions.ServiceVersion.V2020_12_06,
                DataLakeClientOptions.ServiceVersion.V2021_02_12,
                DataLakeClientOptions.ServiceVersion.V2021_04_10,
                DataLakeClientOptions.ServiceVersion.V2021_06_08,
                DataLakeClientOptions.ServiceVersion.V2021_08_06,
                DataLakeClientOptions.ServiceVersion.V2021_10_04,
                DataLakeClientOptions.ServiceVersion.V2021_12_02,
                DataLakeClientOptions.ServiceVersion.V2022_11_02,
                DataLakeClientOptions.ServiceVersion.V2023_01_03,
                DataLakeClientOptions.ServiceVersion.V2023_05_03,
                DataLakeClientOptions.ServiceVersion.V2023_08_03,
                DataLakeClientOptions.ServiceVersion.V2023_11_03,
                DataLakeClientOptions.ServiceVersion.V2024_02_04,
                DataLakeClientOptions.ServiceVersion.V2024_05_04,
                DataLakeClientOptions.ServiceVersion.V2024_08_04,
                DataLakeClientOptions.ServiceVersion.V2024_11_04,
                DataLakeClientOptions.ServiceVersion.V2025_01_05,
                DataLakeClientOptions.ServiceVersion.V2025_05_05,
                DataLakeClientOptions.ServiceVersion.V2025_07_05,
                DataLakeClientOptions.ServiceVersion.V2025_11_05,
                StorageVersionExtensions.LatestVersion,
                StorageVersionExtensions.MaxVersion)
        {
            RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion };
        }
    }
}
