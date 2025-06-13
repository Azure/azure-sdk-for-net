// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Chat
{
    /// <summary>
    /// The options for communication <see cref="ChatClient"/>.
    /// </summary>
    public class ChatClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Chat service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2025_03_15;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatClientOptions"/>.
        /// </summary>
        public ChatClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_07 => "2021-03-07",
                ServiceVersion.V2021_09_07 => "2021-09-07",
                ServiceVersion.V2023_11_07 => "2023-11-07",
                ServiceVersion.V2024_03_07 => "2024-03-07",
                ServiceVersion.V2025_03_15 => "2025-03-15",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Chat service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Chat service.
            /// </summary>
            #pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_03_07 = 1,
            /// <summary>
            /// The V2021_09_07 of the Chat service.
            /// </summary>
            #pragma warning restore CA1707 // Identifiers should not contain underscores
            V2021_09_07 = 2,
            /// <summary>
            /// The V2023_11_07 of the Chat service.
            /// </summary>
            #pragma warning restore CA1707 // Identifiers should not contain underscores
            V2023_11_07 = 3,
            /// <summary>
            /// The V2024_03_07 of the Chat service.
            /// </summary>
            #pragma warning restore CA1707 // Identifiers should not contain underscores
            V2024_03_07 = 4,
            /// <summary>
            /// The V2025_03_15 of the Chat service.
            /// </summary>
            #pragma warning restore CA1707 // Identifiers should not contain underscores
            V2025_03_15 = 5
        }
    }
}
