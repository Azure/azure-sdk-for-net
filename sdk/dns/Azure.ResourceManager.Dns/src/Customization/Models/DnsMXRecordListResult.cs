// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class DnsMXRecordListResult
    {
        /// <summary> Initializes a new instance of DnsMXRecordSetListResult. </summary>
        internal DnsMXRecordListResult()
        {
            Value = new ChangeTrackingList<DnsMXRecordData>();
        }

        /// <summary> Initializes a new instance of DnsMXRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal DnsMXRecordListResult(IReadOnlyList<DnsMXRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<DnsMXRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
