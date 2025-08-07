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
        public static DnsAaaaRecordData DnsAaaaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsAaaaRecordInfo> aaaaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aaaaRecords ??= new List<DnsAaaaRecordInfo>();

            return new DnsAaaaRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                aaaaRecords: aaaaRecords,
                serializedAdditionalRawData: null);
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
        public static DnsARecordData DnsARecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsARecordInfo> aRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            aRecords ??= new List<DnsARecordInfo>();

            return new DnsARecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                aRecords: aRecords,
                serializedAdditionalRawData: null);
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
        public static DnsCaaRecordData DnsCaaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsCaaRecordInfo> caaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            caaRecords ??= new List<DnsCaaRecordInfo>();

            return new DnsCaaRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                caaRecords: caaRecords,
                serializedAdditionalRawData: null);
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
        public static DnsCnameRecordData DnsCnameRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, string CnameRecordName = null)
        {
            metadata ??= new Dictionary<string, string>();
            DnsCnameRecordInfo cnameRecord = new DnsCnameRecordInfo(CnameRecordName, serializedAdditionalRawData: null);

            return new DnsCnameRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                cnameRecord: new DnsCnameRecordInfo(),
                serializedAdditionalRawData: null)
            {
                Cname = CnameRecordName
            };
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
        /// <returns> A new <see cref="Dns.DnsDSRecordData"/> instance for mocking. </returns>
        public static DnsMXRecordData DnsMXRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsMXRecordInfo> mxRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            mxRecords ??= new List<DnsMXRecordInfo>();

            return new DnsMXRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                mxRecords: mxRecords,
                serializedAdditionalRawData: null);
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
        public static DnsNSRecordData DnsNSRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsNSRecordInfo> nsRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            nsRecords ??= new List<DnsNSRecordInfo>();

            return new DnsNSRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                nsRecords: nsRecords,
                serializedAdditionalRawData: null);
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
        public static DnsPtrRecordData DnsPtrRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsPtrRecordInfo> ptrRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            ptrRecords ??= new List<DnsPtrRecordInfo>();

            return new DnsPtrRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                ptrRecords: ptrRecords,
                serializedAdditionalRawData: null);
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
        public static DnsSoaRecordData DnsSoaRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, DnsSoaRecordInfo soaRecords = null)
        {
            metadata ??= new Dictionary<string, string>();

            return new DnsSoaRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                soaRecord: soaRecords,
                serializedAdditionalRawData: null);
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
        public static DnsSrvRecordData DnsSrvRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsSrvRecordInfo> srvRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            srvRecords ??= new List<DnsSrvRecordInfo>();

            return new DnsSrvRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                srvRecords: srvRecords,
                serializedAdditionalRawData: null);
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
        public static DnsTxtRecordData DnsTxtRecordData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, ETag? etag = default, IDictionary<string, string> metadata = null, long? ttl = null, string fqdn = null, string provisioningState = null, WritableSubResource targetResource = null, IList<DnsTxtRecordInfo> txtRecords = null)
        {
            metadata ??= new Dictionary<string, string>();
            txtRecords ??= new List<DnsTxtRecordInfo>();

            return new DnsTxtRecordData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: new WritableSubResource(),
                txtRecords: txtRecords,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="DnsRecordData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The etag of the record set. </param>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttl"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="trafficManagementProfile"> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </param>
        /// <param name="aRecords"> The list of A records in the record set. </param>
        /// <param name="aaaaRecords"> The list of AAAA records in the record set. </param>
        /// <param name="mxRecords"> The list of MX records in the record set. </param>
        /// <param name="nsRecords"> The list of NS records in the record set. </param>
        /// <param name="ptrRecords"> The list of PTR records in the record set. </param>
        /// <param name="srvRecords"> The list of SRV records in the record set. </param>
        /// <param name="txtRecords"> The list of TXT records in the record set. </param>
        /// <param name="cname"> The canonical name for this CNAME record. </param>
        /// <param name="soaRecordInfo"> The SOA record in the record set. </param>
        /// <param name="caaRecords"> The list of CAA records in the record set. </param>
        /// <param name="dsRecords"> The list of DS records in the record set. </param>
        /// <param name="tlsaRecords"> The list of TLSA records in the record set. </param>
        /// <param name="naptrRecords"> The list of NAPTR records in the record set. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        public static DnsRecordData DnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, ETag? etag, IDictionary<string, string> metadata, long? ttl, string fqdn, string provisioningState, WritableSubResource targetResource, WritableSubResource trafficManagementProfile, IList<DnsARecordInfo> aRecords, IList<DnsAaaaRecordInfo> aaaaRecords, IList<DnsMXRecordInfo> mxRecords, IList<DnsNSRecordInfo> nsRecords, IList<DnsPtrRecordInfo> ptrRecords, IList<DnsSrvRecordInfo> srvRecords, IList<DnsTxtRecordInfo> txtRecords, string cname, DnsSoaRecordInfo soaRecordInfo, IList<DnsCaaRecordInfo> caaRecords, IList<DnsDSRecordInfo> dsRecords, IList<DnsTlsaRecordInfo> tlsaRecords, IList<DnsNaptrRecordInfo> naptrRecords, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            metadata ??= new Dictionary<string, string>();
            aRecords ??= new List<DnsARecordInfo>();
            aaaaRecords ??= new List<DnsAaaaRecordInfo>();
            mxRecords ??= new List<DnsMXRecordInfo>();
            nsRecords ??= new List<DnsNSRecordInfo>();
            ptrRecords ??= new List<DnsPtrRecordInfo>();
            srvRecords ??= new List<DnsSrvRecordInfo>();
            txtRecords ??= new List<DnsTxtRecordInfo>();
            caaRecords ??= new List<DnsCaaRecordInfo>();
            dsRecords ??= new List<DnsDSRecordInfo>();
            tlsaRecords ??= new List<DnsTlsaRecordInfo>();
            naptrRecords ??= new List<DnsNaptrRecordInfo>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();
            DnsCnameRecordInfo cnameRecodrInfo = new DnsCnameRecordInfo() { Cname = cname };

            return new DnsRecordData(
                id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                etag: etag,
                metadata: metadata,
                ttl: ttl,
                fqdn: fqdn,
                provisioningState: provisioningState,
                targetResource: targetResource,
                trafficManagementProfile: trafficManagementProfile,
                aRecords: aRecords,
                aaaaRecords: aaaaRecords,
                mxRecords: mxRecords,
                nsRecords: nsRecords,
                ptrRecords: ptrRecords,
                srvRecords: srvRecords,
                txtRecords: txtRecords,
                cnameRecordInfo: cnameRecodrInfo,
                soaRecordInfo: soaRecordInfo,
                caaRecords: caaRecords,
                dsRecords: dsRecords,
                tlsaRecords: tlsaRecords,
                naptrRecords: naptrRecords,
                serializedAdditionalRawData: serializedAdditionalRawData);
        }
    }
}
