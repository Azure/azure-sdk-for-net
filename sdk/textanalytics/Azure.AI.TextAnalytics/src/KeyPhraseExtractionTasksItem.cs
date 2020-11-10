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
        /// <param name="lastUpdateDateTime"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal KeyPhraseExtractionTasksItem(DateTimeOffset lastUpdateDateTime, string name, JobStatus status) : base(lastUpdateDateTime, name, status)
        {
        }

        /// <summary> Initializes a new instance of KeyPhraseExtractionTasksItem. </summary>
        /// <param name="lastUpdateDateTime"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <param name="results"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal KeyPhraseExtractionTasksItem(DateTimeOffset lastUpdateDateTime, string name, JobStatus status, KeyPhraseResult results) : base(lastUpdateDateTime, name, status)
        {
            Results = results;
        }
        internal KeyPhraseResult Results { get; }
    }
}
