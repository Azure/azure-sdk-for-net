// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// RecognizePiiEntitiesActionResults
    /// </summary>
    public class RecognizePiiEntitiesActionResult : TextAnalyticsActionDetails
    {
        internal RecognizePiiEntitiesActionResult(RecognizePiiEntitiesResultCollection result, DateTimeOffset completedOn, TextAnalyticsErrorInternal error) : base(completedOn, error)
        {
            Result = result;
        }

        /// <summary>
        /// Results
        /// </summary>
        public RecognizePiiEntitiesResultCollection Result { get; }
    }
}
