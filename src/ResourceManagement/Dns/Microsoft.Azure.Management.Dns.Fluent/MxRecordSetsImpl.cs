// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of MXRecordSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmRucy5pbXBsZW1lbnRhdGlvbi5NeFJlY29yZFNldHNJbXBs
    internal partial class MXRecordSetsImpl  :
        ReadableWrappers<IMXRecordSet,MXRecordSetImpl,RecordSetInner>,
        IMXRecordSets
    {
        private DnsZoneImpl dnsZone;
        
        private DnsZoneImpl Parent()
        {
            return dnsZone;
        }

        public async Task<IMXRecordSet> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            RecordSetInner inner = await dnsZone.Manager.Inner.RecordSets.GetAsync(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                name,
                RecordType.MX,
                cancellationToken);
            return new MXRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:1AD3FB2435C046F2F71535A24004CDFD
        public IMXRecordSet GetByName(string name)
        {
            return this.GetByNameAsync(name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:35BF201395273B958A9213F1436D5DD1
        public PagedList<IMXRecordSet> List()
        {
            var pagedList = new PagedList<RecordSetInner>(dnsZone.Manager.Inner.RecordSets.ListByType(
                dnsZone.ResourceGroupName,
                dnsZone.Name,
                RecordType.MX), (string nextPageLink) =>
                {
                    return dnsZone.Manager.Inner.RecordSets.ListByTypeNext(nextPageLink);
                });
            return WrapList(pagedList);
        }

        ///GENMHASH:A65D7F670CB73E56248FA5B252060BCD:AE9F50303BC13DCE8F677D0C754BDBC0
        protected override IMXRecordSet WrapModel(RecordSetInner inner)
        {
            return new MXRecordSetImpl(dnsZone, inner);
        }

        ///GENMHASH:6F2FBDD481155D6AAAD51709649A57BB:93DD647D9AB0DB30D017785882D88829
        internal  MXRecordSetsImpl(DnsZoneImpl dnsZone)
        {
            this.dnsZone = dnsZone;
        }
    }
}
