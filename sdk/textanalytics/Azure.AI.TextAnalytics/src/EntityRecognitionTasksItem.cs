// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    [CodeGenModel("TasksStateTasksEntityRecognitionTasksItem")]
    public partial class EntityRecognitionTasksItem
    {
        internal EntitiesResult Results { get; }
    }
}
