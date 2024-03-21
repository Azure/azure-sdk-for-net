// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDnsModelFactory
    {
        /// <summary> Initializes a new instance of DnsAaaaRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsAaaaRecordData"/> instance for mocking. </returns>
        public static DnsAaaaRecordData DnsAaaaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsAaaaRecordInfo> aaaaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aaaaRecords ??= new List<DnsAaaaRecordInfo>();

            return new DnsAaaaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aaaaRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsARecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsARecordData"/> instance for mocking. </returns>
        public static DnsARecordData DnsARecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsARecordInfo> aRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aRecords ??= new List<DnsARecordInfo>();

            return new DnsARecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, aRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsCaaRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="caaRecords"> The list of Caa records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsCaaRecordData"/> instance for mocking. </returns>
        public static DnsCaaRecordData DnsCaaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsCaaRecordInfo> caaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            caaRecords ??= new List<DnsCaaRecordInfo>();

            return new DnsCaaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, caaRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsCnameRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="CnameRecordName"> The canonical name for this CNAME record. </param>
        /// <returns> A new <see cref="Dns.DnsCnameRecordData"/> instance for mocking. </returns>
        public static DnsCnameRecordData DnsCnameRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, string CnameRecordName = null)
        {
            metadata ??= new Dictionary<string, string>();
            DnsCnameRecordInfo cnameRecord = new DnsCnameRecordInfo(CnameRecordName, serializedAdditionalRawData: null);

            return new DnsCnameRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, cnameRecord, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsMXRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsMXRecordData"/> instance for mocking. </returns>
        public static DnsMXRecordData DnsMXRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsMXRecordInfo> mxRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            mxRecords ??= new List<DnsMXRecordInfo>();

            return new DnsMXRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, mxRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsNSRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsNSRecordData"/> instance for mocking. </returns>
        public static DnsNSRecordData DnsNSRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsNSRecordInfo> nsRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            nsRecords ??= new List<DnsNSRecordInfo>();

            return new DnsNSRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, nsRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsPtrRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="ptrRecords"> The list of Ptr records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsPtrRecordData"/> instance for mocking. </returns>
        public static DnsPtrRecordData DnsPtrRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsPtrRecordInfo> ptrRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            ptrRecords ??= new List<DnsPtrRecordInfo>();

            return new DnsPtrRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, ptrRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsSoaRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="soaRecords"> The SOA record in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsSoaRecordData"/> instance for mocking. </returns>
        public static DnsSoaRecordData DnsSoaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, DnsSoaRecordInfo soaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();

            return new DnsSoaRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, soaRecords, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsSrvRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="srvRecords"> The list of Srv records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsSrvRecordData"/> instance for mocking. </returns>
        public static DnsSrvRecordData DnsSrvRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsSrvRecordInfo> srvRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            srvRecords ??= new List<DnsSrvRecordInfo>();

            return new DnsSrvRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, srvRecords?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of DnsTxtRecordData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The Ttl (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="txtRecords"> The list of Txt records in the record set. </param>
        /// <returns> A new <see cref="Dns.DnsTxtRecordData"/> instance for mocking. </returns>
        public static DnsTxtRecordData DnsTxtRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsTxtRecordInfo> txtRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            txtRecords ??= new List<DnsTxtRecordInfo>();

            return new DnsTxtRecordData(id, name, resourceType, systemData, etag, metadata, ttl, fqdn, provisioningState, targetResource, txtRecords?.ToList(), serializedAdditionalRawData: null);
        }
    }
}
