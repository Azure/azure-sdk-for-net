// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// AnalyzeTasks.
    /// </summary>
    [CodeGenModel("TasksStateTasks")]
    public partial class AnalyzeTasks
    {
        /// <summary> Initializes a new instance of AnalyzeTasks. </summary>
        /// <param name="tasks"></param>
        /// <param name="idToIndexMap"></param>
        internal AnalyzeTasks(AnalyzeTasks tasks, IDictionary<string, int> idToIndexMap)
        {
            Details = tasks.Details;
            Completed = tasks.Completed;
            Failed = tasks.Failed;
            InProgress = tasks.InProgress;
            Total = tasks.Total;

            if (tasks.EntityRecognitionTasks.Count > 0)
            {
                EntityRecognitionTasks = Transforms.ConvertToEntityRecognitionTasks(tasks.EntityRecognitionTasks, idToIndexMap);
            }

            if (tasks.EntityRecognitionPiiTasks.Count > 0)
            {
                EntityRecognitionPiiTasks = Transforms.ConvertToEntityRecognitionPiiTasks(tasks.EntityRecognitionPiiTasks, idToIndexMap);
            }

            if (tasks.KeyPhraseExtractionTasks.Count > 0)
            {
                KeyPhraseExtractionTasks = Transforms.ConvertToKeyPhraseExtractionTasks(tasks.KeyPhraseExtractionTasks, idToIndexMap);
            }
        }
        /// <summary>
        /// Details
        /// </summary>
        public TasksStateTasksDetails Details { get; }

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
        public IReadOnlyList<EntityRecognitionTasksItem> EntityRecognitionTasks { get; } = new List<EntityRecognitionTasksItem>();

        /// <summary>
        /// EntityRecognitionPiiTasks
        /// </summary>
        public IReadOnlyList<EntityRecognitionPiiTasksItem> EntityRecognitionPiiTasks { get; } = new List<EntityRecognitionPiiTasksItem>();

        /// <summary>
        /// KeyPhraseExtractionTasks
        /// </summary>
        public IReadOnlyList<KeyPhraseExtractionTasksItem> KeyPhraseExtractionTasks { get; } = new List<KeyPhraseExtractionTasksItem>();
    }
}
