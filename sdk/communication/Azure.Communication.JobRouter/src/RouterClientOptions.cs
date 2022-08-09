// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// The options for communication <see cref="RouterClient"/>.
    /// </summary>
    public class RouterClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Router service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_07_18_preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouterClientOptions"/>.
        /// </summary>
        public RouterClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_10_20_preview2 => "2021-10-20-preview2",
                ServiceVersion.V2022_07_18_preview => "2022-07-18-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Router service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Router service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
            V2021_10_20_preview2 = 1,

            /// <summary>
            /// The V2 of the Router service.
            /// </summary>
            V2022_07_18_preview = 2
#pragma warning restore AZC0016 // All parts of ServiceVersion members' names must begin with a number or uppercase letter and cannot have consecutive underscores
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
