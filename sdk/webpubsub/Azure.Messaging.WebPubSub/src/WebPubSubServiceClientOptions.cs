// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// The options for <see cref="WebPubSubServiceClient"/>.
    /// </summary>
    public class WebPubSubServiceClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClientOptions"/>.
        /// </summary>
        /// <param name="version">Service API version</param>
        public WebPubSubServiceClientOptions(ServiceVersion version = ServiceVersion.V2021_05_01)
        {
            Version = version switch
            {
                ServiceVersion.V2021_05_01 => "2021-05-01-preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Azure Web PubSub service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The 2021.05.01 beta of Azure Web PubSub.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V2021_05_01 = 1
#pragma warning restore
        }
    }
}
