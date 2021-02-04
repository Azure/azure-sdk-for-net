// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// RecognizeEntitiesActionResults
    /// </summary>
    public class RecognizeEntitiesActionResults : TextAnalyticsActionDetails
    {
        internal RecognizeEntitiesActionResults(IList<RecognizeEntitiesResultCollection> results, DateTimeOffset completedOn, IReadOnlyList<TextAnalyticsErrorInternal> errors, bool hasError) : base(completedOn, errors, hasError)
        {
            Results = new ReadOnlyCollection<RecognizeEntitiesResultCollection>(results);
        }

        /// <summary>
        /// Results
        /// </summary>
        public IReadOnlyList<RecognizeEntitiesResultCollection> Results { get; }
    }
}
