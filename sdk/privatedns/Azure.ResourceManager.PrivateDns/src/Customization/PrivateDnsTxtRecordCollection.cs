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

[assembly: CodeGenSuppressType("PrivateDnsTxtRecordCollection")]

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a collection of <see cref="PrivateDnsTxtRecordResource" /> and their operations.
    /// Each <see cref="PrivateDnsTxtRecordResource" /> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource" />.
    /// To get a <see cref="PrivateDnsTxtRecordCollection" /> instance call the GetPrivateDnsTxtRecords method from an instance of <see cref="PrivateDnsZoneResource" />.
    /// </summary>
    public partial class PrivateDnsTxtRecordCollection : ArmCollection, IEnumerable<PrivateDnsTxtRecordResource>, IAsyncEnumerable<PrivateDnsTxtRecordResource>
    {
        private readonly ClientDiagnostics _txtRecordInfoRecordSetsClientDiagnostics;
        private readonly PrivateDnsTxtRecordRestOperations _txtRecordInfoRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsTxtRecordCollection"/> class for mocking. </summary>
        protected PrivateDnsTxtRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsTxtRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PrivateDnsTxtRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _txtRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsTxtRecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PrivateDnsTxtRecordResource.ResourceType, out string txtRecordInfoRecordSetsApiVersion);
            _txtRecordInfoRecordSetsRestClient = new PrivateDnsTxtRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, txtRecordInfoRecordSetsApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PrivateDnsTxtRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _txtRecordInfoRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new PrivateDnsArmOperation<PrivateDnsTxtRecordResource>(Response.FromValue(new PrivateDnsTxtRecordResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PrivateDnsTxtRecordResource> CreateOrUpdate(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _txtRecordInfoRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new PrivateDnsArmOperation<PrivateDnsTxtRecordResource>(Response.FromValue(new PrivateDnsTxtRecordResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        public virtual async Task<Response<PrivateDnsTxtRecordResource>> GetAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _txtRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        public virtual Response<PrivateDnsTxtRecordResource> Get(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Get");
            scope.Start();
            try
            {
                var response = _txtRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="PrivateDnsTxtRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsTxtRecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PrivateDnsTxtRecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _txtRecordInfoRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsTxtRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PrivateDnsTxtRecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _txtRecordInfoRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsTxtRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A collection of <see cref="PrivateDnsTxtRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsTxtRecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<PrivateDnsTxtRecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _txtRecordInfoRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsTxtRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PrivateDnsTxtRecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _txtRecordInfoRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsTxtRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _txtRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(txtRecordName, nameof(txtRecordName));

            using var scope = _txtRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _txtRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT".ToRecordType(), txtRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PrivateDnsTxtRecordResource> IEnumerable<PrivateDnsTxtRecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PrivateDnsTxtRecordResource> IAsyncEnumerable<PrivateDnsTxtRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
