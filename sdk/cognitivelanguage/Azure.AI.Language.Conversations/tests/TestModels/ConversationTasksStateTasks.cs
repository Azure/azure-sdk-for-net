// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The ConversationTasksStateTasks. </summary>
    public partial class ConversationTasksStateTasks
    {
        /// <summary> Initializes a new instance of ConversationTasksStateTasks. </summary>
        /// <param name="completed"> Count of tasks completed successfully. </param>
        /// <param name="failed"> Count of tasks that failed. </param>
        /// <param name="inProgress"> Count of tasks in progress currently. </param>
        /// <param name="total"> Total count of tasks submitted as part of the job. </param>
        internal ConversationTasksStateTasks(int completed, int failed, int inProgress, int total)
        {
            Completed = completed;
            Failed = failed;
            InProgress = inProgress;
            Total = total;
            Items = new ChangeTrackingList<AnalyzeConversationJobResult>();
        }

        /// <summary> Initializes a new instance of ConversationTasksStateTasks. </summary>
        /// <param name="completed"> Count of tasks completed successfully. </param>
        /// <param name="failed"> Count of tasks that failed. </param>
        /// <param name="inProgress"> Count of tasks in progress currently. </param>
        /// <param name="total"> Total count of tasks submitted as part of the job. </param>
        /// <param name="items">
        /// List of results from tasks (if available).
        /// Please note <see cref="AnalyzeConversationJobResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AnalyzeConversationPIIResult"/>, <see cref="AnalyzeConversationSentimentResult"/> and <see cref="AnalyzeConversationSummarizationResult"/>.
        /// </param>
        internal ConversationTasksStateTasks(int completed, int failed, int inProgress, int total, IReadOnlyList<AnalyzeConversationJobResult> items)
        {
            Completed = completed;
            Failed = failed;
            InProgress = inProgress;
            Total = total;
            Items = items;
        }

        /// <summary> Count of tasks completed successfully. </summary>
        public int Completed { get; }
        /// <summary> Count of tasks that failed. </summary>
        public int Failed { get; }
        /// <summary> Count of tasks in progress currently. </summary>
        public int InProgress { get; }
        /// <summary> Total count of tasks submitted as part of the job. </summary>
        public int Total { get; }
        /// <summary>
        /// List of results from tasks (if available).
        /// Please note <see cref="AnalyzeConversationJobResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AnalyzeConversationPIIResult"/>, <see cref="AnalyzeConversationSentimentResult"/> and <see cref="AnalyzeConversationSummarizationResult"/>.
        /// </summary>
        public IReadOnlyList<AnalyzeConversationJobResult> Items { get; }
    }
}
