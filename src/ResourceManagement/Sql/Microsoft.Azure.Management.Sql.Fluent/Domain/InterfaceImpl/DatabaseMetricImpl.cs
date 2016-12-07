// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class DatabaseMetricImpl 
    {
        /// <return>The current limit of the metric.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.Limit
        {
            get
            {
                return this.Limit();
            }
        }

        /// <return>The metric display name.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.DisplayName
        {
            get
            {
                return this.DisplayName() as string;
            }
        }

        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.ResourceName
        {
            get
            {
                return this.ResourceName() as string;
            }
        }

        /// <return>The current value of the metric.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.CurrentValue
        {
            get
            {
                return this.CurrentValue();
            }
        }

        /// <return>The units of the metric.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.Unit
        {
            get
            {
                return this.Unit() as string;
            }
        }

        /// <return>The next reset time for the metric (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric.NextResetTime
        {
            get
            {
                return this.NextResetTime();
            }
        }
    }
}