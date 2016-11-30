// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;

    internal partial class SloUsageMetricImpl 
    {
        /// <return>The serviceLevelObjective for SLO usage metric.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective() as string;
            }
        }

        /// <return>The serviceLevelObjectiveId for SLO usage metric.</return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.ServiceLevelObjectiveId
        {
            get
            {
                return this.ServiceLevelObjectiveId();
            }
        }

        /// <return>InRangeTimeRatio for SLO usage metric.</return>
        double Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetric.InRangeTimeRatio
        {
            get
            {
                return this.InRangeTimeRatio();
            }
        }
    }
}