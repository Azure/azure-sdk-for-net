// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Metrics
{
    public partial class MetricsClientOptions
    {
        /// <summary>
        /// Gets or sets the audience to use for authentication with Microsoft Entra ID.
        /// </summary>
        /// <value>If <c>null</c>, <see cref="MetricsClientAudience.AzurePublicCloud" /> will be assumed.</value>
        public MetricsClientAudience? Audience { get; set; }
    }
}
