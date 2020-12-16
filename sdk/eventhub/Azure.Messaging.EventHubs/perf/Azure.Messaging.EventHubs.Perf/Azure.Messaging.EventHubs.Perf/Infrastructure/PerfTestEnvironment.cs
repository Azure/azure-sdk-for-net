// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Storage.Files.Shares.Perf
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
        /// The name of the EventHub to test against.
        /// </summary>
        /// <value>The Files Shares storage account name, read from the "AZURE_STORAGE_ACCOUNT_NAME" environment variable.</value>
        public string EventHubName => GetVariable("EVENTHUB_NAME");

        /// <summary>
        /// The connection string for accessing the Files Shares storage account used for testing.
        /// </summary>
        public string EventHubConnectionString => GetVariable("EVENTHUB_CONNECTION_STRING");

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        public PerfTestEnvironment() { }
    }
}
