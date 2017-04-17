// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    internal partial class ServiceTierAdvisorImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets or sets currentServiceLevelObjectiveId for service tier advisor.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjectiveId
        {
            get
            {
                return this.CurrentServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets or sets maxDtu for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxDtu
        {
            get
            {
                return this.MaxDtu();
            }
        }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodEnd
        {
            get
            {
                return this.ObservationPeriodEnd();
            }
        }

        /// <summary>
        /// Gets or sets databaseSizeBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets or sets avgDtu for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.AvgDtu
        {
            get
            {
                return this.AvgDtu();
            }
        }

        /// <summary>
        /// Gets or sets databaseSizeBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjective
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the observation period start (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodStart
        {
            get
            {
                return this.ObservationPeriodStart();
            }
        }

        /// <summary>
        /// Gets or sets overallRecommendationServiceLevelObjectiveId for service
        /// tier advisor.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets or sets maxSizeInGB for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxSizeInGB
        {
            get
            {
                return this.MaxSizeInGB();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets or sets disasterPlanBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets or sets currentServiceLevelObjective for service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjective
        {
            get
            {
                return this.CurrentServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets or sets disasterPlanBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets or sets minDtu for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MinDtu
        {
            get
            {
                return this.MinDtu();
            }
        }

        /// <summary>
        /// Gets serviceLevelObjectiveUsageMetrics for the service tier
        /// advisor.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface> Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ServiceLevelObjectiveUsageMetrics
        {
            get
            {
                return this.ServiceLevelObjectiveUsageMetrics() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface>;
            }
        }

        /// <summary>
        /// Gets the activeTimeRatio for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ActiveTimeRatio
        {
            get
            {
                return this.ActiveTimeRatio();
            }
        }

        /// <summary>
        /// Gets or sets confidence for service tier advisor.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.Confidence
        {
            get
            {
                return this.Confidence();
            }
        }

        /// <summary>
        /// Gets or sets usageBasedRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjective();
            }
        }
    }
}