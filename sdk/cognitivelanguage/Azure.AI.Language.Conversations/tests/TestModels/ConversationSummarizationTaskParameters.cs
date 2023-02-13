// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Supported parameters for an conversational summarization task. </summary>
    public partial class ConversationSummarizationTaskParameters : PreBuiltTaskParameters
    {
        /// <summary> Initializes a new instance of ConversationSummarizationTaskParameters. </summary>
        /// <param name="summaryAspects"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="summaryAspects"/> is null. </exception>
        public ConversationSummarizationTaskParameters(IEnumerable<SummaryAspect> summaryAspects)
        {
            Argument.AssertNotNull(summaryAspects, nameof(summaryAspects));

            SummaryAspects = summaryAspects.ToList();
            PhraseControls = new ChangeTrackingList<PhraseControl>();
        }

        /// <summary> Initializes a new instance of ConversationSummarizationTaskParameters. </summary>
        /// <param name="loggingOptOut"></param>
        /// <param name="modelVersion"></param>
        /// <param name="summaryAspects"></param>
        /// <param name="sentenceCount"> It controls the approximate number of sentences in the output summaries. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. </param>
        /// <param name="phraseControls"> Control the phrases to be used in the summary. </param>
        internal ConversationSummarizationTaskParameters(bool? loggingOptOut, string modelVersion, IList<SummaryAspect> summaryAspects, int? sentenceCount, StringIndexType? stringIndexType, IList<PhraseControl> phraseControls) : base(loggingOptOut, modelVersion)
        {
            SummaryAspects = summaryAspects;
            SentenceCount = sentenceCount;
            StringIndexType = stringIndexType;
            PhraseControls = phraseControls;
        }

        /// <summary> Gets the summary aspects. </summary>
        public IList<SummaryAspect> SummaryAspects { get; }
        /// <summary> It controls the approximate number of sentences in the output summaries. </summary>
        public int? SentenceCount { get; set; }
        /// <summary> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. </summary>
        public StringIndexType? StringIndexType { get; set; }
        /// <summary> Control the phrases to be used in the summary. </summary>
        public IList<PhraseControl> PhraseControls { get; }
    }
}
