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
        public const ServiceVersion LatestVersion = ServiceVersion.V2021_01_27_Preview4;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatClientOptions"/>.
        /// </summary>
        public ChatClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_01_27_Preview4 => "2021-01-27-preview4",
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
            V2021_01_27_Preview4 = 1
            #pragma warning restore CA1707 // Identifiers should not contain underscores

        }
    }
}
