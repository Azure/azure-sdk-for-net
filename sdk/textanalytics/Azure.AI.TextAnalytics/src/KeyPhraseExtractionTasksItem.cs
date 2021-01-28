// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// KeyPhraseExtractionTasksItem.
    /// </summary>
    [CodeGenModel("TasksStateTasksKeyPhraseExtractionTasksItem")]
    public partial class KeyPhraseExtractionTasksItem
    {
        /// <summary> Initializes a new instance of KeyPhraseExtractionTasksItem. </summary>
        internal KeyPhraseExtractionTasksItem(KeyPhraseExtractionTasksItem task, IDictionary<string, int> idToIndexMap) : base(task.LastUpdateDateTime, task.Name, task.Status)
        {
            Results = Transforms.ConvertToExtractKeyPhrasesResultCollection(task.ResultsInternal, idToIndexMap);
        }

        /// <summary>
        /// RecognizeEntitiesResultCollection Result
        /// </summary>
        public ExtractKeyPhrasesResultCollection Results { get; }

        /// <summary>
        /// Results for KeyPhraseExtractionTasksItem
        /// </summary>
        [CodeGenMember("Results")]
        internal KeyPhraseResult ResultsInternal { get; }
    }
}
