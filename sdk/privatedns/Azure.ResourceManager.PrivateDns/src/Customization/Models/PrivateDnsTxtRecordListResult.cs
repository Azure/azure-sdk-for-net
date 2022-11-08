// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.PrivateDns;

namespace Azure.ResourceManager.PrivateDns.Models
{
    /// <summary> The response to a record set List operation. </summary>
    internal partial class PrivateDnsTxtRecordListResult
    {
        /// <summary> Initializes a new instance of PrivateDnsTxtRecordSetListResult. </summary>
        internal PrivateDnsTxtRecordListResult()
        {
            Value = new ChangeTrackingList<PrivateDnsTxtRecordData>();
        }

        /// <summary> Initializes a new instance of PrivateDnsTxtRecordSetListResult. </summary>
        /// <param name="value"> Information about the record sets in the response. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal PrivateDnsTxtRecordListResult(IReadOnlyList<PrivateDnsTxtRecordData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the record sets in the response. </summary>
        public IReadOnlyList<PrivateDnsTxtRecordData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
