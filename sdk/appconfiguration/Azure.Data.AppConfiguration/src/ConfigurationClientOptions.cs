// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

[assembly: CodeGenSuppressType("ConfigurationClientOptions")]
namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Options that allow users to configure the requests sent to the App Configuration service.
    /// </summary>
    public partial class ConfigurationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary>
        /// The versions of the App Configuration service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 1.0.
            /// </summary>
            V1_0 = 0,

            ///// <summary>
            ///// Version 2022-11-01-preview.
            ///// </summary>
            //V2022_11_01_Preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        internal string Version { get; }

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
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
                // ServiceVersion.V2022_11_01_Preview => "2022-11-01-preview",

                _ => throw new NotSupportedException()
            };
            this.ConfigureLogging();
        }
    }
}
