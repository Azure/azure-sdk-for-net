// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="JobMetadata"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    public class AnalyzeOperationResult
    {
        /// <summary>
        /// </summary>
        /// <param name="jobState"></param>
        /// <param name="idToIndexMap"></param>
        internal AnalyzeOperationResult(AnalyzeJobState jobState, IDictionary<string, int> idToIndexMap)
        {
            Errors = Transforms.ConvertToErrors(jobState.Errors);
            Statistics = jobState.Statistics;
            DisplayName = jobState.DisplayName;
            Status = jobState.Status;
            Tasks = new AnalyzeTasks(jobState.Tasks, idToIndexMap);
        }

        /// <summary>
        /// Tasks
        /// </summary>
        public AnalyzeTasks Tasks { get; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Status
        /// </summary>
        public JobStatus Status { get; }

        /// <summary>
        /// Errors for AnalyzeOperationResult
        /// </summary>
        public IReadOnlyList<TextAnalyticsError> Errors { get; }

        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
