// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The SummaryResultConversationsItem. </summary>
    public partial class SummaryResultConversationsItem : ConversationsSummaryResult
    {
        /// <summary> Initializes a new instance of SummaryResultConversationsItem. </summary>
        /// <param name="summaries"></param>
        /// <param name="id"> Unique, non-empty conversation identifier. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="summaries"/>, <paramref name="id"/> or <paramref name="warnings"/> is null. </exception>
        public SummaryResultConversationsItem(IEnumerable<ConversationsSummaryResultSummariesItem> summaries, string id, IEnumerable<InputWarning> warnings) : base(summaries)
        {
            Argument.AssertNotNull(summaries, nameof(summaries));
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(warnings, nameof(warnings));

            Id = id;
            Warnings = warnings.ToList();
        }

        /// <summary> Initializes a new instance of SummaryResultConversationsItem. </summary>
        /// <param name="summaries"></param>
        /// <param name="id"> Unique, non-empty conversation identifier. </param>
        /// <param name="warnings"> Warnings encountered while processing document. </param>
        /// <param name="statistics"> If showStats=true was specified in the request this field will contain information about the conversation payload. </param>
        internal SummaryResultConversationsItem(IList<ConversationsSummaryResultSummariesItem> summaries, string id, IList<InputWarning> warnings, ConversationStatistics statistics) : base(summaries)
        {
            Id = id;
            Warnings = warnings;
            Statistics = statistics;
        }

        /// <summary> Unique, non-empty conversation identifier. </summary>
        public string Id { get; set; }
        /// <summary> Warnings encountered while processing document. </summary>
        public IList<InputWarning> Warnings { get; }
        /// <summary> If showStats=true was specified in the request this field will contain information about the conversation payload. </summary>
        public ConversationStatistics Statistics { get; set; }
    }
}
