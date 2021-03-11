// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Action result class for linked entities
    /// </summary>
    public class RecognizeLinkedEntitiesActionResult : TextAnalyticsActionDetails
    {
        internal RecognizeLinkedEntitiesActionResult(RecognizeLinkedEntitiesResultCollection result, DateTimeOffset completedOn, TextAnalyticsErrorInternal error) : base(completedOn, error)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result collection for linked entities
        /// </summary>
        public RecognizeLinkedEntitiesResultCollection Result { get; }
    }
}
