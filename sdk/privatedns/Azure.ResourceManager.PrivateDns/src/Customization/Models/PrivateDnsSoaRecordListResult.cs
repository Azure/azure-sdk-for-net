// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsSoaRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsSoaRecordSetListResult. </summary>
        internal PrivateDnsSoaRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsSoaRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsSoaRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsSoaRecordListResult(IReadOnlyList<PrivateDnsSoaRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsSoaRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
