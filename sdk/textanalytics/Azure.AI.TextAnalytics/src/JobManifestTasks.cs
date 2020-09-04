// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("JobManifestTasks")]
    internal partial class JobManifestTasks
    {
        internal IList<EntitiesTask> EntityRecognitionTasks { get; }
        internal IList<PiiTask> EntityRecognitionPiiTasks { get; }
        internal IList<EntityLinkingTask> EntityLinkingTasks { get; }
        internal IList<KeyPhrasesTask> KeyPhraseExtractionTasks { get; }
        internal IList<SentimentTask> SentimentAnalysisTasks { get; }
        internal IList<CustomClassificationTask> CustomClassificationTasks { get; }
        internal IList<CustomEntitiesTask> CustomEntityRecognitionTasks { get; }

    }
}
