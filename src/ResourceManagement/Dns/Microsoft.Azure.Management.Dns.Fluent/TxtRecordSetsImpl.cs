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
    /// Implementation of TxtRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5UeHRSZWNvcmRTZXRzSW1wbA==
    internal partial class TxtRecordSetsImpl  :
        ReadableWrappers<ITxtRecordSet,TxtRecordSetImpl,RecordSetInner>,
        ITxtRecordSets
    {
        private DnsZoneImpl dnsZone;
        private IRecordSetsOperations client;
        ///GENMHASH:70F336C47374A14980F4F5D3557E78E9:93DD647D9AB0DB30D017785882D88829
        internal  TxtRecordSetsImpl(DnsZoneImpl dnsZone, IRecordSetsOperations client)
        {
            this.dnsZone = dnsZone;
            this.client = client;
        }

        public async Task<ITxtRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await this.client.GetAsync(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                name,
                RecordType.TXT,
                cancellationToken);
            return new TxtRecordSetImpl(this.dnsZone, inner, this.client);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:AAC0A7813BAD48114C2EF153D9E157A1
        public ITxtRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).Result;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:0A5A4DAF4EB520E3FAB8309AF1336143
        public PagedList<ITxtRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(this.client.ListByType(this.dnsZone.ResourceGroupName,
                this.dnsZone.Name,
                RecordType.TXT), (string nextPageLink) =>
                {
                    return client.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:C6F06A2EC17D0A1052A28CE3A09D4D83
        protected override ITxtRecordSet WrapModel(RecordSetInner inner)
        {
            return new TxtRecordSetImpl(this.dnsZone, inner, this.client);
        }
    }
}