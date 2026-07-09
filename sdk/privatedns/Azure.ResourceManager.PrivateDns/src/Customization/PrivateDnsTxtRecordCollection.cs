// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

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
using Azure.ResourceManager.PrivateDns.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a collection of <see cref="PrivateDnsTxtRecordResource"/> and their operations.
    /// Each <see cref="PrivateDnsTxtRecordResource"/> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource"/>.
    /// To get a <see cref="PrivateDnsTxtRecordCollection"/> instance call the GetPrivateDnsTxtRecords method from an instance of <see cref="PrivateDnsZoneResource"/>.
    /// </summary>
    public partial class PrivateDnsTxtRecordCollection : ArmCollection, IEnumerable<PrivateDnsTxtRecordResource>, IAsyncEnumerable<PrivateDnsTxtRecordResource>
    {
        /// <summary> Creates or updates a DNS TXT record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="txtRecordName"> The name of the TXT record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PrivateDnsTxtRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, txtRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a DNS TXT record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="txtRecordName"> The name of the TXT record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PrivateDnsTxtRecordResource> CreateOrUpdate(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, txtRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken);

        /// <summary> Lists the TXT record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsTxtRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsTxtRecordResource> GetAllAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAllAsync(_recordSetsRestClient, Client, Id, "TXT", top, recordsetnamesuffix, cancellationToken, "PrivateDnsTxtRecordCollection.GetAll", (client, data) => new PrivateDnsTxtRecordResource(client, data.ToTxtRecordData()));

        /// <summary> Lists the TXT record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsTxtRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsTxtRecordResource> GetAll(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAll(_recordSetsRestClient, Client, Id, "TXT", top, recordsetnamesuffix, cancellationToken, "PrivateDnsTxtRecordCollection.GetAll", (client, data) => new PrivateDnsTxtRecordResource(client, data.ToTxtRecordData()));

        IEnumerator<PrivateDnsTxtRecordResource> IEnumerable<PrivateDnsTxtRecordResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<PrivateDnsTxtRecordResource> IAsyncEnumerable<PrivateDnsTxtRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
