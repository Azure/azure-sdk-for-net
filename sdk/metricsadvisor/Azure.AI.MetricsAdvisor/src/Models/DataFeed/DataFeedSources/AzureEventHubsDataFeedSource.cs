// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Event Hubs data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureEventHubsDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureEventHubsDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for authenticating to the Azure Event Hubs resource.</param>
        /// <param name="consumerGroup">The Azure Event Hubs consumer group to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="consumerGroup"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="consumerGroup"/> is empty.</exception>
        public AzureEventHubsDataFeedSource(string connectionString, string consumerGroup)
            : base(DataFeedSourceKind.AzureEventHubs)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));

            ConnectionString = connectionString;
            ConsumerGroup = consumerGroup;
        }

        internal AzureEventHubsDataFeedSource(AzureEventHubsParameter parameter)
            : base(DataFeedSourceKind.AzureEventHubs)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            ConsumerGroup = parameter.ConsumerGroup;
        }

        /// <summary>
        /// The Azure Event Hubs consumer group to use.
        /// </summary>
        public string ConsumerGroup { get; set; }

        /// <summary>
        /// The connection string for authenticating to the Azure Event Hubs resource.
        /// </summary>
        internal string ConnectionString
        {
            get => Volatile.Read(ref _connectionString);
            private set => Volatile.Write(ref _connectionString, value);
        }

        /// <summary>
        /// Updates the connection string.
        /// </summary>
        /// <param name="connectionString">The new connection string to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> is empty.</exception>
        public void UpdateConnectionString(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }
    }
}
