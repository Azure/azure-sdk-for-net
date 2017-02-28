// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Resource.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of NSRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5Oc1JlY29yZFNldHNJbXBs
    internal partial class NSRecordSetsImpl  :
        ReadableWrappers<INSRecordSet,NSRecordSetImpl,RecordSetInner>,
        INSRecordSets
    {
        private DnsZoneImpl dnsZone;

        public async Task<INSRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                RecordType.NS,
                cancellationToken);
            return new NSRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:4A497749B5E023624BDEB285134C423F
        public INSRecordSet GetByName(string name)
        {
            return GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:87CC6AA908BEE0D6E4535EB1332F9164:93DD647D9AB0DB30D017785882D88829
        internal  NSRecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:1D093FE5F27526EC91963B97D8C4EFC9
        public PagedList<INSRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(dnsZone.Manager.Inner.RecordSets.ListByType(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                RecordType.NS), (string nextPageLink) =>
                {
                    return dnsZone.Manager.Inner.RecordSets.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:ADE4AD664D47FA28F09C3CE440BD1806
        protected override INSRecordSet WrapModel(RecordSetInner inner)
        {
            return new NSRecordSetImpl(dnsZone, inner);
        }
    }
}
