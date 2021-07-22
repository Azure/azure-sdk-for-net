// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The options for communication <see cref="CallConnection"/> and <see cref="ServerCall"/>.
    /// </summary>
    public class CallingServerClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the CallingServer service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_06_15_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerClientOptions"/>.
        /// </summary>
        public CallingServerClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_06_15_Preview => "2021-06-15-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The CallingServer service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The Beta of the CallingServer service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_06_15_Preview = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
