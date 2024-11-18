// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseShares;

using System;
using Azure.Core.TestFramework;
using BaseShares::Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DataMovementShareClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public DataMovementShareClientTestFixtureAttribute(params object[] additionalParameters)
            : base(
                serviceVersions: new object[]
                {
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
                    ShareClientOptions.ServiceVersion.V2022_11_02,
                    ShareClientOptions.ServiceVersion.V2023_01_03,
                    ShareClientOptions.ServiceVersion.V2023_05_03,
                    ShareClientOptions.ServiceVersion.V2023_08_03,
                    ShareClientOptions.ServiceVersion.V2023_11_03,
                    ShareClientOptions.ServiceVersion.V2024_02_04,
                    ShareClientOptions.ServiceVersion.V2024_05_04,
                    ShareClientOptions.ServiceVersion.V2024_08_04,
                    ShareClientOptions.ServiceVersion.V2024_11_04,
                    StorageVersionExtensions.LatestVersion,
                    StorageVersionExtensions.MaxVersion
                },
                additionalParameters: additionalParameters)
        {
            RecordingServiceVersion = StorageVersionExtensions.LatestVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.MaxVersion, };
        }
    }
}
