// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Additional properties for supporting transcript conversation. </summary>
    public partial class TranscriptConversationItem : ConversationItemBase
    {
        /// <summary> Initializes a new instance of TranscriptConversationItem. </summary>
        /// <param name="id"> The ID of a conversation item. </param>
        /// <param name="participantId"> The participant ID of a conversation item. </param>
        /// <param name="itn"> Inverse Text Normalization representation of input. The inverse-text-normalized form is the recognized text from Microsoft&apos;s Speech to Text API, with phone numbers, numbers, abbreviations, and other transformations applied. </param>
        /// <param name="maskedItn"> The Inverse Text Normalized format with profanity masking applied. </param>
        /// <param name="text"> The display form of the recognized text from speech to text API, with punctuation and capitalization added. </param>
        /// <param name="lexical"> The lexical form of the recognized text from speech to text API with the actual words recognized. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="participantId"/>, <paramref name="itn"/>, <paramref name="maskedItn"/>, <paramref name="text"/> or <paramref name="lexical"/> is null. </exception>
        public TranscriptConversationItem(string id, string participantId, string itn, string maskedItn, string text, string lexical) : base(id, participantId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(participantId, nameof(participantId));
            Argument.AssertNotNull(itn, nameof(itn));
            Argument.AssertNotNull(maskedItn, nameof(maskedItn));
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(lexical, nameof(lexical));

            Itn = itn;
            MaskedItn = maskedItn;
            Text = text;
            Lexical = lexical;
            WordLevelTimings = new ChangeTrackingList<WordLevelTiming>();
        }

        /// <summary> Inverse Text Normalization representation of input. The inverse-text-normalized form is the recognized text from Microsoft&apos;s Speech to Text API, with phone numbers, numbers, abbreviations, and other transformations applied. </summary>
        public string Itn { get; }
        /// <summary> The Inverse Text Normalized format with profanity masking applied. </summary>
        public string MaskedItn { get; }
        /// <summary> The display form of the recognized text from speech to text API, with punctuation and capitalization added. </summary>
        public string Text { get; }
        /// <summary> The lexical form of the recognized text from speech to text API with the actual words recognized. </summary>
        public string Lexical { get; }
        /// <summary> The list of word level audio timing information. </summary>
        public IList<WordLevelTiming> WordLevelTimings { get; }
        /// <summary> Conversation item level audio timing. This still can help on AI quality if word level audio timings are not available. </summary>
        public ConversationItemLevelTiming ConversationItemLevelTiming { get; set; }
    }
}
