// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;

// <summary> Rename parameter: relativeRecordSetName to FooRecordName. </summary>
[assembly: CodeGenSuppressType("DnsZoneResource")]

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A Class representing a DnsZone along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DnsZoneResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDnsZoneResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetDnsZone method.
    /// </summary>
    public partial class DnsZoneResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DnsZoneResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string zoneName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _dnsZoneZonesClientDiagnostics;
        private readonly ZonesRestOperations _dnsZoneZonesRestClient;
        private readonly ClientDiagnostics _recordSetsClientDiagnostics;
        private readonly RecordSetsRestOperations _recordSetsRestClient;
        private readonly DnsZoneData _data;

        /// <summary> Initializes a new instance of the <see cref="DnsZoneResource"/> class for mocking. </summary>
        protected DnsZoneResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DnsZoneResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal DnsZoneResource(ArmClient client, DnsZoneData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="DnsZoneResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal DnsZoneResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dnsZoneZonesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string dnsZoneZonesApiVersion);
            _dnsZoneZonesRestClient = new ZonesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dnsZoneZonesApiVersion);
            _recordSetsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Dns", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _recordSetsRestClient = new RecordSetsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/dnsZones";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual DnsZoneData Data
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

        /// <summary> Gets a collection of DnsARecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsARecordResources and their operations over a DnsARecordResource. </returns>
        public virtual DnsARecordCollection GetDnsARecords()
        {
            return GetCachedClient(Client => new DnsARecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{aRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsARecordResource>> GetDnsARecordAsync(string aRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsARecords().GetAsync(aRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{aRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsARecordResource> GetDnsARecord(string aRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsARecords().Get(aRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsAaaaRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsAaaaRecordResources and their operations over a DnsAaaaRecordResource. </returns>
        public virtual DnsAaaaRecordCollection GetDnsAaaaRecords()
        {
            return GetCachedClient(Client => new DnsAaaaRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{aaaaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aaaaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsAaaaRecordResource>> GetDnsAaaaRecordAsync(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsAaaaRecords().GetAsync(aaaaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{aaaaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aaaaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsAaaaRecordResource> GetDnsAaaaRecord(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsAaaaRecords().Get(aaaaRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsCaaRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsCaaRecordResources and their operations over a DnsCaaRecordResource. </returns>
        public virtual DnsCaaRecordCollection GetDnsCaaRecords()
        {
            return GetCachedClient(Client => new DnsCaaRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsCaaRecordResource>> GetDnsCaaRecordAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsCaaRecords().GetAsync(caaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{caaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsCaaRecordResource> GetDnsCaaRecord(string caaRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsCaaRecords().Get(caaRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsCnameRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsCnameRecordResources and their operations over a DnsCnameRecordResource. </returns>
        public virtual DnsCnameRecordCollection GetDnsCnameRecords()
        {
            return GetCachedClient(Client => new DnsCnameRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{cnameRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cnameRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsCnameRecordResource>> GetDnsCnameRecordAsync(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsCnameRecords().GetAsync(cnameRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{cnameRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cnameRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsCnameRecordResource> GetDnsCnameRecord(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsCnameRecords().Get(cnameRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsMXRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsMXRecordResources and their operations over a DnsMXRecordResource. </returns>
        public virtual DnsMXRecordCollection GetDnsMXRecords()
        {
            return GetCachedClient(Client => new DnsMXRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{mxRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsMXRecordResource>> GetDnsMXRecordAsync(string mxRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsMXRecords().GetAsync(mxRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{mxRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsMXRecordResource> GetDnsMXRecord(string mxRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsMXRecords().Get(mxRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsNSRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsNSRecordResources and their operations over a DnsNSRecordResource. </returns>
        public virtual DnsNSRecordCollection GetDnsNSRecords()
        {
            return GetCachedClient(Client => new DnsNSRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsNSRecordResource>> GetDnsNSRecordAsync(string nsRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsNSRecords().GetAsync(nsRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{nsRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsNSRecordResource> GetDnsNSRecord(string nsRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsNSRecords().Get(nsRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsPtrRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsPtrRecordResources and their operations over a DnsPtrRecordResource. </returns>
        public virtual DnsPtrRecordCollection GetDnsPtrRecords()
        {
            return GetCachedClient(Client => new DnsPtrRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{ptrRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsPtrRecordResource>> GetDnsPtrRecordAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsPtrRecords().GetAsync(ptrRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{ptrRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsPtrRecordResource> GetDnsPtrRecord(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsPtrRecords().Get(ptrRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsSoaRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsSoaRecordResources and their operations over a DnsSoaRecordResource. </returns>
        public virtual DnsSoaRecordCollection GetDnsSoaRecords()
        {
            return GetCachedClient(Client => new DnsSoaRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsSoaRecordResource>> GetDnsSoaRecordAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsSoaRecords().GetAsync(soaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{soaRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsSoaRecordResource> GetDnsSoaRecord(string soaRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsSoaRecords().Get(soaRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsSrvRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsSrvRecordResources and their operations over a DnsSrvRecordResource. </returns>
        public virtual DnsSrvRecordCollection GetDnsSrvRecords()
        {
            return GetCachedClient(Client => new DnsSrvRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{srvRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="srvRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsSrvRecordResource>> GetDnsSrvRecordAsync(string srvRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsSrvRecords().GetAsync(srvRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{srvRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="srvRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsSrvRecordResource> GetDnsSrvRecord(string srvRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsSrvRecords().Get(srvRecordName, cancellationToken);
        }

        /// <summary> Gets a collection of DnsTxtRecordResources in the DnsZone. </summary>
        /// <returns> An object representing collection of DnsTxtRecordResources and their operations over a DnsTxtRecordResource. </returns>
        public virtual DnsTxtRecordCollection GetDnsTxtRecords()
        {
            return GetCachedClient(Client => new DnsTxtRecordCollection(Client, Id));
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{txtRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsTxtRecordResource>> GetDnsTxtRecordAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            return await GetDnsTxtRecords().GetAsync(txtRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a record set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{txtRecordName}
        /// Operation Id: RecordSets_Get
        /// </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsTxtRecordResource> GetDnsTxtRecord(string txtRecordName, CancellationToken cancellationToken = default)
        {
            return GetDnsTxtRecords().Get(txtRecordName, cancellationToken);
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DnsZoneResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Get");
            scope.Start();
            try
            {
                var response = await _dnsZoneZonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DnsZoneResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Get");
            scope.Start();
            try
            {
                var response = _dnsZoneZonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DnsZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a DNS zone. WARNING: All DNS records in the zone will also be deleted. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always delete the current zone. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Delete");
            scope.Start();
            try
            {
                using var message = _dnsZoneZonesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch);
                var response = await _dnsZoneZonesRestClient.DeleteAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new DnsArmOperation(_dnsZoneZonesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
        /// Deletes a DNS zone. WARNING: All DNS records in the zone will also be deleted. This operation cannot be undone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always delete the current zone. Specify the last-seen etag value to prevent accidentally deleting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Delete");
            scope.Start();
            try
            {
                using var message = _dnsZoneZonesRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ifMatch);
                var response = _dnsZoneZonesRestClient.Delete(message, cancellationToken);
                var operation = new DnsArmOperation(_dnsZoneZonesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
        /// Updates a DNS zone. Does not modify DNS records within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Update
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<DnsZoneResource>> UpdateAsync(DnsZonePatch patch, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Update");
            scope.Start();
            try
            {
                var response = await _dnsZoneZonesRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, ifMatch, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DnsZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates a DNS zone. Does not modify DNS records within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Update
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<DnsZoneResource> Update(DnsZonePatch patch, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.Update");
            scope.Start();
            try
            {
                var response = _dnsZoneZonesRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, patch, ifMatch, cancellationToken);
                return Response.FromValue(new DnsZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets
        /// Operation Id: RecordSets_ListByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DnsRecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsRecordData> GetAllRecordDataAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DnsRecordData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordData");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListByDnsZoneAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DnsRecordData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordData");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListByDnsZoneNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets
        /// Operation Id: RecordSets_ListByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsRecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsRecordData> GetAllRecordData(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<DnsRecordData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordData");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListByDnsZone(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DnsRecordData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordData");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListByDnsZoneNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordsetnamesuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
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
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<DnsZoneResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _dnsZoneZonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new DnsZonePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<DnsZoneResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _dnsZoneZonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new DnsZonePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags[key] = value;
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<DnsZoneResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _dnsZoneZonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new DnsZonePatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<DnsZoneResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _dnsZoneZonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new DnsZonePatch();
                    patch.Tags.ReplaceWith(tags);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<DnsZoneResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _dnsZoneZonesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    var patch = new DnsZonePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<DnsZoneResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _dnsZoneZonesClientDiagnostics.CreateScope("DnsZoneResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _dnsZoneZonesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                    return Response.FromValue(new DnsZoneResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    var patch = new DnsZonePatch();
                    foreach (var tag in current.Tags)
                    {
                        patch.Tags.Add(tag);
                    }
                    patch.Tags.Remove(key);
                    var result = Update(patch, cancellationToken: cancellationToken);
                    return result;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
