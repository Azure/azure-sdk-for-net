// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
namespace Azure.Storage.Queues.Tests
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class QueueClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        public QueueClientTestFixtureAttribute(params object[] additionalParameters)
            : base(
                serviceVersions: new object[]
                {
                    QueueClientOptions.ServiceVersion.V2019_02_02,
                    QueueClientOptions.ServiceVersion.V2019_07_07,
                    QueueClientOptions.ServiceVersion.V2019_12_12,
                    QueueClientOptions.ServiceVersion.V2020_02_10,
                    QueueClientOptions.ServiceVersion.V2020_04_08,
                    QueueClientOptions.ServiceVersion.V2020_06_12,
                    QueueClientOptions.ServiceVersion.V2020_08_04,
                    QueueClientOptions.ServiceVersion.V2020_10_02,
                    QueueClientOptions.ServiceVersion.V2020_12_06,
                    QueueClientOptions.ServiceVersion.V2021_02_12,
                    QueueClientOptions.ServiceVersion.V2021_04_10,
                    QueueClientOptions.ServiceVersion.V2021_06_08,
                    QueueClientOptions.ServiceVersion.V2021_08_06,
                    QueueClientOptions.ServiceVersion.V2021_10_04,
                    QueueClientOptions.ServiceVersion.V2021_12_02,
                    QueueClientOptions.ServiceVersion.V2022_11_02,
                    QueueClientOptions.ServiceVersion.V2023_01_03,
                    QueueClientOptions.ServiceVersion.V2023_05_03,
                    QueueClientOptions.ServiceVersion.V2023_08_03,
                    QueueClientOptions.ServiceVersion.V2023_11_03,
                    QueueClientOptions.ServiceVersion.V2024_02_04,
                    QueueClientOptions.ServiceVersion.V2024_05_04,
                    QueueClientOptions.ServiceVersion.V2024_08_04,
                    QueueClientOptions.ServiceVersion.V2024_11_04,
                    QueueClientOptions.ServiceVersion.V2025_01_05,
                    QueueClientOptions.ServiceVersion.V2025_05_05,
                    QueueClientOptions.ServiceVersion.V2025_07_05,
                    QueueClientOptions.ServiceVersion.V2025_11_05,
                    QueueClientOptions.ServiceVersion.V2026_02_06,
                    StorageVersionExtensions.LatestVersion,
                    StorageVersionExtensions.MaxVersion
                },
                additionalParameters: additionalParameters)
                {
                    RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
                    LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion, };
                }
    }
}
