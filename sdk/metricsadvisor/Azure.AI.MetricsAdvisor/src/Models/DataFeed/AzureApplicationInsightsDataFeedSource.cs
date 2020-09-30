// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A Data feed source.
    /// </summary>
    public class AzureApplicationInsightsDataFeedSource : DataFeedSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureApplicationInsightsDataFeedSource"/> class.
        /// </summary>
        /// <param name="azureCloud"> Azure cloud environment. </param>
        /// <param name="applicationId"> Azure Application Insights ID. </param>
        /// <param name="apiKey"> API Key. </param>
        /// <param name="query"> Query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="azureCloud"/>, <paramref name="applicationId"/>, <paramref name="apiKey"/>, or <paramref name="query"/> is null. </exception>
        public AzureApplicationInsightsDataFeedSource(string azureCloud, string applicationId, string apiKey, string query)
            : base(DataFeedSourceType.AzureApplicationInsights)
        {
            Argument.AssertNotNullOrEmpty(azureCloud, nameof(azureCloud));
            Argument.AssertNotNullOrEmpty(applicationId, nameof(applicationId));
            Argument.AssertNotNullOrEmpty(apiKey, nameof(apiKey));
            Argument.AssertNotNullOrEmpty(query, nameof(query));

            Parameter = new AzureApplicationInsightsParameter(azureCloud, applicationId, apiKey, query);
        }
    }
}
