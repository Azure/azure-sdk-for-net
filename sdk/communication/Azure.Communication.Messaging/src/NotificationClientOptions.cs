// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Messaging
{
    /// <summary>
    /// The options for communication <see cref="NotificationClient"/>.
    /// </summary>
    public class NotificationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Chat service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2022_06_30;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationClientOptions"/>.
        /// </summary>
        public NotificationClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2022_06_30 => "2022-06-30-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Messaging service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Messaging service.
            /// </summary>
            #pragma warning disable CA1707 // Identifiers should not contain underscores
            V2022_06_30 = 1
            #pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
