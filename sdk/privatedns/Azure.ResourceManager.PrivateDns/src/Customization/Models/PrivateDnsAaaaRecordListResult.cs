// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsAaaaRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsAaaaRecordSetListResult. </summary>
        internal PrivateDnsAaaaRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsAaaaRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsAaaaRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsAaaaRecordListResult(IReadOnlyList<PrivateDnsAaaaRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsAaaaRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
