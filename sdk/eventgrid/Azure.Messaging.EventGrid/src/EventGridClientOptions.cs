// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    ///
    /// </summary>
    public class EventGridClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V2_0_Preview;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventGridClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version of the service to send requests to.</param>
        public EventGridClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version;
        }
        /// <summary>
        ///
        /// </summary>
        public ServiceVersion Version { get; set; }
        /// <summary>
        /// The template service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the template service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2_0_Preview = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
