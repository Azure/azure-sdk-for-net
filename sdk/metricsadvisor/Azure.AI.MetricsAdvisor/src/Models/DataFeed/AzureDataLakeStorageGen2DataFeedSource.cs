// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class AzureDataLakeStorageGen2DataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStorageGen2DataFeedSource"/> class.
        /// </summary>
        /// <param name="accountName"> Account name. </param>
        /// <param name="accountKey"> Account key. </param>
        /// <param name="fileSystemName"> File system name (Container). </param>
        /// <param name="directoryTemplate"> Directory template. </param>
        /// <param name="fileTemplate"> File template. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/>, <paramref name="accountKey"/>, <paramref name="fileSystemName"/>, <paramref name="directoryTemplate"/>, or <paramref name="fileTemplate"/> is null. </exception>
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
