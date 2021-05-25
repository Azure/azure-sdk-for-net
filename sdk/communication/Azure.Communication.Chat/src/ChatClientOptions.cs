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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_04_05_preview6;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatClientOptions"/>.
        /// </summary>
        public ChatClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_04_05_preview6 => "2021-04-05-preview6",
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
            /// The V2021_04_05_preview6 of the Chat service.
            /// </summary>
            V2021_04_05_preview6 = 2,
            #pragma warning restore CA1707 // Identifiers should not contain underscores

        }
    }
}
