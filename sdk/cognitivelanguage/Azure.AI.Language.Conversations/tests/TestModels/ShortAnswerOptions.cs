// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> To configure Answer span prediction feature. </summary>
    public partial class ShortAnswerOptions
    {
        /// <summary> Initializes a new instance of ShortAnswerOptions. </summary>
        public ShortAnswerOptions()
        {
            Enable = true;
        }

        /// <summary> Enable or disable Answer Span prediction. </summary>
        public bool Enable { get; }
        /// <summary> Minimum threshold score required to include an answer span, value ranges from 0 to 1. </summary>
        public double? ConfidenceThreshold { get; set; }
        /// <summary> Number of Top answers to be considered for span prediction from 1 to 10. </summary>
        public int? Top { get; set; }
    }
}
