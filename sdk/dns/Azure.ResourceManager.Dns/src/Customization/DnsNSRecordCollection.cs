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

[assembly: CodeGenSuppressType("DnsNSRecordCollection")]

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a collection of <see cref="DnsNSRecordResource" /> and their operations.
    /// Each <see cref="DnsNSRecordResource" /> in the collection will belong to the same instance of <see cref="DnsZoneResource" />.
    /// To get a <see cref="DnsNSRecordCollection" /> instance call the GetDnsNSRecords method from an instance of <see cref="DnsZoneResource" />.
    /// </summary>
    public partial class DnsNSRecordCollection : ArmCollection, IEnumerable<DnsNSRecordResource>, IAsyncEnumerable<DnsNSRecordResource>
    {
        private readonly ClientDiagnostics _nsRecordRecordSetsClientDiagnostics;
        private readonly DnsNSRecordRestOperations _nsRecordRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DnsNSRecordCollection"/> class for mocking. </summary>
        protected DnsNSRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DnsNSRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DnsNSRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _nsRecordRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", DnsNSRecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DnsNSRecordResource.ResourceType, out string nsRecordRecordSetsApiVersion);
            _nsRecordRecordSetsRestClient = new DnsNSRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, nsRecordRecordSetsApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DnsNSRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string nsRecordName, DnsNSRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _nsRecordRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new DnsArmOperation<DnsNSRecordResource>(Response.FromValue(new DnsNSRecordResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DnsNSRecordResource> CreateOrUpdate(WaitUntil waitUntil, string nsRecordName, DnsNSRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _nsRecordRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new DnsArmOperation<DnsNSRecordResource>(Response.FromValue(new DnsNSRecordResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        public virtual async Task<Response<DnsNSRecordResource>> GetAsync(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _nsRecordRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsNSRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a record set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        public virtual Response<DnsNSRecordResource> Get(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.Get");
            scope.Start();
            try
            {
                var response = _nsRecordRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsNSRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the record sets of a specified type in a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DnsNSRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsNSRecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DnsNSRecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _nsRecordRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsNSRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DnsNSRecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _nsRecordRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsNSRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsNSRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsNSRecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<DnsNSRecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _nsRecordRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsNSRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DnsNSRecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _nsRecordRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DnsNSRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _nsRecordRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nsRecordName, nameof(nsRecordName));

            using var scope = _nsRecordRecordSetsClientDiagnostics.CreateScope("DnsNSRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _nsRecordRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "NS".ToDnsRecordType(), nsRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DnsNSRecordResource> IEnumerable<DnsNSRecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DnsNSRecordResource> IAsyncEnumerable<DnsNSRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
