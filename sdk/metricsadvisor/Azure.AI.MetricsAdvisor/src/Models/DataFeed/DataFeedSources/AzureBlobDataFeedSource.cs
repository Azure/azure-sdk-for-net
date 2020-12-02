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
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Storage Account.</param>
        /// <param name="container">The name of the blob container.</param>
        /// <param name="blobTemplate">
        /// This is the template of the Blob file names. For example: /%Y/%m/X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
        /// <list type="bullet">
        /// <item>
        /// <term>%Y</term>
        /// <description>The year formatted as yyyy</description>
        /// </item>
        /// <item>
        /// <term>%m</term>
        /// <description>The month formatted as MM</description>
        /// </item>
        /// <item>
        /// <term>%d</term>
        /// <description>The day formatted as dd</description>
        /// </item>
        /// <item>
        /// <term>%h</term>
        /// <description>The hour formatted as HH</description>
        /// </item>
        /// <item>
        /// <term>%M</term>
        /// <description>The minute formatted as mm</description>
        /// </item>
        /// </list>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/>, <paramref name="container"/>, or <paramref name="blobTemplate"/> is empty.</exception>
        public AzureBlobDataFeedSource(string connectionString, string container, string blobTemplate)
            : base(DataFeedSourceType.AzureBlob)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(container, nameof(container));
            Argument.AssertNotNullOrEmpty(blobTemplate, nameof(blobTemplate));

            Parameter = new AzureBlobParameter(connectionString, container, blobTemplate);

            ConnectionString = connectionString;
            Container = container;
            BlobTemplate = blobTemplate;
        }

        internal AzureBlobDataFeedSource(AzureBlobParameter parameter)
            : base(DataFeedSourceType.AzureBlob)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            Container = parameter.Container;
            BlobTemplate = parameter.BlobTemplate;
        }

        /// <summary>
        /// The connection string for authenticating to the Azure Storage Account.
        /// </summary>
        public string ConnectionString { get; }

        /// <summary>
        /// The name of the blob container.
        /// </summary>
        public string Container { get; }

        /// <summary>
        /// This is the template of the Blob file names. For example: /%Y/%m/X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
        /// <list type="bullet">
        /// <item>
        /// <term>%Y</term>
        /// <description>The year formatted as yyyy</description>
        /// </item>
        /// <item>
        /// <term>%m</term>
        /// <description>The month formatted as MM</description>
        /// </item>
        /// <item>
        /// <term>%d</term>
        /// <description>The day formatted as dd</description>
        /// </item>
        /// <item>
        /// <term>%h</term>
        /// <description>The hour formatted as HH</description>
        /// </item>
        /// <item>
        /// <term>%M</term>
        /// <description>The minute formatted as mm</description>
        /// </item>
        /// </list>
        /// </summary>
        public string BlobTemplate { get; }
    }
}
