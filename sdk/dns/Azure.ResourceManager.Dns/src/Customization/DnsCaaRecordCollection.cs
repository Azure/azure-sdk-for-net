// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
using Azure.ResourceManager.Dns.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a collection of <see cref="DnsCaaRecordResource"/> and their operations.
    /// Each <see cref="DnsCaaRecordResource"/> in the collection will belong to the same instance of <see cref="DnsZoneResource"/>.
    /// To get a <see cref="DnsCaaRecordCollection"/> instance call the GetDnsCaaRecords method from an instance of <see cref="DnsZoneResource"/>.
    /// </summary>
    [CodeGenSuppressAttribute("CreateOrUpdateAsync", typeof(WaitUntil), typeof(string), typeof(DnsRecordType), typeof(DnsCaaRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("CreateOrUpdate", typeof(WaitUntil), typeof(string), typeof(DnsRecordType), typeof(DnsCaaRecordData), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Get", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("ExistsAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("Exists", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExistsAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetIfExists", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    public partial class DnsCaaRecordCollection : ArmCollection, IEnumerable<DnsCaaRecordResource>, IAsyncEnumerable<DnsCaaRecordResource>
    {
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSets _recordSetsRestClient;

        /// <summary> Initializes a new instance of DnsCaaRecordCollection for mocking. </summary>
        protected DnsCaaRecordCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DnsCaaRecordCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DnsCaaRecordCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(DnsCaaRecordResource.ResourceType, out string dnsCaaRecordApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", DnsCaaRecordResource.ResourceType.Namespace, Diagnostics);
            _recordSetsRestClient = new RecordSets(_recordSetsClientDiagnostics, Pipeline, Endpoint, dnsCaaRecordApiVersion ?? "2023-07-01-preview");
            ValidateResourceId(id);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != DnsZoneResource.ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, DnsZoneResource.ResourceType), nameof(id));
            }
        }

        /// <summary> Creates or updates a DNS CAA record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="caaRecordName"> The name of the CAA record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsCaaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, caaRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken).ConfigureAwait(false);

        /// <summary> Creates or updates a DNS CAA record set. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="caaRecordName"> The name of the CAA record set. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An <see cref="ArmOperation{T}"/> that tracks the operation. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsCaaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, caaRecordName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = new ETag(ifNoneMatch) }, cancellationToken);

        /// <summary> Lists the CAA record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsCaaRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsCaaRecordResource> GetAllAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => DnsRecordData.GetAllAsync(_recordSetsRestClient, Client, Id, "CAA", top, recordsetnamesuffix, cancellationToken, "DnsCaaRecordCollection.GetAll", (client, id) => new DnsCaaRecordResource(client, id));

        /// <summary> Lists the CAA record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsCaaRecordResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsCaaRecordResource> GetAll(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => DnsRecordData.GetAll(_recordSetsRestClient, Client, Id, "CAA", top, recordsetnamesuffix, cancellationToken, "DnsCaaRecordCollection.GetAll", (client, id) => new DnsCaaRecordResource(client, id));

        IEnumerator<DnsCaaRecordResource> IEnumerable<DnsCaaRecordResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<DnsCaaRecordResource> IAsyncEnumerable<DnsCaaRecordResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        /// <summary>
        /// Creates or updates a record set within a DNS zone. Record sets of type SOA can be updated but not created (they are created when the DNS zone is created).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<ArmOperation<DnsCaaRecordResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", DnsCaaRecordData.ToRequestContent(data), matchConditions, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnsCaaRecordData> response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                DnsArmOperation<DnsCaaRecordResource> operation = new DnsArmOperation<DnsCaaRecordResource>(Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> or <paramref name="data"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual ArmOperation<DnsCaaRecordResource> CreateOrUpdate(WaitUntil waitUntil, string caaRecordName, DnsCaaRecordData data, MatchConditions matchConditions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", DnsCaaRecordData.ToRequestContent(data), matchConditions, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnsCaaRecordData> response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                DnsArmOperation<DnsCaaRecordResource> operation = new DnsArmOperation<DnsCaaRecordResource>(Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<DnsCaaRecordResource>> GetAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnsCaaRecordData> response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
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
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<DnsCaaRecordResource> Get(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnsCaaRecordData> response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<DnsCaaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((DnsCaaRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<DnsCaaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((DnsCaaRecordData)null, result);
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<DnsCaaRecordResource>> GetIfExistsAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<DnsCaaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((DnsCaaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<DnsCaaRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<DnsCaaRecordResource> GetIfExists(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsCaaRecordCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, caaRecordName, "CAA", context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<DnsCaaRecordData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(DnsCaaRecordData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((DnsCaaRecordData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<DnsCaaRecordResource>(response.GetRawResponse());
                }
                return Response.FromValue(new DnsCaaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
