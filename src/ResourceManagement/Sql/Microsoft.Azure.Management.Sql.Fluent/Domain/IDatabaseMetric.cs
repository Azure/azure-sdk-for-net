// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL DatabaseMetric.
    /// </summary>
    public interface IDatabaseMetric  :
        IWrapper<Models.DatabaseMetric>
    {
        /// <return>The units of the metric.</return>
        string Unit { get; }

        /// <return>The metric display name.</return>
        string DisplayName { get; }

        /// <return>The current limit of the metric.</return>
        double Limit { get; }

        /// <return>The next reset time for the metric (ISO8601 format).</return>
        System.DateTime NextResetTime { get; }

        /// <return>The name of the resource.</return>
        string ResourceName { get; }

        /// <return>The current value of the metric.</return>
        double CurrentValue { get; }
    }
}