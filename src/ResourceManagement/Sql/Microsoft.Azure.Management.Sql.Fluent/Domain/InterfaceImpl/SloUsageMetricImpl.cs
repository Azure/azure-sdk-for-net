// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    internal partial class SloUsageMetricImpl 
    {
        /// <summary>
        /// Gets the serviceLevelObjective for SLO usage metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets the serviceLevelObjectiveId for SLO usage metric.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.ServiceLevelObjectiveId
        {
            get
            {
                return this.ServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets inRangeTimeRatio for SLO usage metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.InRangeTimeRatio
        {
            get
            {
                return this.InRangeTimeRatio();
            }
        }
    }
}