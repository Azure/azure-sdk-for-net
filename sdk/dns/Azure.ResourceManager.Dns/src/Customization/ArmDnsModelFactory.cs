// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns.Models
{
    public static partial class ArmDnsModelFactory
    {
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="systemData"></param>
        /// <param name="properties"></param>
        /// <param name="eTag"></param>
        /// <returns> A new <see cref="Dns.DnsRecordData"/> instance for mocking. </returns>
        public static DnsRecordData DnsRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, DnsRecordSetProperties properties = default, ETag? eTag = default)
        {
            return new DnsRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, eTag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsARecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsARecordData"/> instance for mocking. </returns>
        public static DnsARecordData DnsARecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsARecordInfo> aRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsARecords: aRecords);
            return new DnsARecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsAaaaRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsAaaaRecordData"/> instance for mocking. </returns>
        public static DnsAaaaRecordData DnsAaaaRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsAaaaRecordInfo> aaaaRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsAaaaRecords: aaaaRecords);
            return new DnsAaaaRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsCaaRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="caaRecords"> The list of CAA records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsCaaRecordData"/> instance for mocking. </returns>
        public static DnsCaaRecordData DnsCaaRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsCaaRecordInfo> caaRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsCaaRecords: caaRecords);
            return new DnsCaaRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsCnameRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="CnameRecordName"> The canonical name for this CNAME record. </param>
        /// <returns> A new <see cref="Dns.DnsCnameRecordData"/> instance for mocking. </returns>
        public static DnsCnameRecordData DnsCnameRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, string CnameRecordName = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, cname: CnameRecordName);
            return new DnsCnameRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsMXRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsMXRecordData"/> instance for mocking. </returns>
        public static DnsMXRecordData DnsMXRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsMXRecordInfo> mxRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsMXRecords: mxRecords);
            return new DnsMXRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsNSRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsNSRecordData"/> instance for mocking. </returns>
        public static DnsNSRecordData DnsNSRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsNSRecordInfo> nsRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsNSRecords: nsRecords);
            return new DnsNSRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsPtrRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsPtrRecordData"/> instance for mocking. </returns>
        public static DnsPtrRecordData DnsPtrRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsPtrRecordInfo> ptrRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsPtrRecords: ptrRecords);
            return new DnsPtrRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsSoaRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="soaRecords"> The SOA record in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsSoaRecordData"/> instance for mocking. </returns>
        public static DnsSoaRecordData DnsSoaRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, DnsSoaRecordInfo soaRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsSoaRecord: soaRecords);
            return new DnsSoaRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsSrvRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsSrvRecordData"/> instance for mocking. </returns>
        public static DnsSrvRecordData DnsSrvRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsSrvRecordInfo> srvRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsSrvRecords: srvRecords);
            return new DnsSrvRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        /// <summary> Initializes a new instance of <see cref="Dns.DnsTxtRecordData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL of the record set. </param>
        /// <param name="fqdn"> The fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> The provisioning state of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsTxtRecordData"/> instance for mocking. </returns>
        public static DnsTxtRecordData DnsTxtRecordData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ETag? etag = default, IDictionary<string, string> metadata = default, long? ttl = default, string fqdn = default, string provisioningState = default, WritableSubResource targetResource = default, IList<DnsTxtRecordInfo> txtRecords = default)
        {
            DnsRecordSetProperties properties = CreateDnsRecordSetProperties(metadata, ttl, fqdn, provisioningState, targetResource, dnsTxtRecords: txtRecords);
            return new DnsTxtRecordData(id, name, resourceType, systemData, new Dictionary<string, BinaryData>(), properties, etag);
        }

        private static DnsRecordSetProperties CreateDnsRecordSetProperties(
            IDictionary<string, string> metadata,
            long? ttlInSeconds,
            string fqdn,
            string provisioningState,
            WritableSubResource targetResource,
            IList<DnsARecordInfo> dnsARecords = default,
            IList<DnsAaaaRecordInfo> dnsAaaaRecords = default,
            IList<DnsMXRecordInfo> dnsMXRecords = default,
            IList<DnsNSRecordInfo> dnsNSRecords = default,
            IList<DnsPtrRecordInfo> dnsPtrRecords = default,
            IList<DnsSrvRecordInfo> dnsSrvRecords = default,
            IList<DnsTxtRecordInfo> dnsTxtRecords = default,
            string cname = default,
            DnsSoaRecordInfo dnsSoaRecord = default,
            IList<DnsCaaRecordInfo> dnsCaaRecords = default)
        {
            return new DnsRecordSetProperties(
                metadata ?? new Dictionary<string, string>(),
                ttlInSeconds,
                fqdn,
                provisioningState,
                targetResource,
                default,
                dnsARecords ?? new List<DnsARecordInfo>(),
                dnsAaaaRecords ?? new List<DnsAaaaRecordInfo>(),
                dnsMXRecords ?? new List<DnsMXRecordInfo>(),
                dnsNSRecords ?? new List<DnsNSRecordInfo>(),
                dnsPtrRecords ?? new List<DnsPtrRecordInfo>(),
                dnsSrvRecords ?? new List<DnsSrvRecordInfo>(),
                dnsTxtRecords ?? new List<DnsTxtRecordInfo>(),
                cname is null ? default : new DnsCnameRecordInfo() { Cname = cname },
                dnsSoaRecord,
                dnsCaaRecords ?? new List<DnsCaaRecordInfo>(),
                new List<DnsDSRecordInfo>(),
                new List<DnsTlsaRecordInfo>(),
                new List<DnsNaptrRecordInfo>(),
                new Dictionary<string, BinaryData>());
        }
    }
}
