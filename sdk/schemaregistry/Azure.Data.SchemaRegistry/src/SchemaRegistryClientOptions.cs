// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// The options for <see cref="SchemaRegistryClient"/>
    /// </summary>
    public class SchemaRegistryClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClientOptions"/>.
        /// </summary>
        public SchemaRegistryClientOptions(ServiceVersion version = ServiceVersion.V2023_07)
        {
            Version = version switch
            {
                ServiceVersion.V2021_10 => "2021-10",
                ServiceVersion.V2022_10 => "2022-10",
                ServiceVersion.V2023_07 => "2023-07-01",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Schema Registry service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2021-10 of the Schema Registry service.
            /// </summary>
#pragma warning disable CA1707
            V2021_10 = 1,

            /// <summary>
            /// Version 2022-10 of the Schema Registry service.
            /// </summary>
            V2022_10 = 2,

            /// <summary>
            /// Version 2023-07 of the Schema Registry service.
            /// </summary>
            V2023_07 = 3
#pragma warning restore CA1707
        }
    }
}
