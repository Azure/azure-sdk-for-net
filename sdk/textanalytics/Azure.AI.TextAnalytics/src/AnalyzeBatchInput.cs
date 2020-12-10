// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    /// <summary>
    /// AnalyzeBatchInput.
    /// </summary>
    [CodeGenModel("AnalyzeBatchInput")]
    internal partial class AnalyzeBatchInput
    {
        /// <summary> Initializes a new instance of AnalyzeBatchInput. </summary>
        /// <param name="analysisInput"> Contains a set of input documents to be analyzed by the service. </param>
        /// <param name="tasks"> The set of tasks to execute on the input documents. Cannot specify the same task more than once. </param>
        /// <param name="displayName">The name wassigned for the job</param>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisInput"/> or <paramref name="tasks"/> is null. </exception>
        public AnalyzeBatchInput(MultiLanguageBatchInput analysisInput, JobManifestTasks tasks, string displayName)
        {
            if (analysisInput == null)
            {
                throw new ArgumentNullException(nameof(analysisInput));
            }
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }
            AnalysisInput = analysisInput;
            Tasks = tasks;
            DisplayName = displayName;
        }
    }
}
