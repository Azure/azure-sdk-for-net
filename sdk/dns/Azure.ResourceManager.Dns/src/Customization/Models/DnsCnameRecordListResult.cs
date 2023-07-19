// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class DnsCnameRecordListResult
    {
        /// <summary> Initializes a new instance of DnsCnameRecordSetListResult. </summary>
        internal DnsCnameRecordListResult()
        {
            Value = new ChangeTrackingList<DnsCnameRecordData>();
        }

        /// <summary> Initializes a new instance of DnsCnameRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal DnsCnameRecordListResult(IReadOnlyList<DnsCnameRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<DnsCnameRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
