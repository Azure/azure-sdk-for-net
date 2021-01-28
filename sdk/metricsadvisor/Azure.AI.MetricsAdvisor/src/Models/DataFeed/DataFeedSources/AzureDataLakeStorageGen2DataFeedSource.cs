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
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageGen2DataFeedSource"/> class.
        /// </summary>
        /// <param name="accountName">The name of the Storage Account.</param>
        /// <param name="accountKey">The Storage Account key.</param>
        /// <param name="fileSystemName">The name of the file system.</param>
        /// <param name="directoryTemplate">The directory template.</param>
        /// <param name="fileTemplate">
        /// This is the file template of the Blob file. For example: X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
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

            AccountName = accountName;
            AccountKey = accountKey;
            FileSystemName = fileSystemName;
            DirectoryTemplate = directoryTemplate;
            FileTemplate = fileTemplate;
        }

        internal AzureDataLakeStorageGen2DataFeedSource(AzureDataLakeStorageGen2Parameter parameter)
            : base(DataFeedSourceType.AzureDataLakeStorageGen2)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            AccountName = parameter.AccountName;
            AccountKey = parameter.AccountKey;
            FileSystemName = parameter.FileSystemName;
            DirectoryTemplate = parameter.DirectoryTemplate;
            FileTemplate = parameter.FileTemplate;
        }

        /// <summary>
        /// The name of the Storage Account.
        /// </summary>
        public string AccountName { get; }

        /// <summary>
        /// The Storage Account key.
        /// </summary>
        public string AccountKey { get; }

        /// <summary>
        /// The name of the file system.
        /// </summary>
        public string FileSystemName { get; }

        /// <summary>
        /// The directory template.
        /// </summary>
        public string DirectoryTemplate { get; }

        /// <summary>
        /// This is the file template of the Blob file. For example: X_%Y-%m-%d-%h-%M.json. The following parameters are supported:
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
        public string FileTemplate { get; }
    }
}
