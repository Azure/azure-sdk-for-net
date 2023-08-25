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
using Azure.ResourceManager.Dns.Models;

[assembly: CodeGenSuppressType("DnsSoaRecordResource")]

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A Class representing a DnsSoaRecord along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DnsSoaRecordResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDnsSoaRecordResource method.
    /// Otherwise you can get one from its parent resource <see cref="DnsZoneResource" /> using the GetDnsSoaRecord method.
    /// </summary>
    public partial class DnsSoaRecordResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DnsSoaRecordResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName, string soaRecordName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/SOA/{soaRecordName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _soaRecordInfoRecordSetsClientDiagnostics;
        private readonly DnsSoaRecordRestOperations _soaRecordInfoRecordSetsRestClient;
        private readonly DnsSoaRecordData _data;

        /// <summary> Initializes a new instance of the <see cref="DnsSoaRecordResource"/> class for mocking. </summary>
        protected DnsSoaRecordResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DnsSoaRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DnsSoaRecordResource(ArmClient client, DnsSoaRecordData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DnsSoaRecordResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DnsSoaRecordResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _soaRecordInfoRecordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string soaRecordInfoRecordSetsApiVersion);
            _soaRecordInfoRecordSetsRestClient = new DnsSoaRecordRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, soaRecordInfoRecordSetsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones/SOA";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DnsSoaRecordData Data
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DnsSoaRecordResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordResource.Get");
            scope.Start();
            try
            {
                var response = await _soaRecordInfoRecordSetsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "SOA".ToDnsRecordType(), Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DnsSoaRecordResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordResource.Get");
            scope.Start();
            try
            {
                var response = _soaRecordInfoRecordSetsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "SOA".ToDnsRecordType(), Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<DnsSoaRecordResource>> UpdateAsync(DnsSoaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordResource.Update");
            scope.Start();
            try
            {
                var response = await _soaRecordInfoRecordSetsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "SOA".ToDnsRecordType(), Id.Name, data, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecordSets_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="data"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the record set. Omit this value to always overwrite the current record set. Specify the last-seen etag value to prevent accidentally overwriting concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<DnsSoaRecordResource> Update(DnsSoaRecordData data, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _soaRecordInfoRecordSetsClientDiagnostics.CreateScope("DnsSoaRecordResource.Update");
            scope.Start();
            try
            {
                var response = _soaRecordInfoRecordSetsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, "SOA".ToDnsRecordType(), Id.Name, data, ifMatch, cancellationToken);
                return Response.FromValue(new DnsSoaRecordResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
