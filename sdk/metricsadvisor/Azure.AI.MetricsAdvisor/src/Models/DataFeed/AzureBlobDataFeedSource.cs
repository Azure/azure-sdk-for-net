// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class AzureBlobDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString"> Azure Blob connection string. </param>
        /// <param name="container"> Container. </param>
        /// <param name="blobTemplate"> Blob Template. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is null. </exception>
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
