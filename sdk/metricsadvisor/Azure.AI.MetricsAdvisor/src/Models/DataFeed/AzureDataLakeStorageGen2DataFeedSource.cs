// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Data Lake Storage Gen2 data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureDataLakeStorageGen2DataFeedSource : DataFeedSource
    {
        // TODODOCS.
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageGen2DataFeedSource"/> class.
        /// </summary>
        /// <param name="accountName">The name of the Storage Account.</param>
        /// <param name="accountKey">The Storage Account key.</param>
        /// <param name="fileSystemName">The name of the file system.</param>
        /// <param name="directoryTemplate">The directory template.</param>
        /// <param name="fileTemplate"></param>
        /// <exception cref="ArgumentNullException"><paramref name="accountName"/>, <paramref name="accountKey"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="accountName"/>, <paramref name="accountKey"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is empty.</exception>
        public AzureDataLakeStorageGen2DataFeedSource(string accountName, string accountKey, string fileSystemName, string directoryTemplate, string fileTemplate)
            : base(DataFeedSourceType.AzureDataLakeStorageGen2)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));
            Argument.AssertNotNullOrEmpty(accountKey, nameof(accountKey));
            Argument.AssertNotNullOrEmpty(fileSystemName, nameof(fileSystemName));
            Argument.AssertNotNullOrEmpty(directoryTemplate, nameof(directoryTemplate));
            Argument.AssertNotNullOrEmpty(fileTemplate, nameof(fileTemplate));

            Parameter = new AzureDataLakeStorageGen2Parameter(accountName, accountKey, fileSystemName, directoryTemplate, fileTemplate);
        }
    }
}
