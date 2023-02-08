// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class DnsCaaRecordListResult
    {
        /// <summary> Initializes a new instance of DnsCaaRecordSetListResult. </summary>
        internal DnsCaaRecordListResult()
        {
            Value = new ChangeTrackingList<DnsCaaRecordData>();
        }

        /// <summary> Initializes a new instance of DnsCaaRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal DnsCaaRecordListResult(IReadOnlyList<DnsCaaRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<DnsCaaRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
