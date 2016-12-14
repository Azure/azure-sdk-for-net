// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZWNvbW1lbmRlZEVsYXN0aWNQb29sTWV0cmljSW1wbA==
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

        ///GENMHASH:76AD19811D456060FEDE2A74548C8170:087192EAB86161F5533CEC4034C1F03C
        public double SizeGB()
        {
            return this.Inner.SizeGB.GetValueOrDefault();
        }

        ///GENMHASH:090B7257C66794F2CE64D88AF49EBAD0:843C6B15DE0A1A9846809157A1D54BE2
        public DateTime DateTimeProperty()
        {
            return this.Inner.DateTime.GetValueOrDefault();
        }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:945958DE33096D51BB9DD38A7F3CDAD0
        public double Dtu()
        {
            return this.Inner.Dtu.GetValueOrDefault();
        }

    }
}
