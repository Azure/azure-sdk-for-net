// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    internal partial class RecommendedElasticPoolMetricImpl 
    {
        /// <summary>
        /// Gets the DTUs (Database Transaction Units)
        /// See  https://azure.microsoft.com/en-us/documentation/articles/sql-database-what-is-a-dtu/.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.Dtu
        {
            get
            {
                return this.Dtu();
            }
        }

        /// <summary>
        /// Gets the time of metric (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.DateTimeProperty
        {
            get
            {
                return this.DateTimeProperty();
            }
        }

        /// <summary>
        /// Gets the size in gigabytes.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPoolMetric.SizeGB
        {
            get
            {
                return this.SizeGB();
            }
        }
    }
}