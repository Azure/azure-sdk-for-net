// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsPtrRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsPtrRecordSetListResult. </summary>
        internal PrivateDnsPtrRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsPtrRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsPtrRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsPtrRecordListResult(IReadOnlyList<PrivateDnsPtrRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsPtrRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
