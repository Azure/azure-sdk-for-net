// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The options for communication <see cref="NotificationMessagesClient"/> and <see cref="MessageTemplateClient"/>.
    /// </summary>
    [CodeGenModel("AzureCommunicationMessagesClientOptions")]
    public partial class CommunicationMessagesClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Chat service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2024_02_01;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationMessagesClientOptions"/>.
        /// </summary>
        public CommunicationMessagesClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2023_08_24_Preview => "2023-08-24-preview",
                ServiceVersion.V2024_02_01 => "2024-02-01",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Messages service version.
        /// </summary>
        public enum ServiceVersion
        {
            #pragma warning disable CA1707 // Identifiers should not contain underscores
            #pragma warning disable AZC0016 // Invalid ServiceVersion member name.
            /// <summary>
            /// Service version "2023-08-24-preview".
            /// </summary>
            V2023_08_24_Preview = 1,
            /// <summary>
            /// Service version "2024-02-01".
            /// </summary>
            V2024_02_01 = 2
            #pragma warning restore AZC0016 // Invalid ServiceVersion member name.
            #pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
