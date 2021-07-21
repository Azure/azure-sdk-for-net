// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes a Log Analytics data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class LogAnalyticsDataFeedSource : DataFeedSource
    {
        private string _clientSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogAnalyticsDataFeedSource"/> class.
        /// </summary>
        /// <param name="workspaceId">The workspace ID of the Log Analytics resource.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="workspaceId"/> or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="workspaceId"/> or <paramref name="query"/> is empty.</exception>
        public LogAnalyticsDataFeedSource(string workspaceId, string query)
            : base(DataFeedSourceKind.LogAnalytics)
        {
            Argument.AssertNotNullOrEmpty(workspaceId, nameof(workspaceId));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            WorkspaceId = workspaceId;
            Query = query;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogAnalyticsDataFeedSource"/> class.
        /// </summary>
        /// <param name="workspaceId">The workspace ID of the Log Analytics resource.</param>
        /// <param name="query">The query to retrieve the data to be ingested.</param>
        /// <param name="clientId">The client ID used for AAD authentication.</param>
        /// <param name="clientSecret">The client secret used for AAD authentication.</param>
        /// <param name="tenantId">The tenant ID used for AAD authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="workspaceId"/>, <paramref name="query"/>, <paramref name="clientId"/>, <paramref name="clientSecret"/>, or <paramref name="tenantId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="workspaceId"/>, <paramref name="query"/>, <paramref name="clientId"/>, <paramref name="clientSecret"/>, or <paramref name="tenantId"/> is empty.</exception>
        public LogAnalyticsDataFeedSource(string workspaceId, string query, string clientId, string clientSecret, string tenantId)
            : base(DataFeedSourceKind.LogAnalytics)
        {
            Argument.AssertNotNullOrEmpty(workspaceId, nameof(workspaceId));
            Argument.AssertNotNullOrEmpty(query, nameof(query));
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));

            WorkspaceId = workspaceId;
            Query = query;
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        internal LogAnalyticsDataFeedSource(AzureLogAnalyticsParameter parameter)
            : base(DataFeedSourceKind.LogAnalytics)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            WorkspaceId = parameter.WorkspaceId;
            Query = parameter.Query;
            ClientId = parameter.ClientId;
            ClientSecret = parameter.ClientSecret;
            TenantId = parameter.TenantId;
        }

        /// <summary>
        /// The workspace ID of the Log Analytics resource.
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// The query to retrieve the data to be ingested.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The client ID used for AAD authentication.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The tenant ID used for AAD authentication.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The client secret used for AAD authentication.
        /// </summary>
        internal string ClientSecret
        {
            get => Volatile.Read(ref _clientSecret);
            private set => Volatile.Write(ref _clientSecret, value);
        }

        /// <summary>
        /// Updates the client secret.
        /// </summary>
        /// <param name="clientSecret">The new connection string to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="clientSecret"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="clientSecret"/> is empty.</exception>
        public void UpdateClientSecret(string clientSecret)
        {
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            ClientSecret = clientSecret;
        }
    }
}
