// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntityRecognitionTasksItem.
    /// </summary>
    [CodeGenModel("TasksStateTasksEntityRecognitionTasksItem")]
    public partial class EntityRecognitionTasksItem
    {
        /// <summary> Initializes a new instance of EntityRecognitionTasksItem. </summary>
        internal EntityRecognitionTasksItem(EntityRecognitionTasksItem task, IDictionary<string, int> idToIndexMap) : base(task.LastUpdateDateTime, task.Name, task.Status)
        {
            Results = Transforms.ConvertToRecognizeEntitiesResultCollection(task.ResultsInternal, idToIndexMap);
        }

        /// <summary>
        /// RecognizeEntitiesResultCollection Result
        /// </summary>
        public RecognizeEntitiesResultCollection Results { get; }

        /// <summary>
        /// Results for EntityRecognitionTasksItem
        /// </summary>
       [CodeGenMember("Results")]
       private EntitiesResult ResultsInternal { get; }
    }
}
