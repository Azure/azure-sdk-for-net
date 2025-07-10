// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Benchmarks.Nuget
{
    /// <summary>
    /// Options for configuring the benchmark client.
    /// </summary>
    public class BenchmarkClientOptions : ClientOptions
    {
        /// <summary>
        /// The versions of the service supported by the client.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 1.0 of the service.
            /// </summary>
            V1_0 = 1,

            /// <summary>
            /// Version 2.0 of the service.
            /// </summary>
            V2_0 = 2
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenchmarkClientOptions"/> class with the specified service version.
        /// </summary>
        /// <param name="version">The service version to use.</param>
        public BenchmarkClientOptions(ServiceVersion version = ServiceVersion.V2_0) // Default to the latest supported version
        {
            Version = version;
        }

        /// <summary>
        /// Gets the service version used by this client.
        /// </summary>
        public ServiceVersion Version { get; }
    }
}
