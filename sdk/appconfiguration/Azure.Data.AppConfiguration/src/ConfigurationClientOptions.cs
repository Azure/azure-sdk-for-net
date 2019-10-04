﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to the service
    /// </summary>
    public class ConfigurationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// The versions of App Config Service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Uses the latest service version
            /// </summary>
            V1_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public ConfigurationClientOptions(ServiceVersion version = LatestVersion)
        {
            this.Version = version;
        }

        internal string GetVersionString()
        {
            string version = string.Empty;

            switch (this.Version)
            {
                case ServiceVersion.V1_0:
                    version = "1.0";
                    break;

                default:
                    throw new ArgumentException(this.Version.ToString());
            }

            return version;
        }
    }
}
