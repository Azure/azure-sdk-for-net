// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using ResourceManager.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Implementation of CNameRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DbmFtZVJlY29yZFNldHNJbXBs
    internal partial class CNameRecordSetsImpl  :
        ReadableWrappers<ICNameRecordSet,CNameRecordSetImpl,RecordSetInner>,
        ICNameRecordSets
    {
        private DnsZoneImpl dnsZone;
        
        private DnsZoneImpl Parent()
        {
            return dnsZone;
        }

        public async Task<ICNameRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                RecordType.CNAME,
                cancellationToken);
            return new CNameRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:21826374215313D0BBCD792A32A35145
        public ICNameRecordSet GetByName(string name)
        {
            return GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:AEF19E721FABB2C4D04AB9D2DEC278FE:93DD647D9AB0DB30D017785882D88829
        internal CNameRecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:835EB6D00E8349C692B56704F6AE6278
        public PagedList<ICNameRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(dnsZone.Manager.Inner.RecordSets.ListByType(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                RecordType.CNAME), (string nextPageLink) =>
                {
                    return dnsZone.Manager.Inner.RecordSets.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:3FD60711AC73E456F2C157D4892D9EF5
        protected override ICNameRecordSet WrapModel(RecordSetInner inner)
        {
            return new CNameRecordSetImpl(dnsZone, inner);
        }
    }
}
