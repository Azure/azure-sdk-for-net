// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;

    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class ServiceTierAdvisorImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor;
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }

        /// <return>Or sets minDtu for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MinDtu
        {
            get
            {
                return this.MinDtu();
            }
        }

        /// <return>
        /// Or sets usageBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <return>
        /// Or sets databaseSizeBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <return>Or sets confidence for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.Confidence
        {
            get
            {
                return this.Confidence();
            }
        }

        /// <return>Or sets currentServiceLevelObjective for service tier advisor.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjective
        {
            get
            {
                return this.CurrentServiceLevelObjective() as string;
            }
        }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodStart
        {
            get
            {
                return this.ObservationPeriodStart();
            }
        }

        /// <return>The activeTimeRatio for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ActiveTimeRatio
        {
            get
            {
                return this.ActiveTimeRatio();
            }
        }

        /// <return>Or sets avgDtu for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.AvgDtu
        {
            get
            {
                return this.AvgDtu();
            }
        }

        /// <return>Or sets maxDtu for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxDtu
        {
            get
            {
                return this.MaxDtu();
            }
        }

        /// <return>
        /// Or sets overallRecommendationServiceLevelObjectiveId for service
        /// tier advisor.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjectiveId();
            }
        }

        /// <return>
        /// Or sets disasterPlanBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjective() as string;
            }
        }

        /// <return>
        /// ServiceLevelObjectiveUsageMetrics for the service tier
        /// advisor.
        /// </return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric> Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ServiceLevelObjectiveUsageMetrics
        {
            get
            {
                return this.ServiceLevelObjectiveUsageMetrics() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric>;
            }
        }

        /// <return>
        /// Or sets overallRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.OverallRecommendationServiceLevelObjective
        {
            get
            {
                return this.OverallRecommendationServiceLevelObjective() as string;
            }
        }

        /// <return>Or sets currentServiceLevelObjectiveId for service tier advisor.</return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.CurrentServiceLevelObjectiveId
        {
            get
            {
                return this.CurrentServiceLevelObjectiveId();
            }
        }

        /// <return>Or sets maxSizeInGB for service tier advisor.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.MaxSizeInGB
        {
            get
            {
                return this.MaxSizeInGB();
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>
        /// Or sets disasterPlanBasedRecommendationServiceLevelObjectiveId for
        /// service tier advisor.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DisasterPlanBasedRecommendationServiceLevelObjectiveId
        {
            get
            {
                return this.DisasterPlanBasedRecommendationServiceLevelObjectiveId();
            }
        }

        /// <return>
        /// Or sets usageBasedRecommendationServiceLevelObjective for service
        /// tier advisor.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.UsageBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.UsageBasedRecommendationServiceLevelObjective() as string;
            }
        }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }

        /// <return>
        /// Or sets databaseSizeBasedRecommendationServiceLevelObjective for
        /// service tier advisor.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.DatabaseSizeBasedRecommendationServiceLevelObjective
        {
            get
            {
                return this.DatabaseSizeBasedRecommendationServiceLevelObjective() as string;
            }
        }

        /// <return>The observation period start (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor.ObservationPeriodEnd
        {
            get
            {
                return this.ObservationPeriodEnd();
            }
        }
    }
}