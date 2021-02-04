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
    public class RecognizePiiEntitiesActionResults : TextAnalyticsActionDetails
    {
        internal RecognizePiiEntitiesActionResults(IList<RecognizePiiEntitiesResultCollection> results, DateTimeOffset completedOn, IReadOnlyList<TextAnalyticsErrorInternal> errors, bool hasError) : base(completedOn, errors, hasError)
        {
            Results = new ReadOnlyCollection<RecognizePiiEntitiesResultCollection>(results);
        }

        /// <summary>
        /// Results
        /// </summary>
        public IReadOnlyList<RecognizePiiEntitiesResultCollection> Results { get; }
    }
}
