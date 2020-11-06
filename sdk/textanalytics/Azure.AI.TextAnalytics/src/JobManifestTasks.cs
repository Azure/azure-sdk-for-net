// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// JobManifestTasks.
    /// </summary>
    [CodeGenModel("JobManifestTasks")]
    public partial class JobManifestTasks
    {
        /// <summary>
        /// EntityRecognitionTasks
        /// </summary>
        public IList<EntitiesTask> EntityRecognitionTasks { get; }

        /// <summary>
        /// EntityRecognitionPiiTasks
        /// </summary>
        public IList<PiiTask> EntityRecognitionPiiTasks { get; }

        /// <summary>
        /// KeyPhraseExtractionTasks
        /// </summary>
        public IList<KeyPhrasesTask> KeyPhraseExtractionTasks { get; }

    }
}
