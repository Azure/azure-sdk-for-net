// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// ExtractKeyPhrasesActionResults
    /// </summary>
    public class ExtractKeyPhrasesActionResults : TextAnalyticsActionDetails
    {
        internal ExtractKeyPhrasesActionResults(IList<ExtractKeyPhrasesResultCollection> results, DateTimeOffset completedOn, IReadOnlyList<TextAnalyticsErrorInternal> errors, bool hasError) : base(completedOn, errors, hasError)
        {
            Results = new ReadOnlyCollection<ExtractKeyPhrasesResultCollection>(results);
        }

        /// <summary>
        /// Results
        /// </summary>
        public IReadOnlyList<ExtractKeyPhrasesResultCollection> Results { get; }
    }
}
