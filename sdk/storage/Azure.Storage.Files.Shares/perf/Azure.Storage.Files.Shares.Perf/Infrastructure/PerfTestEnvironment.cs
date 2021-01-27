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
        ///   The storage account endpoint suffix of the cloud to use for testing.
        /// </summary>
        public new string StorageEndpointSuffix => base.StorageEndpointSuffix ?? "core.windows.net";

        /// <summary>
        /// The name of the Files Shares storage account to test against.
        /// </summary>
        /// <value>The Files Shares storage account name, read from the "AZURE_STORAGE_ACCOUNT_NAME" environment variable.</value>
        public string FilesSharesAccountName => GetVariable("AZURE_STORAGE_ACCOUNT_NAME");

        /// <summary>
        /// The shared access key of the Files Shares storage account to test against.
        /// </summary>
        /// <value>The Files Shares storage account key, read from the "AZURE_STORAGE_ACCOUNT_KEY" environment variable.</value>
        public string FilesSharesAccountKey => GetVariable("AZURE_STORAGE_ACCOUNT_KEY");

        /// <summary>
        /// The connection string for accessing the Files Shares storage account used for testing.
        /// </summary>
        public string FileSharesConnectionString { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        public PerfTestEnvironment()
        {
            FileSharesConnectionString = $"DefaultEndpointsProtocol={Uri.UriSchemeHttps};AccountName={FilesSharesAccountName};AccountKey={FilesSharesAccountKey};EndpointSuffix={StorageEndpointSuffix}";
        }
    }
}
