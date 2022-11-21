// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class DnsAaaaRecordListResult
    {
        /// <summary> Initializes a new instance of DnsAaaaRecordSetListResult. </summary>
        internal DnsAaaaRecordListResult()
        {
            Value = new ChangeTrackingList<DnsAaaaRecordData>();
        }

        /// <summary> Initializes a new instance of DnsAaaaRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal DnsAaaaRecordListResult(IReadOnlyList<DnsAaaaRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<DnsAaaaRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
