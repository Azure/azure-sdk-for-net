// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// Options that allow configuration of requests sent to the ModelRepositoryService.
    /// </summary>
    public class ModelsRepositoryClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_02_11;

        /// <summary>
        /// The versions of Azure IoT Models Repository service supported by this client.
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// 2021_02_11
            /// </summary>
            [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
            V2021_02_11 = 1
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Gets the <see cref="TimeSpan"/> for which the client considers repository metadata stale.
        /// </summary>
        public TimeSpan MetadataExpiry { get; }

        /// <summary>
        /// Gets the default <see cref="TimeSpan"/> for <see cref="MetadataExpiry"/>.
        /// </summary>
        public static TimeSpan DefaultMetadataExpiry { get { return TimeSpan.FromMinutes(60); } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelsRepositoryClientOptions"/> class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when making requests.
        /// </param>
        /// <param name="metadataExpiry">
        /// The minimum <see cref="TimeSpan"/> for which the client considers fetched repository metadata stale.
        /// If no TimeSpan is provided the TimeSpan from <see cref="DefaultMetadataExpiry"/> is used.
        /// When metadata is stale, the next service operation that can make use of metadata will first attempt to
        /// fetch and refresh the client metadata state. The operation will then continue as normal.
        /// </param>
        public ModelsRepositoryClientOptions(
            ServiceVersion version = LatestVersion,
            TimeSpan? metadataExpiry = null)
        {
            Version = version;
            MetadataExpiry = metadataExpiry ?? DefaultMetadataExpiry;
        }
    }
}
