// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// TasksStateTasks.
    /// </summary>
    [CodeGenModel("TasksStateTasks")]
    public partial class TasksStateTasks
    {
        /// <summary>
        /// Details
        /// </summary>
        public IReadOnlyList<TaskState> Details { get; }

        /// <summary>
        /// Completed
        /// </summary>
        public int Completed { get; }

        /// <summary>
        /// Failed
        /// </summary>
        public int Failed { get; }

        /// <summary>
        /// InProgress
        /// </summary>
        public int InProgress { get; }

        /// <summary>
        /// Total
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// EntityRecognitionTasks
        /// </summary>
        public IReadOnlyList<EntityRecognitionTasksItem> EntityRecognitionTasks { get; }

        /// <summary>
        /// EntityRecognitionPiiTasks
        /// </summary>
        public IReadOnlyList<EntityRecognitionPiiTasksItem> EntityRecognitionPiiTasks { get; }

        /// <summary>
        /// KeyPhraseExtractionTasks
        /// </summary>
        public IReadOnlyList<KeyPhraseExtractionTasksItem> KeyPhraseExtractionTasks { get; }
    }
}
