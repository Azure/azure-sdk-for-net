
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
    /// An SOA record.
    /// </summary>
    public partial class SoaRecord
    {
        /// <summary>
        /// Initializes a new instance of the SoaRecord class.
        /// </summary>
        public SoaRecord() { }

        /// <summary>
        /// Initializes a new instance of the SoaRecord class.
        /// </summary>
        public SoaRecord(string host = default(string), string email = default(string), long? serialNumber = default(long?), long? refreshTime = default(long?), long? retryTime = default(long?), long? expireTime = default(long?), long? minimumTtl = default(long?))
        {
            Host = host;
            Email = email;
            SerialNumber = serialNumber;
            RefreshTime = refreshTime;
            RetryTime = retryTime;
            ExpireTime = expireTime;
            MinimumTtl = minimumTtl;
        }

        /// <summary>
        /// Gets or sets the domain name of the authoritative name server,
        /// without a temrinating dot.
        /// </summary>
        [JsonProperty(PropertyName = "host")]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the email for this record.
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the serial number for this record.
        /// </summary>
        [JsonProperty(PropertyName = "serialNumber")]
        public long? SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the refresh value for this record.
        /// </summary>
        [JsonProperty(PropertyName = "refreshTime")]
        public long? RefreshTime { get; set; }

        /// <summary>
        /// Gets or sets the retry time for this record.
        /// </summary>
        [JsonProperty(PropertyName = "retryTime")]
        public long? RetryTime { get; set; }

        /// <summary>
        /// Gets or sets the expire time for this record.
        /// </summary>
        [JsonProperty(PropertyName = "expireTime")]
        public long? ExpireTime { get; set; }

        /// <summary>
        /// Gets or sets the minimum TTL value for this record.
        /// </summary>
        [JsonProperty(PropertyName = "minimumTTL")]
        public long? MinimumTtl { get; set; }

    }
}
