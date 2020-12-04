// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
#if BlobSDK || QueueSDK || FileSDK || DataLakeSDK
            ServiceVersion.V2020_04_08;
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
#if BlobSDK || FileSDK || DataLakeSDK
                ServiceVersion.V2019_02_02 => "2019-02-02",
                ServiceVersion.V2019_07_07 => "2019-07-07",
                ServiceVersion.V2019_12_12 => "2019-12-12",
                ServiceVersion.V2020_02_10 => "2020-02-10",
                ServiceVersion.V2020_04_08 => "2020-04-08",
#elif QueueSDK
                // Queues just bumped the version number without changing the swagger
                ServiceVersion.V2019_02_02 => "2018-11-09",
                ServiceVersion.V2019_07_07 => "2018-11-09",
                ServiceVersion.V2019_12_12 => "2018-11-09",
                ServiceVersion.V2020_02_10 => "2018-11-09",
                ServiceVersion.V2020_04_08 => "2018-11-09",
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
                _ => throw Errors.VersionNotSupported(nameof(version))
            };
#endif
    }
}
