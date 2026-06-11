// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    /// <summary> A class representing the Record data model. </summary>
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("_additionalBinaryDataProperties")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("Properties")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("ETag")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("Metadata")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("TtlInSeconds")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("Fqdn")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("ProvisioningState")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("TargetResource")]
    [global::Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute("TrafficManagementProfile")]
    public partial class DnsRecordData : DnsBaseRecordData
    {
        /// <summary> Initializes a new instance of <see cref="DnsRecordData"/>. </summary>
        public DnsRecordData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DnsRecordData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The properties of the record set. </param>
        /// <param name="eTag"> The etag of the record set. </param>
        internal DnsRecordData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, RecordSetProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, additionalBinaryDataProperties, properties, eTag)
        {
        }

        /// <summary> The list of A records in the record set. </summary>
        public IList<DnsARecordInfo> DnsARecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsARecords;
            }
        }

        /// <summary> The list of AAAA records in the record set. </summary>
        public IList<DnsAaaaRecordInfo> DnsAaaaRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsAaaaRecords;
            }
        }

        /// <summary> The list of MX records in the record set. </summary>
        public IList<DnsMXRecordInfo> DnsMXRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsMXRecords;
            }
        }

        /// <summary> The list of NS records in the record set. </summary>
        public IList<DnsNSRecordInfo> DnsNSRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsNSRecords;
            }
        }

        /// <summary> The list of PTR records in the record set. </summary>
        public IList<DnsPtrRecordInfo> DnsPtrRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsPtrRecords;
            }
        }

        /// <summary> The list of SRV records in the record set. </summary>
        public IList<DnsSrvRecordInfo> DnsSrvRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsSrvRecords;
            }
        }

        /// <summary> The list of TXT records in the record set. </summary>
        public IList<DnsTxtRecordInfo> DnsTxtRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsTxtRecords;
            }
        }

        /// <summary> The SOA record in the record set. </summary>
        public DnsSoaRecordInfo DnsSoaRecord
        {
            get
            {
                return Properties is null ? default : Properties.DnsSoaRecord;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                Properties.DnsSoaRecord = value;
            }
        }

        /// <summary> The list of CAA records in the record set. </summary>
        public IList<DnsCaaRecordInfo> DnsCaaRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsCaaRecords;
            }
        }

        /// <summary> The list of DS records in the record set. </summary>
        public IList<DnsDSRecordInfo> DnsDSRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsDSRecords;
            }
        }

        /// <summary> The list of TLSA records in the record set. </summary>
        public IList<DnsTlsaRecordInfo> DnsTlsaRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsTlsaRecords;
            }
        }

        /// <summary> The list of NAPTR records in the record set. </summary>
        public IList<DnsNaptrRecordInfo> DnsNaptrRecords
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                return Properties.DnsNaptrRecords;
            }
        }

        /// <summary> The canonical name for this CNAME record. </summary>
        public string Cname
        {
            get
            {
                return Properties is null ? default : Properties.Cname;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RecordSetProperties();
                }
                Properties.Cname = value;
            }
        }
    }
}
