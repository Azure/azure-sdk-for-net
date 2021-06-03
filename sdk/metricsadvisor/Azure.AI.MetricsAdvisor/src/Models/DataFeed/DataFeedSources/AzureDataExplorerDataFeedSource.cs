// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Describes an Azure Data Explorer data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureDataExplorerDataFeedSource : DataFeedSource
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataExplorerDataFeedSource"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectionString"/> or <paramref name="query"/> is empty.</exception>
        public AzureDataExplorerDataFeedSource(string connectionString, string query)
            : base(DataFeedSourceType.AzureDataExplorer)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ConnectionString = connectionString;
            Query = query;
        }

        internal AzureDataExplorerDataFeedSource(SqlSourceParameter parameter)
            : base(DataFeedSourceType.AzureDataExplorer)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ConnectionString = parameter.ConnectionString;
            Query = parameter.Query;
        }

        /// <summary>
        /// </summary>
        public enum AuthenticationType
        {
            /// <summary>
            /// </summary>
            Basic,
            /// <summary>
            /// </summary>
            ManagedIdentity,
            /// <summary>
            /// </summary>
            ServicePrincipal,
            /// <summary>
            /// </summary>
            ServicePrincipalInKeyVault
        };

        /// <summary>
        /// </summary>
        public AuthenticationType Authentication { get; set; }

        /// <summary>
        /// </summary>
        public string DatasourceCredentialId { get; set; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The connection string.
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
