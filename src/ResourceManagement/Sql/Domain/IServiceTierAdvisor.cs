// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Service tier advisor.
    /// </summary>
    public interface IServiceTierAdvisor  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServiceTierAdvisorInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <summary>
        /// Gets or sets currentServiceLevelObjective for service tier advisor.
        /// </summary>
        string CurrentServiceLevelObjective { get; }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets or sets databaseSizeBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        string DatabaseSizeBasedRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </summary>
        string OverallRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets or sets avgDtu for service tier advisor.
        /// </summary>
        double AvgDtu { get; }

        /// <summary>
        /// Gets or sets confidence for service tier advisor.
        /// </summary>
        double Confidence { get; }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjectiveId for service
        /// tier advisor.
        /// </summary>
        System.Guid OverallRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets or sets minDtu for service tier advisor.
        /// </summary>
        double MinDtu { get; }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid UsageBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets or sets disasterPlanBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid DisasterPlanBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets or sets maxDtu for service tier advisor.
        /// </summary>
        double MaxDtu { get; }

        /// <summary>
        /// Gets serviceLevelObjectiveUsageMetrics for the service tier
        /// advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> ServiceLevelObjectiveUsageMetrics { get; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime ObservationPeriodEnd { get; }

        /// <summary>
        /// Gets the activeTimeRatio for service tier advisor.
        /// </summary>
        double ActiveTimeRatio { get; }

        /// <summary>
        /// Gets or sets databaseSizeBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid DatabaseSizeBasedRecommendationServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets or sets currentServiceLevelObjectiveId for service tier advisor.
        /// </summary>
        System.Guid CurrentServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime ObservationPeriodStart { get; }

        /// <summary>
        /// Gets or sets disasterPlanBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        string DisasterPlanBasedRecommendationServiceLevelObjective { get; }

        /// <summary>
        /// Gets or sets maxSizeInGB for service tier advisor.
        /// </summary>
        double MaxSizeInGB { get; }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </summary>
        string UsageBasedRecommendationServiceLevelObjective { get; }
    }
}