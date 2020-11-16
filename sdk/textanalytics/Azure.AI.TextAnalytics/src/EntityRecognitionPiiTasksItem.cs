// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// EntityRecognitionPiiTasksItem.
    /// </summary>
    [CodeGenModel("TasksStateTasksEntityRecognitionPiiTasksItem")]
    public partial class EntityRecognitionPiiTasksItem
    {
        /// <summary> Initializes a new instance of EntityRecognitionPiiTasksItem. </summary>
        internal EntityRecognitionPiiTasksItem(EntityRecognitionPiiTasksItem task, IDictionary<string, int> idToIndexMap) : base(task.LastUpdateDateTime, task.Name, task.Status)
        {
            Results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(task.ResultsInternal, idToIndexMap);
        }

        /// <summary>
        /// RecognizePiiEntitiesResultCollection Result
        /// </summary>
        public RecognizePiiEntitiesResultCollection Results { get; }

        /// <summary>
        /// Results for EntityRecognitionPiiTasksItem
        /// </summary>
        [CodeGenMember("Results")]
        internal PiiEntitiesResult ResultsInternal { get; }
    }
}
