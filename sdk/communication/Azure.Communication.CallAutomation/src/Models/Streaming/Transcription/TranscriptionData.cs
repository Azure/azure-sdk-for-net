// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Transcription.
    /// </summary>
    public class TranscriptionData : StreamingData
    {
        internal TranscriptionData(string text, string format, double confidence, ulong offset, ulong duration, IEnumerable<WordData> words, string participantRawID, string resultStatus)
        {
            Text = text;
            Format = ConvertToTextFormatEnum(format);
            Confidence = confidence;
            Offset = offset;
            Duration = duration;
            Words = words;
            if (participantRawID != null)
            {
                Participant = CommunicationIdentifier.FromRawId(participantRawID);
            }
            ResultStatus = ConvertToResultStatusEnum(resultStatus);
        }

        /// <summary>
        /// The display form of the recognized word
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The format of text
        /// </summary>
        public TextFormat Format { get; set; }

        /// <summary>
        /// Confidence of recognition of the whole phrase, from 0.0 (no confidence) to 1.0 (full confidence)
        /// </summary>
        public double Confidence { get; set; }

        /// <summary>
        /// The position of this payload
        /// </summary>

        public ulong Offset { get; set; }

        /// <summary>
        /// Duration in ticks. 1 tick = 100 nanoseconds.
        /// </summary>
        public ulong Duration { get; set; }

        /// <summary>
        /// The result for each word of the phrase
        /// </summary>
        public IEnumerable<WordData> Words { get; set; }

        /// <summary>
        /// The identified speaker based on participant raw ID
        /// </summary>
        public CommunicationIdentifier Participant { get; set; }

        /// <summary>
        /// Status of the result of transcription
        /// </summary>
        public ResultStatus ResultStatus { get; set; }

        private static ResultStatus ConvertToResultStatusEnum(string resultStatus)
        {
            if ("Intermediate".Equals(resultStatus, StringComparison.OrdinalIgnoreCase))
                return ResultStatus.Intermediate;
            else if ("Final".Equals(resultStatus, StringComparison.OrdinalIgnoreCase))
                return ResultStatus.Final;
            else
                throw new NotSupportedException(resultStatus);
        }

        private static TextFormat ConvertToTextFormatEnum(string format)
        {
            if ("Display".Equals(format, StringComparison.OrdinalIgnoreCase))
                return TextFormat.Display;
            else
                throw new NotSupportedException(format);
        }
    }
}
