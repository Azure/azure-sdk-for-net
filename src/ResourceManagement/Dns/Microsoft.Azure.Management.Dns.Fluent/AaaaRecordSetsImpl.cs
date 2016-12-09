// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of AaaaRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5BYWFhUmVjb3JkU2V0c0ltcGw=
    internal partial class AaaaRecordSetsImpl  :
        ReadableWrappers<IAaaaRecordSet,AaaaRecordSetImpl,RecordSetInner>,
        IAaaaRecordSets
    {
        private DnsZoneImpl dnsZone;
        private IRecordSetsOperations client;

        public async Task<IAaaaRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await this.client.GetAsync(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                name,
                RecordType.AAAA,
                cancellationToken);
            return new AaaaRecordSetImpl(this.dnsZone, inner, this.client);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:10EBCE64285B15A348EA16D2076F49EE
        public IAaaaRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:DA1A37E97601F129EF3AF921419B0A9C:93DD647D9AB0DB30D017785882D88829
        internal  AaaaRecordSetsImpl(DnsZoneImpl dnsZone, IRecordSetsOperations client)
        {
            this.dnsZone = dnsZone;
            this.client = client;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:E0A75605560E78B8C503E86A302DCB32
        public PagedList<IAaaaRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(this.client.ListByType(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                RecordType.AAAA), (string nextPageLink) =>
                {
                    return client.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:583D2C6D497AA58FD8B23595EF66DCF0
        protected override IAaaaRecordSet WrapModel(RecordSetInner inner)
        {
            return new AaaaRecordSetImpl(this.dnsZone, inner, this.client);
        }
    }
}