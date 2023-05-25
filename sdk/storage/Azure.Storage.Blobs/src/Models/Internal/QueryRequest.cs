// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

// suppress the type of property `QueryType`
[assembly: CodeGenSuppressType("QueryRequestQueryType")]
namespace Azure.Storage.Blobs.Models
{
    internal partial class QueryRequest
    {
        /// <summary>
        /// The query type.
        /// </summary>
        public string QueryType { get; set;  }

        /// <summary>
        /// A query statement.
        /// </summary>
        public string Expression { get; set; }

        internal QueryRequest() { }
    }
}
