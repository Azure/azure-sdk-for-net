// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Replication link.
    /// </summary>
    public interface IRecommendedElasticPoolMetric  :
        IWrapper<Models.RecommendedElasticPoolMetric>
    {
        /// <return>The size in gigabytes.</return>
        double SizeGB { get; }

        /// <return>The time of metric (ISO8601 format).</return>
        System.DateTime DateTimeProperty { get; }

        /// <return>
        /// The DTUs (Database Transaction Units)
        /// See  https://azure.microsoft.com/en-us/documentation/articles/sql-database-what-is-a-dtu/.
        /// </return>
        double Dtu { get; }
    }
}