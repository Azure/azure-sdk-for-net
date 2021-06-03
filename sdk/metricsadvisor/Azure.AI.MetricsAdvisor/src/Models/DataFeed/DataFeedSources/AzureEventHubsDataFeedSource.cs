// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Event Hubs data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureEventHubsDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureEventHubsDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Event Hubs resource.</param>
        /// <param name="consumerGroup">The Azure Event Hubs consumer group to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="consumerGroup"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="consumerGroup"/> is empty.</exception>
        public AzureEventHubsDataFeedSource(string connectionString, string consumerGroup)
            : base(DataFeedSourceType.AzureEventHubs)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));

            Parameter = new AzureEventHubsParameter(connectionString, consumerGroup);

            ConnectionString = connectionString;
            ConsumerGroup = consumerGroup;
        }

        internal AzureEventHubsDataFeedSource(AzureEventHubsParameter parameter)
            : base(DataFeedSourceType.AzureEventHubs)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            ConnectionString = parameter.ConnectionString;
            ConsumerGroup = parameter.ConsumerGroup;
        }

        /// <summary>
        /// The Azure Event Hubs consumer group to use.
        /// </summary>
        public string ConsumerGroup { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            ConnectionString = connectionString;
        }

        /// <summary>
        /// The connection string for authenticating to the Azure Event Hubs resource.
        /// </summary>
        internal string ConnectionString { get; set; }
    }
}
