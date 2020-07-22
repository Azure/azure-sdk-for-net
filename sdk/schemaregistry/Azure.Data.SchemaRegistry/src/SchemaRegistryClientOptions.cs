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
        public SchemaRegistryClientOptions(ServiceVersion version = ServiceVersion.V1_0)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };
        }

        /// <summary>
        /// The Schema Registry service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The 1.0 of the Schema Registry service.
            /// </summary>
#pragma warning disable CA1707 // Remove the underscores from member name
            V1_0 = 1
#pragma warning restore
        }
    }
}
