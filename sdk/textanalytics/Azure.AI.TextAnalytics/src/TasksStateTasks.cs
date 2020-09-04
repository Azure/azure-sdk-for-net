// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("TasksStateTasks")]
    internal partial class TasksStateTasks
    {
        internal IReadOnlyList<TaskState> Details { get; }
        internal int Completed { get; }
        internal int Failed { get; }
        internal int InProgress { get; }
        internal int Total { get; }
        internal IReadOnlyList<TasksStateTasksEntityRecognitionTasksItem> EntityRecognitionTasks { get; }
        internal IReadOnlyList<TasksStateTasksEntityRecognitionPiiTasksItem> EntityRecognitionPiiTasks { get; }
        internal IReadOnlyList<EntityLinkingTasksItem> EntityLinkingTasks { get; }
        internal IReadOnlyList<TasksStateTasksKeyPhraseExtractionTasksItem> KeyPhraseExtractionTasks { get; }
        internal IReadOnlyList<TasksStateTasksSentimentAnalysisTasksItem> SentimentAnalysisTasks { get; }
        internal IReadOnlyList<CustomClassificationTasksItem> CustomClassificationTasks { get; }
        internal IReadOnlyList<CustomEntityRecognitionTasksItem> CustomEntityRecognitionTasks { get; }

    }
}
