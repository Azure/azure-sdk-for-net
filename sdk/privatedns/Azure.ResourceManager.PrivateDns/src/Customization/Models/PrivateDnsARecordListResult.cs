// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsARecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsARecordSetListResult. </summary>
        internal PrivateDnsARecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsARecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsARecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsARecordListResult(IReadOnlyList<PrivateDnsARecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsARecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
