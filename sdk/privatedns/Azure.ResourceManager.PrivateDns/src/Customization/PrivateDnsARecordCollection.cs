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
using Azure.ResourceManager.PrivateDns.Models;

[assembly: CodeGenSuppressType("PrivateDnsARecordCollection")]

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a collection of <see cref="PrivateDnsARecordResource" /> and their operations.
    /// Each <see cref="PrivateDnsARecordResource" /> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource" />.
    /// To get an <see cref="PrivateDnsARecordCollection" /> instance call the GetPrivateDnsARecords method from an instance of <see cref="PrivateDnsZoneResource" />.
    /// </summary>
    public partial class PrivateDnsARecordCollection : ArmCollection, IEnumerable<PrivateDnsARecordResource>, IAsyncEnumerable<PrivateDnsARecordResource>
    {
        private readonly ClientDiagnostics _aRecordInfoRecordSetsClientDiagnostics;
        private readonly PrivateDnsARecordRestOperations _aRecordInfoRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsARecordCollection"/> class for mocking. </summary>
        protected PrivateDnsARecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsARecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PrivateDnsARecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _aRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsARecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PrivateDnsARecordResource.ResourceType, out string aRecordInfoRecordSetsApiVersion);
            _aRecordInfoRecordSetsRestClient = new PrivateDnsARecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, aRecordInfoRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != PrivateDnsZoneResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, PrivateDnsZoneResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a record set within a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PrivateDnsARecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string aRecordName, PrivateDnsARecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _aRecordInfoRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new PrivateDnsArmOperation<PrivateDnsARecordResource>(Response.FromValue(new PrivateDnsARecordResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates a record set within a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PrivateDnsARecordResource> CreateOrUpdate(WaitUntil waitUntil, string aRecordName, PrivateDnsARecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _aRecordInfoRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new PrivateDnsArmOperation<PrivateDnsARecordResource>(Response.FromValue(new PrivateDnsARecordResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        public virtual async Task<Response<PrivateDnsARecordResource>> GetAsync(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _aRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsARecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        public virtual Response<PrivateDnsARecordResource> Get(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.Get");
            scope.Start();
            try
            {
                var response = _aRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsARecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the record sets of a specified type in a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name to be used to filter the record set enumeration. If this parameter is specified, the returned enumeration will only contain records that end with &quot;.&lt;recordsetnamesuffix&gt;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PrivateDnsARecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsARecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PrivateDnsARecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _aRecordInfoRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsARecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PrivateDnsARecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _aRecordInfoRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsARecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists the record sets of a specified type in a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_ListByType</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name to be used to filter the record set enumeration. If this parameter is specified, the returned enumeration will only contain records that end with &quot;.&lt;recordsetnamesuffix&gt;&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsARecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsARecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<PrivateDnsARecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _aRecordInfoRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsARecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PrivateDnsARecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _aRecordInfoRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsARecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _aRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{aRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(aRecordName, nameof(aRecordName));

            using var scope = _aRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsARecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _aRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "A".ToRecordType(), aRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PrivateDnsARecordResource> IEnumerable<PrivateDnsARecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PrivateDnsARecordResource> IAsyncEnumerable<PrivateDnsARecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
