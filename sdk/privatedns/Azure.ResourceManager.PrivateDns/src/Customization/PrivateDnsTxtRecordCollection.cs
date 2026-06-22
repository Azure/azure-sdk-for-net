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
    /// A class representing a collection of <see cref="PrivateDnsTxtRecordResource"/> and their operations.
    /// Each <see cref="PrivateDnsTxtRecordResource"/> in the collection will belong to the same instance of <see cref="PrivateDnsZoneResource"/>.
    /// To get a <see cref="PrivateDnsTxtRecordCollection"/> instance call the GetPrivateDnsTxtRecords method from an instance of <see cref="PrivateDnsZoneResource"/>.
    /// </summary>
    [CodeGenSuppressAttribute("CreateOrUpdateAsync", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsTxtRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("CreateOrUpdate", typeof(WaitUntil), typeof(PrivateDnsRecordType), typeof(string), typeof(PrivateDnsTxtRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Get", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("ExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Exists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExistsAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExists", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    public partial class PrivateDnsTxtRecordCollection : ArmCollection, IEnumerable<PrivateDnsTxtRecordResource>, IAsyncEnumerable<PrivateDnsTxtRecordResource>
    {
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSets _recordSetsRestClient;

        /// <summary> Initializes a new instance of PrivateDnsTxtRecordCollection for mocking. </summary>
        protected PrivateDnsTxtRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsTxtRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PrivateDnsTxtRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(PrivateDnsTxtRecordResource.ResourceType, out string dnsTxtRecordApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", PrivateDnsTxtRecordResource.ResourceType.Namespace, Diagnostics);
            _recordSetsRestClient = new RecordSets(_recordSetsClientDiagnostics, Pipeline, Endpoint, dnsTxtRecordApiVersion ?? "2024-06-01");
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
            => await CreateOrUpdateAsync(waitUntil, txtRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken).ConfigureAwait(false);

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
            => CreateOrUpdate(waitUntil, txtRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken);

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

        /// <summary>
        /// Creates or updates a record set within a DNS zone. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<PrivateDnsTxtRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, PrivateDnsTxtRecordData.ToRequestContent(data), matchConditions, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsTxtRecordData> response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsTxtRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsTxtRecordResource>(Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<PrivateDnsTxtRecordResource> CreateOrUpdate(WaitUntil waitUntil, string txtRecordName, PrivateDnsTxtRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, PrivateDnsTxtRecordData.ToRequestContent(data), matchConditions, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsTxtRecordData> response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                PrivateDnsArmOperation<PrivateDnsTxtRecordResource> operation = new PrivateDnsArmOperation<PrivateDnsTxtRecordResource>(Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<PrivateDnsTxtRecordResource>> GetAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PrivateDnsTxtRecordData> response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<PrivateDnsTxtRecordResource> Get(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PrivateDnsTxtRecordData> response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsTxtRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsTxtRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsTxtRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsTxtRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<PrivateDnsTxtRecordResource>> GetIfExistsAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<PrivateDnsTxtRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsTxtRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsTxtRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{txtRecordName}. </description>
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
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<PrivateDnsTxtRecordResource> GetIfExists(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("PrivateDnsTxtRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, "TXT", txtRecordName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<PrivateDnsTxtRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(PrivateDnsTxtRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((PrivateDnsTxtRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<PrivateDnsTxtRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new PrivateDnsTxtRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
