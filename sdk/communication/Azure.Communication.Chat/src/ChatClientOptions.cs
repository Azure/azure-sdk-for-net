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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_03_01_Preview5;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatClientOptions"/>.
        /// </summary>
        public ChatClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_01_Preview5 => "2021-03-01-preview5",
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
            V2021_03_01_Preview5 = 1
            #pragma warning restore CA1707 // Identifiers should not contain underscores

        }
    }
}
