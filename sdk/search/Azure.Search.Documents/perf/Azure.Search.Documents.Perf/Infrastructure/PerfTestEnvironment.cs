// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Perf
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
        /// The name of the Azure Search account to test against.
        /// </summary>
        /// <value>The Azure Search account name, read from the "AZURE_SEARCH_ACCOUNT_NAME" environment variable.</value>
        public string SearchAccountName => GetVariable("AZURE_SEARCH_ACCOUNT_NAME");

        /// <summary>
        /// The shared access key of the Search account to test against.
        /// </summary>
        /// <value>The Search account key, read from the "AZURE_SEARCH_ACCOUNT_KEY" environment variable.</value>
        public string SearchAccountKey => GetVariable("AZURE_SEARCH_ACCOUNT_KEY");

        /// <summary>
        /// The connection string for accessing the Files Shares storage account used for testing.
        /// </summary>
        public string SearchConnectionString { get; }

        public string SearchEndPoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        public PerfTestEnvironment()
        {
            SearchEndPoint = $"{Uri.UriSchemeHttps}://{SearchAccountName}.search.windows.net";
        }
    }
}
