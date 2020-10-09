// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Learn.AppConfig
{
    /// <summary>The options for <see cref="ConfigurationClient"/>.</summary>
    public class ConfigurationClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>Initializes a new instance of the <see cref="ConfigurationClientOptions"/>.</summary>
        public ConfigurationClientOptions(ServiceVersion version = ServiceVersion.V1_0)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>The AppConfig service version.</summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary> Version 1.0 of the AppConfig service. </summary>
            V1_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
