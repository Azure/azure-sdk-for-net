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

[assembly: CodeGenSuppressType("PrivateDnsMXRecordCollection")]

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a collection of <see cref="PrivateDnsMXRecordResource" /> and their operations.
    /// Each <see cref="PrivateDnsMXRecordResource" /> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource" />.
    /// To get a <see cref="PrivateDnsMXRecordCollection" /> instance call the GetPrivateDnsMXRecords method from an instance of <see cref="PrivateDnsZoneResource" />.
    /// </summary>
    public partial class PrivateDnsMXRecordCollection : ArmCollection, IEnumerable<PrivateDnsMXRecordResource>, IAsyncEnumerable<PrivateDnsMXRecordResource>
    {
        private readonly ClientDiagnostics _mxRecordRecordSetsClientDiagnostics;
        private readonly PrivateDnsMXRecordRestOperations _mxRecordRecordSetsRestClient;

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsMXRecordCollection"/> class for mocking. </summary>
        protected PrivateDnsMXRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsMXRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PrivateDnsMXRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mxRecordRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsMXRecordResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(PrivateDnsMXRecordResource.ResourceType, out string mxRecordRecordSetsApiVersion);
            _mxRecordRecordSetsRestClient = new PrivateDnsMXRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mxRecordRecordSetsApiVersion);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<PrivateDnsMXRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string mxRecordName, PrivateDnsMXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mxRecordRecordSetsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, data, ifMatch, ifNoneMatch, cancellationToken).ConfigureAwait(false);
                var operation = new PrivateDnsArmOperation<PrivateDnsMXRecordResource>(Response.FromValue(new PrivateDnsMXRecordResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to &apos;*&apos; to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<PrivateDnsMXRecordResource> CreateOrUpdate(WaitUntil waitUntil, string mxRecordName, PrivateDnsMXRecordData data, ETag? ifMatch = null, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mxRecordRecordSetsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, data, ifMatch, ifNoneMatch, cancellationToken);
                var operation = new PrivateDnsArmOperation<PrivateDnsMXRecordResource>(Response.FromValue(new PrivateDnsMXRecordResource(Client, response), response.GetRawResponse()));
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        public virtual async Task<Response<PrivateDnsMXRecordResource>> GetAsync(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.Get");
            scope.Start();
            try
            {
                var response = await _mxRecordRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsMXRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        public virtual Response<PrivateDnsMXRecordResource> Get(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.Get");
            scope.Start();
            try
            {
                var response = _mxRecordRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsMXRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <returns> An async collection of <see cref="PrivateDnsMXRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsMXRecordResource> GetAllAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PrivateDnsMXRecordResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mxRecordRecordSetsRestClient.ListByTypeAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsMXRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PrivateDnsMXRecordResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _mxRecordRecordSetsRestClient.ListByTypeNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsMXRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A collection of <see cref="PrivateDnsMXRecordResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsMXRecordResource> GetAll(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<PrivateDnsMXRecordResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mxRecordRecordSetsRestClient.ListByType(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsMXRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PrivateDnsMXRecordResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _mxRecordRecordSetsRestClient.ListByTypeNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PrivateDnsMXRecordResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = await _mxRecordRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{mxRecordName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        public virtual Response<bool> Exists(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mxRecordName, nameof(mxRecordName));

            using var scope = _mxRecordRecordSetsClientDiagnostics.CreateScope("PrivateDnsMXRecordCollection.Exists");
            scope.Start();
            try
            {
                var response = _mxRecordRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "MX".ToRecordType(), mxRecordName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PrivateDnsMXRecordResource> IEnumerable<PrivateDnsMXRecordResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PrivateDnsMXRecordResource> IAsyncEnumerable<PrivateDnsMXRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
