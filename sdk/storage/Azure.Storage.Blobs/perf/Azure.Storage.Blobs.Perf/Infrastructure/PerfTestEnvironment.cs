// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Storage.Blobs.Perf
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
        /// The name of the Blob storage account to test against.
        /// </summary>
        /// <value>The Blob storage account name, read from the "AZURE_STORAGE_ACCOUNT_NAME" environment variable.</value>
        public string StorageAccountName => GetVariable("AZURE_STORAGE_ACCOUNT_NAME");

        /// <summary>
        /// The shared access key of the Blob storage account to test against.
        /// </summary>
        /// <value>The Blob storage account key, read from the "AZURE_STORAGE_ACCOUNT_KEY" environment variable.</value>
        public string StorageAccountKey => GetOptionalVariable("AZURE_STORAGE_ACCOUNT_KEY");

        public bool StorageUseManagedIdentity
        {
            get
            {
                string useManagedIdentity = GetOptionalVariable("AZURE_STORAGE_USE_MANAGED_IDENTITY");
                if (bool.TryParse(useManagedIdentity, out bool result))
                {
                    return result;
                }
                return false;
            }
        }

        /// <summary>
        /// The Blob storage endpoint.
        /// </summary>
        public Uri StorageEndpoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        public PerfTestEnvironment()
        {
            StorageEndpoint = new Uri($"https://{StorageAccountName}.blob.{StorageEndpointSuffix}");
        }
    }
}
