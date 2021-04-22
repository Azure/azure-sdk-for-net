// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("BatchResponse")]
    public partial class LogsBatchQueryResult
    {
        private IReadOnlyList<LogQueryResponse> Responses { get; }
        private  BatchResponseError Error { get; }
        internal RowBinder RowBinder { get; set; }

        public LogsQueryResult GetResult(string queryId)
        {
            LogQueryResponse result = Responses.SingleOrDefault(r => r.Id == queryId);

            if (result == null)
            {
                throw new ArgumentException($"Query with ID '{queryId}' wasn't part of the batch." +
                                            $" Please use the return value of the {nameof(LogsBatchQuery)}.{nameof(LogsBatchQuery.AddQuery)} as the '{nameof(queryId)}' argument.", nameof(queryId));
            }

            if (result.Body.Error != null)
            {
                throw new RequestFailedException(result.Status ?? 0, result.Body.Error.Message, result.Body.Error.Code, null);
            }

            return result.Body;
        }

        public IReadOnlyList<T> GetResult<T>(string queryId)
        {
            return RowBinder.BindResults<T>(GetResult(queryId));
        }
    }
}