// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class LogAnalyticsDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="query"></param>
        public LogAnalyticsDataFeedSource(string workspaceId, string query)
            : base(DataFeedSourceType.AzureLogAnalytics)
        {
            Argument.AssertNotNullOrEmpty(workspaceId, nameof(workspaceId));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new AzureLogAnalyticsParameter(workspaceId, query);

            WorkspaceId = workspaceId;
            Query = query;
        }

        /// <summary>
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="query"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="tenantId"></param>
        public LogAnalyticsDataFeedSource(string workspaceId, string query, string clientId, string clientSecret, string tenantId)
            : base(DataFeedSourceType.AzureLogAnalytics)
        {
            Argument.AssertNotNullOrEmpty(workspaceId, nameof(workspaceId));
            Argument.AssertNotNullOrEmpty(query, nameof(query));
            Argument.AssertNotNullOrEmpty(clientId, nameof(clientId));
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));

            Parameter = new AzureLogAnalyticsParameter(workspaceId, query);

            WorkspaceId = workspaceId;
            Query = query;
            ClientId = clientId;
            ClientSecret = clientSecret;
            TenantId = tenantId;
        }

        internal LogAnalyticsDataFeedSource(AzureLogAnalyticsParameter parameter)
            : base(DataFeedSourceType.AzureLogAnalytics)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            Parameter = parameter;

            WorkspaceId = parameter.WorkspaceId;
            Query = parameter.Query;
            ClientId = parameter.ClientId;
            ClientSecret = parameter.ClientSecret;
            TenantId = parameter.TenantId;
        }

        /// <summary>
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// </summary>
        internal string ClientSecret { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="clientSecret"></param>
        public void UpdateClientSecret(string clientSecret)
        {
            Argument.AssertNotNullOrEmpty(clientSecret, nameof(clientSecret));

            ClientSecret = clientSecret;
        }
    }
}
