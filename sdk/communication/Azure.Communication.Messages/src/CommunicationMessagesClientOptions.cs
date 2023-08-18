// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The options for communication <see cref="NotificationMessagesClient"/> and <see cref="MessageTemplateClient"/>.
    /// </summary>
    public class CommunicationMessagesClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Chat service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_08_24_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMessagesClientOptions"/>.
        /// </summary>
        public CommunicationMessagesClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2023_08_24_Preview => "2023-08-24-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Messages service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Messages service.
            /// </summary>
            #pragma warning disable CA1707 // Identifiers should not contain underscores
            #pragma warning disable AZC0016 // Invalid ServiceVersion member name.
            V2023_08_24_Preview = 1
            #pragma warning restore AZC0016 // Invalid ServiceVersion member name.
            #pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
