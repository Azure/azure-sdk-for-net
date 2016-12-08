// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for Azure SQL Database's service tier advisor.
    /// </summary>
    internal partial class ServiceTierAdvisorImpl :
        Wrapper<Models.ServiceTierAdvisorInner>,
        IServiceTierAdvisor
    {
        private ResourceId resourceId;
        private IDatabasesOperations databasesInner;
        private IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric> sloUsageMetrics;

        public string CurrentServiceLevelObjective()
        {
            return this.Inner.CurrentServiceLevelObjective.ToString();
        }

        public string DatabaseName()
        {
            return this.resourceId.Parent.Name;
        }

        public double AvgDtu()
        {
            return this.Inner.AvgDtu.GetValueOrDefault();
        }

        public Guid OverallRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.OverallRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        public double MinDtu()
        {
            return this.Inner.MinDtu.GetValueOrDefault();
        }

        public Guid DisasterPlanBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.DisasterPlanBasedRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        public IEnumerable<Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric> ServiceLevelObjectiveUsageMetrics()
        {
            if (sloUsageMetrics == null)
            {
                Func<SloUsageMetric, SloUsageMetricImpl> convertor
                    = (sloUsageMetricInner) => new SloUsageMetricImpl(sloUsageMetricInner);
                sloUsageMetrics = PagedListConverter.Convert(Inner.ServiceLevelObjectiveUsageMetrics, convertor);
            }

            return sloUsageMetrics;
        }

        public DateTime ObservationPeriodStart()
        {
            return this.Inner.ObservationPeriodStart.GetValueOrDefault();
        }

        public string Id()
        {
            return this.Inner.Id;
        }

        public string ResourceGroupName()
        {
            return this.resourceId.ResourceGroupName;
        }

        internal ServiceTierAdvisorImpl(ServiceTierAdvisorInner innerObject, IDatabasesOperations databasesInner)
            : base(innerObject)
        {
            this.resourceId = ResourceId.ParseResourceId(this.Inner.Id);
            this.databasesInner = databasesInner;
        }

        public string SqlServerName()
        {
            return this.resourceId.Parent.Parent.Name;
        }

        public string DatabaseSizeBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.DatabaseSizeBasedRecommendationServiceLevelObjective;
        }

        public string OverallRecommendationServiceLevelObjective()
        {
            return this.Inner.OverallRecommendationServiceLevelObjective;
        }

        public double Confidence()
        {
            return this.Inner.Confidence.GetValueOrDefault();
        }

        public IServiceTierAdvisor Refresh()
        {
            sloUsageMetrics = null;
            this.SetInner(this.databasesInner.GetServiceTierAdvisor(this.ResourceGroupName(), this.SqlServerName(), this.DatabaseName(), this.Name()));
            return this;
        }

        public Guid UsageBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.CurrentServiceLevelObjectiveId.GetValueOrDefault();
        }

        public double MaxDtu()
        {
            return this.Inner.MaxDtu.GetValueOrDefault();
        }

        public DateTime ObservationPeriodEnd()
        {
            return this.Inner.ObservationPeriodEnd.GetValueOrDefault();
        }

        public double ActiveTimeRatio()
        {
            return this.Inner.ActiveTimeRatio.GetValueOrDefault();
        }

        public Guid DatabaseSizeBasedRecommendationServiceLevelObjectiveId()
        {
            return this.Inner.DatabaseSizeBasedRecommendationServiceLevelObjectiveId.GetValueOrDefault();
        }

        public Guid CurrentServiceLevelObjectiveId()
        {
            return this.Inner.CurrentServiceLevelObjectiveId.GetValueOrDefault();
        }

        public string Name()
        {
            return this.Inner.Name;
        }

        public string DisasterPlanBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.DisasterPlanBasedRecommendationServiceLevelObjective;
        }

        public double MaxSizeInGB()
        {
            return this.Inner.MaxSizeInGB.GetValueOrDefault();
        }

        public string UsageBasedRecommendationServiceLevelObjective()
        {
            return this.Inner.UsageBasedRecommendationServiceLevelObjective;
        }
    }
}