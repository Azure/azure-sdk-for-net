// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Implementation of CnameRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5DbmFtZVJlY29yZFNldHNJbXBs
    internal partial class CnameRecordSetsImpl  :
        ReadableWrappers<ICnameRecordSet,CnameRecordSetImpl,RecordSetInner>,
        ICnameRecordSets
    {
        private DnsZoneImpl dnsZone;
        private IRecordSetsOperations client;
        
        public async Task<ICnameRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await this.client.GetAsync(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                name,
                RecordType.CNAME,
                cancellationToken);
            return new CnameRecordSetImpl(this.dnsZone, inner, this.client);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:21826374215313D0BBCD792A32A35145
        public ICnameRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:AEF19E721FABB2C4D04AB9D2DEC278FE:93DD647D9AB0DB30D017785882D88829
        internal  CnameRecordSetsImpl(DnsZoneImpl dnsZone, IRecordSetsOperations client)
        {
            this.dnsZone = dnsZone;
            this.client = client;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:835EB6D00E8349C692B56704F6AE6278
        public PagedList<ICnameRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(this.client.ListByType(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                RecordType.CNAME), (string nextPageLink) =>
                {
                    return client.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:3FD60711AC73E456F2C157D4892D9EF5
        protected override ICnameRecordSet WrapModel(RecordSetInner inner)
        {
            return new CnameRecordSetImpl(this.dnsZone, inner, this.client);
        }
    }
}