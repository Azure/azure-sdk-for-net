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

[assembly: CodeGenSuppressType("DnsCaaRecordCollection")]

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a collection of <see cref="DnsCaaRecordResource" /> and their operations.
    /// Each <see cref="DnsCaaRecordResource" /> in the collection will belong to the same instance of <see cref="DnsZoneResource" />.
    /// To get a <see cref="DnsCaaRecordCollection" /> instance call the GetDnsCaaRecords method from an instance of <see cref="DnsZoneResource" />.
    /// </summary>
    public partial class DnsCaaRecordCollection : ArmCollection, IEnumerable<DnsCaaRecordResource>, IAsyncEnumerable<DnsCaaRecordResource>
    {
        private readonly ClientDiagnostics _caaRecordInfoRecordSetsClientDiagnostics;
        private readonly DnsCaaRecordRestOperations _caaRecordInfoRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DnsCaaRecordCollection"/> class for mocking. </summary>
        protected DnsCaaRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DnsCaaRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DnsCaaRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _caaRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", DnsCaaRecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DnsCaaRecordResource.ResourceType, out string caaRecordInfoRecordSetsApiVersion);
            _caaRecordInfoRecordSetsRestClient = new DnsCaaRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, caaRecordInfoRecordSetsApiVersion);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DnsCaaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _caaRecordInfoRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new DnsArmOperation<DnsCaaRecordResource>(Response.FromValue(new DnsCaaRecordResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DnsCaaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _caaRecordInfoRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new DnsArmOperation<DnsCaaRecordResource>(Response.FromValue(new DnsCaaRecordResource(Client, response), response.GetRawResponse()));
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        public virtual async Task<Response<DnsCaaRecordResource>> GetAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _caaRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        public virtual Response<DnsCaaRecordResource> Get(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Get");
            scope.Start();
            try
            {
                var response = _caaRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="DnsCaaRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsCaaRecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DnsCaaRecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _caaRecordInfoRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsCaaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DnsCaaRecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _caaRecordInfoRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsCaaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A collection of <see cref="DnsCaaRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsCaaRecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<DnsCaaRecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _caaRecordInfoRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsCaaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DnsCaaRecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _caaRecordInfoRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsCaaRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _caaRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(caaRecordName, nameof(caaRecordName));

            using var scope = _caaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _caaRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "CAA".ToDnsRecordType(), caaRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DnsCaaRecordResource> IEnumerable<DnsCaaRecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DnsCaaRecordResource> IAsyncEnumerable<DnsCaaRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
