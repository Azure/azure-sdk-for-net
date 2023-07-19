// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsCnameRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsCnameRecordSetListResult. </summary>
        internal PrivateDnsCnameRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsCnameRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsCnameRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsCnameRecordListResult(IReadOnlyList<PrivateDnsCnameRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsCnameRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
