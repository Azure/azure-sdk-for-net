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
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a collection of <see cref="PrivateDnsSoaRecordResource"/> and their operations.
    /// Each <see cref="PrivateDnsSoaRecordResource"/> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource"/>.
    /// To get a <see cref="PrivateDnsSoaRecordCollection"/> instance call the GetPrivateDnsSoaRecords method from an instance of <see cref="PrivateDnsZoneResource"/>.
    /// </summary>
    [CodeGenSuppressAttribute("CreateOrUpdateAsync", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsSoaRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("CreateOrUpdate", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsSoaRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Get", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("ExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Exists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    public partial class PrivateDnsSoaRecordCollection : ArmCollection, IEnumerable<PrivateDnsSoaRecordResource>, IAsyncEnumerable<PrivateDnsSoaRecordResource>
    {
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSets _recordSetsRestClient;

        /// <summary> Initializes a new instance of PrivateDnsSoaRecordCollection for mocking. </summary>
        protected PrivateDnsSoaRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsSoaRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PrivateDnsSoaRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(PrivateDnsSoaRecordResource.ResourceType, out string dnsSoaRecordApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsSoaRecordResource.ResourceType.Namespace, Diagnostics);
            _recordSetsRestClient = new RecordSets(_recordSetsClientDiagnostics, Pipeline, Endpoint, dnsSoaRecordApiVersion ?? "2024-06-01");
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != PrivateDnsZoneResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, PrivateDnsZoneResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Creates or updates a DNS SOA record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="soaRecordName"> The name of the SOA record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PrivateDnsSoaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string soaRecordName, PrivateDnsSoaRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, soaRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a DNS SOA record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="soaRecordName"> The name of the SOA record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PrivateDnsSoaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string soaRecordName, PrivateDnsSoaRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, soaRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken);

        /// <summary> Lists the SOA record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsSoaRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsSoaRecordResource> GetAllAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAllAsync(_recordSetsRestClient, Client, Id, "SOA", top, recordsetnamesuffix, cancellationToken, "PrivateDnsSoaRecordCollection.GetAll", (client, data) => new PrivateDnsSoaRecordResource(client, data.ToSoaRecordData()));

        /// <summary> Lists the SOA record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsSoaRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsSoaRecordResource> GetAll(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAll(_recordSetsRestClient, Client, Id, "SOA", top, recordsetnamesuffix, cancellationToken, "PrivateDnsSoaRecordCollection.GetAll", (client, data) => new PrivateDnsSoaRecordResource(client, data.ToSoaRecordData()));

        IEnumerator<PrivateDnsSoaRecordResource> IEnumerable<PrivateDnsSoaRecordResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<PrivateDnsSoaRecordResource> IAsyncEnumerable<PrivateDnsSoaRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        /// <summary>
        /// Creates or updates a record set within a DNS zone. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<PrivateDnsSoaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string soaRecordName, PrivateDnsSoaRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, PrivateDnsSoaRecordData.ToRequestContent(data), matchConditions, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsSoaRecordData> response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsSoaRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsSoaRecordResource>(Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a record set within a DNS zone. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<PrivateDnsSoaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string soaRecordName, PrivateDnsSoaRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, PrivateDnsSoaRecordData.ToRequestContent(data), matchConditions, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsSoaRecordData> response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsSoaRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsSoaRecordResource>(Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<PrivateDnsSoaRecordResource>> GetAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsSoaRecordData> response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PrivateDnsSoaRecordResource> Get(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsSoaRecordData> response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsSoaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsSoaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsSoaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsSoaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<PrivateDnsSoaRecordResource>> GetIfExistsAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsSoaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsSoaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsSoaRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{soaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-06-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<PrivateDnsSoaRecordResource> GetIfExists(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsSoaRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "SOA", soaRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsSoaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsSoaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsSoaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsSoaRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
