// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntityLinkingTasksItem.
    /// </summary>
    [CodeGenModel("TasksStateTasksEntityLinkingTasksItem")]
    internal partial class EntityLinkingTasksItem
    {
        /// <summary> Initializes a new instance of EntityLinkingTasksItem. </summary>
        internal EntityLinkingTasksItem(EntityLinkingTasksItem task, IDictionary<string, int> idToIndexMap) : base(task.LastUpdateDateTime, task.Name, task.Status)
        {
            Results = Transforms.ConvertToRecognizeLinkedEntitiesResultCollection(task.ResultsInternal, idToIndexMap);
        }

        /// <summary>
        /// RecognizeLinkedEntitiesResultCollection Result
        /// </summary>
        public RecognizeLinkedEntitiesResultCollection Results { get; }

        /// <summary>
        /// Results for EntityRecognitionPiiTasksItem
        /// </summary>
        [CodeGenMember("Results")]
        internal EntityLinkingResult ResultsInternal { get; }
    }
}
