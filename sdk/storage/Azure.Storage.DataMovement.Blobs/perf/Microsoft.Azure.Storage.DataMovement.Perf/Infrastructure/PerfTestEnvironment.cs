// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.Storage.DataMovement.Perf
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
        /// The storage account endpoint suffix to use for testing.
        /// </summary>
        public new string StorageEndpointSuffix => base.StorageEndpointSuffix ?? "core.windows.net";

        /// <summary>
        /// The name of the Blob storage account to test against.
        /// </summary>
        /// <value>The Blob storage account name, read from the "AZURE_STORAGE_ACCOUNT_NAME" environment variable.</value>
        public string StorageAccountName => GetVariable("AZURE_STORAGE_ACCOUNT_NAME");

        /// <summary>
        /// The shared access key of the Blob storage account to test against.
        /// </summary>
        /// <value>The Blob storage account key, read from the "AZURE_STORAGE_ACCOUNT_KEY" environment variable.</value>
        public string StorageAccountKey => GetVariable("AZURE_STORAGE_ACCOUNT_KEY");
    }
}
