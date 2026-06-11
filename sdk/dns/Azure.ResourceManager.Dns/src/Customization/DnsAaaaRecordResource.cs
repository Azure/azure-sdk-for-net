// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a DnsAaaaRecord along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DnsAaaaRecordResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="DnsZoneResource"/> using the GetDnsAaaaRecords method.
    /// </summary>
    public partial class DnsAaaaRecordResource : ArmResource
    {
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSets _recordSetsRestClient;
        private readonly DnsAaaaRecordData _data;
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones/AAAA";

        /// <summary> Initializes a new instance of DnsAaaaRecordResource for mocking. </summary>
        protected DnsAaaaRecordResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DnsAaaaRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DnsAaaaRecordResource(ArmClient client, DnsAaaaRecordData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of <see cref="DnsAaaaRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DnsAaaaRecordResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            TryGetApiVersion(ResourceType, out string dnsAaaaRecordApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", ResourceType.Namespace, Diagnostics);
            _recordSetsRestClient = new RecordSets(_recordSetsClientDiagnostics, Pipeline, Endpoint, dnsAaaaRecordApiVersion ?? "2023-07-01-preview");
            ValidateResourceId(id);
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        public virtual DnsAaaaRecordData Data
        {
            get
            {
                if (!HasData)
                {
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                }
                return _data;
            }
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="zoneName"> The zoneName. </param>
        /// <param name="relativeRecordSetName"> The relativeRecordSetName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string relativeRecordSetName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/AAAA/{relativeRecordSetName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        /// <summary>
        /// Gets a record set.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DnsAaaaRecordResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnsAaaaRecordData> response = Response.FromValue(DnsAaaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsAaaaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DnsAaaaRecordResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnsAaaaRecordData> response = Response.FromValue(DnsAaaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsAaaaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<DnsAaaaRecordResource>> UpdateAsync(DnsAaaaRecordData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", DnsAaaaRecordData.ToRequestContent(data), ifMatch, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnsAaaaRecordData> response = Response.FromValue(DnsAaaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsAaaaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<DnsAaaaRecordResource> Update(DnsAaaaRecordData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", DnsAaaaRecordData.ToRequestContent(data), ifMatch, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnsAaaaRecordData> response = Response.FromValue(DnsAaaaRecordData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsAaaaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a record set from a DNS zone. This operation cannot be undone. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", ifMatch, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                DnsArmOperation operation = new DnsArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
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
        /// Deletes a record set from a DNS zone. This operation cannot be undone. Record sets of type SOA cannot be deleted (they are deleted when the DNS zone is deleted).
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RecordSets_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsAaaaRecordResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always delete the current record set. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _recordSetsClientDiagnostics.CreateScope("DnsAaaaRecordResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _recordSetsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, "AAAA", ifMatch, context);
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                DnsArmOperation operation = new DnsArmOperation(response, rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
