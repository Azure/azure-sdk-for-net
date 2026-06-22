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
    /// A class representing a collection of <see cref="PrivateDnsPtrRecordResource"/> and their operations.
    /// Each <see cref="PrivateDnsPtrRecordResource"/> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource"/>.
    /// To get a <see cref="PrivateDnsPtrRecordCollection"/> instance call the GetPrivateDnsPtrRecords method from an instance of <see cref="PrivateDnsZoneResource"/>.
    /// </summary>
    [CodeGenSuppressAttribute("CreateOrUpdateAsync", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsPtrRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("CreateOrUpdate", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsPtrRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Get", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("ExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Exists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    public partial class PrivateDnsPtrRecordCollection : ArmCollection, IEnumerable<PrivateDnsPtrRecordResource>, IAsyncEnumerable<PrivateDnsPtrRecordResource>
    {
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSets _recordSetsRestClient;

        /// <summary> Initializes a new instance of PrivateDnsPtrRecordCollection for mocking. </summary>
        protected PrivateDnsPtrRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsPtrRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PrivateDnsPtrRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(PrivateDnsPtrRecordResource.ResourceType, out string dnsPtrRecordApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsPtrRecordResource.ResourceType.Namespace, Diagnostics);
            _recordSetsRestClient = new RecordSets(_recordSetsClientDiagnostics, Pipeline, Endpoint, dnsPtrRecordApiVersion ?? "2024-06-01");
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

        /// <summary> Creates or updates a DNS PTR record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ptrRecordName"> The name of the PTR record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<PrivateDnsPtrRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ptrRecordName, PrivateDnsPtrRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, ptrRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a DNS PTR record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="ptrRecordName"> The name of the PTR record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PrivateDnsPtrRecordResource> CreateOrUpdate(WaitUntil waitUntil, string ptrRecordName, PrivateDnsPtrRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, ptrRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken);

        /// <summary> Lists the PTR record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsPtrRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PrivateDnsPtrRecordResource> GetAllAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAllAsync(_recordSetsRestClient, Client, Id, "PTR", top, recordsetnamesuffix, cancellationToken, "PrivateDnsPtrRecordCollection.GetAll", (client, data) => new PrivateDnsPtrRecordResource(client, data.ToPtrRecordData()));

        /// <summary> Lists the PTR record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PrivateDnsPtrRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PrivateDnsPtrRecordResource> GetAll(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => PrivateDnsRecordData.GetAll(_recordSetsRestClient, Client, Id, "PTR", top, recordsetnamesuffix, cancellationToken, "PrivateDnsPtrRecordCollection.GetAll", (client, data) => new PrivateDnsPtrRecordResource(client, data.ToPtrRecordData()));

        IEnumerator<PrivateDnsPtrRecordResource> IEnumerable<PrivateDnsPtrRecordResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<PrivateDnsPtrRecordResource> IAsyncEnumerable<PrivateDnsPtrRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        /// <summary>
        /// Creates or updates a record set within a DNS zone. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<PrivateDnsPtrRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ptrRecordName, PrivateDnsPtrRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, PrivateDnsPtrRecordData.ToRequestContent(data), matchConditions, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsPtrRecordData> response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsPtrRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsPtrRecordResource>(Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<PrivateDnsPtrRecordResource> CreateOrUpdate(WaitUntil waitUntil, string ptrRecordName, PrivateDnsPtrRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, PrivateDnsPtrRecordData.ToRequestContent(data), matchConditions, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsPtrRecordData> response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsPtrRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsPtrRecordResource>(Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<PrivateDnsPtrRecordResource>> GetAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsPtrRecordData> response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PrivateDnsPtrRecordResource> Get(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsPtrRecordData> response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsPtrRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsPtrRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsPtrRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsPtrRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<PrivateDnsPtrRecordResource>> GetIfExistsAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsPtrRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsPtrRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsPtrRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{ptrRecordName}. </description>
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
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<PrivateDnsPtrRecordResource> GetIfExists(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsPtrRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "PTR", ptrRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsPtrRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsPtrRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsPtrRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsPtrRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsPtrRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
