// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the current status and execution history of an indexer.
    /// </summary>
    public class IndexerExecutionInfo
    {
        /// <summary>
        /// Initializes a new instance of the IndexerExecutionInfo class.
        /// </summary>
        public IndexerExecutionInfo() { }

        /// <summary>
        /// Initializes a new instance of the IndexerExecutionInfo class.
        /// </summary>
        public IndexerExecutionInfo(IndexerStatus status = default(IndexerStatus), IndexerExecutionResult lastResult = default(IndexerExecutionResult), IList<IndexerExecutionResult> executionHistory = default(IList<IndexerExecutionResult>))
        {
            Status = status;
            LastResult = lastResult;
            ExecutionHistory = executionHistory;
        }

        /// <summary>
        /// Overall indexer status. Possible values for this property include:
        /// 'unknown', 'error', 'running'.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public IndexerStatus Status { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

        /// <summary>
        /// The result of the most recent or an in-progress indexer execution.
        /// </summary>
        [JsonProperty(PropertyName = "lastResult")]
        public IndexerExecutionResult LastResult { get; private set; }

        /// <summary>
        /// History of the recent indexer executions, sorted in reverse
        /// chronological order.
        /// </summary>
        [JsonProperty(PropertyName = "executionHistory")]
        public IList<IndexerExecutionResult> ExecutionHistory { get; private set; }

    }
}
