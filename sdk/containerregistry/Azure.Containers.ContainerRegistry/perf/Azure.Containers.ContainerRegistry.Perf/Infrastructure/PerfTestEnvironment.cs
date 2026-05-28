// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Perf
{
    /// <summary>
    /// Represents the ambient environment in which the test suite is being run, offering access to information such as environment variables.
    /// </summary>
    internal sealed class PerfTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        /// The endpoint of the Container Registry resource to test against.
        /// </summary>
        /// <value>The endpoint, read from the "CONTAINERREGISTRY_ENDPOINT" environment variable.</value>
        public string Endpoint => GetVariable("CONTAINERREGISTRY_ENDPOINT");

        /// <summary>
        /// The name of the registry to test against.
        /// </summary>
        /// <value>The registry name, read from the "CONTAINERREGISTRY_REGISTRY_NAME" environment variable.</value>
        public string Registry => GetVariable("CONTAINERREGISTRY_REGISTRY_NAME");
    }
}
