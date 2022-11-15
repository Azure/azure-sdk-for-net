// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Supported parameters for a Conversational PII detection and redaction task. </summary>
    public partial class ConversationPIITaskParameters : PreBuiltTaskParameters
    {
        /// <summary> Initializes a new instance of ConversationPIITaskParameters. </summary>
        public ConversationPIITaskParameters()
        {
            PiiCategories = new ChangeTrackingList<ConversationPIICategory>();
        }

        /// <summary> Initializes a new instance of ConversationPIITaskParameters. </summary>
        /// <param name="loggingOptOut"></param>
        /// <param name="modelVersion"></param>
        /// <param name="piiCategories"> Describes the PII categories to return for detection. If not provided, &apos;default&apos; categories will be returned which will vary with the language. </param>
        /// <param name="includeAudioRedaction"> Flag to indicate if audio redaction is requested. By default audio redaction will not be performed. </param>
        /// <param name="redactionSource"> For transcript conversations, this parameter provides information regarding which content type (ITN, Text, Lexical, Masked ITN) should be used for entity detection. The details of the entities detected - like the offset, length and the text itself - will correspond to the text type selected here. </param>
        internal ConversationPIITaskParameters(bool? loggingOptOut, string modelVersion, IList<ConversationPIICategory> piiCategories, bool? includeAudioRedaction, TranscriptContentType? redactionSource) : base(loggingOptOut, modelVersion)
        {
            PiiCategories = piiCategories;
            IncludeAudioRedaction = includeAudioRedaction;
            RedactionSource = redactionSource;
        }

        /// <summary> Describes the PII categories to return for detection. If not provided, &apos;default&apos; categories will be returned which will vary with the language. </summary>
        public IList<ConversationPIICategory> PiiCategories { get; }
        /// <summary> Flag to indicate if audio redaction is requested. By default audio redaction will not be performed. </summary>
        public bool? IncludeAudioRedaction { get; set; }
        /// <summary> For transcript conversations, this parameter provides information regarding which content type (ITN, Text, Lexical, Masked ITN) should be used for entity detection. The details of the entities detected - like the offset, length and the text itself - will correspond to the text type selected here. </summary>
        public TranscriptContentType? RedactionSource { get; set; }
    }
}
