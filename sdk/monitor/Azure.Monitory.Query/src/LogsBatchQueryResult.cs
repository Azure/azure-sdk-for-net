// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitory.Query.Models
{
    [CodeGenModel("BatchResponse")]
    public partial class LogsBatchQueryResult
    {
        internal IReadOnlyList<LogQueryResponse> Responses { get; }
        internal BatchResponseError Error { get; }

        public LogsQueryResult GetResult(string queryId)
        {
            // TODO check status, add error message
            return Responses.Single(r => r.Id == queryId).Body;
        }
    }
}