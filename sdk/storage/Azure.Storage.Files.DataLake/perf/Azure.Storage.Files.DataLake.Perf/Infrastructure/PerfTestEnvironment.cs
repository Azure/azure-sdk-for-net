// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Storage.Files.DataLake.Perf
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public sealed class PerfTestEnvironment : TestEnvironment
    {
        /// <summary>
        ///   The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        ///
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        ///   The storage account endpoint suffix of the cloud to use for testing.
        /// </summary>
        ///
        public new string StorageEndpointSuffix => base.StorageEndpointSuffix ?? "core.windows.net";

        /// <summary>
        ///   The name of the Data Lake storage account to test against.
        /// </summary>
        ///
        /// <value>The Data Lake storage account name, read from the "DATALAKE_STORAGE_ACCOUNT_NAME" environment variable.</value>
        ///
        public string DataLakeAccountName => GetVariable("DATALAKE_STORAGE_ACCOUNT_NAME");

        /// <summary>
        ///   The shared access key of the Data Lake storage account to test against.
        /// </summary>
        ///
        /// <value>The Data Lake storage account key, read from the "DATALAKE_STORAGE_ACCOUNT_KEY" environment variable.</value>
        ///
        public string DataLakeAccountKey => GetVariable("DATALAKE_STORAGE_ACCOUNT_KEY");

        /// <summary>
        ///   The fully-qualified URI for the Data Lake storage account to test against.
        /// </summary>
        ///
        public Uri DataLakeServiceUri { get; }

        /// <summary>
        ///   The credential for accessing the Data Lake storage account used for testing.
        /// </summary>
        ///
        /// <value>This credential is based on the configured Data Lake shared key.</value>
        ///
        public StorageSharedKeyCredential DataLakeCredential { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        ///
        public PerfTestEnvironment()
        {
            DataLakeServiceUri = new Uri($"{ Uri.UriSchemeHttps }{ Uri.SchemeDelimiter }{ DataLakeAccountName }.dfs.{ StorageEndpointSuffix }");
            DataLakeCredential = new StorageSharedKeyCredential(DataLakeAccountName, DataLakeAccountKey);
        }
    }
}
