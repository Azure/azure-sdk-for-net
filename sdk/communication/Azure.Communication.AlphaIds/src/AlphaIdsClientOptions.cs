// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.AlphaIds
{
    /// <summary>
    /// The options for communication <see cref="AlphaIdsClient"/>.
    /// </summary>
    public class AlphaIdsClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Alpha ID service.
        /// </summary>
        ///
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_09_26_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaIdsClientOptions"/>.
        /// </summary>
        public AlphaIdsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2022_09_26_Preview => "2022-09-26-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Alpha ID service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Alpha ID service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2022_09_26_Preview = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
