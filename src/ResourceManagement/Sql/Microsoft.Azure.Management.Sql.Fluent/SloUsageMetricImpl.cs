// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Azure SQL Database's SloUsageMetric.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TbG9Vc2FnZU1ldHJpY0ltcGw=
    internal partial class SloUsageMetricImpl :
        Wrapper<SloUsageMetric>,
        ISloUsageMetric
    {
        ///GENMHASH:298C815F4D2EB576C32862C86A0F98CB:C0C35E00AF4E17F141675A2C05C7067B
        internal SloUsageMetricImpl(SloUsageMetric innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:8656A38C172C076E1333F8F38C03C729:9F7F41DC9E871B0E7570A255D093021E
        public Guid ServiceLevelObjectiveId()
        {
            return this.Inner.ServiceLevelObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:411E9B7C553E0F8FE64EB33DF4872E6A:A0F10EC124D07E925E3BE6285203F7E0
        public string ServiceLevelObjective()
        {
            return this.Inner.ServiceLevelObjective;
        }

        ///GENMHASH:C1C0B7CC034C960866980D125808D68D:7B4F68BEB7F199EBCBD2599A04BA443A
        public double InRangeTimeRatio()
        {
            return this.Inner.InRangeTimeRatio.GetValueOrDefault();
        }
    }
}
