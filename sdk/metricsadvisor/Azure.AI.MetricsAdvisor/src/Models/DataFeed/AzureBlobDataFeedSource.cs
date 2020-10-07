// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Blob data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureBlobDataFeedSource : DataFeedSource
    {
        // TODODOCS.
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Storage Account.</param>
        /// <param name="container">The name of the blob container.</param>
        /// <param name="blobTemplate"></param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is empty.</exception>
        public AzureBlobDataFeedSource(string connectionString, string container, string blobTemplate)
            : base(DataFeedSourceType.AzureBlob)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(container, nameof(container));
            Argument.AssertNotNullOrEmpty(blobTemplate, nameof(blobTemplate));

            Parameter = new AzureBlobParameter(connectionString, container, blobTemplate);
        }
    }
}
