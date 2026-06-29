// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec emits generic record-set get methods with a recordType parameter; these forwarders preserve the shipped fixed-record-type zone APIs.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Resources;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary>
    /// A class representing a PrivateDnsZone along with the instance operations that can be performed on it.
    /// </summary>
    [CodeGenSuppressAttribute("GetPrivateDnsARecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsARecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsAaaaRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsAaaaRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsCnameRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsCnameRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsMXRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsMXRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsPtrRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsPtrRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsSoaRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsSoaRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsSrvRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsSrvRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    [CodeGenSuppressAttribute("GetPrivateDnsTxtRecordAsync", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppressAttribute("GetPrivateDnsTxtRecord", typeof(PrivateDnsRecordType), typeof(string), typeof(CancellationToken))]    public partial class PrivateDnsZoneResource
    {
        /// <summary> Gets a record set. </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsARecordResource>> GetPrivateDnsARecordAsync(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aRecordName, nameof(aRecordName));
            return await GetPrivateDnsARecords().GetAsync(aRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="aRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsARecordResource> GetPrivateDnsARecord(string aRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aRecordName, nameof(aRecordName));
            return GetPrivateDnsARecords().Get(aRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsAaaaRecordResource>> GetPrivateDnsAaaaRecordAsync(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aaaaRecordName, nameof(aaaaRecordName));
            return await GetPrivateDnsAaaaRecords().GetAsync(aaaaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="aaaaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsAaaaRecordResource> GetPrivateDnsAaaaRecord(string aaaaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aaaaRecordName, nameof(aaaaRecordName));
            return GetPrivateDnsAaaaRecords().Get(aaaaRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsCnameRecordResource>> GetPrivateDnsCnameRecordAsync(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(cnameRecordName, nameof(cnameRecordName));
            return await GetPrivateDnsCnameRecords().GetAsync(cnameRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="cnameRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsCnameRecordResource> GetPrivateDnsCnameRecord(string cnameRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(cnameRecordName, nameof(cnameRecordName));
            return GetPrivateDnsCnameRecords().Get(cnameRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsMXRecordResource>> GetPrivateDnsMXRecordAsync(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mxRecordName, nameof(mxRecordName));
            return await GetPrivateDnsMXRecords().GetAsync(mxRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="mxRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsMXRecordResource> GetPrivateDnsMXRecord(string mxRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(mxRecordName, nameof(mxRecordName));
            return GetPrivateDnsMXRecords().Get(mxRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsPtrRecordResource>> GetPrivateDnsPtrRecordAsync(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));
            return await GetPrivateDnsPtrRecords().GetAsync(ptrRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="ptrRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsPtrRecordResource> GetPrivateDnsPtrRecord(string ptrRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ptrRecordName, nameof(ptrRecordName));
            return GetPrivateDnsPtrRecords().Get(ptrRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsSoaRecordResource>> GetPrivateDnsSoaRecordAsync(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));
            return await GetPrivateDnsSoaRecords().GetAsync(soaRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="soaRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsSoaRecordResource> GetPrivateDnsSoaRecord(string soaRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(soaRecordName, nameof(soaRecordName));
            return GetPrivateDnsSoaRecords().Get(soaRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsSrvRecordResource>> GetPrivateDnsSrvRecordAsync(string srvRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(srvRecordName, nameof(srvRecordName));
            return await GetPrivateDnsSrvRecords().GetAsync(srvRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="srvRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsSrvRecordResource> GetPrivateDnsSrvRecord(string srvRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(srvRecordName, nameof(srvRecordName));
            return GetPrivateDnsSrvRecords().Get(srvRecordName, cancellationToken);
        }
        /// <summary> Gets a record set. </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<PrivateDnsTxtRecordResource>> GetPrivateDnsTxtRecordAsync(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));
            return await GetPrivateDnsTxtRecords().GetAsync(txtRecordName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a record set. </summary>
        /// <param name="txtRecordName"> The name of the record set, relative to the name of the zone. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<PrivateDnsTxtRecordResource> GetPrivateDnsTxtRecord(string txtRecordName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(txtRecordName, nameof(txtRecordName));
            return GetPrivateDnsTxtRecords().Get(txtRecordName, cancellationToken);
        }    }
}