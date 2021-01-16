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
        public SchemaRegistryClientOptions(ServiceVersion version = ServiceVersion.V2020_09_01_preview)
        {
            Version = version switch
            {
                ServiceVersion.V2017_04 => "2017-04",
                ServiceVersion.V2020_09_01_preview => "2020-09-01-preview",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Schema Registry service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 2017-04 of the Schema Registry service.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V2017_04 = 1,
            /// <summary>
            /// Version 2020-09-01-preview of the Schema Registry service.
            /// </summary>
            V2020_09_01_preview = 2
#pragma warning restore
        }
    }
}
