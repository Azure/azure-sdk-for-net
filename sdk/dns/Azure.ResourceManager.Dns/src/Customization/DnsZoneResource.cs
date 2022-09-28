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
        /// <summary>
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/recordsets
        /// Operation Id: RecordSets_ListByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordData> GetRecordsInDnsZoneAsync(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RecordData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetRecordsInDnsZone");
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
            async Task<Page<RecordData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetRecordsInDnsZone");
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
        /// <returns> A collection of <see cref="RecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordData> GetRecordsInDnsZone(int? top = null, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
        {
            Page<RecordData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetRecordsInDnsZone");
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
            Page<RecordData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetRecordsInDnsZone");
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
        /// Lists all record sets in a DNS zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/all
        /// Operation Id: RecordSets_ListAllByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RecordData> GetAllRecordsInDnsZoneAsync(int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RecordData>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordsInDnsZone");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListAllByDnsZoneAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<RecordData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordsInDnsZone");
                scope.Start();
                try
                {
                    var response = await _recordSetsRestClient.ListAllByDnsZoneNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/all
        /// Operation Id: RecordSets_ListAllByDnsZone
        /// </summary>
        /// <param name="top"> The maximum number of record sets to return. If not specified, returns up to 100 record sets. </param>
        /// <param name="recordSetNameSuffix"> The suffix label of the record set name that has to be used to filter the record set enumerations. If this parameter is specified, Enumeration will return only records that end with .&lt;recordSetNameSuffix&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RecordData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RecordData> GetAllRecordsInDnsZone(int? top = null, string recordSetNameSuffix = null, CancellationToken cancellationToken = default)
        {
            Page<RecordData> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordsInDnsZone");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListAllByDnsZone(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<RecordData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _recordSetsClientDiagnostics.CreateScope("DnsZoneResource.GetAllRecordsInDnsZone");
                scope.Start();
                try
                {
                    var response = _recordSetsRestClient.ListAllByDnsZoneNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top, recordSetNameSuffix, cancellationToken: cancellationToken);
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
    }
}
