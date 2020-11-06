// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary>
        /// Results for EntityRecognitionTasksItem
        /// </summary>
        internal EntitiesResult Results { get; }
    }
}
