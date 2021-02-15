﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Identity
{
    /// <summary>
    /// The options for communication <see cref="CommunicationIdentityClientOptions"/>.
    /// </summary>
    public class CommunicationIdentityClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the identity service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_03_07;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClientOptions"/>.
        /// </summary>
        public CommunicationIdentityClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_07 => "2021-03-07",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The token service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V2021_03_07 of the identity service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_03_07 = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
