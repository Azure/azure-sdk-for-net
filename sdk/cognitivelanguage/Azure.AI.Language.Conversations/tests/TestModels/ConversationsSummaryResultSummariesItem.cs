// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The ConversationsSummaryResultSummariesItem. </summary>
    public partial class ConversationsSummaryResultSummariesItem : SummaryResultItem
    {
        /// <summary> Initializes a new instance of ConversationsSummaryResultSummariesItem. </summary>
        /// <param name="aspect"></param>
        /// <param name="text"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="aspect"/> or <paramref name="text"/> is null. </exception>
        public ConversationsSummaryResultSummariesItem(string aspect, string text) : base(aspect, text)
        {
            Argument.AssertNotNull(aspect, nameof(aspect));
            Argument.AssertNotNull(text, nameof(text));
        }

        /// <summary> Initializes a new instance of ConversationsSummaryResultSummariesItem. </summary>
        /// <param name="aspect"></param>
        /// <param name="text"></param>
        /// <param name="contexts"> The context list of the summary. </param>
        internal ConversationsSummaryResultSummariesItem(string aspect, string text, IList<ItemizedSummaryContext> contexts) : base(aspect, text, contexts)
        {
        }
    }
}
