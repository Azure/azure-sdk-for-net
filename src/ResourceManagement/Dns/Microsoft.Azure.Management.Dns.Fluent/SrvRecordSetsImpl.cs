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
    /// Implementation of SrvRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5TcnZSZWNvcmRTZXRzSW1wbA==
    internal partial class SrvRecordSetsImpl  :
        ReadableWrappers<ISrvRecordSet,SrvRecordSetImpl,RecordSetInner>,
        ISrvRecordSets
    {
        private DnsZoneImpl dnsZone;
        private IRecordSetsOperations client;

        public async Task<ISrvRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await this.client.GetAsync(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                name,
                RecordType.SRV,
                cancellationToken);
            return new SrvRecordSetImpl(this.dnsZone, inner, this.client);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:12F579E9FC43A4A571B88A8BBF9CC790
        public ISrvRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:067B649C793B3A4FB476B1DC9A95DBE0:93DD647D9AB0DB30D017785882D88829
        internal  SrvRecordSetsImpl(DnsZoneImpl dnsZone, IRecordSetsOperations client)
        {
            this.dnsZone = dnsZone;
            this.client = client;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:E9415FFDEC272ED3312A39C040C09EFD
        public PagedList<ISrvRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(this.client.ListByType(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                RecordType.SRV), (string nextPageLink) =>
                {
                    return client.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:03274371FE0B9D92DBF3F1DA42023F15
        protected override ISrvRecordSet WrapModel(RecordSetInner inner)
        {
            return new SrvRecordSetImpl(this.dnsZone, inner, this.client);
        }
    }
}