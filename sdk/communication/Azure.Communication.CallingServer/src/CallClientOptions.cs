// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The options for communication <see cref="CallClient"/>.
    /// </summary>
    public class CallClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the CallingServer service.
        /// </summary>
        public const ServiceVersion LatestVersion = ServiceVersion.V2021_04_15_Preview1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallClientOptions"/>.
        /// </summary>
        public CallClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_04_15_Preview1 => "2021-04-15-preview1",
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
            V2021_04_15_Preview1 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
