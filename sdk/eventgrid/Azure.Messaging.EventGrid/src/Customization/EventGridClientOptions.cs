// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service.
    /// </summary>
    public class EventGridClientOptions : ClientOptions
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
        /// Initializes a new instance of the <see cref="EventGridClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public EventGridClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }


        internal string GetVersionString()
        {
            switch (Version)
            {
                case ServiceVersion.V2018_01_01:
                    return "2018-01-01";

                default:
                    throw new ArgumentException($"Version {Version.ToString()} not supported.");
            }
        }
    }
}
