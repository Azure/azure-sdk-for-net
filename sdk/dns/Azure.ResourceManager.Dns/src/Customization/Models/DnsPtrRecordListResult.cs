// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class DnsPtrRecordListResult
    {
        /// <summary> Initializes a new instance of DnsPtrRecordSetListResult. </summary>
        internal DnsPtrRecordListResult()
        {
            Value = new ChangeTrackingList<DnsPtrRecordData>();
        }

        /// <summary> Initializes a new instance of DnsPtrRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal DnsPtrRecordListResult(IReadOnlyList<DnsPtrRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<DnsPtrRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
