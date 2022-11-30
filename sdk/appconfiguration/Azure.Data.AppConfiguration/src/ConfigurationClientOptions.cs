// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

[assembly: CodeGenSuppressType("ServiceVersion")]
namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Options that allow users to configure the requests sent to the App Configuration service.
    /// </summary>
    public partial class ConfigurationClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of the App Configuration service supported by this client library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Version 1.0.
            /// </summary>
            V1_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

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
                _ => throw new NotSupportedException()
            };
            this.ConfigureLogging();
        }
    }
}
