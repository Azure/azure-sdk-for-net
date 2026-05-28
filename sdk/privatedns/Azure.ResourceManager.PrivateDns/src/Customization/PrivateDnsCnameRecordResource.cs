// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PrivateDns.Models;

[assembly: CodeGenSuppressType("PrivateDnsCnameRecordResource")]

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A Class representing a PrivateDnsCnameRecord along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="PrivateDnsCnameRecordResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetPrivateDnsCnameRecordResource method.
    /// Otherwise you can get one from its parent resource <see cref="PrivateDnsZoneResource" /> using the GetPrivateDnsCnameRecord method.
    /// </summary>
    public partial class PrivateDnsCnameRecordResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PrivateDnsCnameRecordResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateZoneName, string cnameRecordName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/CNAME/{cnameRecordName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _cnameRecordInfoRecordSetsClientDiagnostics;
        private readonly PrivateDnsCnameRecordRestOperations _cnameRecordInfoRecordSetsRestClient;
        private readonly PrivateDnsCnameRecordData _data;

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsCnameRecordResource"/> class for mocking. </summary>
        protected PrivateDnsCnameRecordResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "PrivateDnsCnameRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PrivateDnsCnameRecordResource(ArmClient client, PrivateDnsCnameRecordData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateDnsCnameRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PrivateDnsCnameRecordResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _cnameRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PrivateDns", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string cnameRecordInfoRecordSetsApiVersion);
            _cnameRecordInfoRecordSetsRestClient = new PrivateDnsCnameRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, cnameRecordInfoRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/privateDnsZones/CNAME";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PrivateDnsCnameRecordData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a record set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PrivateDnsCnameRecordResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Get");
            scope.Start();
            try
            {
                var response = await _cnameRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsCnameRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PrivateDnsCnameRecordResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Get");
            scope.Start();
            try
            {
                var response = _cnameRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PrivateDnsCnameRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a record set from a Private DNS zone. This operation cannot be undone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always delete the current record set. Specify the last-seen ETag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Delete");
            scope.Start();
            try
            {
                var response = await _cnameRecordInfoRecordSetsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, ifMatch, cancellationToken).ConfigureAwait(false);
                var operation = new PrivateDnsArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a record set from a Private DNS zone. This operation cannot be undone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always delete the current record set. Specify the last-seen ETag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Delete");
            scope.Start();
            try
            {
                var response = _cnameRecordInfoRecordSetsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, ifMatch, cancellationToken);
                var operation = new PrivateDnsArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<PrivateDnsCnameRecordResource>> UpdateAsync(PrivateDnsCnameRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Update");
            scope.Start();
            try
            {
                var response = await _cnameRecordInfoRecordSetsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, data, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new PrivateDnsCnameRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a record set within a Private DNS zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The ETag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<PrivateDnsCnameRecordResource> Update(PrivateDnsCnameRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _cnameRecordInfoRecordSetsClientDiagnostics.CreateScope("PrivateDnsCnameRecordResource.Update");
            scope.Start();
            try
            {
                var response = _cnameRecordInfoRecordSetsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "CNAME".ToRecordType(), Id.Name, data, ifMatch, cancellationToken);
                return Response.FromValue(new PrivateDnsCnameRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
