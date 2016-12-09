// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for RecommendedElasticPoolMetric interface.
    /// </summary>
    internal partial class RecommendedElasticPoolMetricImpl :
        Wrapper<Models.RecommendedElasticPoolMetric>,
        IRecommendedElasticPoolMetric
    {
        internal RecommendedElasticPoolMetricImpl(RecommendedElasticPoolMetric innerObject) : base(innerObject)
        {
        }

        public double SizeGB()
        {
            return this.Inner.SizeGB.GetValueOrDefault();
        }

        public DateTime DateTimeProperty()
        {
            return this.Inner.DateTime.GetValueOrDefault();
        }

        public double Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

    }
}