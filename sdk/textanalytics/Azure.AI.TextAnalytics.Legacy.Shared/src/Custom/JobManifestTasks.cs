// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy
{
    /// <summary>
    /// JobManifestTasks.
    /// </summary>
    [CodeGenModel("JobManifestTasks")]
    internal partial class JobManifestTasks
    {
        /// <summary>
        /// EntityRecognitionTasks
        /// </summary>
        internal IList<EntitiesTask> EntityRecognitionTasks { get; set; }

        /// <summary>
        /// EntityRecognitionPiiTasks
        /// </summary>
        internal IList<PiiTask> EntityRecognitionPiiTasks { get; set; }

        /// <summary>
        /// KeyPhraseExtractionTasks
        /// </summary>
        internal IList<KeyPhrasesTask> KeyPhraseExtractionTasks { get; set; }

        /// <summary>
        /// EntityLinkingTasks
        /// </summary>
        internal IList<EntityLinkingTask> EntityLinkingTasks { get; set; }

        /// <summary>
        /// SentimentAnalysisTasks
        /// </summary>
        internal IList<SentimentAnalysisTask> SentimentAnalysisTasks { get; set; }
    }
}
