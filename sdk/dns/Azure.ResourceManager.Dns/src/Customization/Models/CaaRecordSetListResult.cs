// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class CaaRecordSetListResult
    {
        /// <summary> Initializes a new instance of CaaRecordSetListResult. </summary>
        internal CaaRecordSetListResult()
        {
            Value = new ChangeTrackingList<CaaRecordSetData>();
        }

        /// <summary> Initializes a new instance of CaaRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal CaaRecordSetListResult(IReadOnlyList<CaaRecordSetData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<CaaRecordSetData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
