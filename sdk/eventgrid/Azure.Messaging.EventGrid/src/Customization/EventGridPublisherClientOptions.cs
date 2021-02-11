// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    public class EventGridPublisherClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2018_01_01;

        /// <summary>
        /// The versions of the Event Grid service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// API version "2018-01-01"
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2018_01_01 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        internal ServiceVersion Version { get; }

        /// <summary>
        /// Used to serialize the payloads of given events to UTF-8 encoded JSON.
        /// </summary>
        public ObjectSerializer Serializer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridPublisherClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public EventGridPublisherClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }
    }
}
