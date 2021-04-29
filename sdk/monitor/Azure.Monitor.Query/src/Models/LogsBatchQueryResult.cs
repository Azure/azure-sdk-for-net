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

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddQuery"/>.</param>
        /// <returns>The <see cref="LogsQueryResult"/> with the query results.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query  <paramref name="queryId"/> failed.</exception>
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

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddQuery"/>.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query <paramref name="queryId"/> failed.</exception>
        public IReadOnlyList<T> GetResult<T>(string queryId)
        {
            return RowBinder.BindResults<T>(GetResult(queryId));
        }
    }
}
