// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's SloUsageMetric.
    /// </summary>
    public interface ISloUsageMetric  :
        IWrapper<Models.SloUsageMetricInner>
    {
        /// <return>The serviceLevelObjectiveId for SLO usage metric.</return>
        System.Guid ServiceLevelObjectiveId { get; }

        /// <return>The serviceLevelObjective for SLO usage metric.</return>
        string ServiceLevelObjective { get; }

        /// <return>InRangeTimeRatio for SLO usage metric.</return>
        double InRangeTimeRatio { get; }
    }
}