// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Resources;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.Dns
{
    /// <summary>
    /// A class representing a DnsZone along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="DnsZoneResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetDnsZones method.
    /// </summary>
    [CodeGenSuppressAttribute("GetDnsARecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsARecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsAaaaRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsAaaaRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsCaaRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsCaaRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsCnameRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsCnameRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsMXRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsMXRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsNSRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsNSRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsPtrRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsPtrRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsSoaRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsSoaRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsSrvRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsSrvRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsTxtRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsTxtRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsTlsaRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsTlsaRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsDSRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsDSRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsNaptrRecordAsync", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetDnsNaptrRecord", typeof(string), typeof(DnsRecordType), typeof(CancellationToken))]
    public partial class DnsZoneResource
    {
        /// <summary> Gets a record set. </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="aRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsARecordResource>> GetDnsARecordAsync(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aRecordName, nameof(aRecordName));

            return await GetDnsARecords().GetAsync(aRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="aRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsARecordResource> GetDnsARecord(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aRecordName, nameof(aRecordName));

            return GetDnsARecords().Get(aRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aaaaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="aaaaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsAaaaRecordResource>> GetDnsAaaaRecordAsync(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aaaaRecordName, nameof(aaaaRecordName));

            return await GetDnsAaaaRecords().GetAsync(aaaaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="aaaaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="aaaaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsAaaaRecordResource> GetDnsAaaaRecord(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aaaaRecordName, nameof(aaaaRecordName));

            return GetDnsAaaaRecords().Get(aaaaRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsCaaRecordResource>> GetDnsCaaRecordAsync(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            return await GetDnsCaaRecords().GetAsync(caaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="caaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="caaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsCaaRecordResource> GetDnsCaaRecord(string caaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(caaRecordName, nameof(caaRecordName));

            return GetDnsCaaRecords().Get(caaRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cnameRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="cnameRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsCnameRecordResource>> GetDnsCnameRecordAsync(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(cnameRecordName, nameof(cnameRecordName));

            return await GetDnsCnameRecords().GetAsync(cnameRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="cnameRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="cnameRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsCnameRecordResource> GetDnsCnameRecord(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(cnameRecordName, nameof(cnameRecordName));

            return GetDnsCnameRecords().Get(cnameRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mxRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsMXRecordResource>> GetDnsMXRecordAsync(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mxRecordName, nameof(mxRecordName));

            return await GetDnsMXRecords().GetAsync(mxRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mxRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mxRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsMXRecordResource> GetDnsMXRecord(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mxRecordName, nameof(mxRecordName));

            return GetDnsMXRecords().Get(mxRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nsRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsNSRecordResource>> GetDnsNSRecordAsync(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nsRecordName, nameof(nsRecordName));

            return await GetDnsNSRecords().GetAsync(nsRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="nsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nsRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="nsRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsNSRecordResource> GetDnsNSRecord(string nsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(nsRecordName, nameof(nsRecordName));

            return GetDnsNSRecords().Get(nsRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsPtrRecordResource>> GetDnsPtrRecordAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            return await GetDnsPtrRecords().GetAsync(ptrRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsPtrRecordResource> GetDnsPtrRecord(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));

            return GetDnsPtrRecords().Get(ptrRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsSoaRecordResource>> GetDnsSoaRecordAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            return await GetDnsSoaRecords().GetAsync(soaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="soaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="soaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsSoaRecordResource> GetDnsSoaRecord(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));

            return GetDnsSoaRecords().Get(soaRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="srvRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="srvRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsSrvRecordResource>> GetDnsSrvRecordAsync(string srvRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(srvRecordName, nameof(srvRecordName));

            return await GetDnsSrvRecords().GetAsync(srvRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="srvRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="srvRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsSrvRecordResource> GetDnsSrvRecord(string srvRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(srvRecordName, nameof(srvRecordName));

            return GetDnsSrvRecords().Get(srvRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsTxtRecordResource>> GetDnsTxtRecordAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            return await GetDnsTxtRecords().GetAsync(txtRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="txtRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="txtRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsTxtRecordResource> GetDnsTxtRecord(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));

            return GetDnsTxtRecords().Get(txtRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="tlsaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tlsaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tlsaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsTlsaRecordResource>> GetDnsTlsaRecordAsync(string tlsaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tlsaRecordName, nameof(tlsaRecordName));

            return await GetDnsTlsaRecords().GetAsync(tlsaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="tlsaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tlsaRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tlsaRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsTlsaRecordResource> GetDnsTlsaRecord(string tlsaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tlsaRecordName, nameof(tlsaRecordName));

            return GetDnsTlsaRecords().Get(tlsaRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dsRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dsRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsDSRecordResource>> GetDnsDSRecordAsync(string dsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dsRecordName, nameof(dsRecordName));

            return await GetDnsDSRecords().GetAsync(dsRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="dsRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dsRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dsRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsDSRecordResource> GetDnsDSRecord(string dsRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dsRecordName, nameof(dsRecordName));

            return GetDnsDSRecords().Get(dsRecordName, cancellationToken);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="naptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="naptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="naptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DnsNaptrRecordResource>> GetDnsNaptrRecordAsync(string naptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(naptrRecordName, nameof(naptrRecordName));

            return await GetDnsNaptrRecords().GetAsync(naptrRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="naptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="naptrRecordName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="naptrRecordName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<DnsNaptrRecordResource> GetDnsNaptrRecord(string naptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(naptrRecordName, nameof(naptrRecordName));

            return GetDnsNaptrRecords().Get(naptrRecordName, cancellationToken);
        }

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsRecordData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DnsRecordData> GetAllRecordDataAsync(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => GetByDnsZoneAsync(top, recordsetnamesuffix, cancellationToken);

        /// <summary> Lists all record sets in a DNS zone. </summary>
        /// <param name="top"> The maximum number of record sets to return. </param>
        /// <param name="recordsetnamesuffix"> The suffix label of the record set name used to filter record set enumerations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsRecordData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<DnsRecordData> GetAllRecordData(int? top = default, string recordsetnamesuffix = null, CancellationToken cancellationToken = default)
            => GetByDnsZone(top, recordsetnamesuffix, cancellationToken);

        /// <summary>
        /// Updates a DNS zone. Does not modify DNS records within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Zones_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsZoneResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual async Task<Response<DnsZoneResource>> UpdateAsync(DnsZonePatch patch, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _zonesClientDiagnostics.CreateScope("DnsZoneResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _zonesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, DnsZonePatch.ToRequestContent(patch), ifMatch, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DnsZoneData> response = Response.FromValue(DnsZoneData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
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
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> Zones_Update. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2023-07-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="DnsZoneResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="patch"> Parameters supplied to the Update operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patch"/> is null. </exception>
        public virtual Response<DnsZoneResource> Update(DnsZonePatch patch, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));

            using DiagnosticScope scope = _zonesClientDiagnostics.CreateScope("DnsZoneResource.Update");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _zonesRestClient.CreateUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, DnsZonePatch.ToRequestContent(patch), ifMatch, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DnsZoneData> response = Response.FromValue(DnsZoneData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new DnsZoneResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
