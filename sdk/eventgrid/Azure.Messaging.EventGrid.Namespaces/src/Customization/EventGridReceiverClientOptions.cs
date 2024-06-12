﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    /// <summary>
    /// The options for <see cref="EventGridReceiverClient"/>.
    /// </summary>
    public class EventGridReceiverClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2024_06_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2023-11-01". </summary>
            V2023_11_01 = 1,
            /// <summary> Service version "2024-06-01". </summary>
            V2024_06_01 = 2,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AzureMessagingEventGridNamespacesClientOptions. </summary>
        public EventGridReceiverClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2023_11_01 => "2023-11-01",
                ServiceVersion.V2024_06_01 => "2024-06-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
