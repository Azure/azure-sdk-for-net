// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Dns.Models;

[assembly: CodeGenSuppressType("DnsSoaRecordCollection")]

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a collection of <see cref="DnsSoaRecordResource" /> and their operations.
    /// Each <see cref="DnsSoaRecordResource" /> in the collection will belong to the same instance of <see cref="DnsZoneResource" />.
    /// To get a <see cref="DnsSoaRecordCollection" /> instance call the GetDnsSoaRecords method from an instance of <see cref="DnsZoneResource" />.
    /// </summary>
    public partial class DnsSoaRecordCollection : ArmCollection, IEnumerable<DnsSoaRecordResource>, IAsyncEnumerable<DnsSoaRecordResource>
    {
        private readonly ClientDiagnostics _soaRecordInfoRecordSetsClientDiagnostics;
        private readonly DnsSoaRecordRestOperations _soaRecordInfoRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DnsSoaRecordCollection"/> class for mocking. </summary>
        protected DnsSoaRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DnsSoaRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DnsSoaRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _soaRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", DnsSoaRecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DnsSoaRecordResource.ResourceType, out string soaRecordInfoRecordSetsApiVersion);
            _soaRecordInfoRecordSetsRestClient = new DnsSoaRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, soaRecordInfoRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != DnsZoneResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, DnsZoneResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DnsSoaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string soaRecordName, DnsSoaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _soaRecordInfoRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new DnsArmOperation<DnsSoaRecordResource>(Response.FromValue(new DnsSoaRecordResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a record set within a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DnsSoaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string soaRecordName, DnsSoaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _soaRecordInfoRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new DnsArmOperation<DnsSoaRecordResource>(Response.FromValue(new DnsSoaRecordResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        public virtual async Task<Response<DnsSoaRecordResource>> GetAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _soaRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        public virtual Response<DnsSoaRecordResource> Get(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.Get");
            scope.Start();
            try
            {
                var response = _soaRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}
        /// Operation Id: RecordSets_ListByType
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DnsSoaRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsSoaRecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DnsSoaRecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _soaRecordInfoRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsSoaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DnsSoaRecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _soaRecordInfoRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsSoaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}
        /// Operation Id: RecordSets_ListByType
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsSoaRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsSoaRecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<DnsSoaRecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _soaRecordInfoRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsSoaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DnsSoaRecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _soaRecordInfoRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsSoaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _soaRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(soaRecordName, nameof(soaRecordName));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _soaRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA".ToDnsRecordType(), soaRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DnsSoaRecordResource> IEnumerable<DnsSoaRecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DnsSoaRecordResource> IAsyncEnumerable<DnsSoaRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
