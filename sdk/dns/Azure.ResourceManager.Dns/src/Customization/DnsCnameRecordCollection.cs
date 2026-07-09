// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Dns.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a collection of <see cref="DnsCnameRecordResource"/> and their operations.
    /// Each <see cref="DnsCnameRecordResource"/> in the collection will belong to the same instance of <see cref="DnsZoneResource"/>.
    /// To get a <see cref="DnsCnameRecordCollection"/> instance call the GetDnsCnameRecords method from an instance of <see cref="DnsZoneResource"/>.
    /// </summary>
    public partial class DnsCnameRecordCollection : ArmCollection, IEnumerable<DnsCnameRecordResource>, IAsyncEnumerable<DnsCnameRecordResource>
    {
        /// <summary> Creates or updates a DNS CNAME record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cnameRecordName"> The name of the CNAME record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsCnameRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string cnameRecordName, DnsCnameRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, cnameRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a DNS CNAME record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cnameRecordName"> The name of the CNAME record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsCnameRecordResource> CreateOrUpdate(WaitUntil waitUntil, string cnameRecordName, DnsCnameRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, cnameRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken);

        /// <summary> Lists the CNAME record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsCnameRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsCnameRecordResource> GetAllAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => DnsRecordData.GetAllAsync(_recordSetsRestClient, Client, Id, "CNAME", top, recordsetnamesuffix, cancellationToken, "DnsCnameRecordCollection.GetAll", (client, id) => new DnsCnameRecordResource(client, id));

        /// <summary> Lists the CNAME record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsCnameRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsCnameRecordResource> GetAll(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => DnsRecordData.GetAll(_recordSetsRestClient, Client, Id, "CNAME", top, recordsetnamesuffix, cancellationToken, "DnsCnameRecordCollection.GetAll", (client, id) => new DnsCnameRecordResource(client, id));

        IEnumerator<DnsCnameRecordResource> IEnumerable<DnsCnameRecordResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<DnsCnameRecordResource> IAsyncEnumerable<DnsCnameRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
