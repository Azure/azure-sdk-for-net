// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Describes an Azure Application Insights data source which ingests data into a <see cref="DataFeed"/> for anomaly detection.
    /// </summary>
    public class AzureApplicationInsightsDataFeedSource : DataFeedSource
    {
        private string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureApplicationInsightsDataFeedSource"/> class.
        /// </summary>
        /// <param name="applicationId">The Application ID.</param>
        /// <param name="apiKey">The API key.</param>
        /// <param name="azureCloud">The Azure cloud environment.</param>
        /// <param name="query">The query used to filter the data to be ingested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="applicationId"/>, <paramref name="apiKey"/>, <paramref name="azureCloud"/>, or <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="applicationId"/>, <paramref name="apiKey"/>, <paramref name="azureCloud"/>, or <paramref name="query"/> is empty.</exception>
        public AzureApplicationInsightsDataFeedSource(string applicationId, string apiKey, string azureCloud, string query)
            : base(DataFeedSourceKind.AzureApplicationInsights)
        {
            Argument.AssertNotNullOrEmpty(applicationId, nameof(applicationId));
            Argument.AssertNotNullOrEmpty(azureCloud, nameof(azureCloud));
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            ApplicationId = applicationId;
            ApiKey = apiKey;
            AzureCloud = azureCloud;
            Query = query;
        }

        internal AzureApplicationInsightsDataFeedSource(AzureApplicationInsightsParameter parameter)
            : base(DataFeedSourceKind.AzureApplicationInsights)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            ApplicationId = parameter.ApplicationId;
            ApiKey = parameter.ApiKey;
            AzureCloud = parameter.AzureCloud;
            Query = parameter.Query;
        }

        /// <summary>
        /// The Application ID.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// The Azure cloud environment.
        /// </summary>
        public string AzureCloud { get; set; }

        /// <summary>
        /// The query used to filter the data to be ingested.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The API key.
        /// </summary>
        internal string ApiKey
        {
            get => Volatile.Read(ref _apiKey);
            private set => Volatile.Write(ref _apiKey, value);
        }

        /// <summary>
        /// Updates the API key.
        /// </summary>
        /// <param name="apiKey">The new API key to be used for authentication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="apiKey"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="apiKey"/> is empty.</exception>
        public void UpdateApiKey(string apiKey)
        {
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
            ApiKey = apiKey;
        }
    }
}
