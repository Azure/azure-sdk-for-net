
namespace Microsoft.Azure.Management.Dns.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Describes a DNS RecordSet (a set of DNS records with the same name and
    /// type).
    /// </summary>
    [JsonTransformation]
    public partial class RecordSet
    {
        /// <summary>
        /// Initializes a new instance of the RecordSet class.
        /// </summary>
        public RecordSet() { }

        /// <summary>
        /// Initializes a new instance of the RecordSet class.
        /// </summary>
        public RecordSet(string id = default(string), string name = default(string), string type = default(string), string etag = default(string), IDictionary<string, string> metadata = default(IDictionary<string, string>), long? tTL = default(long?), IList<ARecord> aRecords = default(IList<ARecord>), IList<AaaaRecord> aaaaRecords = default(IList<AaaaRecord>), IList<MxRecord> mxRecords = default(IList<MxRecord>), IList<NsRecord> nsRecords = default(IList<NsRecord>), IList<PtrRecord> ptrRecords = default(IList<PtrRecord>), IList<SrvRecord> srvRecords = default(IList<SrvRecord>), IList<TxtRecord> txtRecords = default(IList<TxtRecord>), CnameRecord cnameRecord = default(CnameRecord), SoaRecord soaRecord = default(SoaRecord))
        {
            Id = id;
            Name = name;
            Type = type;
            Etag = etag;
            Metadata = metadata;
            TTL = tTL;
            ARecords = aRecords;
            AaaaRecords = aaaaRecords;
            MxRecords = mxRecords;
            NsRecords = nsRecords;
            PtrRecords = ptrRecords;
            SrvRecords = srvRecords;
            TxtRecords = txtRecords;
            CnameRecord = cnameRecord;
            SoaRecord = soaRecord;
        }

        /// <summary>
        /// Gets or sets the ID of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the ETag of the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the metadata attached to the resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.metadata")]
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Gets or sets the TTL of the records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.TTL")]
        public long? TTL { get; set; }

        /// <summary>
        /// Gets or sets the list of A records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ARecords")]
        public IList<ARecord> ARecords { get; set; }

        /// <summary>
        /// Gets or sets the list of AAAA records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.AAAARecords")]
        public IList<AaaaRecord> AaaaRecords { get; set; }

        /// <summary>
        /// Gets or sets the list of MX records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.MXRecords")]
        public IList<MxRecord> MxRecords { get; set; }

        /// <summary>
        /// Gets or sets the list of NS records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.NSRecords")]
        public IList<NsRecord> NsRecords { get; set; }

        /// <summary>
        /// Gets or sets the list of PTR records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.PTRRecords")]
        public IList<PtrRecord> PtrRecords { get; set; }

        /// <summary>
        /// Gets or sets the list of SRV records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.SRVRecords")]
        public IList<SrvRecord> SrvRecords { get; set; }

        /// <summary>
        /// Gets or sets the list of TXT records in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.TXTRecords")]
        public IList<TxtRecord> TxtRecords { get; set; }

        /// <summary>
        /// Gets or sets the CNAME record in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.CNAMERecord")]
        public CnameRecord CnameRecord { get; set; }

        /// <summary>
        /// Gets or sets the SOA record in the RecordSet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.SOARecord")]
        public SoaRecord SoaRecord { get; set; }

    }
}
