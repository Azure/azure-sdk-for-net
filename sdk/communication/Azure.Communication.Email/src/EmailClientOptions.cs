// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Communication.Email
{
    /// <summary>
    /// The options for communication <see cref="EmailClient"/>.
    /// </summary>
    public class EmailClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Email service.
        /// </summary>
        ///
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_01_15_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailClientOptions"/>.
        /// </summary>
        public EmailClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_10_01_Preview => "2021-10-01-preview",
                ServiceVersion.V2023_01_15_Preview => "2023-01-15-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Email service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The V1 of the Email service.
            /// </summary>
            V2021_10_01_Preview = 1,
            /// <summary>
            /// The V1 of the Email service.
            /// </summary>
            V2023_01_15_Preview = 2
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
