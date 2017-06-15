// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL DatabaseMetric.
    /// </summary>
    public interface IDatabaseMetric  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.DatabaseMetric>
    {
        /// <summary>
        /// Gets the units of the metric.
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Gets the metric display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the current limit of the metric.
        /// </summary>
        double Limit { get; }

        /// <summary>
        /// Gets the next reset time for the metric (ISO8601 format).
        /// </summary>
        System.DateTime NextResetTime { get; }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string ResourceName { get; }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double CurrentValue { get; }
    }
}