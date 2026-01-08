// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if BlobDataMovementSDK
extern alias BaseBlobs;
#elif ShareDataMovementSDK
extern alias BaseShares;
#endif
using System;

// Alias the ServiceVersion enum used by the service importing this shared
// source file
using ServiceVersion =
#if BlobSDK
    Azure.Storage.Blobs.BlobClientOptions.ServiceVersion;
#elif QueueSDK
    Azure.Storage.Queues.QueueClientOptions.ServiceVersion;
#elif FileSDK
    Azure.Storage.Files.Shares.ShareClientOptions.ServiceVersion;
#elif DataLakeSDK
    Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion;
#elif ChangeFeedSDK
    Azure.Storage.Blobs.BlobClientOptions.ServiceVersion;
#elif DataMovementSDK
    Azure.Storage.Blobs.BlobClientOptions.ServiceVersion;
#elif BlobDataMovementSDK
    BaseBlobs::Azure.Storage.Blobs.BlobClientOptions.ServiceVersion;
#elif ShareDataMovementSDK
    BaseShares::Azure.Storage.Files.Shares.ShareClientOptions.ServiceVersion;
#else
    // If you see this error, you've included this shared source file from a
    // client library that it doesn't know how to help you with.  Either add
    // the appropriate XyzSDK flag to your .csproj or alias your service
    // version above.
    ERROR_STORAGE_SERVICE_NOT_DEFINED;
#endif

namespace Azure.Storage
{
    /// <summary>
    /// Helpers to manage Storage service versions.
    /// </summary>
    internal static class StorageVersionExtensions
    {
        /// <summary>
        /// Gets the latest version of the service supported by this SDK.
        /// </summary>
        public const ServiceVersion LatestVersion =
#if BlobSDK || QueueSDK || FileSDK || DataLakeSDK || ChangeFeedSDK || DataMovementSDK || BlobDataMovementSDK || ShareDataMovementSDK
            ServiceVersion.V2026_02_06;
#else
            ERROR_STORAGE_SERVICE_NOT_DEFINED;
#endif

        /// <summary>
        /// Gets the latest version of the service supported by this SDK.
        /// </summary>
        internal const ServiceVersion MaxVersion =
#if BlobSDK || QueueSDK || FileSDK || DataLakeSDK || ChangeFeedSDK || DataMovementSDK || BlobDataMovementSDK || ShareDataMovementSDK
            ServiceVersion.V2026_04_06;
#else
            ERROR_STORAGE_SERVICE_NOT_DEFINED;
#endif

        /// <summary>
        /// Convert a Storage ServiceVersion enum to an x-ms-version string.
        /// </summary>
        /// <param name="version">The service version enum value.</param>
        /// <returns>The x-ms-version string.</returns>
        public static string ToVersionString(this ServiceVersion version) =>
            version switch
            {
#if BlobSDK || FileSDK || DataLakeSDK || QueueSDK
                ServiceVersion.V2019_02_02 => "2019-02-02",
                ServiceVersion.V2019_07_07 => "2019-07-07",
                ServiceVersion.V2019_12_12 => "2019-12-12",
                ServiceVersion.V2020_02_10 => "2020-02-10",
                ServiceVersion.V2020_04_08 => "2020-04-08",
                ServiceVersion.V2020_06_12 => "2020-06-12",
                ServiceVersion.V2020_08_04 => "2020-08-04",
                ServiceVersion.V2020_10_02 => "2020-10-02",
                ServiceVersion.V2020_12_06 => "2020-12-06",
                ServiceVersion.V2021_02_12 => "2021-02-12",
                ServiceVersion.V2021_04_10 => "2021-04-10",
                ServiceVersion.V2021_06_08 => "2021-06-08",
                ServiceVersion.V2021_08_06 => "2021-08-06",
                ServiceVersion.V2021_10_04 => "2021-10-04",
                ServiceVersion.V2021_12_02 => "2021-12-02",
                ServiceVersion.V2022_11_02 => "2022-11-02",
                ServiceVersion.V2023_01_03 => "2023-01-03",
                ServiceVersion.V2023_05_03 => "2023-05-03",
                ServiceVersion.V2023_08_03 => "2023-08-03",
                ServiceVersion.V2023_11_03 => "2023-11-03",
                ServiceVersion.V2024_02_04 => "2024-02-04",
                ServiceVersion.V2024_05_04 => "2024-05-04",
                ServiceVersion.V2024_08_04 => "2024-08-04",
                ServiceVersion.V2024_11_04 => "2024-11-04",
                ServiceVersion.V2025_01_05 => "2025-01-05",
                ServiceVersion.V2025_05_05 => "2025-05-05",
                ServiceVersion.V2025_07_05 => "2025-07-05",
                ServiceVersion.V2025_11_05 => "2025-11-05",
                ServiceVersion.V2026_02_06 => "2026-02-06",
                ServiceVersion.V2026_04_06 => "2026-04-06",
#endif
                _ => throw Errors.VersionNotSupported(nameof(version))
            };

#if DataLakeSDK
        /// <summary>
        /// Convert a DataLake ServiceVersion to a Blobs ServiceVersion.
        /// </summary>
        /// <param name="version">The DataLake service version.</param>
        /// <returns>The Blobs service version.</returns>
        public static Azure.Storage.Blobs.BlobClientOptions.ServiceVersion AsBlobsVersion(this Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion version) =>
            version switch
            {
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2019_02_02 =>
                             Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2019_02_02,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2019_07_07 =>
                             Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2019_07_07,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2019_12_12 =>
                             Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2019_12_12,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_02_10 =>
                             Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_02_10,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_04_08 =>
                             Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_04_08,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_06_12 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_06_12,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_08_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_08_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_10_02 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_10_02,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2020_12_06 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2020_12_06,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_02_12 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_02_12,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_04_10 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_04_10,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_06_08 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_06_08,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_08_06 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_08_06,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_10_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_10_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2021_12_02 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2021_12_02,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2022_11_02 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2022_11_02,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2023_01_03 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2023_01_03,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2023_05_03 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2023_05_03,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2023_08_03 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2023_08_03,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2023_11_03 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2023_11_03,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2024_02_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2024_02_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2024_05_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2024_05_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2024_08_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2024_08_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2024_11_04 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2024_11_04,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2025_01_05 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2025_01_05,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2025_05_05 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2025_05_05,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2025_07_05 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2025_07_05,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2025_11_05 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2025_11_05,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2026_02_06 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2026_02_06,
                Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2026_04_06 =>
                            Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2026_04_06,
                _ => throw Errors.VersionNotSupported(nameof(version))
            };
#endif
    }
}
