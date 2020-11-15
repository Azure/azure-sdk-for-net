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
        internal PiiEntitiesResult Results { get; }
    }
}
