// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The ConversationsSummaryResult. </summary>
    public partial class ConversationsSummaryResult
    {
        /// <summary> Initializes a new instance of ConversationsSummaryResult. </summary>
        /// <param name="summaries"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="summaries"/> is null. </exception>
        public ConversationsSummaryResult(IEnumerable<ConversationsSummaryResultSummariesItem> summaries)
        {
            Argument.AssertNotNull(summaries, nameof(summaries));

            Summaries = summaries.ToList();
        }

        /// <summary> Initializes a new instance of ConversationsSummaryResult. </summary>
        /// <param name="summaries"></param>
        internal ConversationsSummaryResult(IList<ConversationsSummaryResultSummariesItem> summaries)
        {
            Summaries = summaries;
        }

        /// <summary> Gets the summaries. </summary>
        public IList<ConversationsSummaryResultSummariesItem> Summaries { get; }
    }
}
