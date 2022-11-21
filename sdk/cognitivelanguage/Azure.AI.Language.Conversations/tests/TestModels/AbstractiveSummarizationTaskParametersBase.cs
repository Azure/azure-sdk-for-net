// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Supported parameters for an Abstractive Summarization task. </summary>
    public partial class AbstractiveSummarizationTaskParametersBase
    {
        /// <summary> Initializes a new instance of AbstractiveSummarizationTaskParametersBase. </summary>
        public AbstractiveSummarizationTaskParametersBase()
        {
            PhraseControls = new ChangeTrackingList<PhraseControl>();
        }

        /// <summary> Initializes a new instance of AbstractiveSummarizationTaskParametersBase. </summary>
        /// <param name="sentenceCount"> It controls the approximate number of sentences in the output summaries. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. </param>
        /// <param name="phraseControls"> Control the phrases to be used in the summary. </param>
        internal AbstractiveSummarizationTaskParametersBase(int? sentenceCount, StringIndexType? stringIndexType, IList<PhraseControl> phraseControls)
        {
            SentenceCount = sentenceCount;
            StringIndexType = stringIndexType;
            PhraseControls = phraseControls;
        }

        /// <summary> It controls the approximate number of sentences in the output summaries. </summary>
        public int? SentenceCount { get; set; }
        /// <summary> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. </summary>
        public StringIndexType? StringIndexType { get; set; }
        /// <summary> Control the phrases to be used in the summary. </summary>
        public IList<PhraseControl> PhraseControls { get; }
    }
}
