// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;

namespace Azure.MixedReality.RemoteRendering.Tests
{
    public class RemoteRenderingTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("ARR_ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("ARR_ACCOUNT_ID");

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("ARR_ACCOUNT_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_SERVICE_ENDPOINT environment variable.
        /// </remarks>
        public string ServiceEndpoint => GetRecordedVariable("ARR_SERVICE_ENDPOINT");

        /// <summary>
        /// Gets the storage account name used by conversion tests.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_STORAGE_ACCOUNT_NAME environment variable.
        /// </remarks>
        public string StorageAccountName => GetRecordedVariable("ARR_STORAGE_ACCOUNT_NAME");

        /// <summary>
        /// Gets the blob container name used by the conversion tests.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_BLOB_CONTAINER_NAME environment variable.
        /// </remarks>
        public string BlobContainerName => GetRecordedVariable("ARR_BLOB_CONTAINER_NAME");

        /// <summary>
        /// Get a SAS token which entitles the service to access storage.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ARR_SAS_TOKEN environment variable.
        /// We use SAS for live testing, as there can be a delay before DRAM-based access is available.
        /// </remarks>
        public string SasToken => GetRecordedVariable("ARR_SAS_TOKEN", options => options.IsSecret());
    }
}
