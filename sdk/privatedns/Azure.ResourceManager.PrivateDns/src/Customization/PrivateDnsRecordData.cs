// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates PrivateDnsRecordData with prefixed record-list properties; these members preserve the shipped unprefixed aggregate record API.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the Record data model. </summary>
    [CodeGenSuppressAttribute("_additionalBinaryDataProperties")]
    [CodeGenSuppressAttribute("Properties")]
    [CodeGenSuppressAttribute("ETag")]
    [CodeGenSuppressAttribute("Metadata")]
    [CodeGenSuppressAttribute("TtlInSeconds")]
    [CodeGenSuppressAttribute("Fqdn")]
    [CodeGenSuppressAttribute("IsAutoRegistered")]
    [CodeGenSuppressAttribute("PrivateDnsARecords")]
    [CodeGenSuppressAttribute("PrivateDnsAaaaRecords")]
    [CodeGenSuppressAttribute("PrivateDnsMXRecords")]
    [CodeGenSuppressAttribute("PrivateDnsPtrRecords")]
    [CodeGenSuppressAttribute("PrivateDnsSoaRecord")]
    [CodeGenSuppressAttribute("PrivateDnsSrvRecords")]
    [CodeGenSuppressAttribute("PrivateDnsTxtRecords")]
    [CodeGenSuppressAttribute("Cname")]
    [CodeGenSuppressAttribute("Name")]
    [CodeGenSuppressAttribute("PrivateDnsRecordData", typeof(IDictionary<string, BinaryData>))]
    public partial class PrivateDnsRecordData : PrivateDnsBaseRecordData
    {
        /// <summary> Initializes a new instance of <see cref="PrivateDnsRecordData"/>. </summary>
        public PrivateDnsRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PrivateDnsRecordData"/>. </summary>
        internal PrivateDnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, PrivateDnsRecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, additionalBinaryDataProperties, properties, eTag)
        {
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<PrivateDnsARecordInfo> ARecords => EnsureProperties().PrivateDnsARecords;

        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<PrivateDnsAaaaRecordInfo> AaaaRecords => EnsureProperties().PrivateDnsAaaaRecords;

        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get => Properties is null ? default : Properties.Cname;
            set => EnsureProperties().Cname = value;
        }

        /// <summary> The list of MX records in the record set. </summary>
        public IList<PrivateDnsMXRecordInfo> MXRecords => EnsureProperties().PrivateDnsMXRecords;

        /// <summary> The list of PTR records in the record set. </summary>
        public IList<PrivateDnsPtrRecordInfo> PtrRecords => EnsureProperties().PrivateDnsPtrRecords;

        /// <summary> The SOA record in the record set. </summary>
        public PrivateDnsSoaRecordInfo PrivateDnsSoaRecordInfo
        {
            get => Properties is null ? default : Properties.PrivateDnsSoaRecord;
            set => EnsureProperties().PrivateDnsSoaRecord = value;
        }

        /// <summary> The list of SRV records in the record set. </summary>
        public IList<PrivateDnsSrvRecordInfo> SrvRecords => EnsureProperties().PrivateDnsSrvRecords;

        /// <summary> The list of TXT records in the record set. </summary>
        public IList<PrivateDnsTxtRecordInfo> TxtRecords => EnsureProperties().PrivateDnsTxtRecords;

        /// <summary> The PrivateDnsRecordType in the record set. </summary>
        public PrivateDnsRecordType RecordType
        {
            get
            {
                string resourceTypeString = base.ResourceType.Type.Split('/').Where(part => !string.IsNullOrEmpty(part)).LastOrDefault();
                return PrivateDnsRecordTypeExtensions.ToPrivateDnsRecordType(resourceTypeString);
            }
        }

        internal static AsyncPageable<TResource> GetAllAsync<TResource>(RecordSets recordSetsRestClient, ArmClient client, ResourceIdentifier zoneId, string recordType, int? top, string recordsetnamesuffix, CancellationToken cancellationToken, string diagnosticScope, Func<ArmClient, PrivateDnsRecordData, TResource> createResource)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };

            return new AsyncPageableWrapper<PrivateDnsRecordData, TResource>(
                new RecordSetsGetByTypeAsyncCollectionResultOfT(recordSetsRestClient, zoneId.SubscriptionId, zoneId.ResourceGroupName, zoneId.Name, recordType, top, recordsetnamesuffix, context, diagnosticScope),
                data => createResource(client, data));
        }

            internal static Pageable<TResource> GetAll<TResource>(RecordSets recordSetsRestClient, ArmClient client, ResourceIdentifier zoneId, string recordType, int? top, string recordsetnamesuffix, CancellationToken cancellationToken, string diagnosticScope, Func<ArmClient, PrivateDnsRecordData, TResource> createResource)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };

            return new PageableWrapper<PrivateDnsRecordData, TResource>(
                new RecordSetsGetByTypeCollectionResultOfT(recordSetsRestClient, zoneId.SubscriptionId, zoneId.ResourceGroupName, zoneId.Name, recordType, top, recordsetnamesuffix, context, diagnosticScope),
                data => createResource(client, data));
        }

            internal PrivateDnsARecordData ToARecordData() => new PrivateDnsARecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsAaaaRecordData ToAaaaRecordData() => new PrivateDnsAaaaRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsCnameRecordData ToCnameRecordData() => new PrivateDnsCnameRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsMXRecordData ToMXRecordData() => new PrivateDnsMXRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsPtrRecordData ToPtrRecordData() => new PrivateDnsPtrRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsSoaRecordData ToSoaRecordData() => new PrivateDnsSoaRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsSrvRecordData ToSrvRecordData() => new PrivateDnsSrvRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

            internal PrivateDnsTxtRecordData ToTxtRecordData() => new PrivateDnsTxtRecordData(Id, Name, ResourceType, SystemData, _additionalBinaryDataProperties, Properties, ETag);

        private PrivateDnsRecordSetProperties EnsureProperties()
        {
            if (Properties is null)
            {
                Properties = new PrivateDnsRecordSetProperties();
            }
            return Properties;
        }
    }
}
