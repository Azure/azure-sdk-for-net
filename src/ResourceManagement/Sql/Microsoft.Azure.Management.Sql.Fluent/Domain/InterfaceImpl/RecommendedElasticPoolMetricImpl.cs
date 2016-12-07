// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class RecommendedElasticPoolMetricImpl 
    {
        /// <return>
        /// The DTUs (Database Transaction Units)
        /// See  https://azure.microsoft.com/en-us/documentation/articles/sql-database-what-is-a-dtu/.
        /// </return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.Dtu
        {
            get
            {
                return this.Dtu();
            }
        }

        /// <return>The time of metric (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.DateTimeProperty
        {
            get
            {
                return this.DateTimeProperty();
            }
        }

        /// <return>The size in gigabytes.</return>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.SizeGB
        {
            get
            {
                return this.SizeGB();
            }
        }
    }
}