// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update;
    using Microsoft.Azure.Management.Dns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure DNS Zone.
    /// </summary>
    public interface IDnsZoneBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets the etag associated with this zone.
        /// </summary>
        string ETag { get; }

        /// <return>The record sets in this zone.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets();

        /// <summary>
        /// Lists all the record sets in this zone with the given suffix.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix);

        /// <summary>
        /// Lists all the record sets in this zone with each entries in each page
        /// limited to the given size.
        /// </summary>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(int pageSize);

        /// <summary>
        /// Lists all the record sets in this zone with the given suffix, also limits
        /// the number of entries per page to the given page size.
        /// </summary>
        /// <param name="recordSetNameSuffix">The record set name suffix.</param>
        /// <param name="pageSize">The maximum number of record sets in a page.</param>
        /// <return>The record sets.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet> ListRecordSets(string recordSetNameSuffix, int pageSize);
    }
}