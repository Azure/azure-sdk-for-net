// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for DatabaseMetric interface.
    /// </summary>
    internal partial class DatabaseMetricImpl :
        Wrapper<Models.DatabaseMetric>,
        IDatabaseMetric
    {

        internal DatabaseMetricImpl(DatabaseMetric innerObject) : base(innerObject)
        {
        }

        public string Unit()
        {
            return this.Inner.Unit;
        }

        public string DisplayName()
        {
            return this.Inner.DisplayName;
        }

        public double Limit()
        {
            return this.Inner.Limit.GetValueOrDefault();
        }

        public DateTime NextResetTime()
        {
            return this.Inner.NextResetTime.GetValueOrDefault();
        }

        public string ResourceName()
        {
            return this.Inner.ResourceName;
        }


        public double CurrentValue()
        {
            return this.Inner.CurrentValue.GetValueOrDefault();
        }
    }
}