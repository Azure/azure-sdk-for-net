// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ShareClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public ShareClientTestFixtureAttribute()
            : base(
                ShareClientOptions.ServiceVersion.V2019_02_02,
                ShareClientOptions.ServiceVersion.V2019_07_07,
                ShareClientOptions.ServiceVersion.V2019_12_12,
                ShareClientOptions.ServiceVersion.V2020_02_10,
                ShareClientOptions.ServiceVersion.V2020_04_08,
                ShareClientOptions.ServiceVersion.V2020_06_12,
                ShareClientOptions.ServiceVersion.V2020_08_04,
                ShareClientOptions.ServiceVersion.V2020_10_02,
                ShareClientOptions.ServiceVersion.V2020_12_06,
                ShareClientOptions.ServiceVersion.V2021_02_12,
                ShareClientOptions.ServiceVersion.V2021_04_10,
                ShareClientOptions.ServiceVersion.V2021_06_08,
                ShareClientOptions.ServiceVersion.V2021_08_06,
                ShareClientOptions.ServiceVersion.V2021_10_04,
                ShareClientOptions.ServiceVersion.V2021_12_02,
                StorageVersionExtensions.LatestVersion,
                StorageVersionExtensions.MaxVersion)
        {
            RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion, };
        }
    }
}
