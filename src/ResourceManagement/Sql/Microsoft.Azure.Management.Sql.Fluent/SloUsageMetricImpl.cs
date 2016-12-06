// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Azure SQL Database's SloUsageMetric.
    /// </summary>
    internal partial class SloUsageMetricImpl :
        Wrapper<SloUsageMetricInner>,
        ISloUsageMetric
    {
        internal SloUsageMetricImpl(SloUsageMetricInner innerObject)
            : base(innerObject)
        {
        }

        public Guid ServiceLevelObjectiveId()
        {
            return this.Inner.ServiceLevelObjectiveId.GetValueOrDefault();
        }

        public string ServiceLevelObjective()
        {
            return this.Inner.ServiceLevelObjective;
        }

        public double InRangeTimeRatio()
        {
            return this.Inner.InRangeTimeRatio.GetValueOrDefault();
        }
    }
}