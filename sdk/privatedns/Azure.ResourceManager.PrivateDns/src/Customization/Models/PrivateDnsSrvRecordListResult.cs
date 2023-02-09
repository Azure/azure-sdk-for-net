// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsSrvRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsSrvRecordSetListResult. </summary>
        internal PrivateDnsSrvRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsSrvRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsSrvRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsSrvRecordListResult(IReadOnlyList<PrivateDnsSrvRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsSrvRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
