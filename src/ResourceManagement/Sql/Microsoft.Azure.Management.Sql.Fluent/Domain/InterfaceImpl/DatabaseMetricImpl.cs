// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;

    internal partial class DatabaseMetricImpl 
    {
        /// <summary>
        /// Gets the current limit of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <summary>
        /// Gets the metric display name.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.DisplayName
        {
            get
            {
                return this.DisplayName();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.ResourceName
        {
            get
            {
                return this.ResourceName();
            }
        }

        /// <summary>
        /// Gets the current value of the metric.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <summary>
        /// Gets the units of the metric.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.Unit
        {
            get
            {
                return this.Unit();
            }
        }

        /// <summary>
        /// Gets the next reset time for the metric (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.NextResetTime
        {
            get
            {
                return this.NextResetTime();
            }
        }
    }
}