// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    public class BlobShareClientTestFixtureAttribute : ClientTestFixtureAttribute
    {
        // TODO: provide a way to pass both the BlobClientOptions.ServiceVersion
        // and the ShareClientOptions.Service version.
        public BlobShareClientTestFixtureAttribute()
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
                ShareClientOptions.ServiceVersion.V2022_11_02,
                ShareClientOptions.ServiceVersion.V2023_01_03,
                ShareClientOptions.ServiceVersion.V2023_05_03,
                ShareClientOptions.ServiceVersion.V2023_08_03,
                ShareClientOptions.ServiceVersion.V2023_11_03,
                StorageVersionExtensions.LatestVersion,
                StorageVersionExtensions.MaxVersion)
        {
            RecordingServiceVersion = StorageVersionExtensions.MaxVersion;
            LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion, };
        }
    }
}
