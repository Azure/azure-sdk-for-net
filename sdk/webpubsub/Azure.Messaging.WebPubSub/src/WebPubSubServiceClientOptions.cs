// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    /// <summary>
    /// The options for <see cref="WebPubSubServiceClientOptions"/>
    /// </summary>
    public class WebPubSubServiceClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPubSubServiceClientOptions"/>.
        /// </summary>
        public WebPubSubServiceClientOptions(ServiceVersion version = ServiceVersion.V2020_10_01_beta)
        {
            Version = version switch
            {
                ServiceVersion.V2020_10_01_beta => "2020.10.01",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The version 1.0 beta of the secret service.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V2020_10_01_beta = 1
#pragma warning restore
        }
    }
}
