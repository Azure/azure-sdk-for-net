// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Service tier advisor.
    /// </summary>
    public interface IServiceTierAdvisor  :
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>,
        IWrapper<Models.ServiceTierAdvisorInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>Or sets currentServiceLevelObjective for service tier advisor.</return>
        string CurrentServiceLevelObjective { get; }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string DatabaseName { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <return>
        /// Or sets databaseSizeBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </return>
        string DatabaseSizeBasedRecommendationServiceLevelObjective { get; }

        /// <return>
        /// Or sets overallRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </return>
        string OverallRecommendationServiceLevelObjective { get; }

        /// <return>Or sets avgDtu for service tier advisor.</return>
        double AvgDtu { get; }

        /// <return>Or sets confidence for service tier advisor.</return>
        double Confidence { get; }

        /// <return>
        /// Or sets overallRecommendationServiceLevelObjectiveId for service
        /// tier advisor.
        /// </return>
        System.Guid OverallRecommendationServiceLevelObjectiveId { get; }

        /// <return>Or sets minDtu for service tier advisor.</return>
        double MinDtu { get; }

        /// <return>
        /// Or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid UsageBasedRecommendationServiceLevelObjectiveId { get; }

        /// <return>
        /// Or sets disasterPlanBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid DisasterPlanBasedRecommendationServiceLevelObjectiveId { get; }

        /// <return>Or sets maxDtu for service tier advisor.</return>
        double MaxDtu { get; }

        /// <return>
        /// ServiceLevelObjectiveUsageMetrics for the service tier
        /// advisor.
        /// </return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric> ServiceLevelObjectiveUsageMetrics { get; }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime ObservationPeriodEnd { get; }

        /// <return>The activeTimeRatio for service tier advisor.</return>
        double ActiveTimeRatio { get; }

        /// <return>
        /// Or sets databaseSizeBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid DatabaseSizeBasedRecommendationServiceLevelObjectiveId { get; }

        /// <return>Or sets currentServiceLevelObjectiveId for service tier advisor.</return>
        System.Guid CurrentServiceLevelObjectiveId { get; }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime ObservationPeriodStart { get; }

        /// <return>
        /// Or sets disasterPlanBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </return>
        string DisasterPlanBasedRecommendationServiceLevelObjective { get; }

        /// <return>Or sets maxSizeInGB for service tier advisor.</return>
        double MaxSizeInGB { get; }

        /// <return>
        /// Or sets usageBasedRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </return>
        string UsageBasedRecommendationServiceLevelObjective { get; }
    }
}