// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using DnsZone.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure DNS Zone.
    /// </summary>
    public interface IDnsZone  :
        IGroupableResource,
        IRefreshable<IDnsZone>,
        IWrapper<ZoneInner>,
        IUpdatable<DnsZone.Update.IUpdate>
    {
        /// <return>Entry point to manage record sets in this zone containing A (Ipv4 address) records.</return>
        IARecordSets ARecordSets { get; }

        /// <return>The record set containing Soa (start of authority) record associated with this Dns zone.</return>
        ISoaRecordSet GetSoaRecordSet();

        /// <return>Entry point to manage record sets in this zone containing Txt (text) records.</return>
        ITxtRecordSets TxtRecordSets { get; }

        /// <return>The current number of record sets in this zone.</return>
        long NumberOfRecordSets { get; }

        /// <return>Entry point to manage record sets in this zone containing AAAA (IPv6 address) records.</return>
        IAaaaRecordSets AaaaRecordSets { get; }

        /// <return>Entry point to manage record sets in this zone containing Ns (name server) records.</return>
        INsRecordSets NsRecordSets { get; }

        /// <return>Entry point to manage record sets in this zone containing Ptr (pointer) records.</return>
        IPtrRecordSets PtrRecordSets { get; }

        /// <return>Entry point to manage record sets in this zone containing CName (canonical name) records.</return>
        ICnameRecordSets CnameRecordSets { get; }

        /// <return>Entry point to manage record sets in this zone containing Srv (service) records.</return>
        ISrvRecordSets SrvRecordSets { get; }

        /// <return>Name servers assigned for this zone.</return>
        System.Collections.Generic.IList<string> NameServers { get; }

        /// <return>Entry point to manage record sets in this zone containing Mx (mail exchange) records.</return>
        IMxRecordSets MxRecordSets { get; }

        /// <return>The maximum number of record sets that can be created in this zone.</return>
        long MaxNumberOfRecordSets { get; }
    }
}