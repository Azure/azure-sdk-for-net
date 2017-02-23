// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using DnsZone.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure DNS Zone.
    /// </summary>
    public interface IDnsZone  :
        IGroupableResource<IDnsZoneManager>,
        IRefreshable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        IHasInner<ZoneInner>,
        IUpdatable<DnsZone.Update.IUpdate>
    {
        /// <summary>
        /// Gets entry point to manage record sets in this zone containing A (Ipv4 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IARecordSets ARecordSets { get; }

        /// <return>The record set containing Soa (start of authority) record associated with this DNS zone.</return>
        Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet GetSoaRecordSet();

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Txt (text) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSets TxtRecordSets { get; }

        /// <summary>
        /// Gets the current number of record sets in this zone.
        /// </summary>
        long NumberOfRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing AAAA (IPv6 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSets AaaaRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing NS (name server) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.INSRecordSets NSRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing PTR (pointer) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IPtrRecordSets PtrRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing CName (canonical name) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ICNameRecordSets CNameRecordSets { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Srv (service) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSets SrvRecordSets { get; }

        /// <summary>
        /// Gets name servers assigned for this zone.
        /// </summary>
        System.Collections.Generic.IList<string> NameServers { get; }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing MX (mail exchange) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IMXRecordSets MXRecordSets { get; }

        /// <summary>
        /// Gets the maximum number of record sets that can be created in this zone.
        /// </summary>
        long MaxNumberOfRecordSets { get; }
    }
}