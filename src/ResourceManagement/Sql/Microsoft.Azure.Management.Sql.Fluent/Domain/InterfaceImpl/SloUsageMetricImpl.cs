// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    internal partial class SloUsageMetricImpl 
    {
        /// <summary>
        /// Gets the serviceLevelObjective for SLO usage metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective();
            }
        }

        /// <summary>
        /// Gets inRangeTimeRatio for SLO usage metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface.InRangeTimeRatio
        {
            get
            {
                return this.InRangeTimeRatio();
            }
        }

        /// <summary>
        /// Gets the serviceLevelObjectiveId for SLO usage metric.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISloUsageMetricInterface.ServiceLevelObjectiveId
        {
            get
            {
                return this.ServiceLevelObjectiveId();
            }
        }
    }
}